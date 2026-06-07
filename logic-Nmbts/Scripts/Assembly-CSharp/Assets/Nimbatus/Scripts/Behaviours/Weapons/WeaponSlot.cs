using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects;
using Assets.Nimbatus.Scripts.WorldObjects.Items;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.Weapons
{
	public class WeaponSlot : SerializedMonoBehaviour
	{
		public bool HasPreset;

		[ShowIf("HasPreset", true)]
		public WeaponPreset Preset;

		[HideInInspector]
		public EnemyWeapon Weapon;

		public void Init(NimbatusObject parentObject, int seed, IsShootingCheck shootingCheck)
		{
			Weapon = SerializableMonobehaviour<ItemManager, ItemManagerSaveData>.Instance.GetRandomEnemyWeapon(seed, HasPreset ? Preset : null);
			if (Weapon != null)
			{
				Weapon.gameObject.SetActive(true);
				Weapon.Init(parentObject, (float)RuntimeGlobals.GameModeSettings.EnemyDamage / 100f);
				Weapon.transform.parent = base.transform.parent;
				Weapon.transform.position = base.transform.position;
				Weapon.transform.rotation = base.transform.rotation;
				Weapon.ShootingCheck = shootingCheck;
			}
		}

		public void Release()
		{
			if (Weapon != null)
			{
				Weapon.ShootingCheck = null;
			}
		}
	}
}
