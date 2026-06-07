using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Interfaces;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Weapons;

namespace VampireSurvivors.Objects.Projectiles
{
	public class FB_MultiStageProjectile : Projectile
	{
		[SerializeField]
		private SpriteAnimation _anim;

		public float2 _targetPosition;

		public float _timeSinceChangedTarget;

		private TrailRenderer _trail;

		private MultiTargetTween _trailFade;

		private float _MaxAlpha;

		private float _AlphaDiff;

		protected override void Awake()
		{
		}

		public override void InitProjectile(BulletPool pool, Weapon weapon, int index)
		{
		}

		protected override void OnHasHitAnObject(IDamageable other)
		{
		}

		public override void Despawn()
		{
		}

		private void DoExplosion(int missilesToSpawn = 5)
		{
		}
	}
}
