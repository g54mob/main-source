using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_DualSwordsProjectile_Whirlwind : Projectile
	{
		[SerializeField]
		private ParticleSystem FX;

		private const float Radius = 25f;

		private MultiTargetTween _tween;

		private MultiTargetTween _tween2;

		private bool _initialisedParticles;

		private static readonly int _AlphaMul;

		private Timer _DespawnTimer;

		private Timer _hitboxTimer;

		private bool isMoving;

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
