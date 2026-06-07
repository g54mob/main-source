using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Spite2_Projectile : Projectile
	{
		private float _bodyRadius;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _fadeInTrailTween;

		private List<TP_Spite1_Projectile> _damageBoxes;

		private PhaserSprite _animatedSprite;

		private PhaserSprite _animatedSprite2;

		private PhaserSprite _displaySprite;

		private float despawnCountdown;

		private bool isDespawning;

		private List<float> angles;

		private MultiTargetTween _scale1Tween;

		private MultiTargetTween _scale2Tween;

		private MultiTargetTween _scale3Tween;

		private float despawnTimer;

		private Vector2 direction;

		protected override void Awake()
		{
		}

		public void SetDamageBoxes(List<TP_Spite1_Projectile> boxes)
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void StartPulse()
		{
		}

		private void Pulse()
		{
		}

		private void StartDespawn()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void Despawn()
		{
		}
	}
}
