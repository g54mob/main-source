using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemySlimeXLBoss : EnemySlimeXL
{
	protected override int EnemiesToSpawnAmount => 2;

	protected override EnemyType EnemyToSpawnOnDeath => EnemyType.EX_PHALIEN_L_BOSS;
}
