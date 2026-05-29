using CTS;
using CTS.Core.Utilities;
using UnityEngine.Scripting;

namespace ES3Types
{
	[Preserve]
	public class ES3UserType_FinancialLoaningContract : ES3ComponentType
	{
		public static ES3Type Instance;

		public ES3UserType_FinancialLoaningContract()
			: base(typeof(FinancialLoaningContract))
		{
			Instance = this;
			priority = 1;
		}

		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			FinancialLoaningContract financialLoaningContract = (FinancialLoaningContract)obj;
			writer.WriteAssetReference("LoanData", financialLoaningContract.FinancialLoanSO);
			writer.WritePrivateField("_contractIsActive", financialLoaningContract);
			writer.WritePrivateField("_contractUnlocked", financialLoaningContract);
			writer.WritePrivateField("_currentInterest", financialLoaningContract);
			writer.WritePrivateField("_borrowingPeriod", financialLoaningContract);
			writer.WritePrivateField("_contractAmount", financialLoaningContract);
			writer.WritePrivateField("_monthlyCharges", financialLoaningContract);
			writer.WritePrivateField("_remainingAmount", financialLoaningContract);
			writer.WritePrivateField("_remainingTimeToPay", financialLoaningContract);
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			FinancialLoaningContract objectContainingField = (FinancialLoaningContract)obj;
			foreach (string property in reader.Properties)
			{
				switch (property)
				{
				case "LoanData":
					reader.SetPrivateField("FinancialLoanSO".ToBackingField(), reader.ReadAssetReference<FinancialLoanSO>(), objectContainingField);
					break;
				case "_contractIsActive":
					reader.SetPrivateField("_contractIsActive", reader.Read<bool>(), objectContainingField);
					break;
				case "_contractUnlocked":
					reader.SetPrivateField("_contractUnlocked", reader.Read<bool>(), objectContainingField);
					break;
				case "_currentInterest":
					reader.SetPrivateField("_currentInterest", reader.Read<float>(), objectContainingField);
					break;
				case "_borrowingPeriod":
					reader.SetPrivateField("_borrowingPeriod", reader.Read<int>(), objectContainingField);
					break;
				case "_contractAmount":
					reader.SetPrivateField("_contractAmount", reader.Read<int>(), objectContainingField);
					break;
				case "_monthlyCharges":
					reader.SetPrivateField("_monthlyCharges", reader.Read<int>(), objectContainingField);
					break;
				case "_remainingAmount":
					reader.SetPrivateField("_remainingAmount", reader.Read<int>(), objectContainingField);
					break;
				case "_remainingTimeToPay":
					reader.SetPrivateField("_remainingTimeToPay", reader.Read<int>(), objectContainingField);
					break;
				default:
					reader.Skip();
					break;
				}
			}
		}
	}
}
