using System;
using DG.Tweening;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyPincer : EnemyController
	{
		private int _lives;

		private Tween _onEnterTween;

		public Action OnDead { get; set; }

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void OnUpdate()
		{
		}

		protected override void UpdateDepth()
		{
		}

		public void SetDepth(float newDepth)
		{
		}

		protected override void Die()
		{
		}
	}
}
