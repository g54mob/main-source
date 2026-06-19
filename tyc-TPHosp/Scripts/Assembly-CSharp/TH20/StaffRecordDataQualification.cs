namespace TH20
{
	public class StaffRecordDataQualification : StaffRecordDataItem
	{
		public QualificationDefinition Qualification;

		public override string ToString()
		{
			return Qualification.NameLocalised.ToString();
		}
	}
}
