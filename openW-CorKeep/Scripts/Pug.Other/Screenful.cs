using UnityEngine;

public class Screenful : MonoBehaviour
{
	public RectTransform playerRegion;

	public RectTransform cameraBounds;

	private Vector3[] playerRegionCorners = new Vector3[4];

	private Vector3[] cameraBoundsCorners = new Vector3[4];

	public Rect playerRegionRect
	{
		get
		{
			playerRegion.GetWorldCorners(playerRegionCorners);
			return Rect.MinMaxRect(playerRegionCorners[0].x, playerRegionCorners[0].y, playerRegionCorners[2].x, playerRegionCorners[2].y);
		}
	}

	public Rect cameraBoundsRect
	{
		get
		{
			cameraBounds.GetWorldCorners(cameraBoundsCorners);
			return Rect.MinMaxRect(cameraBoundsCorners[0].x, cameraBoundsCorners[0].y, cameraBoundsCorners[2].x, cameraBoundsCorners[2].y);
		}
	}

	public bool PlayerRegionContainsPoint(Vector2 p)
	{
		return playerRegionRect.Contains(p);
	}
}
