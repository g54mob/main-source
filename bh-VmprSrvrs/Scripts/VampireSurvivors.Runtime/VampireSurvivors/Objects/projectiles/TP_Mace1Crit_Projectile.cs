using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Mace1Crit_Projectile : Projectile
	{
		protected List<Projectile> _swipeAfterImageBodies;

		protected List<Vector2> _lerpRightList;

		protected List<Vector2> _lerpLeftList;

		protected List<Vector2> _lerpList;

		protected SpriteAnimation _anim;

		protected Timer _bodyDisableTimer;

		protected int _flipNum;

		protected float _lerpDist;

		protected bool _lerpActive;

		protected MultiTargetTween _lerpTween;

		[NonSerialized]
		public float lerpRatio;

		private Timer _freezeTimer;

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

		public void UpdatePositions()
		{
		}

		protected float2 MultiLerp(List<Vector2> waypoints, float ratio)
		{
			return default(float2);
		}

		protected int GetVectorIndexFromDistanceTravelled(List<Vector2> waypoints, float distanceTravelled)
		{
			return 0;
		}

		protected float MultiDistance(List<Vector2> waypoints)
		{
			return 0f;
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		public override void Despawn()
		{
		}
	}
}
