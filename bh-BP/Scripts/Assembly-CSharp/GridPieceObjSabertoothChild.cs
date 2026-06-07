public class GridPieceObjSabertoothChild : SubGridPieceObj
{
	public override bool IsBottomOfStack()
	{
		return false;
	}

	public override bool CanApplyStatusEffect(StatusEffect ef)
	{
		return false;
	}

	public override bool CanBeDamaged()
	{
		return false;
	}
}
