using System;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyStalkerNormal : EnemyController
	{
		private bool _hasLostTreasure;

		private bool _done;

		private float _sineF;

		private Tween _onEnterTween;

		private Sequence _onSineTween;

		private GameObject _spritte;

		private SpriteRenderer _ringSprite;

		public Action OnDefeat { get; set; }

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void Disappear()
		{
		}

		public override void Despawn()
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void GetDamaged(float value, HitVfxType showHitVfx = HitVfxType.Default, float damageKb = 1f, WeaponType damageType = WeaponType.VOID, bool hasKb = true)
		{
		}

		private void SpawnSpritte()
		{
		}

		protected override void Die()
		{
		}
	}
}
