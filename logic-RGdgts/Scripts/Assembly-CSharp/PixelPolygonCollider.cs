using System.Collections.Generic;
using UnityEngine;

public sealed class PixelPolygonCollider : MonoBehaviour
{
	public float alphaCutoff;

	public bool smoothPixels;

	public void Regenerate()
	{
	}

	private List<List<Vector2>> FinalizePaths(List<List<Vector2Int>> Pixel_Paths, Sprite sprite)
	{
		return null;
	}

	private static List<List<Vector2Int>> SimplifyPathsPhase1(List<List<Vector2Int>> paths)
	{
		return null;
	}

	private static List<List<Vector2Int>> SimplifyPathsPhase2(List<List<Vector2Int>> inputPaths)
	{
		return null;
	}

	private static List<List<Vector2Int>> SmoothPixels(List<List<Vector2Int>> inputPaths)
	{
		return null;
	}

	private static List<List<Vector2Int>> GetPaths(Sprite sprite, float alphaCutoff)
	{
		return null;
	}
}
