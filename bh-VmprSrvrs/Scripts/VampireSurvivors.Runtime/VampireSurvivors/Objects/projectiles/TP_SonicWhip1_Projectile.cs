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
	public class TP_SonicWhip1_Projectile : TP_WhipCore_Projectile
	{
		[NonSerialized]
		public float LineAlpha;

		private MultiTargetTween _lineTween;

		[NonSerialized]
		public float LerpRatio;

		[NonSerialized]
		public float WaveRatio;

		private MultiTargetTween _lerpTween;

		private Timer _durationTimer;

		private int _attackCount;

		private int _attackAmount;

		private float _wavePixelHeight;

		public List<Gradient> _gradients;

		public override int Nodes => 0;

		protected override void Awake()
		{
		}

		protected override float WhipLength()
		{
			return 0f;
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		private void PlaySFX()
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

		private void UpdateWhipLineRenderer()
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
