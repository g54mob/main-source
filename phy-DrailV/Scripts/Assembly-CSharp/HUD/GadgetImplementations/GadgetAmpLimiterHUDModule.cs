using DV.Customization.Gadgets.Implementations;
using DV.HUD;
using DV.Localization;
using DV.UI.LocoHUD;
using DV.UIFramework;

namespace HUD.GadgetImplementations
{
	public class GadgetAmpLimiterHUDModule : GadgetHUDModule<GadgetAmpLimiter, GadgetAmpLimiterLOD>
	{
		public LocoHUDControlBase limitSelector;

		public LocoHUDControlBase activeIndicator;

		private static string Off => LocalizationAPI.L("hud/amp_limiter_off");

		private void Awake()
		{
			limitSelector.controlModule.ValueChanged += delegate(float val)
			{
				if (val != 0f)
				{
					if (val > 0f)
					{
						gadget.ModeIndex++;
					}
					else
					{
						gadget.ModeIndex--;
					}
					gadgetLOD.SyncControls();
				}
			};
		}

		private void Update()
		{
			if (gadget.IsEnabled)
			{
				limitSelector.textModule.SetTextValue(gadget.EffectiveLimit.ToString("F0"));
				limitSelector.textModule.SetTextUnit("A");
			}
			else
			{
				limitSelector.textModule.SetTextValue(Off);
				limitSelector.textModule.SetTextUnit("");
			}
			limitSelector.visualLevelModule.SetVisualLevel((float)gadget.ModeIndex / (float)(gadget.ModeCount - 1));
			activeIndicator.lightIndicatorModule.SetIndicatorColor(gadgetLOD.limitingIndicator.IsOn ? UIColors.YELLOW : UIColors.CLEAR);
		}
	}
}
