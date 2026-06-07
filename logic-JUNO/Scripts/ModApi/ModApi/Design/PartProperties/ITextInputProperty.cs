namespace ModApi.Design.PartProperties
{
	public interface ITextInputProperty : IConfigurableProperty
	{
		string LabelValue { get; set; }

		string Value { get; }
	}
}
