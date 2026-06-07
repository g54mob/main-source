using System;
using DV.Customization.Gadgets.Implementations;
using DV.HUD;
using DV.UI.LocoHUD;
using DV.UIFramework;

namespace HUD.GadgetImplementations
{
	public class GadgetATSHUDModule : GadgetHUDModule<GadgetATS, GadgetATSLOD>
	{
		public LocoHUDControlBase intervalSelector;

		public LocoHUDControlBase resetButton;

		public LocoHUDControlBase checkIndicator;

		public LocoHUDControlBase countdownDisplay;

		private void Awake()
		{
			intervalSelector.controlModule.ValueChanged += delegate(float val)
			{
				gadget.SetRegime(gadget.Regime + (int)val);
			};
			resetButton.controlModule.ValueChanged += delegate
			{
				gadgetLOD.OnAckButton();
			};
		}

		private void Update()
		{
			TimeSpan timeSpan = TimeSpan.FromSeconds(gadget.currentTimer);
			TimeSpan timeSpan2 = TimeSpan.FromSeconds(gadget.CurrentRegimeTimerLengthIgnorePower);
			countdownDisplay.SetTextValue(timeSpan.TotalSeconds.ToString("F0"));
			countdownDisplay.SetVisualLevel((float)(timeSpan.TotalSeconds / timeSpan2.TotalSeconds));
			checkIndicator.SetIndicatorColor(gadgetLOD.stateLamp.IsOn ? UIColors.YELLOW : UIColors.CLEAR);
			intervalSelector.SetTextValue(timeSpan2.TotalSeconds.ToString("F0"));
			intervalSelector.SetVisualLevel((float)gadget.Regime / ((float)gadget.RegimesCount - 1f));
		}
	}
}
