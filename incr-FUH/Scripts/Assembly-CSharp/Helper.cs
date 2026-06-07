using System;
using UnityEngine;

public class Helper
{
	public static Vector2 GetThrowVelocity(Vector3 from, Vector3 to)
	{
		float num = to.x - from.x;
		Vector2 vector = (to - from).normalized;
		if (num < 0f)
		{
			num = 0f - num;
		}
		float num2 = 45f + (float)UnityEngine.Random.Range(-5, 30);
		float f = num / (Mathf.Sin(2f * num2 * (MathF.PI / 180f)) / (Physics2D.gravity.y * -1f));
		float num3 = Mathf.Sqrt(f) * Mathf.Cos(num2 * (MathF.PI / 180f));
		float y = Mathf.Sqrt(f) * Mathf.Sin(num2 * (MathF.PI / 180f));
		return new Vector2(num3 * vector.x, y);
	}

	public static void SetZForFocus(Transform t)
	{
		if (GameController.Instance != null && GameController.Instance.AreBuildingOnTop)
		{
			if (t.position.z != -1f)
			{
				t.position = new Vector3(t.position.x, t.position.y, -1f);
			}
		}
		else if (t.position.z == -1f)
		{
			t.position = new Vector3(t.position.x, t.position.y, 0f);
		}
	}
}
