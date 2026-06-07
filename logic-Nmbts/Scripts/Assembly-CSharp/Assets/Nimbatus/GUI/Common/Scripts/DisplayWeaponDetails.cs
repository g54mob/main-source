using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Weapons;
using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class DisplayWeaponDetails : MonoBehaviour
	{
		public UILabel NameLabel;

		public UILabel DetailLabel;

		public WeaponDetails WeaponDetails;

		private Weapon _weapon;

		public void Init(Weapon weapon)
		{
			_weapon = weapon;
			if (_weapon != null)
			{
				NameLabel.text = _weapon.Name.GetTranslation();
				DetailLabel.text = _weapon.GetDetailedTooltip();
			}
			else
			{
				NameLabel.text = "";
				DetailLabel.text = "";
			}
			WeaponDetails.ShowWeapon(_weapon);
		}
	}
}
