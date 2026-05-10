using System.Collections.Generic;
using CTS;
using CTS.BBT.Handlers.Transactions;
using ES3Internal;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { "CurrentTransactionsData", "OldTransactionsData", "TransactionsHistoryData" })]
	public class ES3UserType_TransactionsHandlers : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_TransactionsHandlers()
			: base(typeof(TransactionsHandlers))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			TransactionsHandlers transactionsHandlers = (TransactionsHandlers)obj;
			writer.WriteProperty("CurrentTransactionsData", transactionsHandlers.CurrentTransactionsData, ES3TypeMgr.GetOrCreateES3Type(typeof(int[,])));
			writer.WriteProperty("OldTransactionsData", transactionsHandlers.OldTransactionsData, ES3TypeMgr.GetOrCreateES3Type(typeof(int[,])));
			writer.WriteProperty("TransactionsHistoryData", transactionsHandlers.TransactionsHistoryData, ES3TypeMgr.GetOrCreateES3Type(typeof(List<(TransactionType, int, TransactionTag)>)));
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			TransactionsHandlers transactionsHandlers = (TransactionsHandlers)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "CurrentTransactionsData":
					transactionsHandlers.CurrentTransactionsData = reader.Read<int[,]>();
					break;
				case "OldTransactionsData":
					transactionsHandlers.OldTransactionsData = reader.Read<int[,]>();
					break;
				case "TransactionsHistoryData":
					transactionsHandlers.TransactionsHistoryData = reader.Read<List<(TransactionType, int, TransactionTag)>>();
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
