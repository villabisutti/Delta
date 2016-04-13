﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace VillaBisutti.Delta.Core.Business
{
	public class ItensContratar
	{
		public static IEnumerable<Model.Itens> GetReport(DateTime inicio, DateTime termino, bool? definido = null, bool? contratado = null, bool? fornecedorStartado = null, bool? fornecimentoBisutti = null, bool? responsabilidadeBisutti = null)
		{
			string fornecimento = string.Empty;
			if ((fornecimentoBisutti.HasValue && fornecimentoBisutti.Value) && (responsabilidadeBisutti.HasValue && responsabilidadeBisutti.Value))
				fornecimento = "BISUTTI";
			if ((fornecimentoBisutti.HasValue && !fornecimentoBisutti.Value) && (responsabilidadeBisutti.HasValue && responsabilidadeBisutti.Value))
				fornecimento = "TERCEIRO";
			if ((fornecimentoBisutti.HasValue && !fornecimentoBisutti.Value) && (responsabilidadeBisutti.HasValue && !responsabilidadeBisutti.Value))
				fornecimento = "CONTRATANTE";
			Data.Context context = new Data.Context();
			using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["VillaBisuttiDelta"].ConnectionString))
			{
				SqlCommand cmd = new SqlCommand();
				cmd.Connection = connection;
				cmd.CommandType = System.Data.CommandType.StoredProcedure;
				cmd.CommandText = "Popular_Itens";
				cmd.Parameters.AddWithValue("@DataInicio", inicio);
				cmd.Parameters.AddWithValue("@DataTermino", termino);
				if (definido.HasValue)
					cmd.Parameters.AddWithValue("@Definido", definido.Value);
				if (contratado.HasValue)
					cmd.Parameters.AddWithValue("@Contratado", contratado.Value);
				if (fornecedorStartado.HasValue)
					cmd.Parameters.AddWithValue("@FornecedorStartado", fornecedorStartado.Value);
				if (fornecimento != string.Empty)
					cmd.Parameters.AddWithValue("@ContratacaoFornecimento", fornecimento);
				if (cmd.Connection.State != System.Data.ConnectionState.Open)
					cmd.Connection.Open();
				cmd.ExecuteNonQuery();
				cmd.Dispose();
			}
			IEnumerable<Model.Itens> lista = new List<Model.Itens>().AsEnumerable<Model.Itens>();// context.Item;
			return lista;
		}
	}
}


//@DataInicio DATETIME = NULL,
//@DataTermino DATETIME = NULL,
//@Definido BIT = NULL,
//@Contratado BIT = NULL,
//@FornecedorStartado BIT = NULL,
//@ContratacaoFornecimento VARCHAR(50) = NULL
