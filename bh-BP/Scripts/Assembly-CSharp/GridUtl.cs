using UnityEngine;

public static class GridUtl
{
	public static int GetSortOrder(Vector3 pos)
	{
		return 0;
	}

	public static bool IsPlayerPickup(this PickupType t)
	{
		return false;
	}

	public static bool CanFlipX(this GridPieceType t)
	{
		return false;
	}

	public static bool CanFlipY(this GridPieceType t)
	{
		return false;
	}

	public static PrincipleDir ToPrinciple(this CardinalDir dir)
	{
		return default(PrincipleDir);
	}

	public static CardinalDir ToCardinal(this PrincipleDir dir)
	{
		return default(CardinalDir);
	}

	public static PrincipleDir GetPrincipleDir(float angle)
	{
		return default(PrincipleDir);
	}
}
