using System;

namespace Gh.Tk.UI.Dialogs
{
	public class TooltipSettingsPage3DUIView : SettingsPage3DUIView
	{
		public override void Init()
		{
		}

		private void AddLockSettings()
		{
		}

		private Slider3DUIView AddTooltipDelaySliderSetting(string id, string delayId, string labelKey, float defaultValue, string tooltipBody, Func<float> getFunc, Action<float> setFunc)
		{
			return null;
		}

		private Slider3DUIView AddTooltipSlider(string id, string labelKey, string delayId, float defaultValue, Func<float> getFunc, Action<float> setFunc, Func<string> getTooltipBody)
		{
			return null;
		}
	}
}
