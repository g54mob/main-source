using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CircleBasedSpawnerData_default", menuName = "Tower Factory/Procedural Generation/Circle Based Spawner Data")]
public class CircleBasedSpawnerData : BaseSpawnerData
{
	[SerializeField]
	private Vector2 minMaxDistanceFromCenter;

	[SerializeField]
	private int minGeneratedPositions = 1;

	[SerializeField]
	private bool reduceRequirementsToGeneratePositions;

	[SerializeField]
	private bool lookAtCenter;

	[SerializeField]
	private bool debugLog;

	public Vector2 MinMaxDistanceFromCenter => minMaxDistanceFromCenter;

	public int MinGeneratedPositions => minGeneratedPositions;

	public bool LookAtCenter => lookAtCenter;

	public List<Vector2> GetRandomPositions(Grid grid, Vector3 centerPosition, List<(Vector3, float)> invalidAreas, int maxAmount = -1)
	{
		int num = grid.GetGridSize().x * grid.GetGridSize().y;
		int num2 = Mathf.Max((maxAmount < 0) ? GetObjectsAmount(num) : Mathf.Min(GetObjectsAmount(num), maxAmount), MinGeneratedPositions);
		List<Vector2> list = new List<Vector2>();
		int num3 = ((!reduceRequirementsToGeneratePositions) ? 3 : 0);
		float num4 = base.MinDistanceBetweenObjects;
		while (list.Count < num2 && num3 <= 3)
		{
			List<(Vector3, float)> list2 = new List<(Vector3, float)>(invalidAreas);
			foreach (Vector2 item in list)
			{
				list2.Add((new Vector3(item.x, 0f, item.y), num4));
			}
			list.AddRange(LTFunctionLibrary.GetRandomCircleBasedPositions(num2, grid.GetGridSize(), centerPosition, MinMaxDistanceFromCenter, base.DistanceFromBorders, list2, base.MaxIterations, num4));
			num3++;
			if (debugLog && list.Count < num2 && num3 <= 3)
			{
				num4 = Mathf.RoundToInt(base.MinDistanceBetweenObjects * 1f);
				Debug.LogWarning("No se consiguieron spawnear suficientes posiciones válidas con los requisitos actuales. Reduciendo requisitos (" + base.ObjectsToSpawn.Name + ", Aumentando Security Level a " + num3 + ")");
			}
		}
		if (debugLog && list.Count < num2)
		{
			Debug.LogWarning("Finalmente, no se consiguieron spawnear suficientes posiciones válidas (" + base.ObjectsToSpawn.Name + ", generadas " + list.Count + " de " + num2 + ")");
		}
		return list;
	}

	public List<GameObject> SpawnRandomCircleBasedObjects(Grid grid, Vector3 centerPosition, ICollection pathTiles, FMapElements mapPositionsInfo, Transform parent, int maxAmount = -1)
	{
		int num = grid.GetGridSize().x * grid.GetGridSize().y;
		int num2 = ((maxAmount < 0) ? GetObjectsAmount(num) : Mathf.Min(GetObjectsAmount(num), maxAmount));
		if (num2 <= 0)
		{
			return null;
		}
		List<GameObject> list = new List<GameObject>();
		grid.GetGridSize();
		List<(Vector3, float)> invalidAreas = GenerateInvalidAreasList(mapPositionsInfo);
		List<Vector2> randomPositions = GetRandomPositions(grid, centerPosition, invalidAreas, maxAmount);
		int num3 = 0;
		base.ObjectsToSpawn.ResetSelector();
		int num4 = 0;
		while (num3 < num2)
		{
			if (num4 < randomPositions.Count)
			{
				Vector3 position = grid.SnapPositionToGrid(randomPositions[num4].XZ());
				GameObject gameObject = Object.Instantiate(base.ObjectsToSpawn.GetRandomElement(), position, Quaternion.identity, parent);
				if (LookAtCenter)
				{
					Vector3 lhs = centerPosition - gameObject.transform.position;
					lhs.y = 0f;
					lhs.Normalize();
					Vector3[] array = new Vector3[4]
					{
						Vector3.forward,
						Vector3.right,
						Vector3.back,
						Vector3.left
					};
					int num5 = 0;
					float num6 = float.NegativeInfinity;
					for (int i = 0; i < array.Length; i++)
					{
						float num7 = Vector3.Dot(lhs, array[i]);
						if (num7 > num6)
						{
							num6 = num7;
							num5 = i;
						}
					}
					float angle = 90f * (float)num5;
					gameObject.transform.RotateAround(gameObject.GetComponent<PlacementComponent>().GetCenter(), Vector3.up, angle);
				}
				else
				{
					gameObject.transform.RotateAround(gameObject.GetComponent<PlacementComponent>().GetCenter(), Vector3.up, 90 * Random.Range(0, 4));
				}
				if (base.BuildableRadiusAroundObject > 0 && !LTFunctionLibrary.CanBuildAroundPosition(grid, gameObject.GetComponent<PlacementComponent>().GetOccupiedPositions(), base.BuildableRadiusAroundObject, base.ExcludedTileTypes, base.BuildableRadiusHasToBeFree))
				{
					Object.DestroyImmediate(gameObject);
				}
				else if (TryToAssignObjectToGrid(grid, gameObject.GetComponent<PlacementComponent>(), replace: false))
				{
					list.Add(gameObject);
					num3++;
				}
				num4++;
				continue;
			}
			Debug.LogWarning("<color=red><b>Error:</b></color> No se pudieron spawnear todos los objetos ya que no se consiguieron generar suficientes posiciones válidas (" + base.ObjectsToSpawn.Name + " de " + base.name + ")");
			break;
		}
		return list;
	}
}
