using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemySlimeL : EnemySlimeXL
	{
		protected override int EnemiesToSpawnAmount => 0;

		protected override EnemyType EnemyToSpawnOnDeath => default(EnemyType);
	}
}
