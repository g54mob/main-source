using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_DualSwordsProjectile_Torrent : Projectile
	{
		[SerializeField]
		private ParticleSystem FX;

		private const float Radius = 25f;

		private float _spinRadiusX;

		private float _spinRadiusY;

		private float _spinSpeed;

		private MultiTargetTween _tween;

		private MultiTargetTween _tween2;

		private EME_DualSwordsWeapon _trueWeapon;

		private bool _initialisedParticles;

		private static readonly int _ScrollSpeedX;

		private static readonly int _ScrollSpeedY;

		private static readonly int _AlphaMul;

		private Timer _DespawnTimer;

		private Timer _hitboxTimer;

		private bool isMoving;

		private float _elapsedSpinTime;

		private float2 _originalPosition;

		public float SpinSpeed => 0f;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void InitializeSelf()
		{
		}

		private void OnRecycleSelf()
		{
		}

		private void StartDespawn()
		{
		}

		public override void Despawn()
		{
		}

		public override void InternalUpdate()
		{
		}
	}
}
