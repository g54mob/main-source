using System;
using System.Linq;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MechanicalParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.MeleeWeapons;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using I2.Loc;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions
{
	[Serializable]
	public class CombatArenaRequirements : DronePrecondition
	{
		public override bool Check(NimbatusDrone drone)
		{
			if (drone != null)
			{
				if (drone.RootDronePart.GetNumberOfDroneParts((DronePart p) => p is FactoryPart) <= 0 && drone.RootDronePart.GetNumberOfDroneParts((DronePart p) => p is Explosive) <= 0 && drone.RootDronePart.GetNumberOfDroneParts((DronePart p) => p is Weapon) <= 0)
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
				foreach (DronePart item2 in from p in SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItems<DronePart>()
					where p.DronePartType == EDronePartType.DefensePart
					select p)
				{
					if (drone.GetNumberOfParts(item2.UniqueId) > 0)
					{
						return false;
					}
				}
				foreach (Explosive item3 in SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItems<Explosive>())
				{
					if (drone.GetNumberOfParts(item3.UniqueId) > 0)
					{
						return false;
					}
				}
				return drone.WeaponPresets.Count <= 0;
			}
			return false;
		}

		protected override string GetStatus(bool check)
		{
			return (check ? LabelHelper.White : LabelHelper.DarkOrange) + LocalizationManager.GetTermTranslation("Preconditions/CombatArenaRequirements");
		}
	}
}
