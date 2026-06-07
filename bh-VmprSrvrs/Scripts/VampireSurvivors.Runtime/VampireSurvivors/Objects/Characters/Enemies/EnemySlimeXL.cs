using VampireSurvivors.Data;
using VampireSurvivors.Framework.PhaserTweens;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemySlimeXL : EnemyController
	{
		protected bool HasSpawned;

		private MultiTargetTween _onEnterTween;

		protected virtual int EnemiesToSpawnAmount => 0;

		protected virtual EnemyType EnemyToSpawnOnDeath => default(EnemyType);

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void Die()
		{
		}
	}
}
