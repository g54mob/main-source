using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class Unused_TP_Lemuria1_Projectile : TP_WhipCore_Projectile
	{
		[NonSerialized]
		public float LineAlpha;

		private MultiTargetTween _lineTween;

		[NonSerialized]
		public float LerpRatio;

		private MultiTargetTween _lerpTween;

		private List<Vector2> _waypointList;

		private Timer _spikeTimer;

		private float2 _spikePosition;

		private int _attackCount;

		private int _attackAmount;

		protected override float WhipLength()
		{
			return 0f;
		}

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void startAttack(float delay)
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
