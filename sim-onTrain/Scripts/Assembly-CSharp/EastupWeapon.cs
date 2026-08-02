using System;
using UnityEngine;

[Serializable]
public class EastupWeapon
{
	public EasyUpWeaponType weaponType;

	public CollectableItemData weaponData;

	[Range(0.1f, 3f)]
	public float reloadSpeed = 1f;

	[Range(0.1f, 3f)]
	public float equipmentSpeed = 1f;
}
