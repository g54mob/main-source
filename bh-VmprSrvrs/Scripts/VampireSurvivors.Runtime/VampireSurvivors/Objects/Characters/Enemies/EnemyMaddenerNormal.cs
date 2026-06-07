using System;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyMaddenerNormal : EnemyAlias
	{
		[SerializeField]
		private GameObject _SingleWarningPrefab;

		private float _spinRadius;

		private Tween _onEnterTween;

		private Tween _lowerScreenTween;

		private Tween _spinningTween;

		private Sequence _killTween;

		private Bounds _camBounds;

		private SpriteRenderer _ringSprite;

		public Action OnDefeat { get; set; }

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void Despawn()
		{
		}

		protected override void UpdateDepth()
		{
		}

		protected override void Die()
		{
		}

		private void SingleWarning(Vector2 pos)
		{
		}
	}
}
