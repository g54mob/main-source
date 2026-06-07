using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Heads_Projectile : Projectile
	{
		private float _radius;

		private PhaserSprite _animatedSprite;

		private Tween _radiusTween;

		private Timer _expireTimer;

		private Timer _hitBoxTimer;

		private MultiTargetTween _scaleTween;

		private bool _isDespawning;

		private float hDirection;

		private bool canTurnAround;

		private Timer turnAroundTimer;

		private Transform _cachedCameraTransform;

		private float angleTime;

		private Vector3 _center;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}

		private void TurnAround()
		{
		}

		private void LateUpdate()
		{
		}
	}
}
