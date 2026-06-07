namespace SettingScripts
{
	public class SettingLandmarkValues<TValueType>
	{
		public string label;

		public TValueType value;

		public string tooltip;

		public SettingLandmarkValues(string newLabel, TValueType newValue, string tooltipText = null)
		{
			label = newLabel;
			value = newValue;
			tooltip = tooltipText;
		}
	}
}
