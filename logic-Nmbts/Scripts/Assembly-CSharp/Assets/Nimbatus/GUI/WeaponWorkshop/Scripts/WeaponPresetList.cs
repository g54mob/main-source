using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts
{
	public class WeaponPresetList : MonoBehaviour
	{
		public WeaponListItem ItemPrefab;

		public UIGrid ItemGrid;

		public UIScrollView ItemPanel;

		[NonSerialized]
		[HideInInspector]
		public WeaponPreset SelectedItem;

		public void Start()
		{
			FillUp();
		}

		public void FillUp()
		{
			List<WeaponPreset> weaponPresets = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.WeaponPresets;
			ItemGrid.enabled = true;
			(from Transform child in ItemGrid.transform
				select child.gameObject).ToList().ForEach(UnityEngine.Object.DestroyImmediate);
			foreach (WeaponPreset item in weaponPresets)
			{
				WeaponListItem weaponListItem = UnityEngine.Object.Instantiate(ItemPrefab);
				weaponListItem.Init(this, item, ItemPanel);
				weaponListItem.transform.position = ItemGrid.transform.position;
				weaponListItem.transform.parent = ItemGrid.transform;
				weaponListItem.transform.localScale = ItemPrefab.transform.localScale;
			}
			ItemGrid.Reposition();
			ItemPanel.UpdateScrollbars(true);
		}
	}
}
