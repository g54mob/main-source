using CTS;

namespace ES3Types
{
	public class ES3UserType_FinancialLoaningManagerArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_FinancialLoaningManagerArray()
			: base(typeof(FinancialLoaningManager[]), ES3UserType_FinancialLoaningManager.Instance)
		{
			Instance = this;
		}
	}
}
