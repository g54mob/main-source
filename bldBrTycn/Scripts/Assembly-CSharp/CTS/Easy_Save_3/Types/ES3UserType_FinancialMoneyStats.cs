using ES3Types;
using UnityEngine.Scripting;

namespace CTS.Easy_Save_3.Types
{
	[Preserve]
	public class ES3UserType_FinancialMoneyStats : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_FinancialMoneyStats()
			: base(typeof(FinancialMoneyStats))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			FinancialMoneyStats financialMoneyStats = (FinancialMoneyStats)obj;
			financialMoneyStats.SaveSavingData();
			writer.WritePrivateField("_balanceDataSavingSystem", financialMoneyStats);
			writer.WritePrivateField("_currentTransactionsDataSavingSystem", financialMoneyStats);
			writer.WritePrivateField("_oldTransactionsDataSavingSystem", financialMoneyStats);
			writer.WritePrivateField("_chargesDataSavingSystem", financialMoneyStats);
			writer.WritePrivateField("_oldChargesDataSavingSystem", financialMoneyStats);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			FinancialMoneyStats financialMoneyStats = (FinancialMoneyStats)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "_balanceDataSavingSystem":
					financialMoneyStats = (FinancialMoneyStats)reader.SetPrivateField("_balanceDataSavingSystem", reader.Read<int>(), financialMoneyStats);
					break;
				case "_currentTransactionsDataSavingSystem":
					financialMoneyStats = (FinancialMoneyStats)reader.SetPrivateField("_currentTransactionsDataSavingSystem", reader.Read<int[,]>(), financialMoneyStats);
					break;
				case "_oldTransactionsDataSavingSystem":
					financialMoneyStats = (FinancialMoneyStats)reader.SetPrivateField("_oldTransactionsDataSavingSystem", reader.Read<int[,]>(), financialMoneyStats);
					break;
				case "_chargesDataSavingSystem":
					financialMoneyStats = (FinancialMoneyStats)reader.SetPrivateField("_chargesDataSavingSystem", reader.Read<int[]>(), financialMoneyStats);
					break;
				case "_oldChargesDataSavingSystem":
					financialMoneyStats = (FinancialMoneyStats)reader.SetPrivateField("_oldChargesDataSavingSystem", reader.Read<int[]>(), financialMoneyStats);
					break;
				default:
					reader.Skip();
					break;
				}
			}
			financialMoneyStats.LoadSavingData();
		}
	}
}
