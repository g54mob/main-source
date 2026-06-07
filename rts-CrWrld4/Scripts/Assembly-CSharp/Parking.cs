using System.Collections.Generic;
using UnityEngine;

public class Parking
{
	public static void ParkUnits(int cellX, int cellY, List<UnitManager> lums, bool formation = true)
	{
	}

	public static Vector2 ParkUnit(UnitManager um, int gameSpaceX, int gameSpaceY, ref int rangeHint, ref HashSet<int> placements, bool ignoreUnit, bool ignoreLand, bool onlyOnResource, bool avoidContaminant, bool ignoreFog, bool onlyOnVoid, bool allowPlatform, bool avoidMesh)
	{
		return default(Vector2);
	}

	private static bool PlacementTaken(ref HashSet<int> placements, int locX, int locY, int width, int height)
	{
		return false;
	}

	private static void AddPlacement(ref HashSet<int> placements, int locX, int locY, int width, int height)
	{
	}

	public static bool IsLegalPosition(UnitManager ownerLUM, int cellX, int cellY, int WIDTH, int HEIGHT, bool waypoint, Vector2 ignoreSpot, Vector2 ignoreSize, bool ignoreLand, bool onlyOnResource, bool avoidContaminant, bool ignoreFog, bool onlyOnVoid, bool allowPlatform, bool avoidMesh, bool ignoreMovingUnits = false)
	{
		return false;
	}

	public static bool OverEvenLand(int cellX, int cellY, int WIDTH, int HEIGHT)
	{
		return false;
	}
}
