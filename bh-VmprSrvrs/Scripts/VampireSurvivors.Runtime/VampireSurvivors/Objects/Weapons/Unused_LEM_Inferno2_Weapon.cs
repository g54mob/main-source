using VampireSurvivors.Data;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class Unused_LEM_Inferno2_Weapon : Weapon
	{
		private int _killsSinceLastNaneinf;

		private int _runEnemiesKilledOnLastNaneinf;

		private LEM_Inferno1_Weapon _baseWeapon;

		private bool _totalDamageCalculated;

		public int KillsRequiredForNaneinf => 0;

		public float NaneinfPercentage => 0f;

		protected override void OnStart()
		{
		}

		private void CreateDetachedBaseWeapon()
		{
		}

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateKillCount()
		{
		}

		private void ResetKillCount()
		{
		}

		private void UpdateFiringInterval()
		{
		}

		private void UpdateBaseWeapon()
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override void ResetFiringTimer()
		{
		}

		public void TriggerNaneinf()
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
