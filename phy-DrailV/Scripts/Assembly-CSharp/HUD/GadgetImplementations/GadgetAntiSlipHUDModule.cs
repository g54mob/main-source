using DV.Customization.Gadgets.Implementations;
using DV.HUD;
using DV.UI.LocoHUD;
using DV.UIFramework;

namespace HUD.GadgetImplementations
{
	public class GadgetAntiSlipHUDModule : GadgetHUDModule<GadgetAntiSlip, GadgetAntiSlipLOD>
	{
		public LocoHUDControlBase activeIndicator;

		private void Update()
		{
			activeIndicator.SetIndicatorColor(gadget.PowerState ? UIColors.YELLOW : UIColors.CLEAR);
		}
	}
}
