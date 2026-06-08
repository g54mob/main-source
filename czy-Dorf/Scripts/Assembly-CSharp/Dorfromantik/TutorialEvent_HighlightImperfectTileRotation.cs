using UnityEngine;

namespace Dorfromantik
{
	public class TutorialEvent_HighlightImperfectTileRotation : TutorialEvent
	{
		[SerializeField]
		private TileSlotHighlighter tileSlotHighlighterPrefab;

		private TileSlot targetTileSlot;

		private bool currentTileIsOnTargetTileSlot;

		private TilePlacer tilePlacer;

		private TileSlotHighlighter activeTileSlotHighlighter;

		public void SetTargetTileSlot(TileSlot newTarget)
		{
			targetTileSlot = newTarget;
		}

		public override void Begin()
		{
			tilePlacer = OverwritingSingleton<IngameUi>.Instance.tilePlacer;
			tilePlacer.OnCurrentTileMoved += PreviewTileMoved;
			tilePlacer.OnCurrentTileRotated += PreviewTileRotated;
			if (!activeTileSlotHighlighter)
			{
				activeTileSlotHighlighter = Object.Instantiate(tileSlotHighlighterPrefab, targetTileSlot.transform.position, Quaternion.identity, base.transform);
			}
			else
			{
				activeTileSlotHighlighter.transform.position = targetTileSlot.transform.position;
			}
		}

		private void PreviewTileRotated(int rotationAmount, bool animate)
		{
			if (currentTileIsOnTargetTileSlot)
			{
				int num = TileFitter.MatchingTileEdgeCount(tilePlacer.CurrentTile);
				activeTileSlotHighlighter.Show(num < 6);
				if (num >= 6)
				{
					return;
				}
				for (int i = 1; i < 6; i++)
				{
					num = TileFitter.MatchingTileEdgeCount(tilePlacer.CurrentTile, i);
					if (num == 6)
					{
						Debug.Log($"match rotation: {i}");
						activeTileSlotHighlighter.SetMirrored(i <= 3);
						break;
					}
				}
				if (num < 6)
				{
					Debug.Log("no matching rotation found");
				}
			}
			else
			{
				activeTileSlotHighlighter.Show(show: false);
			}
		}

		private void PreviewTileMoved(TileSlot newTileSlot)
		{
			currentTileIsOnTargetTileSlot = (bool)newTileSlot && newTileSlot == targetTileSlot;
			PreviewTileRotated(-1, animate: true);
		}

		public override void Finish()
		{
			tilePlacer.OnCurrentTileMoved -= PreviewTileMoved;
			tilePlacer.OnCurrentTileRotated -= PreviewTileRotated;
			activeTileSlotHighlighter.Show(show: false);
		}

		public override void Skip()
		{
		}
	}
}
