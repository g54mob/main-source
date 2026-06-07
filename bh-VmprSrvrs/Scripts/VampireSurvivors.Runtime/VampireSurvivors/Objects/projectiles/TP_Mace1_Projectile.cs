using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Mace1_Projectile : Projectile
	{
		[SerializeField]
		private TrailRenderer _afterImageTrail;

		private float _angleTime;

		private Timer _swingTimer;

		private MultiTargetTween _alphaTween;

		private float _multiplier;

		private List<List<Projectile>> _swipeBodies;

		private float2 _playerOffset;

		private int _flipNum;

		private float _extraDistTotal;

		private float _extraDistSpacing;

		private bool _isMoving;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void updateAttackAngle(float attackAngle)
		{
		}

		private void LandHit()
		{
		}

		public override void Despawn()
		{
		}

		private void SetupTrails(TrailRenderer _trail)
		{
		}
	}
}
