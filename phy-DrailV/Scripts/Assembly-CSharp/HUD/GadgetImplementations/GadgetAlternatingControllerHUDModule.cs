using DV.Customization.Gadgets.Implementations;
using DV.HUD;
using DV.UI.LocoHUD;
using DV.UIFramework;
using UnityEngine;

namespace HUD.GadgetImplementations
{
	public class GadgetAlternatingControllerHUDModule : GadgetHUDModule<AlternatingController, AlternatingControllerLOD>
	{
		public LocoHUDControlBase switchSelector;

		private void Awake()
		{
			switchSelector.controlModule.ValueChanged += delegate(float val)
			{
				if (val != 0f)
				{
					gadget.SelectedInterval = Mathf.Clamp(gadget.SelectedInterval + (int)val, 0, gadget.IntervalCount);
					gadgetLOD.SyncControls();
				}
			};
		}

		private void Update()
		{
			switchSelector.SetIndicatorColor((gadget.DefaultOutputValue > 0.01f) ? UIColors.YELLOW : UIColors.CLEAR);
			switchSelector.SetVisualLevel((float)gadget.SelectedInterval / (float)(gadget.IntervalCount - 1));
		}
	}
}
