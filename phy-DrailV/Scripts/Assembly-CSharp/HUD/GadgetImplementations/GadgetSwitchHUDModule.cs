using DV.Customization.Gadgets.Implementations;
using DV.HUD;
using DV.UI.LocoHUD;
using DV.UIFramework;

namespace HUD.GadgetImplementations
{
	public class GadgetSwitchHUDModule : GadgetHUDModule<GadgetSwitch, GadgetSwitchLOD>
	{
		public LocoHUDControlBase switchSelector;

		public bool toggleMode;

		public float indicatorThreshold;

		private void Awake()
		{
			switchSelector.controlModule.ValueChanged += delegate(float val)
			{
				if (val != 0f)
				{
					if (toggleMode)
					{
						gadget.SetOutputValue(1f - gadget.RawOutputValue);
					}
					else
					{
						gadget.SetOutputValue(gadget.RawOutputValue + val * 0.1f);
					}
					gadgetLOD.SyncControls();
				}
			};
		}

		private void Update()
		{
			switchSelector.SetIndicatorColor((gadget.DefaultOutputValue > indicatorThreshold) ? UIColors.YELLOW : UIColors.CLEAR);
			switchSelector.SetVisualLevel(gadget.RawOutputValue);
		}
	}
}
