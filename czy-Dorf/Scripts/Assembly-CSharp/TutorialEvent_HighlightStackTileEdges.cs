using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class TutorialEvent_HighlightStackTileEdges : TutorialEvent
{
	[SerializeField]
	private bool disableOnFinish = true;

	[SerializeField]
	private GroupType groupType;

	[SerializeField]
	[FormerlySerializedAs("tileEdgeDescriptionPrefab")]
	private SegmentEdgeHighlight segmentEdgeHighlightPrefab;

	[SerializeField]
	private TilePlacer tilePlacer;

	[SerializeField]
	private TileStack tileStack;

	private List<SegmentEdgeHighlight> tileEdgeDescriptions;

	public override void Begin()
	{
		tileEdgeDescriptions = new List<SegmentEdgeHighlight>();
		tileStack.OnAdvanced += HighlightCurrentTile;
		HighlightCurrentTile();
	}

	private void HighlightCurrentTile()
	{
		HighlightEdges(tileStack.GetStackedTile(0), addToList: false);
		HighlightEdges(tilePlacer.CurrentTile);
	}

	private void HighlightEdges(Tile tileToHighlight, bool addToList = true)
	{
		if (tileToHighlight == null)
		{
			return;
		}
		for (int i = 0; i < 6; i++)
		{
			List<GroupType> edgeTypes = tileToHighlight.GetEdgeTypes(i, Space.World);
			if (edgeTypes.Count > 0 && (groupType == null || edgeTypes.Contains(groupType)))
			{
				SegmentEdgeHighlight segmentEdgeHighlight = Object.Instantiate(segmentEdgeHighlightPrefab);
				segmentEdgeHighlight.Setup(tileToHighlight, (i - tileToHighlight.RotationIndex + 6) % 6, groupType);
				if (addToList)
				{
					tileEdgeDescriptions.Add(segmentEdgeHighlight);
				}
			}
		}
	}

	public override void Finish()
	{
		if (!disableOnFinish)
		{
			return;
		}
		tileStack.OnAdvanced -= HighlightCurrentTile;
		foreach (SegmentEdgeHighlight tileEdgeDescription in tileEdgeDescriptions)
		{
			Object.Destroy(tileEdgeDescription.gameObject);
		}
		tileEdgeDescriptions.Clear();
	}

	public override void Skip()
	{
	}
}
