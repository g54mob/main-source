namespace VampireSurvivors.Objects.Characters.Enemies
{
	public class EnemyDiamondTint_Medusa : EnemyDiamondTint
	{
		protected override bool IsImmovable => false;

		protected override bool IsAxe => false;

		protected override bool IsSnake => false;

		protected override bool DoBaseUpdate => false;

		protected override uint[] TintProgression => null;
	}
}
