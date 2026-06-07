using DV.Customization.Gadgets;
using DV.Customization.Gadgets.Implementations;
using DV.HUD;
using DV.UI.LocoHUD;
using UnityEngine;

namespace HUD.GadgetImplementations
{
	public class GadgetClinometerHUDModule : GadgetHUDModule
	{
		public float maxDegreeValue;

		public LocoHUDControlBase gradeIndicator;

		private GadgetClinometerLOD gadgetLOD;

		public override void SetGadget(GadgetBase gadget)
		{
			gadgetLOD = gadget.GetComponentInChildren<GadgetClinometerLOD>(includeInactive: true);
		}

		private void Update()
		{
			gradeIndicator.SetVisualLevel(Mathf.InverseLerp(0f - maxDegreeValue, maxDegreeValue, gadgetLOD.indicator.Value));
			gradeIndicator.SetTextValue($"{Mathf.Clamp(gadgetLOD.indicator.Value, 0f - maxDegreeValue, maxDegreeValue):F1}");
			gradeIndicator.SetTextUnit("%");
		}

		public override string GetName()
		{
			return gadgetLOD.Base.GadgetItem.Item.InventorySpecs.LocalizedName;
		}
	}
}
