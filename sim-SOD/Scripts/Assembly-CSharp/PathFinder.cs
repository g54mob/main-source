using System;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
	public class PathData
	{
		public List<NewNode.NodeAccess> accessList;

		public NewNode GetNodeAhead(int routeCursor)
		{
			return null;
		}

		public NewNode GetNodeBehind(int routeCursor)
		{
			return null;
		}
	}

	public struct RoomPathKey : IEquatable<RoomPathKey>
	{
		public NewRoom originRoom;

		public NewRoom destinationRoom;

		private bool hasHash;

		private int hash;

		public RoomPathKey(NewRoom locOne, NewRoom locTwo)
		{
			originRoom = null;
			destinationRoom = null;
			hasHash = false;
			hash = 0;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		bool IEquatable<RoomPathKey>.Equals(RoomPathKey other)
		{
			return false;
		}
	}

	public struct GameLocationPathKey : IEquatable<GameLocationPathKey>
	{
		public NewGameLocation originLocation;

		public NewGameLocation destinationLocation;

		private bool hasHash;

		private int hash;

		public GameLocationPathKey(NewGameLocation locOne, NewGameLocation locTwo)
		{
			originLocation = null;
			destinationLocation = null;
			hasHash = false;
			hash = 0;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		bool IEquatable<GameLocationPathKey>.Equals(GameLocationPathKey other)
		{
			return false;
		}
	}

	public class StreetChunk
	{
		public string name;

		public int id;

		public static int assignID;

		public Vector3 anchorTile;

		public List<Vector3> allCoords;

		public List<NewTile> allTiles;

		public bool isJunction;

		public bool isHorizontal;

		public float xMagnitude;

		public float yMagnitude;

		public Vector2 streetMaxSizeX;

		public Vector2 streetMaxSizeY;

		public int footfall;

		public float footfallNormalized;

		public StreetChunk(Vector3 newAnchor, List<Vector3> newList, bool newIsJunction)
		{
		}

		public Dictionary<StreetChunk, bool> GetAdjacentChunks(bool horizontal)
		{
			return null;
		}
	}

	[BurstCompile]
	public struct GetInternalRouteJob : IJob
	{
		public bool pathfindSuccessful;

		[ReadOnly]
		public int3 origin;

		[ReadOnly]
		public int3 destination;

		[ReadOnly]
		public int listIndex;

		[ReadOnly]
		public NativeMultiHashMap<int3, int> accessRef;

		[ReadOnly]
		public NativeHashMap<int, float3> accessPositions;

		[ReadOnly]
		public NativeHashMap<int, int3> toNodeReference;

		public NativeList<int3> noPassRef;

		[WriteOnly]
		public NativeList<int> output;

		public void Execute()
		{
		}

		public float DistanceInt3(int3 origin, int3 destination)
		{
			return 0f;
		}
	}

	private const int INITIAL_COLLECTION_SIZE = 96;

	public Vector3 tileSize;

	public Vector3 nodeSize;

	public Vector2 citySizeReal;

	public Vector2 halfCitySizeReal;

	public Vector2 tileCitySize;

	public Vector2 nodeCitySize;

	public Vector2 nodeRangeX;

	public Vector2 nodeRangeY;

	public Vector2 nodeRangeZ;

	[Header("Debug Data")]
	public int totalPathCalls;

	public int calculatedRoomRoutes;

	public int returnedCachedRoomRoutes;

	public int calculatedInternalRoutes;

	public Dictionary<Vector3, NewNode> nodeMap;

	public Dictionary<Vector3, NewTile> tileMap;

	public Dictionary<GameLocationPathKey, List<NewNode.NodeAccess>> gameLocationRoutes;

	[Header("AI Navigation")]
	public Dictionary<NewAddress.PathKey, List<NewNode.NodeAccess>> internalRoutes;

	public List<NewNode.NodeAccess> streetEntrances;

	public Dictionary<int, NewNode.NodeAccess> nodeAccessReference;

	public NativeMultiHashMap<int3, int> streetAccessRef;

	public NativeHashMap<int, float3> streetAccessPositions;

	public NativeHashMap<int, int3> streetToNodeReference;

	public NativeList<int3> streetNoPassRef;

	public List<StreetChunk> streetChunks;

	private static PathFinder _instance;

	public static PathFinder Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void Start()
	{
	}

	public void DestroySelf()
	{
	}

	public void SetDimensions()
	{
	}

	public void CompilePathFindingMap(bool calculateNewBuildingFacing = true)
	{
	}

	public void CreateStreetChunks()
	{
	}

	private void FootTrafficSimulation()
	{
	}

	private void CreateStreets()
	{
	}

	private StreetController NewRoad(DistrictController dis)
	{
		return null;
	}

	public PathData GetPath(NewNode origin, NewNode destination, Human human, NewNode[] avoidNodes = null)
	{
		return null;
	}

	private List<NewNode.NodeAccess> GetGameLocationRoute(NewNode origin, NewNode destination, Human human)
	{
		return null;
	}

	public List<NewNode.NodeAccess> GetInternalRoute(NewAddress.PathKey pathKey, NewGameLocation gameLocation)
	{
		return null;
	}

	public void GenerateJobPathingData()
	{
	}

	public List<NewTile> GetTileRoute(NewTile origin, NewTile destination, List<NewTile> avoidTiles = null)
	{
		return null;
	}

	private void OnDisable()
	{
	}
}
