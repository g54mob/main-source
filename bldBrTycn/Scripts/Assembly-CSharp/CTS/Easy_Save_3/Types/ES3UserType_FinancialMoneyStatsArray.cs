using ES3Types;

namespace CTS.Easy_Save_3.Types
{
	public class ES3UserType_FinancialMoneyStatsArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_FinancialMoneyStatsArray()
			: base(typeof(FinancialMoneyStats[]), ES3UserType_FinancialMoneyStats.Instance)
		{
			Instance = this;
		}
	}
}
