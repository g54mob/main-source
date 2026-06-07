using System;
using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using I2.Loc;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones.DronePreconditions
{
	[Serializable]
	public class AllPartsAvailable : DronePrecondition
	{
		public override bool Check(NimbatusDrone drone)
		{
			if (drone != null)
			{
				if (!RuntimeGlobals.GameModeSettings.HasPartUnlocking)
				{
					return true;
				}
				foreach (DronePart item in SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItems<DronePart>())
				{
					if (item.IsStackable && item.CurrentStackSize < item.TemporaryUsageCount)
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		public override bool Check(DroneData drone)
		{
			if (drone != null)
			{
				if (!RuntimeGlobals.GameModeSettings.HasPartUnlocking)
				{
					return true;
				}
				List<DronePart> items = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItems<DronePart>();
				foreach (DronePart item in items)
				{
					if (item is RootDronePart)
					{
						continue;
					}
					if (item.Unlocked && item.IsStackable)
					{
						if (drone.GetNumberOfParts(item.UniqueId) > item.CurrentStackSize)
						{
							return false;
						}
					}
					else if (!item.Unlocked && drone.GetNumberOfParts(item.UniqueId) > 0)
					{
						return false;
					}
				}
				foreach (string weapon in drone.GetAllWeapons())
				{
					if (!items.Exists((DronePart d) => d.UniqueId == weapon))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}

		protected override string GetStatus(bool check)
		{
			return (check ? LabelHelper.White : LabelHelper.DarkOrange) + LocalizationManager.GetTermTranslation("Preconditions/Only available parts");
		}
	}
}
