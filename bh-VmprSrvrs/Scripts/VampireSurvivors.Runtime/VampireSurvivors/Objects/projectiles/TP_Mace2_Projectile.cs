using System.Collections.Generic;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Mace2_Projectile : Projectile
	{
		[SerializeField]
		private TrailRenderer _afterImageTrail;

		private float _angleTime;

		private Timer _swingTimer;

		private MultiTargetTween _alphaTween;

		private float _multiplier;

		private List<List<Projectile>> _swipeBodies;

		private float2 _playerOffset;

		private bool _isflipped;

		private int _flipNum;

		private float _extraDistTotal;

		private float _extraDistSpacing;

		protected bool _isCrit;

		private bool _isMoving;

		protected TP_Mace2_Weapon _trueWeapon;

		private Tween _despawnTimer;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public void SetCritical(bool isCritical)
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
