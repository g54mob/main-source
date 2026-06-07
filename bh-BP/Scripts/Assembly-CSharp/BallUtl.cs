using UnityEngine;

public static class BallUtl
{
	public const float kGravityBounceFactor = 0.25f;

	private const float kCostPerBounce = 0.02f;

	public static void CalculateShootScore(Vector3 shootPos, Vector2 aimDir, out float score)
	{
		score = default(float);
	}

	private static void RaycastBounce(Vector3 pos, Vector2 aimDir, ref int curBounceNum, ref float score)
	{
	}

	public static void CalculateLauncherHitBuildings(BuildingObj launcher)
	{
	}

	private static void LauncherRaycastBounce(BuildingObj launcher, Vector3 pos, Vector2 aimDir, ref int curBounceNum)
	{
	}

	public static Vector2 PickBestAimDir(Vector3 pos, Vector2 curAimDir, float curAimTheta)
	{
		return default(Vector2);
	}

	public static Vector3 PickBestLobTgt(Vector3 pos, Vector3 curCursorWorldPos)
	{
		return default(Vector3);
	}

	public static bool IsBallObstacle(this ObstacleType ot)
	{
		return false;
	}
}
