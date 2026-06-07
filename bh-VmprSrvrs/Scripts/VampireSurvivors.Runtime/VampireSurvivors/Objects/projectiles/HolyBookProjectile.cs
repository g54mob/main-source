using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class HolyBookProjectile : Projectile
	{
		private ParticleSystem _pfx;

		private Timer _hitboxTimer;

		private Timer _expireTimer;

		private Tween _scaleTween;

		private Tween _radiusTweenX;

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

		private void Expire()
		{
		}

		private void GenerateParticleSystem()
		{
		}
	}
}
