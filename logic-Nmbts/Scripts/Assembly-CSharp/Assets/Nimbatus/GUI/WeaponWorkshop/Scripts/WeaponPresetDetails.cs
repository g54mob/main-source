using System.Collections.Generic;
using Assets.Nimbatus.GUI.WeaponWorkshop.Scripts.Attributes;
using Assets.Nimbatus.GUI.WeaponWorkshop.Scripts.TechTree;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Ammunitions;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons.Emitters;
using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts
{
	public class WeaponPresetDetails : MonoBehaviour
	{
		public WeaponPresetList List;

		public TechTreeDisplay TechTree;

		public UIInput NameInput;

		public PreviewWeapon PreviewWeapon;

		public GameObject PreviewDisplay;

		public TweenPosition WeaponDetailsTween;

		public CustomChooser EmitterChooser;

		public CustomChooser AmmunitionChooser;

		public ItemSlot AmmunitionSlot;

		public UILabel AmmunitionLabel;

		public List<WeaponUpgradeSlot> UpgradeSlots;

		public List<GameObject> DisableWithPartUnlocking = new List<GameObject>();

		public WeaponAttributeList AttributeList;

		private WeaponPreset _selectedItem;

		public void UpdateWeaponPreview()
		{
			if (RuntimeGlobals.GameModeSettings.HasPartUnlocking)
			{
				DisableWithPartUnlocking.ForEach(delegate(GameObject g)
				{
					g.SetActive(false);
				});
			}
			if (_selectedItem == null)
			{
				return;
			}
			if (_selectedItem.Ammunition != null)
			{
				AmmunitionSlot.Item = _selectedItem.Ammunition;
				AmmunitionSlot.Init();
				AmmunitionLabel.text = _selectedItem.Ammunition.CustomToolTip.GetTranslation();
			}
			PreviewWeapon.ApplyWeaponPreset(_selectedItem);
			for (int num = 0; num < UpgradeSlots.Count; num++)
			{
				if (num >= _selectedItem.UpgradeSlots)
				{
					UpgradeSlots[num].gameObject.SetActive(false);
					continue;
				}
				UpgradeSlots[num].gameObject.SetActive(true);
				UpgradeSlots[num].Init(this, _selectedItem, num);
			}
			PreviewWeapon.Init(1f);
			TechTree.UpdateCompatibility(_selectedItem);
			if (_selectedItem.Emitter == null)
			{
				AttributeList.Fill(null);
			}
			else
			{
				AttributeList.Fill(PreviewWeapon.Emitter);
			}
		}

		public void Update()
		{
			if (List.SelectedItem == null)
			{
				_selectedItem = null;
				WeaponDetailsTween.Play(false);
				TechTree.UpdateCompatibility(null);
				return;
			}
			WeaponDetailsTween.Play(true);
			if (_selectedItem != List.SelectedItem)
			{
				NameInput.value = List.SelectedItem.Name;
				_selectedItem = List.SelectedItem;
				WeaponUpgradeSlot.SelectedSlot = null;
				List<Emitter> items = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItems<Emitter>();
				List<Ammunition> items2 = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetItems<Ammunition>();
				EmitterChooser.Init(items, List.SelectedItem.Emitter);
				AmmunitionChooser.Init(items2, List.SelectedItem.Ammunition);
				UpdateWeaponPreview();
			}
			if (_selectedItem.Emitter != null && _selectedItem.Ammunition != null)
			{
				if (PreviewWeapon.Emitter == null || PreviewWeapon.Ammunition == null || PreviewWeapon.Emitter.UniqueId != _selectedItem.Emitter.UniqueId || PreviewWeapon.Ammunition.UniqueId != _selectedItem.Ammunition.UniqueId)
				{
					UpdateWeaponPreview();
				}
				PreviewDisplay.SetActive(true);
			}
			else
			{
				PreviewDisplay.SetActive(false);
			}
			_selectedItem.Name = NameInput.value;
			_selectedItem.Emitter = (Emitter)EmitterChooser.SelectedOption;
			_selectedItem.Ammunition = (Ammunition)AmmunitionChooser.SelectedOption;
		}
	}
}
