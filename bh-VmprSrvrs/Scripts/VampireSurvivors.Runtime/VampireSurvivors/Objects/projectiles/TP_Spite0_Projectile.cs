using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Spite0_Projectile : Projectile
	{
		[SerializeField]
		private bool ShowWhiteTrail;

		private TrailRenderer _ShotTrail;

		private float _bodyRadius;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _fadeInTrailTween;

		private List<TP_Spite1_Projectile> _damageBoxes;

		protected override void Awake()
		{
		}

		public void SetDamageBoxes(List<TP_Spite1_Projectile> boxes)
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
	}
}
