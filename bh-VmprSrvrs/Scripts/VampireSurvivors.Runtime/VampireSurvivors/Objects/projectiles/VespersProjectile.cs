using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class VespersProjectile : Projectile
	{
		[SerializeField]
		private SpriteAnimation _animation;

		private ParticleSystem _pfx;

		protected MaterialPropertyBlock _propBlock;

		private Timer _hitboxTimer;

		private Timer _expireTimer;

		private MultiTargetTween _scaleTween;

		private float[] _requiemRandomOffsets;

		private int _requiemRandomIndex;

		private float _deltaTime;

		private const float Percentage = 0.0625f;

		private const float Radius = 0.5f;

		private const float SpeedModifier = 35f;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		protected virtual void Expire()
		{
		}

		private void GenerateParticleSystem()
		{
		}
	}
}
