using System;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts
{
	public class DuplicateSelectedWeapon : MonoBehaviour
	{
		public WeaponPresetList List;

		public void Start()
		{
			if (RuntimeGlobals.GameModeSettings.HasPartUnlocking)
			{
				base.gameObject.SetActive(false);
			}
		}

		public void OnClick()
		{
			if (List.SelectedItem != null)
			{
				WeaponPreset weaponPreset = List.SelectedItem.Clone();
				weaponPreset.UniqueID = Guid.NewGuid().ToString();
				SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.WeaponPresets.Add(weaponPreset);
				List.FillUp();
				List.SelectedItem = weaponPreset;
			}
		}
	}
}
