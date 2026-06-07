using DG.Tweening;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.TimerSystem;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class Enemy_SpawnHigh : EnemyController
	{
		private Sequence _onEnterTween;

		private Timer _cullableGraceTimer;

		protected override void OnRecycleEnemy()
		{
		}

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		public override void Despawn()
		{
		}

		protected override void Die()
		{
		}

		private void KillTweens()
		{
		}
	}
}
