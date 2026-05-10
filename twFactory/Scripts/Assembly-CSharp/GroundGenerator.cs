using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using LightTower;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{
	[SerializeField]
	private WeightedRandomSelector<Tile> groundTiles;

	[Header("Ground chunks")]
	[SerializeField]
	private List<BaseSpawnerData> groundChunksSpawnerDatas;

	[Header("Border tiles")]
	[SerializeField]
	private Tile borderTilePrefab;

	[SerializeField]
	private int mapBorderWidth = 5;

	private Transform groundContainer;

	private Transform borderContainer;

	private Transform GroundContainer
	{
		get
		{
			if (groundContainer != null)
			{
				return groundContainer;
			}
			foreach (Transform item in base.transform)
			{
				if (item.name == "GroundContainer")
				{
					GroundContainer = item;
					return groundContainer;
				}
			}
			GroundContainer = new GameObject("GroundContainer").transform;
			GroundContainer.SetParent(base.transform);
			return groundContainer;
		}
		set
		{
			groundContainer = value;
		}
	}

	private Transform BorderContainer
	{
		get
		{
			if (borderContainer == null)
			{
				foreach (Transform item in base.transform)
				{
					if (item.name == "BorderContainer")
					{
						BorderContainer = item;
						return borderContainer;
					}
				}
				BorderContainer = new GameObject("BorderContainer").transform;
				BorderContainer.SetParent(base.transform);
			}
			return borderContainer;
		}
		set
		{
			borderContainer = value;
		}
	}

	public IEnumerator GenerateGround(KeyValuePair<PathTile, EOrientation> firstPathTile, KeyValuePair<PathTile, EOrientation> lastPathTile, Grid grid, PathTile[] pathTiles)
	{
		Stopwatch stopwatch = new Stopwatch();
		stopwatch.Start();
		GroundContainer.DeleteAllChildrenImmediate();
		SpawnGroundChunks(firstPathTile, lastPathTile, grid, pathTiles);
		yield return SpawnFillTiles(grid);
		GenerateBorder(grid);
		stopwatch.Stop();
		UnityEngine.Debug.Log("GROUND: " + (float)stopwatch.ElapsedMilliseconds / 1000f + "s");
	}

	private void SpawnGroundChunks(KeyValuePair<PathTile, EOrientation> firstPathTile, KeyValuePair<PathTile, EOrientation> lastPathTile, Grid grid, PathTile[] pathTiles)
	{
		grid.GetGridSize();
		foreach (BaseSpawnerData groundChunksSpawnerData in groundChunksSpawnerDatas)
		{
			if (!groundChunksSpawnerData || groundChunksSpawnerData.ObjectsAmount <= 0)
			{
				continue;
			}
			List<(Vector3, float)> list = new List<(Vector3, float)>();
			list.Add((firstPathTile.Key.transform.position, groundChunksSpawnerData.PlayerTowerInvalidAreaRange));
			list.Add((lastPathTile.Key.transform.position, groundChunksSpawnerData.EnemyTowerInvalidAreaRange));
			foreach (PathTile pathTile in pathTiles)
			{
				list.Add((pathTile.transform.position.XZ(), Mathf.Max(groundChunksSpawnerData.PathInvalidAreaRange, 1f)));
			}
			List<Vector2> list2 = null;
			if (!(groundChunksSpawnerData is CircleBasedSpawnerData))
			{
				if (!(groundChunksSpawnerData is GridBasedSpawnerData))
				{
					if (groundChunksSpawnerData is PathBasedSpawnerData)
					{
						list2 = (groundChunksSpawnerData as PathBasedSpawnerData).GetRandomPositions(grid, pathTiles, list);
					}
				}
				else
				{
					list2 = (groundChunksSpawnerData as GridBasedSpawnerData).GetRandomPositions(grid, list);
				}
			}
			else
			{
				list2 = (groundChunksSpawnerData as CircleBasedSpawnerData).GetRandomPositions(grid, firstPathTile.Key.transform.position, list);
			}
			int[] array = Enumerable.Range(0, groundChunksSpawnerData.ObjectsToSpawn.Elements.Count).ToArray();
			int num = 0;
			groundChunksSpawnerData.ObjectsToSpawn.ResetSelector();
			int num2 = 0;
			while (num < groundChunksSpawnerData.ObjectsAmount)
			{
				if (list2.Count == 0)
				{
					UnityEngine.Debug.LogWarning("No se pudieron spawnear todos los objetos ya que no se consiguieron generar suficientes posiciones válidas (" + groundChunksSpawnerData.ObjectsToSpawn.Name + ")");
					break;
				}
				Vector3 centerPosition = grid.SnapPositionToGrid(list2[list2.Count - 1].XZ());
				list2.RemoveAt(list2.Count - 1);
				array.Shuffle();
				for (int j = 0; j < array.Length; j++)
				{
					if (TrySpawnGroundChunk(grid, groundChunksSpawnerData.ObjectsToSpawn.GetRandomElement_roundRobin(), centerPosition, groundChunksSpawnerData.BuildableRadiusAroundObject, groundChunksSpawnerData.ExcludedTileTypes))
					{
						num++;
						break;
					}
				}
				num2++;
			}
		}
	}

	private IEnumerator SpawnFillTiles(Grid grid)
	{
		int maxTilesPerFrame = 2500;
		int tilesSpawnedThisFrame = 0;
		groundTiles.ResetSelector();
		for (int i = 0; i < grid.GetGridSize().x; i++)
		{
			for (int j = 0; j < grid.GetGridSize().y; j++)
			{
				if (grid.GetGridCell(i, j) == null || grid.GetGridCell(i, j).Tile == null)
				{
					grid.AddGridCell(Object.Instantiate(groundTiles.GetRandomElement(), new Vector3(i, 0f, j), Quaternion.identity * Quaternion.AngleAxis(Random.Range(0, 4) * 90, Vector3.up), GroundContainer));
					tilesSpawnedThisFrame++;
					if (tilesSpawnedThisFrame >= maxTilesPerFrame)
					{
						tilesSpawnedThisFrame = 0;
						yield return null;
					}
				}
			}
		}
	}

	private void GenerateBorder(Grid grid)
	{
		BorderContainer.DeleteAllChildrenImmediate();
		for (int i = -mapBorderWidth; i < grid.GetGridSize().x + mapBorderWidth; i++)
		{
			for (int j = -mapBorderWidth; j < grid.GetGridSize().y + mapBorderWidth; j++)
			{
				if (grid.GetGridCell(i, j) == null)
				{
					Object.Instantiate(borderTilePrefab, new Vector3(i, 0f, j), Quaternion.identity, BorderContainer);
				}
			}
		}
	}

	private bool CanFitGroundChunk(Grid grid, GroundChunk groundChunk, Vector3 position, int rotation)
	{
		Tile[] tiles = groundChunk.GetTiles();
		foreach (Tile tile in tiles)
		{
			Vector3 position2 = Quaternion.AngleAxis(rotation, Vector3.up) * tile.transform.localPosition + position;
			if (!grid.IsPositionInGrid(position2))
			{
				return false;
			}
			if (grid.GetGridCell(position2) != null)
			{
				return false;
			}
		}
		return true;
	}

	private bool TrySpawnGroundChunk(Grid grid, GameObject groundChunkPrefab, Vector3 centerPosition, int buildableRadiusAroundObject, Tile.ETileType[] excludedTileTypes)
	{
		GroundChunk component = groundChunkPrefab.GetComponent<GroundChunk>();
		int num = 90 * Random.Range(-1, 3);
		for (int i = 0; i < 4; i++)
		{
			num = (num + 90) % 360;
			if (!CanFitGroundChunk(grid, component, centerPosition, num))
			{
				continue;
			}
			GroundChunk component2 = Object.Instantiate(groundChunkPrefab, centerPosition, Quaternion.AngleAxis(num, Vector3.up), GroundContainer).GetComponent<GroundChunk>();
			if (buildableRadiusAroundObject > 0 && !LTFunctionLibrary.CanBuildAroundPosition(grid, component2.GetOccupiedPositions(), buildableRadiusAroundObject, excludedTileTypes))
			{
				Object.DestroyImmediate(component2.gameObject);
				continue;
			}
			Tile[] tiles = component2.GetTiles();
			foreach (Tile tile in tiles)
			{
				TryAssignTileToGrid(grid, tile, tile.transform.position);
			}
			return true;
		}
		return false;
	}

	private bool TryAssignTileToGrid(Grid grid, Tile tile, Vector3 position)
	{
		if (grid.GetGridCell(position) == null)
		{
			grid.AddGridCell(tile);
			return true;
		}
		return false;
	}
}
