using System.Collections.Generic;
using UnityEngine;

public static class MemoryShrinkUtil
{
	public static float UnloadUnusedAssetsDelay = 30f;

	public static IEnumerator<bool> UnloadUnusedAssets()
	{
		Resources.UnloadUnusedAssets();
		return WaitForSeconds(UnloadUnusedAssetsDelay);
	}

	public static IEnumerator<bool> WaitForSeconds(float seconds)
	{
		float start = Time.realtimeSinceStartup;
		while (true)
		{
			if (Time.realtimeSinceStartup - start < seconds)
			{
				yield return false;
			}
		}
	}
}
