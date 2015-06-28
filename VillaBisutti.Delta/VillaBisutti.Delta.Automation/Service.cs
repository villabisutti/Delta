﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Automation
{
	public partial class Service : ServiceBase
	{
		public Service()
		{
			InitializeComponent();
            ServiceName = "Nome do Serviço";
		}

		protected override void OnStart(string[] args)
		{
            this.Start();
            base.OnStart(args);
		}

        public void Start()
        {
            try
            {
                Watcher watch = new Watcher();
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected override void OnContinue()
        {
            base.OnContinue();
        }

		protected override void OnStop()
		{
            base.Stop();
		}

        protected override void OnShutdown()
        {
            base.OnShutdown();
        }

        protected override void OnPause()
        {
            base.OnPause();
        }

	}
}
