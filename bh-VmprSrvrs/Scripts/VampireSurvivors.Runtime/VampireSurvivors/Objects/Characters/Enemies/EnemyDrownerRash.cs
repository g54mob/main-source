using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyDrownerRash : EnemyDrownerNormal
	{
		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override float GetSpawnY()
		{
			return 0f;
		}
	}
}
