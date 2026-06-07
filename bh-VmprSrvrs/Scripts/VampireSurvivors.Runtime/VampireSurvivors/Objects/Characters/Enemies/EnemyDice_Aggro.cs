using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyDice_Aggro : EnemyDice
	{
		protected override float ItemChance => 0f;

		protected override bool IsImmovable => false;

		protected override bool IsAxe => false;

		protected override bool IsSnake => false;

		protected override bool DoBaseUpdate => false;

		public override void InitEnemy(EnemyType enemyType, bool asRemote = false)
		{
		}
	}
}
