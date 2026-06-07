using UnityEngine;

public static class RandomExtensions
{
	public static Vector2 RandomPosition(this Rect rect)
	{
		return new Vector2(Random.Range(rect.xMin, rect.xMax), Random.Range(rect.yMin, rect.yMax));
	}

	public static Vector2 RandomPosition(this Rect rect, float padding = 0f)
	{
		float num = padding * 2f;
		if (rect.size.x <= num || rect.size.y <= num)
		{
			Debug.LogWarning("Rect random position padding exceeds rect size!");
		}
		return new Vector2(Random.Range(rect.xMin + padding, rect.xMax - padding), Random.Range(rect.yMin + padding, rect.yMax - padding));
	}
}
