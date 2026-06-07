using VampireSurvivors.Data;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects
{
	public class CharacterWeaponsManager : EquipmentManager
	{
		private int _maxActiveCount;

		private int _maxHiddenCount;

		public bool ShouldSkipWeaponUpdates => false;

		public void SetWeaponsActive(bool active)
		{
		}

		public Weapon SetWeaponActive(bool active, Weapon effectedWeapon = null)
		{
			return null;
		}

		public void SetMaxWeaponCount(int maxActives, int maxHidden)
		{
		}

		private void SetWeaponVisible(Weapon weapon, bool visible)
		{
		}

		protected override void OnUpdate()
		{
		}

		public Weapon GetWeaponByType(WeaponType weaponType, bool searchHidden = false)
		{
			return null;
		}

		public Weapon GetWeaponByTypeFromAnyCollection(WeaponType weaponType)
		{
			return null;
		}
	}
}
