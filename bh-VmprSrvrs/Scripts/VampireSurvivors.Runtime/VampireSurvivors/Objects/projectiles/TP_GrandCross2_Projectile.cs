using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_GrandCross2_Projectile : Projectile
	{
		[SerializeField]
		private MeshRenderer _CrossMesh;

		[SerializeField]
		private SpriteRenderer _TrailSprite;

		[SerializeField]
		private SpriteTrail _Trail;

		[SerializeField]
		private SpriteTrail _GoldenTrail;

		private const float Radius = 24f;

		private const float MaxAcceleration = 2f;

		private TP_GrandCross2_Weapon _trueWeapon;

		private Vector2 _velocity;

		private float _acceleration;

		private bool _isGoingBackwards;

		private bool _hasOverlappedBeam;

		private bool _canDespawn;

		private bool _isDespawning;

		private Tween _angleTween;

		private Tween _accelTween;

		private Tween _backwardsTween;

		private Timer _cullingTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void InitPosition()
		{
		}

		private void InitVelocity()
		{
		}

		private void InitDepth()
		{
		}

		private void InitTrails()
		{
		}

		private void InitBouncing()
		{
		}

		private void DoTweens()
		{
		}

		private void GoBackwards()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void UpdateVelocity()
		{
		}

		private void CheckForBeamOverlap()
		{
		}

		private void SetTrailAlpha(SpriteTrail trail, float alpha)
		{
		}

		private void PlaySfx()
		{
		}

		private void Bounce(Body b, bool up, bool down, bool left, bool right)
		{
		}

		protected override void OnHasHitAnotherPlayerObject(IDamageable other)
		{
		}

		private void CheckForDespawn()
		{
		}

		public override void Despawn()
		{
		}
	}
}
