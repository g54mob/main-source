using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.NumberTypes;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class BloodPlanetProjectile : Projectile
	{
		[SerializeField]
		private SpriteAnimation _SpriteAnimation;

		public EggFloat _Radius;

		private readonly List<float> _angles;

		private readonly List<string> _animNames;

		private float2 _ground;

		private float _myRotationAngle;

		private float _angleUnit;

		private float _angleRotUnit;

		public float _RadiusMulY;

		private float _radiusMulX;

		private float _amount;

		private BloodAstronomiaWeapon _trueWeapon;

		private MultiTargetTween _scaleTween;

		private MultiTargetTween _alphaTween;

		private Timer _expireTimer;

		private readonly List<float> _durations;

		private readonly List<float> _bodyRadii;

		private Timer _activationTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void OverrideWeaponData(Weapon weapon)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		public override bool CanExplode()
		{
			return false;
		}

		public override void Explode(Vector2? pos = null)
		{
		}

		private void FadeOut()
		{
		}
	}
}
