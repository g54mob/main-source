using System;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class TP_Lemuria1Spike_Projectile : Projectile
	{
		public LineRenderer _lineRenderer;

		protected MultiTargetTween _alphaTween;

		[NonSerialized]
		public float LineAlpha;

		protected MultiTargetTween _lineTween;

		[NonSerialized]
		public float LineRatio;

		private float _spikeHeight;

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		private void OnLineComplete()
		{
		}

		public override void Despawn()
		{
		}
	}
}
