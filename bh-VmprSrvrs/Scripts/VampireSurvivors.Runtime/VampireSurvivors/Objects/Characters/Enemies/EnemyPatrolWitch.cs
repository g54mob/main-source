using DG.Tweening;
using UnityEngine;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyPatrolWitch : EnemyGallo
	{
		private float _sineF;

		private float _patrolDuration;

		private Tween _onEnterTween;

		private Tween _onFireTimer;

		private Tween _onSineTween;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void SetOwner(GameObject owner)
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
