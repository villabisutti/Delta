﻿using ServiceStack.ServiceHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model = VillaBisutti.Delta.Core.Model;

namespace VillaBisutti.Delta.ServiceModel.OutroItem
{
	[Route("/outroitem/{Id}", "GET")]
	public class Get : IReturn<model.OutrosItens>
	{
		public int Id { get; set; }
	}
	[Route("/outroitem", "GET")]
	public class GetAll : IReturn<List<model.OutrosItens>> { }
	[Route("/outroitem", "POST")]
	public class New
	{
        public model.OutrosItens entity { get; set; }
	}
	[Route("/outroitem", "PUT")]
	public class Update
	{
        public model.OutrosItens entity { get; set; }
	}
	[Route("/outroitem/{Id}", "DELETE")]
	public class Delete
	{
		public int Id { get; set; }
	}
}
