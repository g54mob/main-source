namespace TH20
{
	public class StaffRecordDataXP : StaffRecordDataItem
	{
		public int CumulativeAmount;

		public int EarnedThisYear;

		public override string ToString()
		{
			return "Cumulative " + CumulativeAmount + " - EarnedThisYear " + EarnedThisYear;
		}
	}
}
