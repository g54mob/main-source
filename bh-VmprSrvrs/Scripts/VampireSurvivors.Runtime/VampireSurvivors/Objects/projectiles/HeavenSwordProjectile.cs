using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class HeavenSwordProjectile : Projectile
	{
		[SerializeField]
		private SpriteTrail _Trail;

		private Tween _angleTween;

		private Tween _accelTween;

		private Tween _backwardsTween;

		private Timer _cullingTimer;

		private float _acceleration;

		private Vector2 _velocity;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void Bounce(Body b, bool up, bool down, bool left, bool right)
		{
		}

		protected override void OnHasHitAnotherPlayerObject(IDamageable other)
		{
		}

		private void GoBackwards()
		{
		}

		public override void Despawn()
		{
		}
	}
}
