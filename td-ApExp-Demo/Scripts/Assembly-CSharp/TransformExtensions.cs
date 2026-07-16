using UnityEngine;

public static class TransformExtensions
{
	public static bool IsOutsideViewport(this Transform transform)
	{
		float num = 0.1f;
		Vector3 vector = Camera.main.WorldToViewportPoint(transform.position);
		if (vector.x < 0f - num || vector.x > 1f + num || vector.y < 0f - num || vector.y > 1f + num)
		{
			return true;
		}
		return false;
	}

	public static bool TryWrap(this Transform transform)
	{
		Camera main = Camera.main;
		Vector3 vector = main.WorldToViewportPoint(transform.position);
		Vector3 position = transform.position;
		bool result = false;
		if (vector.x < 0f)
		{
			position.x = main.ViewportToWorldPoint(new Vector3(1f, vector.y, vector.z)).x;
			result = true;
		}
		else if (vector.x > 1f)
		{
			position.x = main.ViewportToWorldPoint(new Vector3(0f, vector.y, vector.z)).x;
			result = true;
		}
		if (vector.y < 0f)
		{
			position.y = main.ViewportToWorldPoint(new Vector3(vector.x, 1f, vector.z)).y;
			result = true;
		}
		else if (vector.y > 1f)
		{
			position.y = main.ViewportToWorldPoint(new Vector3(vector.x, 0f, vector.z)).y;
			result = true;
		}
		transform.position = position;
		return result;
	}
}
