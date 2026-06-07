public class GridPieceObjDynamite : GridPieceObj
{
	public override void Init(GridPieceInst inst)
	{
	}

	public override bool Damage(int amt, DamageType dt, HitType hitType)
	{
		return false;
	}

	public override void Die(bool runDeathAnim)
	{
	}

	protected override void OnDeathComplete()
	{
	}

	public override void AttackPlayer()
	{
	}

	public override void AttackTortoise(PetObjTortoise tortoise)
	{
	}
}
