using System.Collections.Generic;
using LightTower;
using UnityEngine;

public abstract class BaseSpawnerData : ScriptableObject
{
	public struct FMapElements
	{
		public PlayerTower playerTower;

		public EnemyTower enemyTower;

		public ICollection<GameObject> crystalAltars;

		public PathTile[] pathTiles;

		public ICollection<GameObject> obelisks;

		public ICollection<GameObject> specialBuildings;

		public FMapElements(PlayerTower playerTowerPos, EnemyTower enemyTowerPos, ICollection<GameObject> crystalAltars, PathTile[] pathTiles, ICollection<GameObject> obelisks, ICollection<GameObject> specialBuildings)
		{
			playerTower = playerTowerPos;
			enemyTower = enemyTowerPos;
			this.crystalAltars = crystalAltars;
			this.pathTiles = pathTiles;
			this.obelisks = obelisks;
			this.specialBuildings = specialBuildings;
		}
	}

	protected const int SECURITY_ITERATIONS = 3;

	[SerializeField]
	private WeightedRandomSelector<GameObject> objectsToSpawn;

	[SerializeField]
	private int objectsAmount;

	[SerializeField]
	private float objectsDensity;

	[SerializeField]
	private bool useDensity;

	[SerializeField]
	private float minDistanceBetweenObjects = 15f;

	[SerializeField]
	private int distanceFromBorders = 5;

	[SerializeField]
	[Tooltip("Radio cuadrado alrededor del objeto que tendrá que tener Tiles en los que se pueda construir")]
	private int buildableRadiusAroundObject;

	[SerializeField]
	[Tooltip("Si es true, se comprueba que los tiles alrededor del objeto estén libres además de que se pueda construir en ellos")]
	private bool buildableRadiusHasToBeFree;

	[SerializeField]
	[Tooltip("TileTypes que no se tendrán en cuenta para el radio de seguridad")]
	private Tile.ETileType[] excludedTileTypes;

	[SerializeField]
	private int maxIterations = 500;

	[SerializeField]
	private float playerTowerInvalidAreaRange = 20f;

	[SerializeField]
	private float enemyTowerInvalidAreaRange = 20f;

	[SerializeField]
	private float pathInvalidAreaRange = 10f;

	[SerializeField]
	private float crystalAltarsInvalidAreaRange;

	[SerializeField]
	private float obelisksInvalidAreaRange;

	[SerializeField]
	private float specialBuildingsInvalidAreaRange;

	public WeightedRandomSelector<GameObject> ObjectsToSpawn => objectsToSpawn;

	public float MinDistanceBetweenObjects => minDistanceBetweenObjects;

	public int DistanceFromBorders => distanceFromBorders;

	public int BuildableRadiusAroundObject => buildableRadiusAroundObject;

	public bool BuildableRadiusHasToBeFree => buildableRadiusHasToBeFree;

	public Tile.ETileType[] ExcludedTileTypes => excludedTileTypes;

	public int MaxIterations => maxIterations;

	public float PlayerTowerInvalidAreaRange => playerTowerInvalidAreaRange;

	public float EnemyTowerInvalidAreaRange => enemyTowerInvalidAreaRange;

	public float CrystalAltarsInvalidAreaRange => crystalAltarsInvalidAreaRange;

	public float ObelisksInvalidAreaRange => obelisksInvalidAreaRange;

	public float SpecialBuildingsInvalidAreaRange => specialBuildingsInvalidAreaRange;

	public float PathInvalidAreaRange
	{
		get
		{
			return pathInvalidAreaRange;
		}
		protected set
		{
			pathInvalidAreaRange = value;
		}
	}

	public int GetObjectsAmount(float mapM2)
	{
		if (useDensity)
		{
			return Mathf.RoundToInt(objectsDensity * 0.01f * mapM2);
		}
		return objectsAmount;
	}

	public int GetObjectsAmount()
	{
		return objectsAmount;
	}

	protected bool TryToAssignObjectToGrid(Grid grid, PlacementComponent placementComponent, bool replace, bool forcePlace = false)
	{
		GridCell gridCell = null;
		Vector3[] occupiedPositions;
		if (!forcePlace)
		{
			occupiedPositions = placementComponent.GetOccupiedPositions();
			foreach (Vector3 position in occupiedPositions)
			{
				gridCell = grid.GetGridCell(position);
				if (gridCell != null && gridCell.Tile.PreventBuildOnMapGeneration)
				{
					Object.DestroyImmediate(placementComponent.gameObject);
					return false;
				}
				if (gridCell == null || (!gridCell.CanBuild() && gridCell.BuiltObject != this))
				{
					if (gridCell == null || gridCell.IsFree())
					{
						Object.DestroyImmediate(placementComponent.gameObject);
						return false;
					}
					if (!replace)
					{
						Object.DestroyImmediate(placementComponent.gameObject);
						return false;
					}
					Object.DestroyImmediate(gridCell.BuiltObject.gameObject);
				}
			}
		}
		Tile[] componentsInChildren = placementComponent.gameObject.GetComponentsInChildren<Tile>();
		foreach (Tile tile in componentsInChildren)
		{
			if (grid.GetGridCell(tile.transform.position) != null)
			{
				Object.DestroyImmediate(grid.GetGridCell(tile.transform.position).Tile.gameObject);
			}
			grid.AddGridCell(tile);
		}
		occupiedPositions = placementComponent.GetOccupiedPositions();
		foreach (Vector3 position2 in occupiedPositions)
		{
			grid.GetGridCell(position2).BuiltObject = placementComponent;
		}
		return true;
	}

	protected List<(Vector3, float)> GenerateInvalidAreasList(FMapElements mapElements)
	{
		List<(Vector3, float)> list = new List<(Vector3, float)>();
		if (PlayerTowerInvalidAreaRange > 0f)
		{
			list.Add((mapElements.playerTower.transform.position, PlayerTowerInvalidAreaRange));
		}
		if (EnemyTowerInvalidAreaRange > 0f)
		{
			list.Add((mapElements.enemyTower.transform.position, EnemyTowerInvalidAreaRange));
		}
		if (CrystalAltarsInvalidAreaRange > 0f)
		{
			foreach (GameObject crystalAltar in mapElements.crystalAltars)
			{
				list.Add((crystalAltar.transform.position, CrystalAltarsInvalidAreaRange));
			}
		}
		if (SpecialBuildingsInvalidAreaRange > 0f)
		{
			foreach (GameObject specialBuilding in mapElements.specialBuildings)
			{
				list.Add((specialBuilding.transform.position, SpecialBuildingsInvalidAreaRange));
			}
		}
		if (ObelisksInvalidAreaRange > 0f)
		{
			foreach (GameObject obelisk in mapElements.obelisks)
			{
				list.Add((obelisk.transform.position, ObelisksInvalidAreaRange));
			}
		}
		if (PathInvalidAreaRange > 0f)
		{
			PathTile[] pathTiles = mapElements.pathTiles;
			foreach (PathTile pathTile in pathTiles)
			{
				list.Add((pathTile.transform.position, PathInvalidAreaRange));
			}
		}
		return list;
	}
}
