using System;
using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Unused_TP_DragonWater1_Projectile : TP_WhipCore_Projectile
	{
		[NonSerialized]
		public float LineAlpha;

		private MultiTargetTween _lineTween;

		[NonSerialized]
		public float LerpRatio;

		private MultiTargetTween _lerpTween;

		private Timer _despawnTimer;

		private List<Vector2> _waypointList;

		private int _attackCount;

		private int _attackAmount;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void startAttack(float delay)
		{
		}

		private void OnWhipStart()
		{
		}

		private void OnWhipComplete()
		{
		}

		private void StartOrbTracker()
		{
		}

		private void StepOrbTracker()
		{
		}

		private void CompleteOrbTracker()
		{
		}

		public override void InternalUpdate()
		{
		}

		private void ApplyManualNodeControl()
		{
		}

		protected override float CalculateIndexNodeDistance(int index)
		{
			return 0f;
		}

		public override void Despawn()
		{
		}
	}
}
