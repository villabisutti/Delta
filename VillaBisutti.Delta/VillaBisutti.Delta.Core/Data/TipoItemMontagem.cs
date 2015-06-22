﻿using System.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Data
{
	public class TipoItemMontagem : DataAccessBase<Model.TipoItemMontagem>
	{
		public override void Update(Model.TipoItemMontagem entity)
		{
			Model.TipoItemMontagem original = context.TipoItemMontagem.FirstOrDefault(a => a.Id == entity.Id);
			context.Entry(original).CurrentValues.SetValues(entity);
			context.SaveChanges();
		}

		public override System.Data.Entity.Infrastructure.DbEntityEntry GetCurrent(Model.TipoItemMontagem entity)
		{
			return context.Entry(entity);
		}

		public override void Insert(Model.TipoItemMontagem entity)
		{
			context.TipoItemMontagem.Add(entity);
			context.SaveChanges();
		}

		protected override List<Model.TipoItemMontagem> GetCollection()
		{
			return context.TipoItemMontagem.ToList();
		}
	}
}
