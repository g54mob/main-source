using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Signals;

namespace VampireSurvivors.Objects.Weapons
{
	public class TP_SacredBeasts1_Weapon : Weapon
	{
		private BulletPool _standardPool;

		private BulletPool _retaliationPool;

		private bool _canRetaliate;

		private bool _canOverheal;

		private Timer _retaliationTimer;

		private Timer _overHealTimer;

		private float OverhealTriggerValue;

		private float OverhealDelay;

		private float RetaliationDelay;

		private Timer _invulTimer;

		private bool _canInvul;

		private float invulDelay;

		private PhaserSprite _guardianSprite1;

		private PhaserSprite _guardianSprite2;

		private PhaserSprite _guardianSprite3;

		private PhaserSprite _guardianSprite4;

		private MultiTargetTween _guardianTween1;

		private MultiTargetTween _guardianTween2;

		private MultiTargetTween _guardianTween3;

		private MultiTargetTween _guardianTween4;

		private MultiTargetTween _guardianTween5;

		public int SlotNumber;

		protected virtual bool hasInvulnerabilityBonus => false;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		private void OnHpRecoveryCallback(float value, float rawValue)
		{
		}

		private void PlayInvulAnimation(float duration)
		{
		}

		private void OnPlayerHit()
		{
		}

		public override void Cleanup()
		{
		}

		protected override void OnStart()
		{
		}

		private void OnPlayerHitDamage(GameplaySignals.CharacterReceivedDamageSignal signal)
		{
		}

		private void OnPlayerHitShield(GameplaySignals.CharacterLostShieldSignal signal)
		{
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void FireStandardProjectiles()
		{
		}

		public void FireProjectiles(BulletPool pool)
		{
		}

		public override void SetVisible(bool visible)
		{
		}
	}
}
