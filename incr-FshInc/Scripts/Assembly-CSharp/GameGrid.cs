using System.Collections.Generic;
using UnityEngine;

public class GameGrid : MonoBehaviour
{
	public Transform gridParent;

	public int numberOfBubbleSpots = 3;

	private List<Tile> allTiles = new List<Tile>();

	private FishingManager fishingManager;

	public Vector2 pondCenter { get; private set; }

	public Vector2 pondSize { get; private set; }

	public static GameGrid Instance { get; private set; }

	public List<Tile> AllTiles => allTiles;

	private void Awake()
	{
		if (Instance == null)
		{
			Instance = this;
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	private void Start()
	{
		fishingManager = FishingManager.Instance;
		if (fishingManager == null)
		{
			Debug.LogError("Could not find FishingManager in the scene!");
			return;
		}
		InitializePrebuiltGrid();
		CreateBubbleSpots(numberOfBubbleSpots);
	}

	private void InitializePrebuiltGrid()
	{
		if (gridParent == null)
		{
			Debug.LogError("Grid Parent is not assigned in the GameGrid script!");
			return;
		}
		gridParent.GetComponentsInChildren(allTiles);
		if (allTiles.Count == 0)
		{
			Debug.LogWarning("No tiles found in the grid parent!");
			return;
		}
		Bounds bounds = new Bounds(allTiles[0].transform.position, Vector3.zero);
		foreach (Tile allTile in allTiles)
		{
			bounds.Encapsulate(allTile.transform.position);
		}
		pondCenter = bounds.center;
		pondSize = bounds.size;
		foreach (Tile allTile2 in allTiles)
		{
			allTile2.onTileClicked.RemoveAllListeners();
			allTile2.onTileClicked.AddListener(fishingManager.OnTileClicked);
			if (allTile2.onTileHoverEntered != null)
			{
				allTile2.onTileHoverEntered.RemoveAllListeners();
				allTile2.onTileHoverEntered.AddListener(fishingManager.OnTileHoverEntered);
			}
			if (allTile2.onTileHoverExited != null)
			{
				allTile2.onTileHoverExited.RemoveAllListeners();
				allTile2.onTileHoverExited.AddListener(fishingManager.OnTileHoverExited);
			}
		}
		Debug.Log("Initialized " + allTiles.Count + " pre-placed tiles. Pond Center: " + pondCenter.ToString() + ", Pond Size: " + pondSize.ToString());
	}

	public void CreateBubbleSpots(int numberOfSpots)
	{
		foreach (Tile allTile in allTiles)
		{
			allTile.SetBubbleSpot(isActive: false);
		}
		for (int i = 0; i < numberOfSpots; i++)
		{
			if (allTiles.Count > 0)
			{
				int index = Random.Range(0, allTiles.Count);
				if (!allTiles[index].isBubbleSpot)
				{
					allTiles[index].SetBubbleSpot(isActive: true);
				}
				else
				{
					i--;
				}
			}
		}
	}
}
