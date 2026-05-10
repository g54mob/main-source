using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GridBasedSpawnerData_default", menuName = "Tower Factory/Procedural Generation/Grid Based Spawner Data")]
public class GridBasedSpawnerData : BaseSpawnerData
{
	[SerializeField]
	private int subdivisions = 5;

	[SerializeField]
	[Range(0f, 1f)]
	private float randomOffsetBias = 0.85f;

	[SerializeField]
	private CircleBasedSpawnerData subResource;

	[SerializeField]
	[Range(0f, 1f)]
	private float subresourceSpawnProbability;

	public int Subdivisions => subdivisions;

	public float RandomOffsetBias => randomOffsetBias;

	public CircleBasedSpawnerData SubResource => subResource;

	public float SubresourceSpawnProbability => subresourceSpawnProbability;

	public List<Vector2> GetRandomPositions(Grid grid, List<(Vector3, float)> invalidAreas)
	{
		List<Vector2> randomGridBasedPositions = LTFunctionLibrary.GetRandomGridBasedPositions(grid.GetGridSize(), Subdivisions, base.DistanceFromBorders, RandomOffsetBias, invalidAreas, base.MaxIterations, base.MinDistanceBetweenObjects);
		randomGridBasedPositions.Shuffle();
		return randomGridBasedPositions;
	}

	public List<GameObject> SpawnRandomGridBasedObjects(Grid grid, ICollection pathTiles, Transform parent, FMapElements mapElements)
	{
		if (base.ObjectsAmount <= 0)
		{
			return null;
		}
		List<GameObject> list = new List<GameObject>();
		grid.GetGridSize();
		List<(Vector3, float)> invalidAreas = GenerateInvalidAreasList(mapElements);
		List<Vector2> randomPositions = GetRandomPositions(grid, invalidAreas);
		int num = 0;
		base.ObjectsToSpawn.ResetSelector();
		int num2 = 0;
		while (num < base.ObjectsAmount)
		{
			if (num2 < randomPositions.Count)
			{
				Vector3 vector = grid.SnapPositionToGrid(randomPositions[num2].XZ());
				GameObject gameObject = Object.Instantiate(base.ObjectsToSpawn.GetRandomElement(), vector, Quaternion.identity, parent);
				gameObject.transform.RotateAround(gameObject.GetComponent<PlacementComponent>().GetCenter(), Vector3.up, 90 * Random.Range(0, 4));
				if (base.BuildableRadiusAroundObject > 0 && !LTFunctionLibrary.CanBuildAroundPosition(grid, gameObject.GetComponent<PlacementComponent>().GetOccupiedPositions(), base.BuildableRadiusAroundObject, base.ExcludedTileTypes, base.BuildableRadiusHasToBeFree))
				{
					Object.DestroyImmediate(gameObject);
				}
				else if (TryToAssignObjectToGrid(grid, gameObject.GetComponent<PlacementComponent>(), replace: false))
				{
					list.Add(gameObject);
					num++;
					if ((bool)SubResource && SubresourceSpawnProbability > 0f && Random.value <= SubresourceSpawnProbability)
					{
						SubResource.SpawnRandomCircleBasedObjects(grid, vector, pathTiles, mapElements, parent);
					}
				}
				num2++;
				continue;
			}
			Debug.LogWarning("<color=red><b>Error:</b></color> No se pudieron spawnear todos los objetos ya que no se consiguieron generar suficientes posiciones válidas (" + base.ObjectsToSpawn.Name + ")");
			break;
		}
		return list;
	}
}
