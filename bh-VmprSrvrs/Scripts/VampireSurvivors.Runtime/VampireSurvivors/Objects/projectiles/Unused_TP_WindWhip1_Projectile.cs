using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Unused_TP_WindWhip1_Projectile : TP_WhipCore_Projectile
	{
		[NonSerialized]
		public float LineAlpha;

		private MultiTargetTween _lineTween;

		[NonSerialized]
		public float LerpRatio;

		private MultiTargetTween _lerpTween;

		[NonSerialized]
		public float Lerp2Ratio;

		private MultiTargetTween _lerp2Tween;

		private List<Vector2> _waypointList;

		private List<Vector2> _waypoint2List;

		private int _attackCount;

		private int _attackAmount;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void startAttack(int delay)
		{
		}

		protected override Projectile CreateNodeProjectile(float2 pos)
		{
			return null;
		}

		private void OnWhipStart()
		{
		}

		private void OnWhipComplete()
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
