using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class DebugTileDataViewer : MonoBehaviour
{
	public Dictionary<Vector2Int, Color> squareTileData = new Dictionary<Vector2Int, Color>();

	public Dictionary<Vector2Int, Color> checkerSquareTileData = new Dictionary<Vector2Int, Color>();

	public Dictionary<Vector2Int, string> stringData = new Dictionary<Vector2Int, string>();

	public bool squareTilesOn = true;

	public bool checkerTilesOn = true;

	public bool tileTextOn = true;

	public bool tileCoordinatesOn = true;

	public int textSize = 10;

	[ResizableTextArea]
	public string context;

	public bool onlyDrawWhenSelected = true;

	public void Clear()
	{
		squareTileData.Clear();
		checkerSquareTileData.Clear();
		stringData.Clear();
	}
}
