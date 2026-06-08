using UnityEngine;

namespace Dorfromantik
{
	public class TutorialEvent_HighlightMatchingEdges : TutorialEvent
	{
		[SerializeField]
		private MatchingTileEdgeHighlighter highligterPrefab;

		[SerializeField]
		private bool displayEdgeScore;

		private TilePlacer tilePlacer;

		private MatchingTileEdgeHighlighter currentHighlighter;

		private bool[] edgesFit = new bool[6];

		private Tile currentPreviewTile;

		public override void Begin()
		{
			tilePlacer = OverwritingSingleton<IngameUi>.Instance.tilePlacer;
			UpdateCurrentTile(tilePlacer.CurrentTile);
			tilePlacer.OnNewPreviewTileSet += UpdateCurrentTile;
			tilePlacer.OnLastTileSet += UpdateCurrentTileFromGameOver;
		}

		private void UpdateCurrentTileFromGameOver()
		{
			UpdateCurrentTile(null);
		}

		private void UpdateCurrentTile(Tile newPreviewTile)
		{
			if ((bool)currentPreviewTile)
			{
				currentPreviewTile.OnNeighborTileAdded -= UpdateTileEdge;
			}
			currentPreviewTile = newPreviewTile;
			if ((bool)currentPreviewTile)
			{
				if (currentHighlighter == null)
				{
					currentHighlighter = Object.Instantiate(highligterPrefab);
				}
				currentHighlighter.ShowEdgeScore(displayEdgeScore);
				currentPreviewTile.OnNeighborTileAdded += UpdateTileEdge;
				currentHighlighter.transform.parent = currentPreviewTile.transform;
				currentHighlighter.transform.localPosition = Vector3.zero;
				currentHighlighter.transform.rotation = Quaternion.identity;
				for (int i = 0; i < edgesFit.Length; i++)
				{
					edgesFit[i] = false;
				}
			}
			else if ((bool)currentHighlighter)
			{
				for (int j = 0; j < 6; j++)
				{
					currentHighlighter.HighlightEdge(j, TileEdgeState.Undefined);
				}
				Object.Destroy(currentHighlighter.gameObject, 1f);
				currentHighlighter = null;
			}
		}

		private void UpdateTileEdge(int worldEdge, Tile neighborTile)
		{
			if (neighborTile == null)
			{
				currentHighlighter.HighlightEdge(worldEdge, TileEdgeState.Undefined);
				edgesFit[worldEdge] = true;
				return;
			}
			bool flag = false;
			GroupType groupType = currentPreviewTile.GetElementGroup(worldEdge, Space.World)?.GroupType;
			GroupType groupType2 = neighborTile.GetElementGroup((worldEdge + 3) % 6, Space.World)?.GroupType;
			if (groupType == groupType2)
			{
				flag = true;
			}
			else if (groupType != null && groupType2 != null && (groupType == neighborTile.GetElementGroup((worldEdge + 3) % 6, Space.World, groupType)?.GroupType || groupType2 == currentPreviewTile.GetElementGroup(worldEdge, Space.World, groupType2)?.GroupType))
			{
				flag = true;
			}
			else if ((currentPreviewTile.GetHybridEdges(worldEdge, Space.World).Count > 0 && groupType2 == null) || (neighborTile.GetHybridEdges((worldEdge + 3) % 6, Space.World).Count > 0 && groupType == null))
			{
				flag = true;
			}
			currentHighlighter.HighlightEdge(worldEdge, (!flag) ? TileEdgeState.Imperfect : TileEdgeState.Perfect);
			edgesFit[worldEdge] = flag;
		}

		public override void Finish()
		{
			UpdateCurrentTile(null);
			currentHighlighter = null;
			if ((bool)tilePlacer)
			{
				tilePlacer.OnNewPreviewTileSet -= UpdateCurrentTile;
				tilePlacer.OnLastTileSet -= UpdateCurrentTileFromGameOver;
			}
		}

		public override void Skip()
		{
		}
	}
}
