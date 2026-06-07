using Assets.Scripts.Craft.Parts;

namespace Assets.Scripts.Flight.Combat
{
	public class WeaponPart
	{
		public string CustomName { get; set; }

		public float Distance { get; set; }

		public bool IsActive
		{
			get
			{
				if (Part.ConnectedToMainCockpit)
				{
					return Weapon.IsArmed;
				}
				return false;
			}
		}

		public PartScript Part { get; private set; }

		public IWeapon Weapon { get; private set; }

		public WeaponPart(PartScript part, IWeapon weapon, float distanceFromCenter, string customName)
		{
			Weapon = weapon;
			Part = part;
			Distance = distanceFromCenter;
			CustomName = customName;
		}
	}
}
