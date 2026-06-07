using DV.Customization.Gadgets;
using UnityEngine;

namespace DV.Interaction
{
	public class GadgetSolderingToolReloadVolume : ItemMagazineTriggerReloadVolume<GadgetSolderingResource>
	{
		private GadgetSolderingTool solderingTool;

		protected override bool Initialize()
		{
			solderingTool = GetComponentInParent<GadgetSolderingTool>();
			if (solderingTool == null)
			{
				Debug.LogError("GadgetSolderingToolReloadVolume: Missing GadgetSolderingTool. Destroying self.", this);
				Object.Destroy(this);
				return false;
			}
			return true;
		}

		public override bool ValidReload(GadgetSolderingResource ammo)
		{
			if (ammo == null)
			{
				return false;
			}
			return solderingTool.IsUseCompatible(ammo.AmmoUseTarget);
		}
	}
}
