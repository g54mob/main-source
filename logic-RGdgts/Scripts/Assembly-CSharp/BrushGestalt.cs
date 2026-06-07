using System;
using UnityEngine;

[CreateAssetMenu]
public class BrushGestalt : ScriptableObject
{
	[Serializable]
	public struct Bounds
	{
		public Vector2Int leftBound;

		public Vector2Int rightBound;

		public Vector2Int topBound;

		public Vector2Int bottomBound;
	}

	public BrushGestaltEnum id;

	public Texture2D atlas;

	public Bounds[] bounds;

	public const int sizesCount = 9;

	public const float atlasElementNormalizedWidth = 1f / 9f;

	public int elementWidth => 0;

	public int elementHeight => 0;

	public Vector2Int elementSize => default(Vector2Int);

	public int width => 0;

	public int height => 0;

	public Vector2Int size => default(Vector2Int);

	public Rect GetUvRect(int brushSize)
	{
		return default(Rect);
	}

	private void RefreshBounds()
	{
	}

	private void SetAsInvalid()
	{
	}
}
