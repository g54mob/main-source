using System;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_RPG2_Projectile : Projectile
	{
		private MultiTargetTween _speedTween;

		private TP_RPG1_Weapon _rpgWeapon;

		[NonSerialized]
		public float SpeedMulti;

		private Timer _durationTimer;

		private Vector2 startingVelocity;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		protected void Explode()
		{
		}

		public override void Despawn()
		{
		}
	}
}
