using Dorfromantik;
using UnityEngine;

public class TutorialWatcher_GroupFormed : TutorialWatcher
{
	[SerializeField]
	private GroupType groupType;

	[SerializeField]
	private int targetGroupSize;

	[SerializeField]
	private TilePlacementEventBroadcaster tilePlacementEventBroadcaster;

	private ElementGroupManager elementGroupManager;

	public override void StartWatching()
	{
		elementGroupManager = Object.FindObjectOfType<ElementGroupManager>();
		tilePlacementEventBroadcaster.OnTilePlaced_UndoStored += CheckIfTileWasPlaced;
	}

	private void CheckIfTileWasPlaced(Tile placedTile, bool isPlacedByPlayer)
	{
		if (isPlacedByPlayer && elementGroupManager.GetGroupCountByCondition(groupType, null, EqualityComparison.MoreThan, CountTarget.Segments) >= targetGroupSize)
		{
			ConditionFulfilled();
		}
	}

	private void OnDestroy()
	{
		tilePlacementEventBroadcaster.OnTilePlaced_UndoStored -= CheckIfTileWasPlaced;
	}
}
