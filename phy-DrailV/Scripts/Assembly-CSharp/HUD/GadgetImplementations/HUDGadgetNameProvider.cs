using DV.HUD;
using DV.UI.LocoHUD;

namespace HUD.GadgetImplementations
{
	public class HUDGadgetNameProvider : HUDElementNameProviderBase
	{
		public GadgetHUDModule module;

		public override string GetName()
		{
			return module.GetName();
		}

		private void Reset()
		{
			if (module == null)
			{
				module = GetComponent<GadgetHUDModule>();
			}
		}
	}
}
