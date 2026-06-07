using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.Particles;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_BloodProjectile : Projectile
	{
		[SerializeField]
		private List<Color> _tints;

		private List<BlendMode> _blendModes;

		private MultiTargetTween _alphaTween;

		private MultiTargetTween _scaleTween;

		private ParticleSystem _damageVfx;

		private ParticleEmitterManager _particlesManager;

		private GravityWell _well;

		private Timer bloodTimer;

		private Timer expireTimer;

		private PhaserSprite _displaySprite;

		private EnemyController _myTarget;

		private bool _targetFound;

		private Vector2 targetPosition;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void LateUpdate()
		{
		}

		public void Activate()
		{
		}

		public virtual void OnTargetHit()
		{
		}

		public override void Despawn()
		{
		}

		private void FadeOut()
		{
		}
	}
}
