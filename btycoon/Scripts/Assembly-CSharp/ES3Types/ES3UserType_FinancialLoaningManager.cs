using CTS;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	[ES3Properties(new string[] { })]
	public class ES3UserType_FinancialLoaningManager : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_FinancialLoaningManager()
			: base(typeof(FinancialLoaningManager))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			FinancialLoaningManager financialLoaningManager = (FinancialLoaningManager)obj;
			writer.WriteList("Contracts", financialLoaningManager.Contracts, ES3.ReferenceMode.ByRefAndValue);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			FinancialLoaningManager financialLoaningManager = (FinancialLoaningManager)obj;
			foreach (string property in reader.Properties)
			{
				if (!reader.TryReadIntoList(property, "Contracts", financialLoaningManager.Contracts))
				{
					reader.Skip();
				}
			}
			foreach (FinancialLoaningContract contract in financialLoaningManager.Contracts)
			{
				contract.LoadSavingData();
			}
		}
	}
}
