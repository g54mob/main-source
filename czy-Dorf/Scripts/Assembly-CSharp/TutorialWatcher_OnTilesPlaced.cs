using Dorfromantik;
using UnityEngine;

public class TutorialWatcher_OnTilesPlaced : TutorialWatcher
{
	[SerializeField]
	private int targetTilesPlacedCount = 5;

	[SerializeField]
	private int currentTilesPlacedCount;

	[SerializeField]
	private TilePlacementEventBroadcaster tilePlacementEventBroadcaster;

	public override void StartWatching()
	{
		currentTilesPlacedCount = 0;
		tilePlacementEventBroadcaster.OnTilePlaced_UndoStored += TilePlaced;
	}

	private void TilePlaced(Tile placedTile, bool isPlacedByPlayer)
	{
		if (isPlacedByPlayer)
		{
			currentTilesPlacedCount++;
			if (currentTilesPlacedCount >= targetTilesPlacedCount)
			{
				ConditionFulfilled();
			}
		}
	}

	private void OnDestroy()
	{
		tilePlacementEventBroadcaster.OnTilePlaced_UndoStored -= TilePlaced;
	}
}
