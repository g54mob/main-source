using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemySlimeLBoss : EnemySlimeXL
{
	protected override int EnemiesToSpawnAmount => 4;

	protected override EnemyType EnemyToSpawnOnDeath => EnemyType.EX_PHALIEN_BOSS;
}
