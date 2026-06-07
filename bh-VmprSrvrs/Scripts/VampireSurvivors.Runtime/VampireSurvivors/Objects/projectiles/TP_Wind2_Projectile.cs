using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Wind2_Projectile : Projectile
	{
		[SerializeField]
		private TrailRenderer _Trail;

		private float _startingAngle;

		private float _bodyRadius;

		private float _spriteSize;

		protected float[] _firingAngles;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _fadeInTrailTween;

		protected float _trailAlpha;

		private bool _mirrored;

		private bool _flip;

		private Sequence _windSequence;

		private bool _isLight;

		private float _waveAngle;

		private float _waveIncrement;

		private Vector3 _startingPosition;

		private Vector3 _startingOffset;

		private float _height;

		private Tween _heightTween;

		private float _spriteRotateAngle;

		private float _spriteRotateSpeed;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void SetFlip(bool __flip, bool __horizontalMirror)
		{
		}

		private void StartDespawn()
		{
		}

		public override void InternalUpdate()
		{
		}

		private float UpdateTrailAlpha()
		{
			return 0f;
		}

		public override void Despawn()
		{
		}

		private void SetupTrail()
		{
		}
	}
}
