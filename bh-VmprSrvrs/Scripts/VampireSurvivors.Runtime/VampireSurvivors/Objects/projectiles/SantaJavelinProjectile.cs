using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class SantaJavelinProjectile : Projectile
	{
		[SerializeField]
		private SpriteRenderer _JavelinSprite;

		[SerializeField]
		private SpriteRenderer _GroundFx;

		[SerializeField]
		private SpriteTrail _Trail;

		protected SantaJavelinWeapon _trueWeapon;

		private Camera _camera;

		private Tween _positionTween;

		private Timer _expireTimer;

		private ParticleSystem _explosionPfx1;

		private ParticleSystem _explosionPfx2;

		private const float Radius = 32f;

		private const float ExploRadius = 8f;

		private bool _isBroken;

		private bool _isDespawning;

		private MultiTargetTween _tween1;

		private MultiTargetTween _tween2;

		private MultiTargetTween _tween3;

		private MultiTargetTween _tween4;

		private float fullSalvoDuration;

		private MultiTargetTween _tween5;

		private MultiTargetTween _tween6;

		private float _javelinScale;

		private Vector3 _trailScale;

		protected virtual bool MirrorMotion => false;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void SetNullTarget()
		{
		}

		public void SetTargetVec(Vector3 target)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void Break()
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}

		private void GetComponents()
		{
		}

		private void GenerateParticleSystems()
		{
		}
	}
}
