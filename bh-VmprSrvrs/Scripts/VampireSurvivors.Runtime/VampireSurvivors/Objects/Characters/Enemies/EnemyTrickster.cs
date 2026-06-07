using System;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyTrickster : EnemyController
	{
		private bool _hasLostTreasure;

		private bool _done;

		private float _sineF;

		private Timer _gemSummonTimer;

		private Tween _onEnterTween;

		private Tween _onSineTween;

		private GameObject _spritte;

		private SpriteRenderer _ringSprite;

		public Action OnDefeat { get; set; }

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void OnUpdate()
		{
		}

		public override void Disappear()
		{
		}

		public override void Despawn()
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

		private void SummonAll(float? duration, int moreX, float moreZ)
		{
		}
	}
}
