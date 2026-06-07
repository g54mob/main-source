using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneSelection.Scripts
{
	public class DisplayPartRequirements : MonoBehaviour
	{
		public UILabel Label;

		public void Init(DroneData drone)
		{
			if (!SaveManager.LoadedSave.Settings.HasPartUnlocking)
			{
				base.gameObject.SetActive(false);
				return;
			}
			bool flag = true;
			foreach (DronePart item in SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItems<DronePart>())
			{
				if (item is RootDronePart)
				{
					continue;
				}
				if (item.Unlocked && item.IsStackable)
				{
					if (drone.GetNumberOfParts(item.UniqueId) > item.CurrentStackSize)
					{
						flag = false;
						break;
					}
				}
				else if (!item.Unlocked && drone.GetNumberOfParts(item.UniqueId) > 0)
				{
					flag = false;
					break;
				}
			}
			Label.text = "Part requirements fullfilled: " + flag;
		}
	}
}
