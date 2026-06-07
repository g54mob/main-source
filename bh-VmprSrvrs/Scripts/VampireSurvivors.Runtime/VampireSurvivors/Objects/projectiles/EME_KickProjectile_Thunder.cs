using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_KickProjectile_Thunder : Projectile
	{
		[SerializeField]
		private List<TrailRenderer> _Trails;

		[SerializeField]
		private float TrailPreTime;

		[SerializeField]
		private ParticleSystem ThunderHeadFX;

		[SerializeField]
		private ParticleSystem ThunderHeadEndFX;

		[SerializeField]
		private bool FadeAlpha;

		private Vector2 _saveVel;

		private List<int> _targetAngles;

		private int _wallBounces;

		private static readonly int Tiling;

		private EME_Kick1Weapon _trueWeapon;

		private int _bouncedTimes;

		private bool _isLeft;

		[SerializeField]
		protected int ExtraBounces;

		[SerializeField]
		protected int AngleOffset;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void SetRotationBasedOnVelocity(Transform target, Vector2 velocity)
		{
		}

		private void Bounce(Body b, bool up, bool down, bool left, bool right)
		{
		}

		private void SetupTrails(TrailRenderer _trail)
		{
		}

		private void FadeOutAndDispose()
		{
		}

		public override void Despawn()
		{
		}
	}
}
