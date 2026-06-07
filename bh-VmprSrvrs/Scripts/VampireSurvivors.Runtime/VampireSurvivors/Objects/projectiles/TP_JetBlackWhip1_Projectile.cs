using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_JetBlackWhip1_Projectile : TP_WhipCore_Projectile
	{
		[NonSerialized]
		public float LineAlpha;

		private MultiTargetTween _lineTween;

		[NonSerialized]
		public float LerpRatio;

		private MultiTargetTween _lerpTween;

		private List<Vector2> _waypointListDefault;

		private List<Vector2> _waypointList;

		private bool _targetEnemy;

		private int _attackCount;

		private int _attackAmount;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override Projectile CreateNodeProjectile(float2 pos)
		{
			return null;
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
