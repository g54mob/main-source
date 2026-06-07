using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
	public static TileManager instance;

	[SerializeField]
	private GameObject tilePlacementFXObject;

	[SerializeField]
	private GameObject[] deadEndTiles;

	[SerializeField]
	private GameObject[] Ltiles;

	[SerializeField]
	private GameObject[] Ttiles;

	[SerializeField]
	private GameObject[] Rtiles;

	[SerializeField]
	private GameObject[] LTtiles;

	[SerializeField]
	private GameObject[] LRtiles;

	[SerializeField]
	private GameObject[] TRtiles;

	[SerializeField]
	private GameObject[] LTRtiles;

	public TerrainTile startTile;

	[SerializeField]
	private GameObject tileSpawnLocation;

	private int[,] intArray = new int[99, 99];

	private TerrainTile[,] tileArray = new TerrainTile[99, 99];

	public bool splitMode;

	private void Awake()
	{
		instance = this;
	}

	private void Start()
	{
		intArray[50, 50] = 1;
		tileArray[50, 50] = startTile;
		for (int i = 0; i < 99; i++)
		{
			intArray[0, i] = 1;
			intArray[i, 0] = 1;
			intArray[98, i] = 1;
			intArray[i, 98] = 1;
		}
		UpdateIntArrayFromTile(startTile, 50, 50);
		if (PlayerPrefs.GetInt("SplitMode", 0) == 1)
		{
			splitMode = true;
			Debug.Log("Splitsville");
		}
	}

	private void UpdateIntArrayFromTile(TerrainTile tile, int posX, int posY)
	{
		if (tile.south != null && tile.south != tile.last && intArray[posX, posY - 1] == 0)
		{
			intArray[posX, posY - 1] = 2;
			TileSpawnLocation component = Object.Instantiate(tileSpawnLocation, new Vector3(posX - 50, 0f, posY - 1 - 50) * 7f, Quaternion.identity).GetComponent<TileSpawnLocation>();
			component.eulerAngle = 180;
			component.posX = posX;
			component.posY = posY - 1;
		}
		if (tile.west != null && tile.west != tile.last && intArray[posX - 1, posY] == 0)
		{
			intArray[posX - 1, posY] = 2;
			TileSpawnLocation component2 = Object.Instantiate(tileSpawnLocation, new Vector3(posX - 1 - 50, 0f, posY - 50) * 7f, Quaternion.identity).GetComponent<TileSpawnLocation>();
			component2.eulerAngle = 270;
			component2.posX = posX - 1;
			component2.posY = posY;
		}
		if (tile.north != null && tile.north != tile.last && intArray[posX, posY + 1] == 0)
		{
			intArray[posX, posY + 1] = 2;
			TileSpawnLocation component3 = Object.Instantiate(tileSpawnLocation, new Vector3(posX - 50, 0f, posY + 1 - 50) * 7f, Quaternion.identity).GetComponent<TileSpawnLocation>();
			component3.eulerAngle = 0;
			component3.posX = posX;
			component3.posY = posY + 1;
		}
		if (tile.east != null && tile.east != tile.last && intArray[posX + 1, posY] == 0)
		{
			intArray[posX + 1, posY] = 2;
			TileSpawnLocation component4 = Object.Instantiate(tileSpawnLocation, new Vector3(posX + 1 - 50, 0f, posY - 50) * 7f, Quaternion.identity).GetComponent<TileSpawnLocation>();
			component4.eulerAngle = 90;
			component4.posX = posX + 1;
			component4.posY = posY;
		}
	}

	public void SpawnNewTile(int posX, int posY, int eulerAngle)
	{
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		bool flag4 = false;
		if (intArray[posX, posY - 1] == 0)
		{
			flag = true;
		}
		if (intArray[posX - 1, posY] == 0)
		{
			flag2 = true;
		}
		if (intArray[posX, posY + 1] == 0)
		{
			flag3 = true;
		}
		if (intArray[posX + 1, posY] == 0)
		{
			flag4 = true;
		}
		bool left = false;
		bool top = false;
		bool right = false;
		switch (eulerAngle)
		{
		case 0:
			left = flag2;
			top = flag3;
			right = flag4;
			break;
		case 90:
			left = flag3;
			top = flag4;
			right = flag;
			break;
		case 180:
			left = flag4;
			top = flag;
			right = flag2;
			break;
		case 270:
			left = flag;
			top = flag2;
			right = flag3;
			break;
		default:
			Debug.LogError("Trying to spawn a tile at an invalid eulerAngle" + eulerAngle);
			break;
		}
		List<GameObject> spawnList = new List<GameObject>();
		int num = SpawnManager.instance.lastLevel - SpawnManager.instance.level;
		int count = SpawnManager.instance.tileSpawnUis.Count;
		bool flag5 = false;
		bool flag6 = false;
		int num2 = GameManager.instance.gameMode * 3;
		if (count + 3 >= num || (SpawnManager.instance.level < num2 && !splitMode))
		{
			flag5 = true;
		}
		if (count == num)
		{
			flag6 = true;
		}
		if (!flag6)
		{
			if (splitMode && !flag5)
			{
				SpawnSelectionSplitMode(ref spawnList, left, top, right, flag5);
			}
			else
			{
				SpawnSelectionNormal(ref spawnList, left, top, right, flag5);
			}
		}
		if (spawnList.Count == 0)
		{
			spawnList.AddRange(deadEndTiles);
		}
		GameObject original = spawnList[Random.Range(0, spawnList.Count)];
		Vector3 vector = new Vector3(posX - 50, 0f, posY - 50) * 7f;
		GameObject obj = Object.Instantiate(original, vector, Quaternion.identity);
		obj.transform.eulerAngles = new Vector3(0f, eulerAngle, 0f);
		intArray[posX, posY] = 1;
		TerrainTile component = obj.GetComponent<TerrainTile>();
		tileArray[posX, posY] = component;
		component.SetCardinalDirections();
		UpdateIntArrayFromTile(component, posX, posY);
		TerrainTile terrainTile = null;
		switch (eulerAngle)
		{
		case 0:
			terrainTile = tileArray[posX, posY - 1];
			break;
		case 90:
			terrainTile = tileArray[posX - 1, posY];
			break;
		case 180:
			terrainTile = tileArray[posX, posY + 1];
			break;
		case 270:
			terrainTile = tileArray[posX + 1, posY];
			break;
		default:
			Debug.LogError("Trying to spawn a tile at an invalid eulerAngle" + eulerAngle);
			break;
		}
		if (terrainTile == null)
		{
			Debug.LogError("Unable to find previous tile");
		}
		component.ConnectToTile(terrainTile);
		if (tilePlacementFXObject != null)
		{
			Object.Instantiate(tilePlacementFXObject, vector + Vector3.up, Quaternion.identity).transform.localScale = Vector3.one * 7f;
		}
	}

	private void SpawnSelectionNormal(ref List<GameObject> spawnList, bool left, bool top, bool right, bool onlySingles)
	{
		if (left)
		{
			spawnList.AddRange(Ltiles);
		}
		if (top)
		{
			spawnList.AddRange(Ttiles);
		}
		if (right)
		{
			spawnList.AddRange(Rtiles);
		}
		if (left && top && !onlySingles)
		{
			spawnList.AddRange(LTtiles);
		}
		if (left && right && !onlySingles)
		{
			spawnList.AddRange(LRtiles);
		}
		if (top && right && !onlySingles)
		{
			spawnList.AddRange(TRtiles);
		}
		if (left && top && right && !onlySingles)
		{
			spawnList.AddRange(LTRtiles);
		}
	}

	private void SpawnSelectionSplitMode(ref List<GameObject> spawnList, bool left, bool top, bool right, bool onlySingles)
	{
		if (left && top && !onlySingles)
		{
			spawnList.AddRange(LTtiles);
		}
		if (left && right && !onlySingles)
		{
			spawnList.AddRange(LRtiles);
		}
		if (top && right && !onlySingles)
		{
			spawnList.AddRange(TRtiles);
		}
		if (left && top && right && !onlySingles)
		{
			spawnList.AddRange(LTRtiles);
		}
		if (spawnList.Count == 0)
		{
			if (left)
			{
				spawnList.AddRange(Ltiles);
			}
			if (top)
			{
				spawnList.AddRange(Ttiles);
			}
			if (right)
			{
				spawnList.AddRange(Rtiles);
			}
		}
	}
}
