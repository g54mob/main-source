namespace ModApi.Design.PartProperties
{
	public interface IToggleButtonProperty : IConfigurableProperty
	{
		string LabelValue { get; set; }

		bool ToggleValue { get; set; }
	}
}
