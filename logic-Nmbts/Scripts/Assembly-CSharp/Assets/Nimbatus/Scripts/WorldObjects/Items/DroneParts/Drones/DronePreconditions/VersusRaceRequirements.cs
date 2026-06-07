using System;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MechanicalParts;
using I2.Loc;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions
{
	[Serializable]
	public class VersusRaceRequirements : DronePrecondition
	{
		public override bool Check(NimbatusDrone drone)
		{
			if (drone != null)
			{
				if (drone.RootDronePart.GetNumberOfDroneParts((DronePart p) => p is FactoryPart) <= 0 && drone.RootDronePart.GetNumberOfDroneParts((DronePart p) => p.DronePartType == EDronePartType.Weapon) <= 0)
				{
					return drone.RootDronePart.GetNumberOfDroneParts((DronePart p) => p.DronePartType == EDronePartType.DefensePart) <= 0;
				}
				return false;
			}
			return false;
		}

		public override bool Check(DroneData drone)
		{
			if (drone != null)
			{
				foreach (FactoryPart item in SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItems<FactoryPart>())
				{
					if (drone.GetNumberOfParts(item.UniqueId) > 0)
					{
						return false;
					}
				}
				return drone.NumberOfWeapons <= 0;
			}
			return false;
		}

		protected override string GetStatus(bool check)
		{
			return (check ? LabelHelper.White : LabelHelper.DarkOrange) + LocalizationManager.GetTermTranslation("Preconditions/NoWeapons");
		}
	}
}
