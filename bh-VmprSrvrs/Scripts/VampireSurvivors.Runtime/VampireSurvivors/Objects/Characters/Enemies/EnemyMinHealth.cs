using DG.Tweening;
using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyMinHealth : EnemyController
	{
		private Sequence _onEnterTween;

		private int _lives;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void Despawn()
		{
		}

		protected override void Die()
		{
		}
	}
}
