using System.Collections.Generic;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Framework.TimerSystem;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class EME_MagicProjectile_HeavensThunder : Projectile
	{
		[SerializeField]
		protected ParticleSystem _particleSystem;

		[SerializeField]
		protected ParticleEventCall _particleEventCall;

		private MultiTargetTween _despawnTween;

		private MultiTargetTween _alphaTween;

		private Timer _hitboxTimer;

		private MultiTargetTween _moveTween;

		private Transform target;

		private List<SfxType> _sfxList;

		private static int _sfxIndex;

		private bool _follow;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		public override void InternalUpdate()
		{
		}

		public override void Despawn()
		{
		}

		private void DespawnAfterParticlesToFinish()
		{
		}
	}
}
