using VampireSurvivors.Data;

namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyDiamondTint_Facing : EnemyDiamondTint
	{
		private int MaxHits;

		protected override float ItemChance => 0f;

		protected override bool IsImmovable => false;

		protected override bool IsAxe => false;

		protected override bool IsSnake => false;

		protected override bool DoBaseUpdate => false;

		protected override uint[] TintProgression => null;

		public override void InitEnemy(EnemyType enemyType, bool asRemote)
		{
		}

		protected override void ChangeFrame()
		{
		}
	}
}
