using System;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyDrownerNormal : EnemyController
	{
		private Stage _stage;

		private bool _hasLostTreasure;

		private bool _dismissed;

		private bool _isFresh;

		private bool _done;

		private Tween _onEnterTween;

		private Tween _onFireTimer;

		private EnemyBulletW _bullet;

		private GameObject _spritte;

		private ParticleSystem _pfxEmitter;

		private SpriteRenderer _ringSprite;

		protected float _goNutsMinute;

		protected float _distanceMultiplier;

		public Action OnDefeat { get; set; }

		protected override void FakeConstruct()
		{
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void Disappear()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void Despawn()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		protected override void Die()
		{
		}

		private void SpawnBullet()
		{
		}

		private void SpawnSpritte()
		{
		}

		protected virtual float GetSpawnY()
		{
			return 0f;
		}

		private void HandleDrownerUpdate()
		{
		}

		private float Approach(float start, float end, float shift)
		{
			return 0f;
		}

		private void Dismiss()
		{
		}

		private void GenerateParticleSystems()
		{
		}
	}
}
