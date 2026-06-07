using System.Collections.Generic;
using LightTower;
using UnityEngine;

public class PathChunk : MonoBehaviour
{
	[SerializeField]
	private bool isStarterPathChunk;

	[SerializeField]
	private Vector2 chunkSize;

	[SerializeField]
	private int pathLength;

	[SerializeField]
	private int curvature;

	public Vector2 ChunkSize
	{
		get
		{
			return chunkSize;
		}
		private set
		{
			chunkSize = value;
		}
	}

	public int PathLength
	{
		get
		{
			return pathLength;
		}
		private set
		{
			pathLength = value;
		}
	}

	public int Curvature
	{
		get
		{
			return curvature;
		}
		private set
		{
			curvature = value;
		}
	}

	public bool IsStarterPathChunk => isStarterPathChunk;

	public PathTile[] GetPathTiles()
	{
		return GetComponentsInChildren<PathTile>();
	}

	public List<KeyValuePair<PathTile, EOrientation>> GetStarterPathTiles()
	{
		List<KeyValuePair<PathTile, EOrientation>> list = new List<KeyValuePair<PathTile, EOrientation>>();
		EOrientation value = EOrientation.None;
		PathTile[] pathTiles = GetPathTiles();
		foreach (PathTile pathTile in pathTiles)
		{
			if (IsBorderPathTile(pathTile))
			{
				if (pathTile.transform.localPosition.x == 0f && pathTile.GetPath(LTFunctionLibrary.OrientationToWorldSpace(EOrientation.West, base.transform)) != null)
				{
					value = LTFunctionLibrary.OrientationToWorldSpace(EOrientation.West, base.transform);
				}
				else if (pathTile.transform.localPosition.x == ChunkSize.x - 1f && pathTile.GetPath(LTFunctionLibrary.OrientationToWorldSpace(EOrientation.East, base.transform)) != null)
				{
					value = LTFunctionLibrary.OrientationToWorldSpace(EOrientation.East, base.transform);
				}
				else if (pathTile.transform.localPosition.z == 0f && pathTile.GetPath(LTFunctionLibrary.OrientationToWorldSpace(EOrientation.South, base.transform)) != null)
				{
					value = LTFunctionLibrary.OrientationToWorldSpace(EOrientation.South, base.transform);
				}
				else if (pathTile.transform.localPosition.z == ChunkSize.y - 1f && pathTile.GetPath(LTFunctionLibrary.OrientationToWorldSpace(EOrientation.North, base.transform)) != null)
				{
					value = LTFunctionLibrary.OrientationToWorldSpace(EOrientation.North, base.transform);
				}
				list.Add(new KeyValuePair<PathTile, EOrientation>(pathTile, value));
			}
		}
		return list;
	}

	private bool IsBorderPathTile(PathTile pathTile)
	{
		if ((pathTile.transform.localPosition.x != 0f || pathTile.GetPath(LTFunctionLibrary.OrientationToWorldSpace(EOrientation.West, base.transform)) == null) && (pathTile.transform.localPosition.z != 0f || pathTile.GetPath(LTFunctionLibrary.OrientationToWorldSpace(EOrientation.South, base.transform)) == null) && (pathTile.transform.localPosition.x != ChunkSize.x - 1f || pathTile.GetPath(LTFunctionLibrary.OrientationToWorldSpace(EOrientation.East, base.transform)) == null))
		{
			if (pathTile.transform.localPosition.z == ChunkSize.y - 1f)
			{
				return pathTile.GetPath(LTFunctionLibrary.OrientationToWorldSpace(EOrientation.North, base.transform)) != null;
			}
			return false;
		}
		return true;
	}

	private void CalculateChunkSize()
	{
		new List<PathTile>();
		Vector2 zero = Vector2.zero;
		PathTile[] pathTiles = GetPathTiles();
		foreach (PathTile pathTile in pathTiles)
		{
			zero.x = Mathf.Max(zero.x, pathTile.transform.localPosition.x + 1f);
			zero.y = Mathf.Max(zero.y, pathTile.transform.localPosition.z + 1f);
		}
		ChunkSize = zero;
	}

	private void CalculatePathProperties()
	{
		PathTile[] pathTiles = GetPathTiles();
		foreach (PathTile pathTile in pathTiles)
		{
			pathTile.transform.position = new Vector3(Mathf.RoundToInt(pathTile.transform.position.x), Mathf.RoundToInt(pathTile.transform.position.y), Mathf.RoundToInt(pathTile.transform.position.z));
		}
		List<KeyValuePair<PathTile, EOrientation>> starterPathTiles = GetStarterPathTiles();
		if (starterPathTiles.Count > 0)
		{
			List<PathTile> visitedPathTiles = new List<PathTile>();
			int num = 0;
			GetPathTileDistanceFromEnd(starterPathTiles[0].Key, starterPathTiles[0].Value, ref visitedPathTiles, ref num);
			PathLength = num;
		}
		else
		{
			PathLength = 0;
		}
		if (starterPathTiles[0].Value == LTFunctionLibrary.InverseOrientation(starterPathTiles[1].Value))
		{
			curvature = 0;
		}
		else if (starterPathTiles[0].Value == LTFunctionLibrary.RightOrientation(starterPathTiles[1].Value))
		{
			curvature = 1;
		}
		else if (starterPathTiles[0].Value == LTFunctionLibrary.LeftOrientation(starterPathTiles[1].Value))
		{
			curvature = -1;
		}
	}

	private bool GetPathTileDistanceFromEnd(PathTile pathTile, EOrientation startOrientation, ref List<PathTile> visitedPathTiles, ref int pathLength)
	{
		List<PathTile> nextPathTiles = LTFunctionLibrary.GetNextPathTiles(pathTile, startOrientation, GetComponentsInChildren<PathTile>());
		if (nextPathTiles.Count == 0)
		{
			pathLength = 1;
			return true;
		}
		visitedPathTiles.Add(pathTile);
		int num = 0;
		bool flag = false;
		foreach (PathTile item in nextPathTiles)
		{
			if (!visitedPathTiles.Contains(item))
			{
				EOrientation orientationBetweenPositions = LTFunctionLibrary.GetOrientationBetweenPositions(item.transform.position, pathTile.transform.position);
				if (GetPathTileDistanceFromEnd(item, orientationBetweenPositions, ref visitedPathTiles, ref pathLength))
				{
					num = Mathf.Max(num, pathLength);
					flag = true;
				}
			}
		}
		visitedPathTiles.Remove(pathTile);
		if (!flag)
		{
			return false;
		}
		pathLength = num;
		pathLength++;
		return true;
	}
}
