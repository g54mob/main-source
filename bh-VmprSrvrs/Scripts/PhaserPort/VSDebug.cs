using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class VSDebug
{
	private static Material _debugMat;

	private static Mesh _debugMesh;

	private static List<Vector3> _debugLineVerts;

	private static List<Color> _debugLineColours;

	private static List<int> _debugLineIndices;

	public static bool s_drawDebug;

	public static void Init()
	{
	}

	public static void FlushDebugLines(Vector3 offset)
	{
	}

	public static void ClearDebugLines()
	{
	}

	public static void DrawDebugLine(float2 point1, float2 point2)
	{
	}

	public static void DrawDebugLine(float2 point1, float2 point2, Color colour)
	{
	}

	public static void DrawDebugLine(double x1, double y1, double x2, double y2)
	{
	}

	public static void DrawDebugLine(double x1, double y1, double x2, double y2, Color colour)
	{
	}

	public static void DrawDebugLine(float x1, float y1, float x2, float y2, Color colour)
	{
	}

	public static void DrawDebugRect(double x, double y, double width, float height)
	{
	}

	public static void DrawDebugRect(double x, double y, double width, double height, Color colour)
	{
	}

	public static void DrawDebugCircle(double x, double y, double radius)
	{
	}

	public static void DrawDebugCircle(double x, double y, double radius, Color colour)
	{
	}

	public static void DrawBounds(Bounds bounds, Color colour)
	{
	}
}
