using System;
using System.Collections.Generic;
using NSEipix.Base;
using UnityEngine;

[Serializable]
public class SiegeWeaponSettings : Model
{
	[Serializable]
	private class SiegeWeaponSettingItem
	{
		public string weaponBlueprintId;

		public string ammoResourceId;

		public int ammoCount;
	}

	[SerializeField]
	private List<SiegeWeaponSettingItem> settings;

	private Dictionary<string, SiegeWeaponSettingItem> weaponIdToSettings;

	public override string GetID()
	{
		return "SiegeWeaponSettings";
	}

	public (string resourceId, int count) GetAmmoInfo(string weaponBlueprintId)
	{
		if (weaponIdToSettings == null)
		{
			weaponIdToSettings = new Dictionary<string, SiegeWeaponSettingItem>();
			foreach (SiegeWeaponSettingItem setting in settings)
			{
				weaponIdToSettings[setting.weaponBlueprintId] = setting;
			}
		}
		if (!weaponIdToSettings.TryGetValue(weaponBlueprintId, out var value))
		{
			throw new Exception("Siege weapon ammo info not found for weapon blueprint '" + weaponBlueprintId + "'");
		}
		return (resourceId: value.ammoResourceId, count: value.ammoCount);
	}
}
