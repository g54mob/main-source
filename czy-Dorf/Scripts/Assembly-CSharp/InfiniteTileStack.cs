using Dorfromantik;
using UnityEngine;

public class InfiniteTileStack : MonoBehaviour
{
	[SerializeField]
	private TileStack tileStack;

	[SerializeField]
	private TilePlacementEventBroadcaster tilePlacementEventBroadcaster;

	private void OnEnable()
	{
		tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed += AddTile;
	}

	private void OnDisable()
	{
		tilePlacementEventBroadcaster.OnTilePlaced_QuestsProcessed -= AddTile;
	}

	private void AddTile(Tile placedTile, bool advanceStack)
	{
		if (advanceStack)
		{
			tileStack.AddRandomTiles(1);
		}
	}
}
