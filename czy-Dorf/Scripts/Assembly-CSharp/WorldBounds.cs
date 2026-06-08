using Dorfromantik;
using UnityEngine;

public class WorldBounds : MonoBehaviour
{
	public Rect Bounds;

	private Vector2 minBounds = Vector2.zero;

	private Vector2 maxBounds = Vector2.zero;

	private TilePlacer tilePlacer;

	[SerializeField]
	private TilePlacementEventBroadcaster tilePlacementEventBroadcaster;

	private void Awake()
	{
		Bounds = default(Rect);
		tilePlacer = GetComponent<TilePlacer>();
		if ((bool)tilePlacer)
		{
			tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed += ExtendBounds;
		}
	}

	private void ExtendBounds(Tile placedTile, bool advanceStack)
	{
		Vector3 position = placedTile.transform.position;
		if (position.x < Bounds.xMin)
		{
			Bounds.xMin = position.x;
		}
		if (position.x > Bounds.xMax)
		{
			Bounds.xMax = position.x;
		}
		if (position.z < Bounds.yMin)
		{
			Bounds.yMin = position.z;
		}
		if (position.z > Bounds.yMax)
		{
			Bounds.yMax = position.z;
		}
	}

	private void OnDestroy()
	{
		tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed -= ExtendBounds;
	}
}
