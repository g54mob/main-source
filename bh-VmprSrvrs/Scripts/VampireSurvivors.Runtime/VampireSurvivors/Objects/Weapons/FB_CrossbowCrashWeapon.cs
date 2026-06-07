using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Geom;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;

namespace VampireSurvivors.Objects.Weapons
{
	public class FB_CrossbowCrashWeapon : FB_BladeCrossbowWeapon
	{
		private BulletPool _crossPool;

		public float defaultWidth;

		private float _critChance;

		private Timer _evoTimer;

		private float _crossTime;

		private float _crossBaseDelay;

		private float _nextInterval;

		private float _projectileStock;

		private float _projectileTime;

		private float _projectileInterval;

		private PhaserSprite _lightSprite;

		private bool _hasSprites;

		private MultiTargetTween _tween1;

		private MultiTargetTween _tween2;

		private ParticleEmitterManager _pfxManager;

		private ParticleSystem _pfx;

		private Rectangle _pfxRecta;

		private float Intensity()
		{
			return 0f;
		}

		public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
		{
		}

		private float GetSpecialInterval()
		{
			return 0f;
		}

		public override void InternalUpdate()
		{
		}

		public void FireOneEvoProjectile(Vector2 pos, int index, float duration = 30000f)
		{
		}

		public override float SecondaryPPower()
		{
			return 0f;
		}

		private void LateUpdate()
		{
		}
	}
}
