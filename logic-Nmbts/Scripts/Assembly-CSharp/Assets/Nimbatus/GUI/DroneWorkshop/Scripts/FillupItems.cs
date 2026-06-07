using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Persistence.SaveSystem;
using Assets.Nimbatus.Scripts.WorldObjects.DronePartTemplates;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.GUI.DroneWorkshop.Scripts
{
	public class FillupItems : MonoBehaviour
	{
		public static List<ItemSlot> FillUp(UIScrollView panel, UIGrid grid, GameObject itemPrefab, bool dragAndDrop, Func<DronePart, bool> checkFunction = null)
		{
			List<DronePart> list = new List<DronePart>();
			list.AddRange(SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetUnlockedDroneParts(EDronePartType.BasicPart));
			list.AddRange(SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetUnlockedDroneParts(EDronePartType.Thruster));
			list.AddRange(SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetUnlockedDroneParts(EDronePartType.Battery));
			list.AddRange(SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetUnlockedDroneParts(EDronePartType.FuelTank));
			list.AddRange(SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetUnlockedDroneParts(EDronePartType.DefensePart));
			list.AddRange(SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetUnlockedDroneParts(EDronePartType.MechanicalPart));
			List<DronePart> list2 = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetUnlockedDroneParts(EDronePartType.Weapon);
			if (SaveManager.LoadedSave.Settings.HasPartUnlocking)
			{
				list2 = list2.Where((DronePart w) => w.UnlimitedStackSize || w.CurrentStackSize != 0 || w.CurrentStackSize - w.TemporaryUsageCount != 0).ToList();
			}
			list.AddRange(list2);
			list.AddRange(SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetUnlockedDroneParts(EDronePartType.HarvestingPart));
			list.AddRange(SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetUnlockedDroneParts(EDronePartType.SensorPart));
			list.AddRange(SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetUnlockedDroneParts(EDronePartType.LogicPart));
			if (checkFunction != null)
			{
				list = list.Where(checkFunction).ToList();
			}
			grid.enabled = true;
			(from Transform child in grid.transform
				select child.gameObject).ToList().ForEach(UnityEngine.Object.Destroy);
			List<ItemSlot> list3 = new List<ItemSlot>();
			foreach (DronePart item in list)
			{
				GameObject obj = UnityEngine.Object.Instantiate(itemPrefab);
				ItemSlot component = obj.GetComponent<ItemSlot>();
				component.Item = item;
				component.AllowDragAndDrop = dragAndDrop;
				component.Init(panel);
				list3.Add(component);
				obj.transform.position = grid.transform.position;
				obj.transform.parent = grid.transform;
				obj.transform.localScale = itemPrefab.transform.localScale;
			}
			grid.Reposition();
			panel.ResetPosition();
			panel.UpdateScrollbars(true);
			return list3;
		}

		public static List<DronePartTemplateItem> FillUpTemplates(UIScrollView panel, UIGrid grid, GameObject itemPrefab)
		{
			List<DronePartTemplateData> templates = BaseSingleton<DronePartTemplateManager>.Instance.Templates;
			grid.enabled = true;
			(from Transform child in grid.transform
				select child.gameObject).ToList().ForEach(UnityEngine.Object.Destroy);
			List<DronePartTemplateItem> list = new List<DronePartTemplateItem>();
			foreach (DronePartTemplateData item in templates)
			{
				GameObject obj = UnityEngine.Object.Instantiate(itemPrefab);
				DronePartTemplateItem component = obj.GetComponent<DronePartTemplateItem>();
				component.Item = item;
				component.Init(panel, grid);
				list.Add(component);
				obj.transform.position = grid.transform.position;
				obj.transform.parent = grid.transform;
				obj.transform.localScale = itemPrefab.transform.localScale;
			}
			grid.Reposition();
			panel.ResetPosition();
			panel.UpdateScrollbars(true);
			return list;
		}
	}
}
