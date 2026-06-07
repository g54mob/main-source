using DV.Customization.Gadgets.Implementations;
using DV.HUD;
using DV.Localization;
using DV.UI.LocoHUD;
using DV.UIFramework;
using UnityEngine;

namespace HUD.GadgetImplementations
{
	public class GadgetDPUHUDModule : GadgetHUDModule<GadgetDPU, GadgetDPULOD>
	{
		private static readonly string[] RegimeLocKeys = new string[3] { "hud/wmc_tx", "hud/wmc_off", "hud/wmc_rx" };

		private static readonly string[] OrientLocKeys = new string[2] { "hud/wmc_r", "hud/wmc_f" };

		public LocoHUDControlBase connectedLight;

		public LocoHUDControlBase syncingLight;

		public LocoHUDControlBase conflictLight;

		public LocoHUDControlBase regimeSelector;

		public LocoHUDControlBase orientationSelector;

		public LocoHUDControlBase channelSelector;

		private void Awake()
		{
			regimeSelector.controlModule.ValueChanged += delegate(float val)
			{
				if (!0f.Equals(val))
				{
					if (!(-1f).Equals(val))
					{
						if (1f.Equals(val) && gadget.Regime != GadgetDPU.WirelessMode.Transmit)
						{
							gadget.Regime--;
						}
					}
					else if (gadget.Regime != GadgetDPU.WirelessMode.Receive)
					{
						gadget.Regime++;
					}
					gadgetLOD.SyncControls();
				}
			};
			orientationSelector.controlModule.ValueChanged += delegate(float val)
			{
				if (val != 0f)
				{
					gadget.ReverseOrientation = val < 0f;
					gadgetLOD.SyncControls();
				}
			};
			channelSelector.controlModule.ValueChanged += delegate(float val)
			{
				if (val != 0f)
				{
					int num = gadget.Channel + (int)Mathf.Sign(val);
					if (num >= 0 && num < 8)
					{
						gadget.Channel = num;
						gadgetLOD.SyncControls();
					}
				}
			};
		}

		private void Update()
		{
			regimeSelector.textModule.SetTextValue(LocalizationAPI.L(RegimeLocKeys[(uint)gadget.Regime]));
			regimeSelector.visualLevelModule.SetVisualLevel(1f - (float)(int)gadget.Regime / 2f);
			orientationSelector.textModule.SetTextValue(LocalizationAPI.L(OrientLocKeys[(!gadget.ReverseOrientation) ? 1u : 0u]));
			orientationSelector.visualLevelModule.SetVisualLevel((!gadget.ReverseOrientation) ? 1 : 0);
			channelSelector.textModule.SetTextValue((gadget.Channel + 1).ToString());
			channelSelector.visualLevelModule.SetVisualLevel((float)gadget.Channel / 7f);
			conflictLight.lightIndicatorModule.SetIndicatorColor(gadgetLOD.lampConflict.IsOn ? UIColors.RED : UIColors.CLEAR);
			connectedLight.lightIndicatorModule.SetIndicatorColor(gadgetLOD.lampConnected.IsOn ? UIColors.BLUE : UIColors.CLEAR);
			syncingLight.lightIndicatorModule.SetIndicatorColor(gadgetLOD.lampRXTX.IsOn ? UIColors.GREEN : UIColors.CLEAR);
		}
	}
}
