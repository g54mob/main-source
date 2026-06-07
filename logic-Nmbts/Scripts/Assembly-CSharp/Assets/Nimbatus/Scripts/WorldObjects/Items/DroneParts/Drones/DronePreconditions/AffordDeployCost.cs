using System;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DeployCosts;
using I2.Loc;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions
{
	[Serializable]
	public class AffordDeployCost : DronePrecondition
	{
		public override bool Check(NimbatusDrone drone)
		{
			if (drone != null)
			{
				return DeployCostHelper.HasEnoughResources(DeployCostHelper.CalculateDeployCost(drone.RootDronePart.GetNumberOfDroneParts<DronePart>()));
			}
			return false;
		}

		public override bool Check(DroneData drone)
		{
			if (drone == null)
			{
				return false;
			}
			return DeployCostHelper.HasEnoughResources(DeployCostHelper.CalculateDeployCost(drone.NumberOfParts));
		}

		protected override string GetStatus(bool check)
		{
			return (check ? LabelHelper.White : LabelHelper.DarkOrange) + LocalizationManager.GetTermTranslation("Preconditions/DeployCost");
		}
	}
}
