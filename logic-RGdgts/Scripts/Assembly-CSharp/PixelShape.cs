using System;
using UnityEngine;

public class PixelShape : MonoBehaviour
{
	[Serializable]
	public class Shape
	{
		public int width;

		public int height;

		public byte[] data;
	}

	[HideInInspector]
	public Shape shape;

	[HideInInspector]
	public BoxCollider2D boundsCollider;

	public bool isEmpty => false;

	public Bounds bounds => default(Bounds);

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void SetShape(Shape shape)
	{
	}

	public void RefreshCollider()
	{
	}

	public bool IsOverlapping(PixelShape other)
	{
		return false;
	}

	public Vector2 ClosestPoint(Vector2 point)
	{
		return default(Vector2);
	}

	public bool OverlapPoint(Vector2 point)
	{
		return false;
	}

	public bool OverlapRect(Rect rect)
	{
		return false;
	}

	public bool OverlapCircle(Vector2 point, float radius)
	{
		return false;
	}

	public bool IsInside(PixelShape other, out Vector2 invalidPoint)
	{
		invalidPoint = default(Vector2);
		return false;
	}

	public Vector2 CalculateCentroid(PixelShape avoidShape = null)
	{
		return default(Vector2);
	}

	private void OnDestroy()
	{
	}

	public static PixelShapePreset GeneratePixelShapePreset(uint colorMask, params Tuple<SpriteRotationInfo, Vector2>[] sprites)
	{
		return null;
	}
}
