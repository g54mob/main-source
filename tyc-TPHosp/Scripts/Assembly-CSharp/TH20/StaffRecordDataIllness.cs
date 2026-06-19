namespace TH20
{
	public class StaffRecordDataIllness : StaffRecordDataItem
	{
		public IllnessDefinition Illness;

		public override string ToString()
		{
			return Illness.Name.ToString();
		}
	}
}
