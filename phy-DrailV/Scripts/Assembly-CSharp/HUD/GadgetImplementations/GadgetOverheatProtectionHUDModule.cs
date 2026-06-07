using DV.Customization.Gadgets.Implementations;
using DV.HUD;
using DV.Localization;
using DV.UI.LocoHUD;
using DV.UIFramework;

namespace HUD.GadgetImplementations
{
	public class GadgetOverheatProtectionHUDModule : GadgetHUDModule<GadgetOverheatProtection, GadgetOverheatProtectionLOD>
	{
		private static readonly string[] ModesLocKeys = new string[2] { "hud/overheat_reduce", "hud/overheat_cut" };

		public LocoHUDControlBase tempSelector;

		public LocoHUDControlBase activeIndicator;

		public LocoHUDControlBase modeSelector;

		private void Awake()
		{
			tempSelector.controlModule.ValueChanged += delegate(float val)
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
			modeSelector.controlModule.ValueChanged += delegate(float val)
			{
				if (val != 0f)
				{
					gadget.cutEngine = val > 0.5f;
					gadgetLOD.SyncControls();
				}
			};
		}

		private void Update()
		{
			tempSelector.SetTextValue(gadget.CurrentLimit.ToString("F0"));
			tempSelector.SetTextUnit("C");
			tempSelector.SetVisualLevel((float)gadget.ModeIndex / ((float)gadget.ModeCount - 1f));
			activeIndicator.SetIndicatorColor(gadgetLOD.active.IsOn ? UIColors.YELLOW : UIColors.CLEAR);
			modeSelector.SetTextValue(LocalizationAPI.L(ModesLocKeys[gadget.cutEngine ? 1 : 0]));
			modeSelector.SetVisualLevel(gadget.cutEngine ? 1 : 0);
		}
	}
}
