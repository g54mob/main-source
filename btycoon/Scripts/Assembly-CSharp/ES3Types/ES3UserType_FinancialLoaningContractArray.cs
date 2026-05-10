using CTS;

namespace ES3Types
{
	public class ES3UserType_FinancialLoaningContractArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_FinancialLoaningContractArray()
			: base(typeof(FinancialLoaningContract[]), ES3UserType_FinancialLoaningContract.Instance)
		{
			Instance = this;
		}
	}
}
