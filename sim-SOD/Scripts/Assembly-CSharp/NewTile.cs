using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class NewTile
{
	[Header("ID")]
	public int tileID;

	public static int assignID;

	[Header("Transform")]
	public string name;

	public Vector3 position;

	public Transform parent;

	[Header("Location")]
	public NewBuilding building;

	public NewFloor floor;

	public CityTile cityTile;

	public Vector2Int floorCoord;

	public Vector3Int globalTileCoord;

	public PathFinder.StreetChunk streetChunk;

	[Header("Tile Contents")]
	public List<NewNode> nodes;

	public NewNode anchorNode;

	[Header("Tile")]
	public bool isSetup;

	public bool isLoaded;

	public bool isOutside;

	public bool isObstacle;

	public bool isMapCorner;

	public bool isEdge;

	public int rotation;

	public bool isEntrance;

	public bool isMainEntrance;

	public NewTile entrancePair;

	public bool isStairwell;

	public int stairwellRotation;

	public bool isInvertedStairwell;

	public int elevatorRotation;

	public bool isTop;

	public bool isBottom;

	[Header("Roads")]
	public StreetController streetController;

	[Header("Optimization")]
	public bool useOptimizedFloor;

	public bool useOptimizedCeiling;

	[Header("Spawned Objects")]
	public GameObject entranceArrow;

	public GameObject stairwell;

	public GameObject elevator;

	[NonSerialized]
	public Elevator stairwellAssign;

	public void SetupInterior(NewFloor newFloor, Vector2Int newCoord, bool newIsEdge)
	{
	}

	public void SetupExterior(CityTile newCityTile, Vector3Int newCityCoord)
	{
	}

	private void CommonSetup()
	{
	}

	public void LoadPathfindTileData(CitySaveData.TileCitySave data)
	{
	}

	public void LoadExterior(CitySaveData.TileCitySave data)
	{
	}

	public void LoadInterior(CitySaveData.TileCitySave data)
	{
	}

	public void AddNewNode(NewNode newNode)
	{
	}

	public void RemoveNode(NewNode newNode)
	{
	}

	public void SetRotation(int newRot)
	{
	}

	public void SetAsEntrance(bool val, bool mainEntrance, bool set = false)
	{
	}

	public void SetAsStairwell(bool val, bool spawnPrefabs, bool isInverted)
	{
	}

	public void SetStairwellRotation(int newRot)
	{
	}

	public void SetAsTop(bool newIsTop)
	{
	}

	public void SetAsBottom(bool newIsBottom)
	{
	}

	public bool CanBeOptimized()
	{
		return false;
	}

	public void SetFloorCeilingOptimization(bool val, bool spawnPrefabs)
	{
	}

	public void SetAsObstacle(bool val)
	{
	}

	public void SetAsOutside(bool val)
	{
	}

	public void CheckOffMap()
	{
	}

	public void ConnectStairwell()
	{
	}

	public CitySaveData.TileCitySave GenerateSaveData()
	{
		return null;
	}
}
