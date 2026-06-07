using System.Collections.Generic;
using Unity.Mathematics;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons
{
	public class PhaserWeapon : Weapon
	{
		protected List<BaseBody> bodies;

		protected int _accumulatedActivations;

		private int _sfxIndex;

		public float[] _detuneValues;

		private Timer _testBeatTimer;

		protected SfxType _soundEffect;

		protected float _soundVolume;

		protected float _musicBeatInterval;

		protected float _timeUnit;

		protected float _camOffsetPerc;

		protected float _camSizePerc;

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

		public void OnBeatFireAlt(bool skipTriggers = false)
		{
		}

		public float2 RandomPos()
		{
			return default(float2);
		}

		public virtual float2 PickRandomEnemyOnScreenRect()
		{
			return default(float2);
		}

		public override void Cleanup()
		{
		}
	}
}
