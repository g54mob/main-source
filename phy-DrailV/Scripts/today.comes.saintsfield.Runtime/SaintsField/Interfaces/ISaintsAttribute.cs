namespace SaintsField.Interfaces
{
	public interface ISaintsAttribute
	{
		SaintsAttributeType AttributeType { get; }

		string GroupBy { get; }
	}
}
