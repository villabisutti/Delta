﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


namespace VillaBisutti.Delta
{
	public static class Util
	{
		public static string GetDescription(this Enum value)
		{
			FieldInfo field = value.GetType().GetField(value.ToString());
			DescriptionAttribute DescAttribute =
				field.GetCustomAttribute<DescriptionAttribute>();
			if (DescAttribute != null)
				return DescAttribute.Description;
			DisplayAttribute DisplayAttribute =
				field.GetCustomAttribute<DisplayAttribute>();
			if (DisplayAttribute != null)
				return DisplayAttribute.Name;
			return value.ToString();
		}
		public static T Get<T>(string name)
		{
			string config = ConfigurationManager.AppSettings[name];
			T value = default(T);
			if (!String.IsNullOrEmpty(config))
			{
				value = (T)Convert.ChangeType(config, typeof(T));
				return value;
			}
			return value;
		}
		public static List<T> GetList<T>(string name, char separator = ',')
		{
			string config = ConfigurationManager.AppSettings[name];
			List<T> value = new List<T>();
			if (!String.IsNullOrEmpty(config))
			{
				value = config.Split(separator).Cast<T>().ToList();
				return value;
			}
			return value;
		}
		public static string GetName(string fileName)
		{
			string fileExtension = fileName.Split('.')[fileName.Split('.').Length - 1];
			return DateTime.Now.ToString("yyyyMMddhhmmss") + "." + fileExtension;
		}
		public static void HandleImage(HttpPostedFileBase URL, string path)
		{
			Image image = Image.FromStream(URL.InputStream);
			System.Drawing.Bitmap imageResized = ResizeImage(image);
			imageResized.Save(path);
		}
		private static Bitmap ResizeImage(Image image)
		{
			int defaultWidth = Get<int>("largura");
			int defaultHeight = Get<int>("altura");
			int width = defaultWidth;
			int height = defaultHeight;
            Bitmap destImage = new Bitmap(width, height);
            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
            if (image.Height < defaultHeight && image.Width < defaultWidth)
            {
                destImage = new Bitmap(width, height);
                destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
                using (var graphics = Graphics.FromImage(destImage))
                {
                    //Rectangle rect = new Rectangle(0, 0, defaultWidth, defaultHeight);
                    using (ImageAttributes wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImageUnscaled(image, new Rectangle(0, 0, image.Width, image.Height));
                    }
                    Rectangle rect = new Rectangle(0, image.Height + 20, 400, 15);
                    graphics.FillRectangle(Brushes.White, rect);
                    graphics.DrawString("Imagem Meramente ilustrativa", new Font("Helvetica", 11, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.Black), rect);
                }
            }
            else
            {
                double x = (double)defaultWidth / (double)image.Width;
                double y = (double)defaultHeight / (double)image.Height;
                if (x < y)
                    height = (int)(image.Height * x);
                else
                    width = (int)(image.Width * y);
                var destRect = new Rectangle(0, 0, width, height);

                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    using (ImageAttributes wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(image, new Rectangle(0, 0, width, height), 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                    Rectangle rect = new Rectangle(0, height - 20, destImage.Width, destImage.Height);
                    graphics.FillRectangle(Brushes.White, rect);
                    graphics.DrawString(Get<string>("disclaimerImagem"), new Font("Helvetica", 11, FontStyle.Bold, GraphicsUnit.Pixel), new SolidBrush(Color.Black), rect);
                    graphics.Flush();
                }
            }
			return destImage;
		}

		private static Dictionary<Core.Model.LocalCerimonia, string> locaisCerimonia;
		public static Dictionary<Core.Model.LocalCerimonia, string> LocalCerimonia
		{
			get
			{
				if (locaisCerimonia == null)
				{
					locaisCerimonia = new Dictionary<Core.Model.LocalCerimonia, string>();
					foreach (Delta.Core.Model.LocalCerimonia item in Enum.GetValues(typeof(Delta.Core.Model.LocalCerimonia)).Cast<Delta.Core.Model.LocalCerimonia>())
						locaisCerimonia[item] = item.GetDescription();
				}
				return locaisCerimonia;
			}
		}
		private static Dictionary<Core.Model.TipoEvento, string> tiposEvento;
		public static Dictionary<Core.Model.TipoEvento, string> TiposEvento
		{
			get
			{
				if (tiposEvento == null)
				{
					tiposEvento = new Dictionary<Core.Model.TipoEvento, string>();
					foreach (Delta.Core.Model.TipoEvento item in Enum.GetValues(typeof(Delta.Core.Model.TipoEvento)).Cast<Delta.Core.Model.TipoEvento>())
						tiposEvento[item] = item.GetDescription();
				}
				return tiposEvento;
			}
		}

		public static Core.Data.Context context_;
		public static Core.Data.Context context
		{
			get
			{
				if (context_ == null)
					context_ = new Core.Data.Context();
				return context_;
			}
		}
		public static void ResetContext()
		{
			context_.Dispose();
			context_ = null;
		}

		public static string ReadFileEmail(string nomeArquivoEmail)
		{
			string message = string.Empty;
			string file = Path.Combine(Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory)) + "\\Padrao Emails\\" + nomeArquivoEmail;
			if (File.Exists(file))
			{
				using (FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
				{
					using (StreamReader reader = new StreamReader(fileStream))
					{
						message = reader.ReadToEnd();
						reader.Close();
						reader.Dispose();
					}
					fileStream.Close();
					fileStream.Dispose();
				}
			}
			return message;
		}
	}
}
