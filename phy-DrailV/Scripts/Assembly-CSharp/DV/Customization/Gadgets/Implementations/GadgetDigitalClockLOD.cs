using System;
using DV.Utils;
using DV.WeatherSystem;

namespace DV.Customization.Gadgets.Implementations
{
	public class GadgetDigitalClockLOD : CustomizerLODObject<GadgetBase>
	{
		public LCDDriver display;

		public IndicatorEmission backlight;

		public string format = "HH:mm";

		private WeatherPresetManager weatherPresetManager;

		private void UpdateTime()
		{
			if (!base.Base.PowerState)
			{
				display.Clear();
				backlight.Value = 0f;
			}
			else
			{
				backlight.Value = 1f;
				display.Display(weatherPresetManager.DateTime.ToString(format));
			}
		}

		private void Awake()
		{
			weatherPresetManager = SingletonBehaviour<WeatherDriver>.Instance?.manager;
			if (weatherPresetManager == null)
			{
				display.Display(DateTime.MinValue.ToString(format));
			}
			else
			{
				weatherPresetManager.MinuteChanged += UpdateTime;
			}
		}

		private void Start()
		{
			UpdateTime();
		}

		protected internal override void OnPowerStateChanged(bool newValue)
		{
			UpdateTime();
		}

		private void OnDestroy()
		{
			weatherPresetManager.MinuteChanged -= UpdateTime;
			weatherPresetManager = null;
		}
	}
}
