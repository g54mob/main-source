using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Slash1Projectile : Projectile
	{
		[SerializeField]
		private SpriteTrail _Trail;

		private Tween _angleTween;

		private Tween _accelTween;

		private Tween _backwardsTween;

		private Timer _cullingTimer;

		private const float AccelForward = 2f;

		private const float AccelBack = -4f;

		private float _acceleration;

		private Vector2 _velocity;

		private Timer _despawnTimer;

		private bool _isGoingBack;

		private float _accumulatedTime;

		private MultiTargetTween _despawnTween;

		private bool _isDespawning;

		private float2 offset;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void GoBackwards()
		{
		}

		public void StartDespawn()
		{
		}

		public void OwnerHit()
		{
		}

		public override void Despawn()
		{
		}
	}
}
