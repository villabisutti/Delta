﻿using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class FotoVideo : DataAccessBase<Model.ItemFotoVideoSelecionado>
	{
		public override void Update(Model.ItemFotoVideoSelecionado entity)
		{
			Model.ItemFotoVideoSelecionado original = context.FotosVideos.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).OriginalValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.ItemFotoVideoSelecionado entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.ItemFotoVideoSelecionado entity)
		{
			context.FotosVideos.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.ItemFotoVideoSelecionado> GetCollection()
		{
			return context.FotosVideos.ToList();
		}
	}
}
