using UnityEngine;

public class SpawnGridTile
{
	private AxisAllignedRectangle _rectangle;

	public bool IsBlocked { get; private set; }

	public int ClearanceIndex { get; set; } = int.MaxValue;

	public Vector2 Center => _rectangle._center;

	public float Width { get; private set; }

	public float Height { get; private set; }

	public SpawnGridTile(float centerX, float centerY, float width, float height)
	{
		_rectangle = new AxisAllignedRectangle(new Vector2(centerX, centerY), new Vector2(width, height));
		Width = width;
		Height = height;
	}

	public void Reset()
	{
		ClearanceIndex = int.MaxValue;
	}

	public void SetBlockedWhenOverlappingSphere(Vector2 sphereCenter, float sphereRadius, bool invert = false)
	{
		if (!IsBlocked)
		{
			IsBlocked = _rectangle.ReturnIsSphereOverlapping(sphereCenter, sphereRadius);
			if (invert)
			{
				IsBlocked = !IsBlocked;
			}
		}
	}

	public void SetBlockedWhenContainedBySphere(Vector2 sphereCenter, float sphereRadius, bool invert = false)
	{
		if (!IsBlocked)
		{
			IsBlocked = _rectangle.ReturnIsContainedBySphere(sphereCenter, sphereRadius);
			if (invert)
			{
				IsBlocked = !IsBlocked;
			}
		}
	}
}
