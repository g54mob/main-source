using System;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class NewNode
{
	public enum FloorTileType
	{
		none = 0,
		floorAndCeiling = 1,
		floorOnly = 2,
		CeilingOnly = 3,
		noneButIndoors = 4
	}

	public class NodeSpace
	{
		public NewNode node;

		public NodeSpaceOccupancy occ;

		public Actor occupier;

		public Vector3 position;

		public void SetEmpty()
		{
		}

		public void SetOccuppier(Actor newOcc, NodeSpaceOccupancy occType)
		{
		}
	}

	public enum NodeSpaceOccupancy
	{
		empty = 0,
		position = 1,
		reserved = 2
	}

	[Serializable]
	public class NodeAccess : IEquatable<NodeAccess>
	{
		public enum AccessType
		{
			streetToStreet = 0,
			door = 1,
			openDoorway = 2,
			verticalSpace = 3,
			adjacent = 4,
			window = 5,
			bannister = 6
		}

		public string name;

		public int id;

		public static int assignId;

		public float weight;

		public NewDoor door;

		public NewWall wall;

		public AccessType accessType;

		public NewNode fromNode;

		public NewNode toNode;

		public bool walkingAccess;

		public bool employeeDoor;

		public Vector3 worldAccessPoint;

		public NodeAccess oppositeAccess;

		public Dictionary<NodeAccess, float> entranceWeights;

		private bool hasHash;

		private int hash;

		bool IEquatable<NodeAccess>.Equals(NodeAccess other)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public NodeAccess(NewNode newFrom, NewNode newTo, NewWall newWall, NewDoor newDoorway, bool forceAccessType = false, AccessType forcedAccessType = AccessType.adjacent, bool forceWalkable = false)
		{
		}

		public NewNode GetOther(NewNode fromThis)
		{
			return null;
		}

		public NewRoom GetOtherRoom(NewRoom fromThis)
		{
			return null;
		}

		public NewRoom GetOtherRoom(NewGameLocation fromThis)
		{
			return null;
		}

		public NewNode GetOtherGameLocation(NewNode fromThis)
		{
			return null;
		}

		public NewGameLocation GetOtherGameLocation(NewGameLocation fromThis)
		{
			return null;
		}

		public void PreComputeEntranceWeights()
		{
		}

		public void GetEntranceSidePoints(out Vector3 leftSide, out Vector3 rightSide)
		{
			leftSide = default(Vector3);
			rightSide = default(Vector3);
		}

		public void UpdateWorldAccessPoint()
		{
		}
	}

	[Header("Transform")]
	public string name;

	public Vector3 position;

	public GameObject physicalObject;

	[Header("Location")]
	public NewBuilding building;

	public NewFloor floor;

	public NewGameLocation gameLocation;

	public NewRoom room;

	public NewTile tile;

	[Space(5f)]
	public Vector2Int floorCoord;

	public Vector2Int localTileCoord;

	public Vector3Int nodeCoord;

	[Header("Node Contents")]
	public List<NewWall> walls;

	public Dictionary<Vector2, NewWall> wallDict;

	[Header("Details")]
	public int floorHeight;

	public FloorTileType floorType;

	public List<Vector2> preventEntrances;

	[Header("Spawned Objects")]
	public GameObject floorPrefab;

	public GameObject spawnedFloor;

	public GameObject ceilingPrefab;

	public GameObject spawnedCeiling;

	[Header("AI Navigation")]
	public float nodeWeightMultiplier;

	public bool isObstacle;

	public bool isOutside;

	public bool isConnected;

	public bool stairwellLowerLink;

	public bool stairwellUpperLink;

	public bool isInaccessable;

	public bool isIndoorsEntrance;

	public bool ceilingAirVent;

	public bool floorAirVent;

	public bool noPassThrough;

	public bool noAccess;

	[NonSerialized]
	public RoomConfiguration forcedRoom;

	public string forcedRoomRef;

	public NodeSpace defaultSpace;

	public Dictionary<Vector3, NodeSpace> walkableNodeSpace;

	public HashSet<NodeSpace> occupiedSpace;

	public bool detectGeometry;

	[Header("Furniture")]
	public bool allowNewFurniture;

	public List<FurnitureLocation> individualFurniture;

	[Header("Interactables")]
	public List<Interactable> interactables;

	[Header("Air Ducts")]
	public List<AirDuctGroup.AirDuctSection> airDucts;

	[Header("Audio Source")]
	public AudioEvent audioEvent;

	public AudioController.LoopingSoundInfo loop;

	public Vector3 audioOffset;

	public Dictionary<NewNode, NodeAccess> accessToOtherNodes;

	public void Setup(NewTile newTile, NewGameLocation newGameLoc, Vector2Int newLocalCoord)
	{
	}

	public Vector3 TransformPoint(Vector3 localPos)
	{
		return default(Vector3);
	}

	public Vector3 InverseTransformPoint(Vector3 worldPos)
	{
		return default(Vector3);
	}

	public void Load(CitySaveData.NodeCitySave data, NewRoom newRoom)
	{
	}

	public void AddNewWall(NewWall newWall)
	{
	}

	public void RemoveWall(NewWall newWall)
	{
	}

	public void SpawnFloor(bool prepForCombinedMeshes)
	{
	}

	public void SpawnCeiling(bool prepForCombinedMeshes)
	{
	}

	public void SetFloorType(FloorTileType newType)
	{
	}

	public void SetAsObstacle(bool val)
	{
	}

	public void SetAsOutside(bool val)
	{
	}

	public void AddAccessToOtherNode(NewNode newNode, bool twoWay = true, bool forceAccessType = false, NodeAccess.AccessType forcedAccessType = NodeAccess.AccessType.adjacent, bool forceWalkable = false)
	{
	}

	public void RemoveAccessToOtherNode(NewNode newNode, bool twoWay = true)
	{
	}

	public void SetForcedRoom(RoomConfiguration newRoom)
	{
	}

	public void AddInteractable(Interactable newInteractable)
	{
	}

	public void RemoveInteractable(Interactable newInteractable)
	{
	}

	[Button("Teleport Player", EButtonEnableMode.Always)]
	public void DebugTeleportPlayerToLocation()
	{
	}

	public void SetFloorHeight(int val, bool setTest = true)
	{
	}

	public void AddFurniture(FurnitureLocation newFurn)
	{
	}

	public void ResetFurniture()
	{
	}

	public void SetAllowNewFurniture(bool val)
	{
	}

	public void AddToNodeWeightMultiplier(float val)
	{
	}

	public CitySaveData.NodeCitySave GenerateSaveData()
	{
		return null;
	}

	public bool AddHumanTraveller(Actor newActor, Interactable.UsagePoint usagePoint, out Vector3 usePosition, bool useRandomNodeSublocation = false)
	{
		usePosition = default(Vector3);
		return false;
	}

	public void UpdateWalkableSublocations()
	{
	}

	public void ClearTravellers()
	{
	}

	public void SetAsAudioSource(AudioEvent newEvent, Vector3 newOffset)
	{
	}

	public void SetCeilingVent(bool val)
	{
	}

	public void SetFloorVent(bool val)
	{
	}

	public bool HasValidFloor()
	{
		return false;
	}

	public bool HasValidCeiling()
	{
		return false;
	}
}
