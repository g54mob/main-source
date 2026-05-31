using System;
using TMPro;

namespace ShellanderGames.WeaponWheel
{
	[Serializable]
	public class SgDemoWeapon
	{
		public string name;

		public int maxAmmo;

		public int ammoLeft;

		public TextMeshProUGUI ammoTextComponent;
	}
}
