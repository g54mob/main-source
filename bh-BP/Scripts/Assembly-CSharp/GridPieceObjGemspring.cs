public class GridPieceObjGemspring : GridPieceObj
{
	public int NumHits;

	private int _curThreshold;

	public static readonly int[] kXPThresholds;

	public override void Init(GridPieceInst inst)
	{
	}

	public override bool Damage(int amt, DamageType dt, HitType hitType)
	{
		return false;
	}

	public override void ResetSprite()
	{
	}

	public override void AttackPlayer()
	{
	}

	public override void AttackTortoise(PetObjTortoise tortoise)
	{
	}

	public override void DropDeathStuff()
	{
	}
}
