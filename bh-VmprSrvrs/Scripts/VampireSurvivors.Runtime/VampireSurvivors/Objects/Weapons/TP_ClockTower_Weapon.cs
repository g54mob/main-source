using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_ClockTower_Weapon : Weapon
	{
		private TP_Gear_Weapon _weaponGears;

		private TP_Pendulum_Weapon _weaponPendulum;

		private TP_Elevator_Weapon _weaponElevator;

		private TP_Heads_Weapon _weaponHeads;

		private bool _totalDamageCalculated;

		private MultiTargetTween _screenShakeTween;

		protected override void Awake()
		{
		}

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public override float CalculateTotalDamage()
		{
			return 0f;
		}

		public override void Cleanup()
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
