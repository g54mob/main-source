using System.Collections.Generic;
using LightTower;
using UnityEngine;

[CreateAssetMenu(fileName = "PathBasedSpawnerData_default", menuName = "Tower Factory/Procedural Generation/Path Based Spawner Data")]
public class PathBasedSpawnerData : BaseSpawnerData
{
	[SerializeField]
	private Vector2 minMaxDistanceFromPath;

	[SerializeField]
	private int minGeneratedPositions = 1;

	[SerializeField]
	private bool debugLog;

	public Vector2 MinMaxDistanceFromCenter => minMaxDistanceFromPath;

	public int MinGeneratedPositions => minGeneratedPositions;

	public List<Vector2> GetRandomPositions(Grid grid, PathTile[] pathTiles, List<(Vector3, float)> invalidAreas)
	{
		return GetRandomPathBasedPositions(grid, pathTiles, invalidAreas);
	}

	public List<GameObject> SpawnRandomPathBasedObjects(Grid grid, FMapElements mapPositionsInfo, Transform parent)
	{
		if (base.ObjectsAmount <= 0)
		{
			return null;
		}
		List<GameObject> list = new List<GameObject>();
		grid.GetGridSize();
		base.PathInvalidAreaRange = minMaxDistanceFromPath.x;
		List<(Vector3, float)> invalidAreas = GenerateInvalidAreasList(mapPositionsInfo);
		List<Vector2> randomPositions = GetRandomPositions(grid, mapPositionsInfo.pathTiles, invalidAreas);
		int num = 0;
		base.ObjectsToSpawn.ResetSelector();
		int num2 = 0;
		while (num < base.ObjectsAmount)
		{
			if (num2 < randomPositions.Count)
			{
				Vector3 position = grid.SnapPositionToGrid(randomPositions[num2].XZ());
				GameObject gameObject = Object.Instantiate(base.ObjectsToSpawn.GetRandomElement(), position, Quaternion.identity, parent);
				gameObject.transform.RotateAround(gameObject.GetComponent<PlacementComponent>().GetCenter(), Vector3.up, 90 * Random.Range(0, 4));
				if (base.BuildableRadiusAroundObject > 0 && !LTFunctionLibrary.CanBuildAroundPosition(grid, gameObject.GetComponent<PlacementComponent>().GetOccupiedPositions(), base.BuildableRadiusAroundObject, base.ExcludedTileTypes, base.BuildableRadiusHasToBeFree))
				{
					Object.DestroyImmediate(gameObject);
				}
				else if (TryToAssignObjectToGrid(grid, gameObject.GetComponent<PlacementComponent>(), replace: false))
				{
					list.Add(gameObject);
					num++;
				}
				num2++;
				continue;
			}
			Debug.LogWarning("<color=red><b>Error:</b></color> No se pudieron spawnear todos los objetos ya que no se consiguieron generar suficientes posiciones válidas (" + base.ObjectsToSpawn.Name + ")");
			break;
		}
		return list;
	}

	private List<Vector2> GetRandomPathBasedPositions(Grid grid, PathTile[] pathTiles, List<(Vector3 position, float radius)> invalidAreas)
	{
		List<Vector2> list = new List<Vector2>();
		int num = 0;
		int num2 = 0;
		float circleRadius = base.MinDistanceBetweenObjects;
		while (list.Count < Mathf.Max(minGeneratedPositions, base.ObjectsAmount) && num2 < 3)
		{
			bool flag = true;
			num = 0;
			while (num < base.MaxIterations && flag)
			{
				num++;
				flag = false;
				Vector2 vector = pathTiles[Random.Range(0, pathTiles.Length)].transform.position.XZ();
				vector += Random.insideUnitCircle.normalized * Random.Range(minMaxDistanceFromPath.x, minMaxDistanceFromPath.y);
				if (vector.x < (float)base.DistanceFromBorders || vector.x > (float)(grid.GetGridSize().x - base.DistanceFromBorders) || vector.y < (float)base.DistanceFromBorders || vector.y > (float)(grid.GetGridSize().y - base.DistanceFromBorders))
				{
					continue;
				}
				if (invalidAreas != null)
				{
					foreach (var invalidArea in invalidAreas)
					{
						if (FunctionLibrary.IsPositionInsideCircle(vector, invalidArea.position.XZ(), invalidArea.radius))
						{
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					continue;
				}
				foreach (Vector2 item in list)
				{
					Vector3 vector2 = item;
					if (FunctionLibrary.IsPositionInsideCircle(vector, vector2, circleRadius))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					list.Add(vector);
				}
			}
			if (flag)
			{
				num2++;
				circleRadius = Mathf.RoundToInt(base.MinDistanceBetweenObjects * (1f - 0.25f * (float)num2));
				if (debugLog)
				{
					Debug.LogWarning("No se consiguieron spawnear suficientes posiciones válidas con los requisitos actuales. Reduciendo requisitos (" + base.ObjectsToSpawn.Name + ", Aumentando Security Level a " + num2 + ")");
				}
			}
		}
		if (debugLog && list.Count < Mathf.Max(minGeneratedPositions, base.ObjectsAmount))
		{
			Debug.LogWarning("Finalmente, no se consiguieron spawnear suficientes posiciones válidas (" + base.ObjectsToSpawn.Name + ", generadas " + list.Count + " de " + Mathf.Max(minGeneratedPositions, base.ObjectsAmount) + ")");
		}
		return list;
	}
}
