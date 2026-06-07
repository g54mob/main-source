using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class ShowWeaponPreview : MonoBehaviour
	{
		public PreviewWeapon Weapon;

		public void ShowWeapon(Weapon weapon)
		{
			ShowWeaponPreset(weapon.Preset);
		}

		public void ShowWeaponPreset(WeaponPreset weapon)
		{
			if (Weapon != null)
			{
				Weapon.ApplyWeaponPreset(weapon);
				Weapon.Init(1f);
			}
		}
	}
}
