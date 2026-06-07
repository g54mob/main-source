using Assets.Scripts.Craft.Parts.Modifiers.Propulsion;
using ModApi.Craft.Parts;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class CrossFeedScript : PartModifierScript<CrossFeedData>
	{
		public bool GetFuelTanks(out FuelTankScript source, out FuelTankScript target)
		{
			source = null;
			target = null;
			if (base.Data.Mode != CrossFeedData.CrossFeedMode.Disabled)
			{
				FuelTankData fuelTank = EngineUtilities.GetFuelTank(base.PartScript, base.Data.AttachPointA, null);
				FuelTankData fuelTank2 = EngineUtilities.GetFuelTank(base.PartScript, base.Data.AttachPointB, null);
				if (fuelTank != null && fuelTank2 != null && fuelTank != fuelTank2 && fuelTank.FuelType == fuelTank2.FuelType && fuelTank.FuelType.AllowFuelTransfer)
				{
					if (base.Data.Mode == CrossFeedData.CrossFeedMode.Normal || base.Data.Mode == CrossFeedData.CrossFeedMode.Equalize)
					{
						source = fuelTank.Script;
						target = fuelTank2.Script;
						return true;
					}
					if (base.Data.Mode == CrossFeedData.CrossFeedMode.Reversed)
					{
						source = fuelTank2.Script;
						target = fuelTank.Script;
						return true;
					}
					Debug.LogErrorFormat("Unsupported Cross Feed Mode: {0}", base.Data.Mode);
				}
			}
			return false;
		}
	}
}
