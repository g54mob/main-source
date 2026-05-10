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
		int num = Mathf.Max((maxAmount < 0) ? base.ObjectsAmount : Mathf.Min(base.ObjectsAmount, maxAmount), MinGeneratedPositions);
		List<Vector2> list = new List<Vector2>();
		int num2 = ((!reduceRequirementsToGeneratePositions) ? 3 : 0);
		float num3 = base.MinDistanceBetweenObjects;
		while (list.Count < num && num2 <= 3)
		{
			List<(Vector3, float)> list2 = new List<(Vector3, float)>(invalidAreas);
			foreach (Vector2 item in list)
			{
				list2.Add((new Vector3(item.x, 0f, item.y), num3));
			}
			list.AddRange(LTFunctionLibrary.GetRandomCircleBasedPositions(num, grid.GetGridSize(), centerPosition, MinMaxDistanceFromCenter, base.DistanceFromBorders, list2, base.MaxIterations, num3));
			num2++;
			if (debugLog && list.Count < num && num2 <= 3)
			{
				num3 = Mathf.RoundToInt(base.MinDistanceBetweenObjects * 1f);
				Debug.LogWarning("No se consiguieron spawnear suficientes posiciones válidas con los requisitos actuales. Reduciendo requisitos (" + base.ObjectsToSpawn.Name + ", Aumentando Security Level a " + num2 + ")");
			}
		}
		if (debugLog && list.Count < num)
		{
			Debug.LogWarning("Finalmente, no se consiguieron spawnear suficientes posiciones válidas (" + base.ObjectsToSpawn.Name + ", generadas " + list.Count + " de " + num + ")");
		}
		return list;
	}

	public List<GameObject> SpawnRandomCircleBasedObjects(Grid grid, Vector3 centerPosition, ICollection pathTiles, FMapElements mapPositionsInfo, Transform parent, int maxAmount = -1)
	{
		int num = ((maxAmount < 0) ? base.ObjectsAmount : Mathf.Min(base.ObjectsAmount, maxAmount));
		if (num <= 0)
		{
			return null;
		}
		List<GameObject> list = new List<GameObject>();
		grid.GetGridSize();
		List<(Vector3, float)> invalidAreas = GenerateInvalidAreasList(mapPositionsInfo);
		List<Vector2> randomPositions = GetRandomPositions(grid, centerPosition, invalidAreas, maxAmount);
		int num2 = 0;
		base.ObjectsToSpawn.ResetSelector();
		int num3 = 0;
		while (num2 < num)
		{
			if (num3 < randomPositions.Count)
			{
				Vector3 position = grid.SnapPositionToGrid(randomPositions[num3].XZ());
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
					int num4 = 0;
					float num5 = float.NegativeInfinity;
					for (int i = 0; i < array.Length; i++)
					{
						float num6 = Vector3.Dot(lhs, array[i]);
						if (num6 > num5)
						{
							num5 = num6;
							num4 = i;
						}
					}
					float angle = 90f * (float)num4;
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
					num2++;
				}
				num3++;
				continue;
			}
			Debug.LogWarning("<color=red><b>Error:</b></color> No se pudieron spawnear todos los objetos ya que no se consiguieron generar suficientes posiciones válidas (" + base.ObjectsToSpawn.Name + " de " + base.name + ")");
			break;
		}
		return list;
	}
}
