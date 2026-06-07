using System;
using System.Collections.Generic;
using System.Linq;
using LightTower;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
	[Serializable]
	private struct FPathTilesPrefabs
	{
		public GameObject straight;

		public GameObject curve;

		public GameObject cross3;
	}

	[SerializeField]
	private List<PathChunk> availableStarterPathChunks;

	[SerializeField]
	private List<PathChunk> availablePathChunks;

	[SerializeField]
	private FPathTilesPrefabs pathTilesPrefabs;

	[SerializeField]
	[Tooltip("Longitud del camino que se considera \"starter\", donde solo se colocan starter path chunks")]
	private int starterPathLength = 1;

	[SerializeField]
	private int totalPathLength = 10;

	[SerializeField]
	[Tooltip("Cantidad máxima de curvas que se pueden poner en el mismo sentido sin \"deshacer\" con curvas en sentido contrario)")]
	private int maxPathCurvature;

	[SerializeField]
	[Tooltip("Tamaño de área cuadrada alrededor de la torre del jugador en la cual no podrá haber casillas de camino que no sean starter path")]
	private int playerSafeAreaWidth = 10;

	[SerializeField]
	[Tooltip("Tamaño de área cuadrada alrededor de la torre del enemigo en la cual no podrá haber casillas de camino")]
	private int enemySafeAreaWidth = 10;

	[SerializeField]
	[Tooltip("Distancia mínima entre el principio y el final del camino")]
	private int minDistanceBetweenEnds;

	private Transform pathContainer;

	private KeyValuePair<PathTile, EOrientation> firstPathTile;

	private KeyValuePair<PathTile, EOrientation> lastPathTile;

	public int StarterPathLength => starterPathLength;

	public int TotalPathLength => totalPathLength;

	private Transform PathContainer
	{
		get
		{
			if (pathContainer == null)
			{
				foreach (Transform item in base.transform)
				{
					if (item.name == "PathContainer")
					{
						PathContainer = item;
						return pathContainer;
					}
				}
				PathContainer = new GameObject("PathContainer").transform;
				PathContainer.SetParent(base.transform);
			}
			return pathContainer;
		}
		set
		{
			pathContainer = value;
		}
	}

	public KeyValuePair<PathTile, EOrientation> FirstPathTile
	{
		get
		{
			return firstPathTile;
		}
		private set
		{
			firstPathTile = value;
		}
	}

	public KeyValuePair<PathTile, EOrientation> LastPathTile
	{
		get
		{
			return lastPathTile;
		}
		private set
		{
			lastPathTile = value;
		}
	}

	private bool IsStarterPathChunk(PathChunk pathChunk)
	{
		return pathChunk.IsStarterPathChunk;
	}

	private bool IsNotStarterPathChunk(PathChunk pathChunk)
	{
		return !pathChunk.IsStarterPathChunk;
	}

	public bool GeneratePath()
	{
		PathContainer.DeleteAllChildrenImmediate();
		PathContainer.transform.position = Vector3.zero;
		FirstPathTile = default(KeyValuePair<PathTile, EOrientation>);
		LastPathTile = default(KeyValuePair<PathTile, EOrientation>);
		Vector3 startPosition = Vector3.zero;
		EOrientation eOrientation = EOrientation.South;
		PathChunk pathChunk = null;
		int currentStarterPathTileIndex = 0;
		int i = 0;
		int num = 0;
		KeyValuePair<PathTile, EOrientation> auxStarterPathTile = default(KeyValuePair<PathTile, EOrientation>);
		HashSet<Vector2Int> hashSet = new HashSet<Vector2Int>();
		bool flag = false;
		PathTile[] pathTiles;
		for (; i < TotalPathLength; i += pathChunk.PathLength)
		{
			pathChunk = TryToPlaceNextChunk(ref currentStarterPathTileIndex, ref auxStarterPathTile, i, num, startPosition, eOrientation, hashSet);
			if (!pathChunk)
			{
				return false;
			}
			if (!flag && i >= starterPathLength)
			{
				Vector2 frontDirection = LTFunctionLibrary.GetDirectionFromOrientation(FirstPathTile.Value).XZ();
				AddPlayerTowerSafeAreaPositions(hashSet, frontDirection, Vector2Int.RoundToInt(FirstPathTile.Key.transform.position.XZ()), playerSafeAreaWidth);
				flag = true;
			}
			if (FirstPathTile.Key == null)
			{
				FirstPathTile = new KeyValuePair<PathTile, EOrientation>(auxStarterPathTile.Key, eOrientation);
			}
			pathTiles = pathChunk.GetPathTiles();
			foreach (PathTile pathTile in pathTiles)
			{
				hashSet.Add(Vector2Int.RoundToInt(pathTile.transform.position.XZ()));
			}
			auxStarterPathTile = pathChunk.GetStarterPathTiles()[(currentStarterPathTileIndex + 1) % 2];
			eOrientation = auxStarterPathTile.Value;
			startPosition = auxStarterPathTile.Key.transform.position + LTFunctionLibrary.GetDirectionFromOrientation(eOrientation);
			num += pathChunk.Curvature * ((currentStarterPathTileIndex == 0) ? 1 : (-1));
		}
		LastPathTile = auxStarterPathTile;
		if ((FirstPathTile.Key.transform.position - LastPathTile.Key.transform.position).sqrMagnitude < (float)(minDistanceBetweenEnds * minDistanceBetweenEnds))
		{
			return false;
		}
		CenterPathTiles(hashSet);
		HashSet<Vector2Int> hashSet2 = new HashSet<Vector2Int>();
		pathTiles = pathChunk.GetPathTiles();
		foreach (PathTile pathTile2 in pathTiles)
		{
			hashSet2.Add(Vector2Int.RoundToInt(pathTile2.transform.position.XZ()));
		}
		Vector2 frontDirection2 = LTFunctionLibrary.GetDirectionFromOrientation(LTFunctionLibrary.InverseOrientation(LastPathTile.Value)).XZ();
		if (!CheckEnemyTowerSafeAreaPositions(hashSet, Vector2Int.RoundToInt(LastPathTile.Key.transform.position.XZ()), frontDirection2, enemySafeAreaWidth, hashSet2))
		{
			return false;
		}
		ReplacePathChunkTiles(PathContainer.GetComponentsInChildren<PathTile>());
		AutoConfigureNextPathTiles();
		return true;
	}

	private void AutoConfigureNextPathTiles()
	{
		List<KeyValuePair<PathTile, EOrientation>> list = new List<KeyValuePair<PathTile, EOrientation>>();
		list.Add(LastPathTile);
		ICollection<PathTile> componentsInChildren = PathContainer.GetComponentsInChildren<PathTile>();
		List<PathTile> visitedPathTiles = new List<PathTile>();
		foreach (KeyValuePair<PathTile, EOrientation> item in list)
		{
			SetupNextPathTile(item.Key, item.Value, componentsInChildren, visitedPathTiles, list, FirstPathTile.Key);
		}
	}

	private List<PathTile> SetupNextPathTile(PathTile currentPathTile, EOrientation startOrientation, ICollection<PathTile> allPathTiles, List<PathTile> visitedPathTiles, List<KeyValuePair<PathTile, EOrientation>> enemySidePathTiles, PathTile playerSidePathTile)
	{
		List<PathTile> list = new List<PathTile>();
		if (visitedPathTiles.Contains(currentPathTile))
		{
			if (currentPathTile.NextPathTiles == null || currentPathTile.NextPathTiles.Count == 0)
			{
				return null;
			}
			list.Add(currentPathTile);
			return list;
		}
		List<PathTile> nextPathTiles = LTFunctionLibrary.GetNextPathTiles(currentPathTile, startOrientation, allPathTiles);
		visitedPathTiles.Add(currentPathTile);
		if (nextPathTiles.Count == 0)
		{
			if (currentPathTile == playerSidePathTile)
			{
				list.Add(currentPathTile);
				return list;
			}
			return null;
		}
		List<PathTile> list2 = new List<PathTile>();
		foreach (PathTile item in nextPathTiles)
		{
			EOrientation orientationBetweenPositions = LTFunctionLibrary.GetOrientationBetweenPositions(item.transform.position, currentPathTile.transform.position);
			list2 = SetupNextPathTile(item, orientationBetweenPositions, allPathTiles, visitedPathTiles, enemySidePathTiles, playerSidePathTile);
			if (list2 == null || list2.Count == 0)
			{
				visitedPathTiles.Remove(item);
				continue;
			}
			currentPathTile.NextPathTiles.AddRange(list2);
			list.AddUnique(currentPathTile);
		}
		return list;
	}

	private PathChunk TryToPlaceNextChunk(ref int currentStarterPathTileIndex, ref KeyValuePair<PathTile, EOrientation> auxStarterPathTile, int currentPathLength, int totalPathCurvature, Vector3 startPosition, EOrientation startOrientation, HashSet<Vector2Int> occupiedPositions)
	{
		PathChunk pathChunk = null;
		List<int> list = Enumerable.Range(0, availableStarterPathChunks.Count).ToList();
		list.Shuffle();
		List<int> list2 = Enumerable.Range(0, availablePathChunks.Count).ToList();
		list2.Shuffle();
		bool flag = false;
		bool flag2 = false;
		while (!flag && list.Count > 0 && list2.Count > 0)
		{
			flag = true;
			if (flag2)
			{
				currentStarterPathTileIndex = (currentStarterPathTileIndex + 1) % 2;
			}
			else
			{
				pathChunk = InstantiateNextPathChunk(currentPathLength, list, list2, PathContainer);
				currentStarterPathTileIndex = UnityEngine.Random.Range(0, 2);
			}
			auxStarterPathTile = pathChunk.GetStarterPathTiles()[currentStarterPathTileIndex];
			Quaternion quaternion = auxStarterPathTile.Key.transform.rotation * LTFunctionLibrary.GetRotationFromToOrientation(auxStarterPathTile.Value, LTFunctionLibrary.InverseOrientation(startOrientation));
			pathChunk.transform.position = startPosition - quaternion * Quaternion.Inverse(auxStarterPathTile.Key.transform.localRotation) * auxStarterPathTile.Key.transform.localPosition;
			pathChunk.transform.rotation = quaternion * Quaternion.Inverse(auxStarterPathTile.Key.transform.localRotation);
			if (!IsValidCurvature(totalPathCurvature, pathChunk.Curvature * ((currentStarterPathTileIndex == 0) ? 1 : (-1))) || AreChunkPositionsAlreadyOccupied(pathChunk, occupiedPositions))
			{
				flag = false;
				flag2 = !flag2;
				if (!flag2)
				{
					UnityEngine.Object.DestroyImmediate(pathChunk.gameObject);
				}
			}
		}
		if (flag)
		{
			return pathChunk;
		}
		return null;
	}

	private PathChunk InstantiateNextPathChunk(int currentPathLength, List<int> availableStarterPathChunksIndexes, List<int> availablePathChunksIndexes, Transform parent)
	{
		PathChunk result;
		if (currentPathLength < starterPathLength)
		{
			result = UnityEngine.Object.Instantiate(availableStarterPathChunks[availableStarterPathChunksIndexes[0]], pathContainer);
			availableStarterPathChunksIndexes.RemoveAt(0);
		}
		else
		{
			result = UnityEngine.Object.Instantiate(availablePathChunks[availablePathChunksIndexes[0]], pathContainer);
			availablePathChunksIndexes.RemoveAt(0);
		}
		return result;
	}

	private void ReplacePathChunkTiles(PathTile[] tiles)
	{
		for (int i = 0; i < tiles.Length; i++)
		{
			Transform child = tiles[i].transform.GetChild(0);
			if ((bool)GetPathTilePrefabByType(tiles[i].PathTileType))
			{
				UnityEngine.Object.Instantiate(GetPathTilePrefabByType(tiles[i].PathTileType), child.position, child.rotation, child.parent);
				UnityEngine.Object.DestroyImmediate(child.gameObject);
			}
		}
	}

	private bool IsValidCurvature(int totalPathCurvature, int curvature)
	{
		if (curvature != 0)
		{
			return Mathf.Abs(totalPathCurvature + curvature) <= maxPathCurvature;
		}
		return true;
	}

	private bool AreChunkPositionsAlreadyOccupied(PathChunk pathChunk, HashSet<Vector2Int> occupiedPositions)
	{
		PathTile[] pathTiles = pathChunk.GetPathTiles();
		foreach (PathTile pathTile in pathTiles)
		{
			if (occupiedPositions.Contains(Vector2Int.RoundToInt(pathTile.transform.position.XZ())))
			{
				return true;
			}
		}
		return false;
	}

	public Vector2 GetPathPosition()
	{
		return PathContainer.transform.position.XZ();
	}

	public void SetPathPosition(Vector2 position)
	{
		PathContainer.transform.position = position.XZ();
	}

	public void AddPathPosition(Vector2 position)
	{
		PathContainer.transform.position += position.XZ();
	}

	public PathTile[] GetPathTiles()
	{
		if ((bool)pathContainer)
		{
			return pathContainer.GetComponentsInChildren<PathTile>();
		}
		return null;
	}

	public Vector2Int GetPathBoundingSize()
	{
		Vector2Int zero = Vector2Int.zero;
		foreach (Transform item in pathContainer)
		{
			foreach (Transform item2 in item)
			{
				if (item2.position.x > (float)zero.x)
				{
					zero.x = Mathf.RoundToInt(item2.position.x);
				}
				if (item2.position.z > (float)zero.y)
				{
					zero.y = Mathf.RoundToInt(item2.position.z);
				}
			}
		}
		return zero + Vector2Int.one;
	}

	private void CenterPathTiles(HashSet<Vector2Int> occupiedPositionsSet)
	{
		float num = 2.1474836E+09f;
		float num2 = 2.1474836E+09f;
		foreach (Transform item in pathContainer)
		{
			foreach (Transform item2 in item)
			{
				if (item2.position.x < num)
				{
					num = item2.position.x;
				}
				if (item2.position.z < num2)
				{
					num2 = item2.position.z;
				}
			}
		}
		foreach (Transform item3 in pathContainer)
		{
			item3.position -= new Vector3(num, 0f, num2);
		}
		occupiedPositionsSet.Clear();
		PathTile[] pathTiles = GetPathTiles();
		foreach (PathTile pathTile in pathTiles)
		{
			occupiedPositionsSet.Add(Vector2Int.RoundToInt(pathTile.transform.position.XZ()));
		}
	}

	private void AddPlayerTowerSafeAreaPositions(HashSet<Vector2Int> occupiedPositionsHash, Vector2 frontDirection, Vector2Int centerPosition, int safeAreaWidth)
	{
		for (int i = centerPosition.x - safeAreaWidth / 2; i < centerPosition.x + safeAreaWidth / 2; i++)
		{
			for (int j = centerPosition.y - safeAreaWidth / 2; j < centerPosition.y + safeAreaWidth / 2; j++)
			{
				if (Vector2.Dot(frontDirection, ((Vector2)(new Vector2Int(i, j) - centerPosition)).normalized) < 0.3f)
				{
					occupiedPositionsHash.Add(new Vector2Int(i, j));
				}
			}
		}
	}

	private bool CheckEnemyTowerSafeAreaPositions(HashSet<Vector2Int> occupiedPositionsHash, Vector2Int centerPosition, Vector2 frontDirection, int safeAreaWidth, HashSet<Vector2Int> ignoredPositions)
	{
		for (int i = centerPosition.x - safeAreaWidth / 2; i < centerPosition.x + safeAreaWidth / 2; i++)
		{
			for (int j = centerPosition.y - safeAreaWidth / 2; j < centerPosition.y + safeAreaWidth / 2; j++)
			{
				Vector2Int vector2Int = new Vector2Int(i, j);
				if (Vector2.Dot(frontDirection, ((Vector2)(vector2Int - centerPosition)).normalized) < 0.3f && !ignoredPositions.Contains(vector2Int) && occupiedPositionsHash.Contains(vector2Int))
				{
					return false;
				}
			}
		}
		return true;
	}

	private GameObject GetPathTilePrefabByType(PathTile.EPathTileType tileType)
	{
		return tileType switch
		{
			PathTile.EPathTileType.Straigth => pathTilesPrefabs.straight, 
			PathTile.EPathTileType.Curve => pathTilesPrefabs.curve, 
			PathTile.EPathTileType.Cross3 => pathTilesPrefabs.cross3, 
			_ => null, 
		};
	}
}
