using UnityEngine;

namespace ModularOptions
{
	[DefaultExecutionOrder(3)]
	[AddComponentMenu("Modular Options/Preset")]
	public sealed class OptionPreset : DropdownOption
	{
		public SliderData[] sliderPresetData;

		public DropdownData[] dropdownPresetData;

		public ToggleData[] togglePresetData;

		private void Start()
		{
		}

		public void SetCustom()
		{
		}

		protected override void ApplySetting(int _value)
		{
		}
	}
}
