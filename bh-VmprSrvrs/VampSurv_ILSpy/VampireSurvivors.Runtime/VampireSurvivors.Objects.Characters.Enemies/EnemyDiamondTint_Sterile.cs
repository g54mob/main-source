namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyDiamondTint_Sterile : EnemyDiamondTint
{
	protected override float ItemChance
	{
		get
		{
			//IL_0006: Expected F4, but got I4
			return 0f;
		}
	}

	protected override bool IsImmovable => false;

	protected override bool IsAxe => false;

	protected override bool IsSnake => true;

	protected override bool DoBaseUpdate => true;

	protected override uint[] TintProgression => new uint[8] { 16777215u, 15658734u, 14540253u, 13421772u, 12303291u, 11184810u, 10066329u, 8947848u };

	public EnemyDiamondTint_Sterile()
	{
		base._grav = 0.3125f;
		((EnemyDiamond)this)._002Ector();
	}
}
