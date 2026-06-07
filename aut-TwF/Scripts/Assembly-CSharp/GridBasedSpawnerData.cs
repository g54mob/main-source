using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GridBasedSpawnerData_default", menuName = "Tower Factory/Procedural Generation/Grid Based Spawner Data")]
public class GridBasedSpawnerData : BaseSpawnerData
{
	[SerializeField]
	private int subdivisions = 5;

	[SerializeField]
	private float subdivisionsSize;

	[SerializeField]
	private bool useSubdivisionsSize;

	[SerializeField]
	[Range(0f, 1f)]
	private float randomOffsetBias = 0.85f;

	[SerializeField]
	private CircleBasedSpawnerData subResource;

	[SerializeField]
	[Range(0f, 1f)]
	private float subresourceSpawnProbability;

	public float RandomOffsetBias => randomOffsetBias;

	public CircleBasedSpawnerData SubResource => subResource;

	public float SubresourceSpawnProbability => subresourceSpawnProbability;

	public int GetSubdivisions()
	{
		return subdivisions;
	}

	public int GetSubdivisions(Grid grid)
	{
		if (useSubdivisionsSize)
		{
			Vector2Int gridSize = grid.GetGridSize();
			return Mathf.RoundToInt((float)Mathf.Max(gridSize.x, gridSize.y) / subdivisionsSize);
		}
		return subdivisions;
	}

	public List<Vector2> GetRandomPositions(Grid grid, List<(Vector3, float)> invalidAreas)
	{
		List<Vector2> randomGridBasedPositions = LTFunctionLibrary.GetRandomGridBasedPositions(grid.GetGridSize(), GetSubdivisions(grid), base.DistanceFromBorders, RandomOffsetBias, invalidAreas, base.MaxIterations, base.MinDistanceBetweenObjects);
		randomGridBasedPositions.Shuffle();
		return randomGridBasedPositions;
	}

	public List<GameObject> SpawnRandomGridBasedObjects(Grid grid, ICollection pathTiles, Transform parent, FMapElements mapElements)
	{
		int num = grid.GetGridSize().x * grid.GetGridSize().y;
		if (GetObjectsAmount(num) <= 0)
		{
			return null;
		}
		List<GameObject> list = new List<GameObject>();
		grid.GetGridSize();
		List<(Vector3, float)> invalidAreas = GenerateInvalidAreasList(mapElements);
		List<Vector2> randomPositions = GetRandomPositions(grid, invalidAreas);
		int num2 = 0;
		base.ObjectsToSpawn.ResetSelector();
		int num3 = 0;
		while (num2 < GetObjectsAmount(num))
		{
			if (num3 < randomPositions.Count)
			{
				Vector3 vector = grid.SnapPositionToGrid(randomPositions[num3].XZ());
				GameObject gameObject = Object.Instantiate(base.ObjectsToSpawn.GetRandomElement(), vector, Quaternion.identity, parent);
				gameObject.transform.RotateAround(gameObject.GetComponent<PlacementComponent>().GetCenter(), Vector3.up, 90 * Random.Range(0, 4));
				if (base.BuildableRadiusAroundObject > 0 && !LTFunctionLibrary.CanBuildAroundPosition(grid, gameObject.GetComponent<PlacementComponent>().GetOccupiedPositions(), base.BuildableRadiusAroundObject, base.ExcludedTileTypes, base.BuildableRadiusHasToBeFree))
				{
					Object.DestroyImmediate(gameObject);
				}
				else if (TryToAssignObjectToGrid(grid, gameObject.GetComponent<PlacementComponent>(), replace: false))
				{
					list.Add(gameObject);
					num2++;
					if ((bool)SubResource && SubresourceSpawnProbability > 0f && Random.value <= SubresourceSpawnProbability)
					{
						SubResource.SpawnRandomCircleBasedObjects(grid, vector, pathTiles, mapElements, parent);
					}
				}
				num3++;
				continue;
			}
			Debug.LogWarning("<color=red><b>Error:</b></color> No se pudieron spawnear todos los objetos ya que no se consiguieron generar suficientes posiciones válidas (" + base.ObjectsToSpawn.Name + ")");
			break;
		}
		return list;
	}
}
