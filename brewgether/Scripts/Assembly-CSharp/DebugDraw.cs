using UnityEngine;

public static class DebugDraw
{
	public static void DrawMarker(Vector3 position, float size, Color color, float duration, bool depthTest = true)
	{
	}

	public static void DrawPlane(Vector3 position, Vector3 normal, float size, Color color, float duration, bool depthTest = true)
	{
	}

	public static void DrawVector(Vector3 position, Vector3 direction, float raySize, float markerSize, Color color, float duration, bool depthTest = true)
	{
	}

	public static void DrawTriangle(Vector3 a, Vector3 b, Vector3 c, Color color)
	{
	}

	public static void DrawTriangle(Vector3 a, Vector3 b, Vector3 c, Color color, Transform t)
	{
	}

	public static void DrawMesh(Mesh mesh, Color color, Transform t)
	{
	}

	public static Color RandomColor()
	{
		return default(Color);
	}
}
