using UnityEngine;
using UnityEngine.Events;

namespace Dorfromantik
{
	public class TutorialWatcher_PerfectPlacement : TutorialWatcher
	{
		[SerializeField]
		private RewardSystem rewardSystem;

		[SerializeField]
		private TutorialPhase onFailedPhase;

		[SerializeField]
		private TilePlacementEventBroadcaster tilePlacementEventBroadcaster;

		[SerializeField]
		private UnityEvent onRepeat;

		private TileSlot targetTileSlot;

		public override void StartWatching()
		{
			tilePlacementEventBroadcaster.OnTilePlaced_Finalized += TilePlaced;
		}

		private void TilePlaced(Tile placedTile, bool placedByPlayer)
		{
			if (placedByPlayer)
			{
				if ((bool)targetTileSlot && placedTile.GridPos != targetTileSlot.GridPos)
				{
					Debug.Log("Tile Placed somewhere else");
					onRepeat?.Invoke();
				}
				else if (placedTile.FittingPlacedNeighbors.Count == 6)
				{
					tilePlacementEventBroadcaster.OnTilePlaced_Finalized -= TilePlaced;
					Debug.Log("Perfect Placement Successful!");
					tutorialPhase.Finish();
				}
				else
				{
					tilePlacementEventBroadcaster.OnTilePlaced_Finalized -= TilePlaced;
					Debug.Log("Perfect Placement Failed!");
					tutorialPhase.Finish(startNextPhase: false);
					onFailedPhase.gameObject.SetActive(value: true);
					onFailedPhase.Begin();
				}
			}
		}

		public void SetTargetTileSlot(TileSlot newTileSlot)
		{
			targetTileSlot = newTileSlot;
		}

		private void OnDestroy()
		{
			tilePlacementEventBroadcaster.OnTilePlaced_Finalized -= TilePlaced;
		}
	}
}
