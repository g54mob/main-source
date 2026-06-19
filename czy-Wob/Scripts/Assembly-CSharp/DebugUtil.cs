using UnityEngine;

public class DebugUtil : MonoBehaviour
{
	public static void Print(string str)
	{
		MonoBehaviour.print(str);
	}

	public static void LogError(string str)
	{
		Debug.LogError(str);
	}

	public static void DrawBox(BoundingBoxComponent bbc)
	{
		bbc.ForceUpdateBoundingBox();
		DrawBox(bbc.GetBoxCenter(), bbc.GetBoxSize());
	}

	public static void DrawBox(Vector3 boxCenter, Vector3 halfExtents, Color? color = null, float duration = 5f)
	{
		Vector3 vector = new Vector3(halfExtents.x, 0f, 0f);
		Vector3 vector2 = new Vector3(0f, halfExtents.y, 0f);
		Vector3 vector3 = new Vector3(0f, 0f, halfExtents.z);
		Color color2 = Color.red;
		if (color.HasValue)
		{
			color2 = color.Value;
		}
		Debug.DrawLine(boxCenter - vector - vector2 - vector3, boxCenter - vector + vector2 - vector3, color2, duration);
		Debug.DrawLine(boxCenter + vector - vector2 - vector3, boxCenter + vector + vector2 - vector3, color2, duration);
		Debug.DrawLine(boxCenter - vector - vector2 + vector3, boxCenter - vector + vector2 + vector3, color2, duration);
		Debug.DrawLine(boxCenter + vector - vector2 + vector3, boxCenter + vector + vector2 + vector3, color2, duration);
		Debug.DrawLine(boxCenter + vector - vector2 - vector3, boxCenter + vector - vector2 + vector3, color2, duration);
		Debug.DrawLine(boxCenter - vector - vector2 - vector3, boxCenter - vector - vector2 + vector3, color2, duration);
		Debug.DrawLine(boxCenter + vector + vector2 - vector3, boxCenter + vector + vector2 + vector3, color2, duration);
		Debug.DrawLine(boxCenter - vector + vector2 - vector3, boxCenter - vector + vector2 + vector3, color2, duration);
		Debug.DrawLine(boxCenter - vector - vector2 - vector3, boxCenter + vector - vector2 - vector3, color2, duration);
		Debug.DrawLine(boxCenter - vector - vector2 + vector3, boxCenter + vector - vector2 + vector3, color2, duration);
		Debug.DrawLine(boxCenter - vector + vector2 - vector3, boxCenter + vector + vector2 - vector3, color2, duration);
		Debug.DrawLine(boxCenter - vector + vector2 + vector3, boxCenter + vector + vector2 + vector3, color2, duration);
	}
}
