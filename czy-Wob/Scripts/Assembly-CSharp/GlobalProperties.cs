using UnityEngine;

public static class GlobalProperties
{
	public static float gravMod = 1f;

	public static float gravboostMultDog = -0.666f;

	public static int targetFramerate = 60;

	public static float GRAV_CONST = -29.43f;

	public static int dogNameCharLimit = 15;

	public static float standardTimeslice = 0.0166f;

	public static void UpdateGravity()
	{
		Physics.gravity = GetGravity();
	}

	public static Vector3 GetGravity()
	{
		return new Vector3(0f, GRAV_CONST * gravMod, 0f);
	}

	public static void UpdateTargetFramerate()
	{
		Application.targetFrameRate = targetFramerate;
	}
}
