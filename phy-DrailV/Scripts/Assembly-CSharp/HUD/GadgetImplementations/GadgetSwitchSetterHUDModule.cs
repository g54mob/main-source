using DV.Customization.Gadgets.Implementations;
using DV.HUD;
using DV.Localization;
using DV.UI.LocoHUD;
using DV.UIFramework;
using UnityEngine;

namespace HUD.GadgetImplementations
{
	public class GadgetSwitchSetterHUDModule : GadgetHUDModule<GadgetSwitchSetter, GadgetSwitchSetterLOD>
	{
		private static readonly string[] OrientLocKeys = new string[3] { "hud/switch_fwd", "hud/switch_auto", "hud/switch_rev" };

		private static readonly string[] DirLocKeys = new string[2] { "hud/switch_dir", "hud/switch_side" };

		public LocoHUDControlBase distanceSelector;

		public LocoHUDControlBase orientationSelector;

		public LocoHUDControlBase modeSelector;

		public LocoHUDControlBase switchButton;

		public LocoHUDControlBase leftIndicator;

		public LocoHUDControlBase rightIndicator;

		private void Awake()
		{
			distanceSelector.controlModule.ValueChanged += delegate(float val)
			{
				if (val != 0f)
				{
					gadget.Mode = Mathf.Clamp(gadget.Mode + (int)val, 0, gadget.ModeCount - 1);
					gadgetLOD.SyncControls();
				}
			};
			orientationSelector.controlModule.ValueChanged += delegate(float val)
			{
				if (val != 0f)
				{
					gadget.DirectionMode = Mathf.Clamp(gadget.DirectionMode + (int)val, 0, 2);
					gadgetLOD.SyncControls();
				}
			};
			modeSelector.controlModule.ValueChanged += delegate(float val)
			{
				if (val != 0f)
				{
					gadget.SideCorrectRegime = val > 0f;
					gadgetLOD.SyncControls();
				}
			};
			switchButton.controlModule.ValueChanged += delegate(float val)
			{
				if (val != 0f)
				{
					gadgetLOD.BtnChange();
				}
			};
		}

		private void Update()
		{
			distanceSelector.visualLevelModule.SetVisualLevel((float)gadget.Mode / ((float)gadget.ModeCount - 1f));
			distanceSelector.textModule.SetTextValue(gadget.GetRange().ToString("F0"));
			distanceSelector.textModule.SetTextUnit("m");
			orientationSelector.textModule.SetTextValue(LocalizationAPI.L(OrientLocKeys[gadget.DirectionMode]));
			orientationSelector.visualLevelModule.SetVisualLevel((float)gadget.DirectionMode / 2f);
			modeSelector.textModule.SetTextValue(LocalizationAPI.L(DirLocKeys[gadget.SideCorrectRegime ? 1 : 0]));
			modeSelector.visualLevelModule.SetVisualLevel(gadget.SideCorrectRegime ? 1 : 0);
			leftIndicator.lightIndicatorModule.SetIndicatorColor(gadgetLOD.lampLeft.IsOn ? UIColors.RED : UIColors.CLEAR);
			rightIndicator.lightIndicatorModule.SetIndicatorColor(gadgetLOD.lampRight.IsOn ? UIColors.RED : UIColors.CLEAR);
			switchButton.lightIndicatorModule.SetIndicatorColor(gadgetLOD.lampInRange.IsOn ? UIColors.YELLOW : UIColors.CLEAR);
		}
	}
}
