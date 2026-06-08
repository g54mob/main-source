using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dorfromantik
{
	public class TutorialEvent_PreparePerfectPlacement : TutorialEvent
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<TileSlot, bool> _003C_003E9__7_0;

			public static Func<TileSlot, int> _003C_003E9__7_1;

			internal bool _003CBegin_003Eb__7_0(TileSlot x)
			{
				return !x.HasAdaptiveEdge();
			}

			internal int _003CBegin_003Eb__7_1(TileSlot x)
			{
				return x.EmptyNeighborsExcludingPreplacedTiles;
			}
		}

		[SerializeField]
		private TileSlotPreviewer tileSlotPreviewer;

		[SerializeField]
		private TilePlacer tilePlacer;

		[SerializeField]
		private TileStack tileStack;

		[SerializeField]
		private InputRouter inputRouter;

		[SerializeField]
		private MatchingTileGenerator matchingTileGenerator;

		public TileSlotEvent OnTileSlotSelected;

		private TileSlot targetTileSlot;

		public override void Begin()
		{
			List<TileSlot> list = Enumerable.ToList(Enumerable.OrderBy(Enumerable.Where(tileSlotPreviewer.AllTileSlots, (TileSlot x) => !x.HasAdaptiveEdge()), (TileSlot x) => x.EmptyNeighborsExcludingPreplacedTiles));
			targetTileSlot = list[0];
			Debug.Log($"Prepare Perfect Placement on {targetTileSlot}", targetTileSlot);
			List<Vector2Int> list2 = new List<Vector2Int>(GridCalculator.NeighborDirections(targetTileSlot.GridPos));
			for (int num = list2.Count - 1; num >= 0; num--)
			{
				if (targetTileSlot.NeighborTiles[num] != null)
				{
					list2.RemoveAt(num);
				}
			}
			matchingTileGenerator.PreventAdaptiveSegmentsEndingOn(targetTileSlot);
			while (list2.Count > 0)
			{
				for (int num2 = list2.Count - 1; num2 >= 0; num2--)
				{
					TileSlot tileSlot = tileSlotPreviewer.GetTileSlot(targetTileSlot.GridPos + list2[num2]);
					if ((bool)tileSlot)
					{
						Tile tile = matchingTileGenerator.GenerateFittingTile(tileSlot);
						tile.InitializeSeed();
						tilePlacer.PlaceTileDirectly(tile, tileSlot.GridPos);
						list2.RemoveAt(num2);
					}
				}
			}
			OnTileSlotSelected?.Invoke(targetTileSlot);
			GenerateFittingTile();
		}

		public void GenerateFittingTile()
		{
			if (tileStack.Height < 1)
			{
				Debug.LogError($"wants to generate fitting tile, but tile stack height is {tileStack.Height}");
				return;
			}
			Tile tile = matchingTileGenerator.GenerateFittingTile(targetTileSlot);
			tileStack.ReplaceStackedTile(1, tile, randomizeSeed: true, generateDuplicate: false);
			inputRouter.DiscardCurrentPreviewTile(refillStack: true);
			Debug.Log($"Generate fitting tile {tile}", tile);
		}

		public override void Finish()
		{
		}

		public override void Skip()
		{
		}
	}
}
