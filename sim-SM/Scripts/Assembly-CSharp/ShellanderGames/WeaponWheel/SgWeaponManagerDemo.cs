using TMPro;
using UnityEngine;

namespace ShellanderGames.WeaponWheel
{
	public class SgWeaponManagerDemo : MonoBehaviour
	{
		public SgDemoWeapon[] weapons;

		public SgWeaponWheel weaponWheel;

		public TextMeshProUGUI textComponent;

		private SgDemoWeapon currentWeapon;

		private void Start()
		{
		}

		public void OnSliceSelected(SgSliceController slice)
		{
		}

		private void UpdateUi()
		{
		}

		private SgDemoWeapon FindWeapon(string name)
		{
			return null;
		}

		private void Update()
		{
		}

		private void Fire()
		{
		}
	}
}
