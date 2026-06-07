using UnityEngine;

public class GridPieceObjYetiQueenShield : SubGridPieceObj
{
	public PartSysGroup PunchParts;

	public BoxCollider2D BoxCol;

	public override void Init(GridPieceInst inst)
	{
	}

	public override void Reset()
	{
	}

	public override bool CanBeDamaged()
	{
		return false;
	}

	public override bool IsShielded(Vector2 hitNormal)
	{
		return false;
	}

	public override bool ShouldDestroyPieceOnTouch()
	{
		return false;
	}

	public override bool CanApplyStatusEffect(StatusEffect ef)
	{
		return false;
	}

	public void ResetColSize()
	{
	}

	public void SetColSize(float size, float mult = -1f)
	{
	}
}
