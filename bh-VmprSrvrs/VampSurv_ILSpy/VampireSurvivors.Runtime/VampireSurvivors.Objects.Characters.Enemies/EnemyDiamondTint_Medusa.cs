namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyDiamondTint_Medusa : EnemyDiamondTint
{
	protected override bool IsImmovable => false;

	protected override bool IsAxe => false;

	protected override bool IsSnake => false;

	protected override bool DoBaseUpdate => true;

	protected override uint[] TintProgression => new uint[5] { 13434828u, 8978312u, 4521796u, 2293538u, 65280u };

	public EnemyDiamondTint_Medusa()
	{
		base._grav = 0.3125f;
		((EnemyDiamond)this)._002Ector();
	}
}
