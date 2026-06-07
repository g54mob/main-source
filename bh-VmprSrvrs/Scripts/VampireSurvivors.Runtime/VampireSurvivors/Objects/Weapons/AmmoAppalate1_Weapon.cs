using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class AmmoAppalate1_Weapon : Weapon
	{
		protected int _accumulatedActivations;

		private int _sfxIndex;

		private const WeaponType _counterWeaponType = WeaponType.EX_AMMO1_COUNTER;

		private Weapon _counterWeapon;

		public float[] _detuneValues;

		private Timer _testBeatTimer;

		protected SfxType _soundEffect;

		protected float _soundVolume;

		protected float _musicBeatInterval;

		protected float _timeUnit;

		protected float _camOffsetPerc;

		protected float _camSizePerc;

		protected virtual bool _isMirrored => false;

		public virtual bool FireInTheFacedDirection => false;

		public override void InitWeapon(CharacterController characterController, WeaponType weaponType)
		{
		}

		protected virtual void Setuppo()
		{
		}

		protected virtual float GetProjectilesAmount()
		{
			return 0f;
		}

		protected virtual float GetTimeUnit()
		{
			return 0f;
		}

		public override void Fire(bool skipTriggers = false)
		{
		}

		public void OnBeatFire(bool skipTriggers = false)
		{
		}

		public float2 RandomPos()
		{
			return default(float2);
		}

		public override void Cleanup()
		{
		}

		protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
		{
			return false;
		}

		public override void CheckArcanas()
		{
		}

		public override bool LevelUp()
		{
			return false;
		}

		protected override FiringAnimation GetFiringAnimation()
		{
			return default(FiringAnimation);
		}
	}
}
