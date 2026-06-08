using System.Collections.Generic;
using Dorfromantik;
using UnityEngine;

public class TutorialEvent_HighlightQuestEdges : TutorialEvent
{
	[SerializeField]
	private QuestManager questManager;

	[SerializeField]
	private TilePlacementEventBroadcaster tilePlacementEventBroadcaster;

	private List<ElementGroup> highlightedGroups;

	private QuestWatcher questWatcher;

	public override void Begin()
	{
		tilePlacementEventBroadcaster.OnTilePlaced_UndoStored += StartHighlightingQuest;
	}

	private void StartHighlightingQuest(Tile placedTile, bool isPlacedByPlayer)
	{
		if (isPlacedByPlayer)
		{
			tilePlacementEventBroadcaster.OnTilePlaced_UndoStored -= StartHighlightingQuest;
			questWatcher = questManager.GetLatestQuest();
			if ((bool)questWatcher)
			{
				questWatcher.HighlightWatchTarget(newHighlight: true);
			}
		}
	}

	public override void Finish()
	{
		tilePlacementEventBroadcaster.OnTilePlaced_UndoStored -= StartHighlightingQuest;
	}

	public override void Skip()
	{
	}
}
