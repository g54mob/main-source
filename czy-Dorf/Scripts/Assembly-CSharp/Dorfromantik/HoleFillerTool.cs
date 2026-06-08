using System.Collections.Generic;
using UnityEngine;

namespace Dorfromantik
{
	public class HoleFillerTool : MonoBehaviour
	{
		[SerializeField]
		private VfxConfiguration tileStackVfx;

		[SerializeField]
		private InputRouter inputRouter;

		[SerializeField]
		private TileStack tileStack;

		[SerializeField]
		private List<GroupType> allGroupTypes;

		[SerializeField]
		private MatchingTileGenerator matchingTileGenerator;

		[SerializeField]
		private VfxManager vfxManager;

		[SerializeField]
		private List<SegmentFitConstellation> debug_segmentFits;

		private Dictionary<GroupTypeId, GroupType> groupTypeById;

		private void Start()
		{
			inputRouter.OnFillHole += UseFillHoleTool;
			groupTypeById = new Dictionary<GroupTypeId, GroupType>();
			foreach (GroupType allGroupType in allGroupTypes)
			{
				groupTypeById.Add(allGroupType.id, allGroupType);
			}
		}

		private void UseFillHoleTool(TileSlot targetTileSlot)
		{
			Tile newTile = matchingTileGenerator.GenerateFittingTile(targetTileSlot);
			tileStack.ReplaceStackedTile(0, newTile, randomizeSeed: true, generateDuplicate: false);
			vfxManager.SpawnEffectAtTransform(tileStackVfx, tileStack.GetStackedTile(0).transform);
		}

		private void OnDestroy()
		{
			inputRouter.OnFillHole -= UseFillHoleTool;
		}
	}
}
