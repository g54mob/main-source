using UnityEngine;

public class Util
{
	public delegate void LOSMasterCallback(bool hasLOS, int cellX, int cellY, int terrainHeight);

	public static Plane[] terrainPlanes;

	private static Vector3 noHit;

	static Util()
	{
	}

	public static float AngleSpan(float ang1, float ang2)
	{
		return 0f;
	}

	private static float ToStandardAngle(float ang)
	{
		return 0f;
	}

	public static int GetMaxHeightToTarget(Vector3 start, Vector3 end, out int cellX, out int cellY)
	{
		cellX = default(int);
		cellY = default(int);
		return 0;
	}

	public static bool HasLOSIndirect(Vector3 startF, Vector3 endF, float maxHeightOffset, bool sort)
	{
		return false;
	}

	public static bool HasLOS(Vector3 startF, Vector3 endF, bool sort)
	{
		return false;
	}

	public static bool HasLOS(float x0, float y0, float z0, float x1, float y1, float z1, bool sort)
	{
		return false;
	}

	public static bool HasLOSOld(float startX, float startY, float startZ, float endX, float endY, float endZ)
	{
		return false;
	}

	public static bool HasLOSFast(Vector3 startF, Vector3 endF)
	{
		return false;
	}

	public static int GetRangeFromTerrainHeightMod(int range, float terrainHeightMod)
	{
		return 0;
	}

	public static void HasLOSMaster(LOSMasterCallback callback, bool includeFalse, Vector3 start, int range, float targetHeightOffset, bool ignoreTerrain, float terrainHeightMod, bool losIndirect, float losIndirectHeightOffset, bool sort, float startDistBias = 0f)
	{
	}

	public static Vector3 PredictiveTarget(Vector3 bulletPosition, Vector3 targetPosition, float bulletSpeed, Vector3 targetVelocity, out float timeToImpact)
	{
		timeToImpact = default(float);
		return default(Vector3);
	}

	public static Vector2 PredictiveTarget(Vector2 bulletPosition, Vector2 targetPosition, float bulletSpeed, Vector2 targetVelocity, out float timeToImpact)
	{
		timeToImpact = default(float);
		return default(Vector2);
	}

	public static bool RayTriangleIntersectPlane(Vector3 p1, Vector3 p2, Vector3 p3, Ray ray, out Vector3 hitPoint)
	{
		hitPoint = default(Vector3);
		return false;
	}

	public static bool RayTriangleIntersect(Vector3 p1, Vector3 p2, Vector3 p3, Ray ray, out Vector3 hitPoint)
	{
		hitPoint = default(Vector3);
		return false;
	}

	public static void LineNoDiag(int x0, int y0, int x1, int y1)
	{
	}

	public static void GetTrianglesForCell(int cx, int cy, out Vector3 a0, out Vector3 a1, out Vector3 a2, out Vector3 b0, out Vector3 b1, out Vector3 b2)
	{
		a0 = default(Vector3);
		a1 = default(Vector3);
		a2 = default(Vector3);
		b0 = default(Vector3);
		b1 = default(Vector3);
		b2 = default(Vector3);
	}

	public static bool RayHitPlane(Ray ray, Vector3 inNormal, Vector3 inPoint, out float enter)
	{
		enter = default(float);
		return false;
	}

	public static bool RayHitTerrainCellTriangles(Ray ray, int cx, int cy, out Vector3 hitPoint)
	{
		hitPoint = default(Vector3);
		return false;
	}

	public static bool HasStraightLineLOS(Vector3 start, Vector3 end, bool checkLastCell)
	{
		return false;
	}

	public static bool HasStraightLineLOS(Vector3 start, Vector3 end, bool checkLastCell, out Vector3 hitPoint)
	{
		hitPoint = default(Vector3);
		return false;
	}

	public static bool RayHitCellAnything(Ray ray, int cx, int cy, bool enemy)
	{
		return false;
	}

	public static bool HasLOSEverything(Vector3 start, Vector3 end, bool enemy, bool checkLastCell)
	{
		return false;
	}

	public static float GetMinMoveHeight(int cellX, int cellY, bool enemy)
	{
		return 0f;
	}

	public static float GetMinMoveHeight(int cellX, int cellY, bool enemy, bool avoidCreeper, bool extra)
	{
		return 0f;
	}

	public static float Remap(float s, float a1, float a2, float b1, float b2)
	{
		return 0f;
	}
}
