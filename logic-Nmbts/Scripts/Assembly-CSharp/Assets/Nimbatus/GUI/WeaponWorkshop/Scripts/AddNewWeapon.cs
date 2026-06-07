using System;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.GUI.WeaponWorkshop.Scripts
{
	public class AddNewWeapon : MonoBehaviour
	{
		public WeaponPresetList List;

		public void Start()
		{
			if (RuntimeGlobals.GameModeSettings.HasPartUnlocking)
			{
				base.gameObject.SetActive(false);
			}
		}

		public void OnTooltip(bool show)
		{
			NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("DroneWorkshop/CreateNewWeapon"));
			if (!show)
			{
				NimbatusToolTip.Show(null);
			}
		}

		public void OnClick()
		{
			WeaponPreset weaponPreset = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.DefaultWeapon.Clone();
			weaponPreset.UniqueID = Guid.NewGuid().ToString();
			SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.WeaponPresets.Add(weaponPreset);
			List.FillUp();
			List.SelectedItem = weaponPreset;
		}
	}
}
