namespace ModApi.Design.PartProperties
{
	public interface ISliderProperty : IConfigurableProperty
	{
		string LabelValue { get; set; }

		float MaxValue { get; }

		float MinValue { get; }

		int NumberOfSteps { get; }

		string SliderValue { get; set; }

		void UpdateSliderSettings(float minValue, float maxValue, int numberOfSteps);

		void UpdateSliderSettings(float minValue, float maxValue, int numberOfSteps, bool refreshUI);
	}
}
