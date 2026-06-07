using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Upgrades;
using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class WeaponDetails : MonoBehaviour
	{
		public UIGrid SlotsGrid;

		public GameObject[] UpgradeSlots;

		public ItemSlot Prefab;

		private bool _doReposition;

		public void ShowWeapon(Weapon weapon, bool clickable = true)
		{
			SlotsGrid.transform.DestroyAllChildren();
			if (weapon == null)
			{
				SlotsGrid.enabled = false;
				return;
			}
			List<NimbatusItem> modules = weapon.GetModules();
			SlotsGrid.enabled = true;
			if (UpgradeSlots != null)
			{
				for (int i = 0; i < UpgradeSlots.Length; i++)
				{
					UpgradeSlots[i].SetActive(i < weapon.UpgradeSlots && i >= modules.OfType<WeaponAttributeUpgrade>().Count());
				}
			}
			List<NimbatusItem> list = new List<NimbatusItem>();
			list.Add(weapon.Emitter);
			list.Add(weapon.Ammunition);
			list.AddRange(modules);
			foreach (NimbatusItem item in list)
			{
				ItemSlot itemSlot = Object.Instantiate(Prefab);
				itemSlot.Item = item;
				if (!clickable)
				{
					itemSlot.GetComponent<Collider>().enabled = false;
				}
				itemSlot.DisableScaling = true;
				itemSlot.Init();
				itemSlot.AllowDragAndDrop = false;
				itemSlot.transform.position = SlotsGrid.transform.position;
				itemSlot.transform.parent = SlotsGrid.transform;
				itemSlot.transform.localScale = Prefab.transform.localScale;
			}
			_doReposition = true;
			SlotsGrid.Reposition();
		}

		public void ShowWeaponPreset(WeaponPreset weapon, bool clickable = true)
		{
			SlotsGrid.transform.DestroyAllChildren();
			if (weapon == null)
			{
				SlotsGrid.enabled = false;
				return;
			}
			SlotsGrid.enabled = true;
			if (UpgradeSlots != null)
			{
				for (int i = 0; i < UpgradeSlots.Length; i++)
				{
					UpgradeSlots[i].SetActive(i < weapon.UpgradeSlots);
				}
			}
			List<NimbatusItem> list = new List<NimbatusItem>();
			weapon.Emitter.Ammunition = weapon.Ammunition;
			list.Add(weapon.Emitter);
			list.Add(weapon.Ammunition);
			list.AddRange(weapon.Emitter.GetModules());
			list.AddRange(weapon.Upgrades);
			foreach (NimbatusItem item in list)
			{
				ItemSlot itemSlot = Object.Instantiate(Prefab);
				itemSlot.Item = item;
				if (!clickable)
				{
					itemSlot.GetComponent<Collider>().enabled = false;
				}
				itemSlot.DisableScaling = true;
				itemSlot.Init();
				itemSlot.AllowDragAndDrop = false;
				itemSlot.transform.position = SlotsGrid.transform.position;
				itemSlot.transform.parent = SlotsGrid.transform;
				itemSlot.transform.localScale = Prefab.transform.localScale;
			}
			_doReposition = true;
			SlotsGrid.Reposition();
		}

		public void Update()
		{
			if (_doReposition)
			{
				SlotsGrid.Reposition();
				_doReposition = false;
			}
		}
	}
}
