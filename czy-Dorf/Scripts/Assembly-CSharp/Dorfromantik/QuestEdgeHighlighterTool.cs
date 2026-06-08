using UnityEngine;

namespace Dorfromantik
{
	public class QuestEdgeHighlighterTool : MonoBehaviour
	{
		[SerializeField]
		private QuestManager questManager;

		[SerializeField]
		private TilePlacementEventBroadcaster tilePlacementEventBroadcaster;

		public void StartTool()
		{
			tilePlacementEventBroadcaster.OnTilePlaced_UndoStored += StartHighlightingQuestFromTilePlaced;
			StartHighlightingQuest();
		}

		private void StartHighlightingQuestFromTilePlaced(Tile placedTile, bool isPlacedByPlayer)
		{
			if (isPlacedByPlayer)
			{
				StartHighlightingQuest();
			}
		}

		private void StartHighlightingQuest()
		{
			foreach (QuestWatcher allQuestWatcher in questManager.AllQuestWatchers)
			{
				allQuestWatcher.HighlightWatchTarget(newHighlight: true);
			}
		}

		public void StopTool()
		{
			tilePlacementEventBroadcaster.OnTilePlaced_UndoStored -= StartHighlightingQuestFromTilePlaced;
			foreach (QuestWatcher allQuestWatcher in questManager.AllQuestWatchers)
			{
				allQuestWatcher.HighlightWatchTarget(newHighlight: false);
			}
		}
	}
}
