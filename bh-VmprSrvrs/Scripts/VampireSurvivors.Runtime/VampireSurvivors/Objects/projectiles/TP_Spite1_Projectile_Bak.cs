using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Spite1_Projectile_Bak : Projectile
	{
		[SerializeField]
		private TrailRenderer _LightTrail;

		[SerializeField]
		private TrailRenderer _DarkTrail;

		[SerializeField]
		private Transform _Light;

		[SerializeField]
		private Transform _Dark;

		private Vector2 _initialVel;

		private float _startingAngle;

		private float _bodyRadius;

		protected float[] _firingAngles;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _fadeInTrailTween;

		protected float _trailAlpha;

		private bool _mirrored;

		private bool _flip;

		private Sequence _windSequence;

		private float _waveAngle;

		private float _waveIncrement;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void SetFlip(bool __flip)
		{
		}

		private void StartDespawn()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		private void SetupTrail()
		{
		}
	}
}
