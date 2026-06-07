using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class CherryStarProjectile : Projectile
	{
		[SerializeField]
		private TrailRenderer _trail;

		protected List<float2> _positions;

		protected float _maxPositions;

		protected uint _color;

		private float2 _target;

		private List<float2> _targets;

		private bool _canUpdate;

		private Timer _bounceTimer;

		private CherryStarsWeapon _trueWeapon;

		private float _maxStars;

		private List<PhaserSprite> _stars1;

		private List<PhaserSprite> _stars2;

		private float _bouncedTimes;

		private float _sin;

		private float _cos;

		private int starIndex;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void Despawn()
		{
		}

		public void ForceDespawn()
		{
		}

		public void PickNewTarget()
		{
		}

		protected override void OnUpdate()
		{
		}

		public void MakeStar()
		{
		}

		public void CheckTimer()
		{
		}

		public void StartTimer()
		{
		}

		public void ExplodeAll()
		{
		}

		protected void clearPositions()
		{
		}

		public float Approach(float start, float end, float shift)
		{
			return 0f;
		}

		public override void SetTarget(Transform target)
		{
		}

		public override void SetNullTarget()
		{
		}
	}
}
