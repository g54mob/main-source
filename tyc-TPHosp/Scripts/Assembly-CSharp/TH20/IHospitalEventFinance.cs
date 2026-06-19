namespace TH20
{
	public interface IHospitalEventFinance
	{
		int GetFinanceValue();

		bool IsFinanceValueValid();

		bool ShowOnStatement();
	}
}
