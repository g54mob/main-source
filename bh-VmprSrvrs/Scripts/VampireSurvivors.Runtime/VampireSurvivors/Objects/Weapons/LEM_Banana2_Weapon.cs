using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons
{
	public class LEM_Banana2_Weapon : LEM_Banana1_Weapon
	{
		private const float BonusCritChanceMultiplier = 2f;

		private const float HiddenWeaponFireChance = 0.001f;

		private LEM_Banana2_Hidden_Weapon _hiddenWeapon;

		private bool _totalDamageCalculated;

		public override bool DespawnOnExplode => false;

		protected override void OnStart()
		{
		}

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		private void AddCritChanceBonusToWeapon(GameplaySignals.WeaponAddedToCharacterSignal sig)
		{
		}

		private void AddCritChanceBonusToActiveWeapons()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		private void CheckForFiringHiddenWeapon()
		{
		}

		private void FireHiddenWeapon()
		{
		}

		public override float CalculateTotalDamage()
		{
			return 0f;
		}

		public override void Cleanup()
		{
		}
	}
}
