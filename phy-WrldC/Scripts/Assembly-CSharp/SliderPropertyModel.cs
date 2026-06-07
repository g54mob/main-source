public class SliderPropertyModel : OverridablePropertyModel
{
	public float MaxValue { get; set; }

	public float MinValue { get; set; }

	public float StepValue { get; set; }

	public string DisplayFormat { get; set; }

	public SliderPropertyModel(string key, string value)
		: base(key, value)
	{
	}
}
