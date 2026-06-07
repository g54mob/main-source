using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_MechProjectile_HailstormExplosion : Projectile
	{
		[SerializeField]
		private SpriteRenderer _GroundVFX;

		private const float Radius = 60f;

		private const float VFXScale = 0.8f;

		private Tween _tween;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void LateUpdate()
		{
		}

		private void FadeOut()
		{
		}

		private void PlaySfx()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}
	}
}
