using System;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_SacredBeast1_Bird_Projectile : Projectile
	{
		private Vector3 _movement;

		private float _flipSwitch;

		[NonSerialized]
		public float orbitRadius;

		[NonSerialized]
		public float orbitAngle;

		private MultiTargetTween _speedTween;

		private MultiTargetTween _scaleTween;

		private float _spinDuration;

		private bool _rotatingState;

		private Vector3 _offset;

		private SpriteAnimation _anim;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void shootDiscus()
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}
	}
}
