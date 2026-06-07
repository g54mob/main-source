using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyStalker_Generic : EnemyController
	{
		private float _sineF;

		private Tween _onEnterTween;

		private Sequence _onSineTween;

		private GameObject _spritte;

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
	}
}
