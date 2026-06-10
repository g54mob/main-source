using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GenerationController : MonoBehaviour
{
	[Serializable]
	public class PossibleRoomLocation : IComparable<PossibleRoomLocation>
	{
		public List<NewNode> nodes;

		public float randomRanking;

		public float exteriorWindowRanking;

		public float exteriorWallsRanking;

		public float floorSpaceRanking;

		public float entrancesRanking;

		public List<OverrideData> overrideRankingData;

		public float ranking;

		public List<NewNode> requiredAdjoiningOptions;

		public List<NewNode> requiredHallway;

		public GenerationDebugController debugScript;

		public int CompareTo(PossibleRoomLocation otherObject)
		{
			return 0;
		}
	}

	[Serializable]
	public struct OverrideData
	{
		public NewRoom room;

		public float floorSpacePenalty;

		public float exteriorWindowPenalty;

		public float exteriorWallPenalty;

		public float overridingPenalty;
	}

	[Serializable]
	public class PossibleDoorwayLocation : IComparable<PossibleDoorwayLocation>
	{
		public NewWall wall;

		public float ranking;

		public bool requireFlatDoorway;

		public List<NewWall> roomDivider;

		public int CompareTo(PossibleDoorwayLocation otherObject)
		{
			return 0;
		}
	}

	[Serializable]
	public class PossibleNullExpansion : IComparable<PossibleNullExpansion>
	{
		public List<NewNode> nodesToExpand;

		public NewRoom addToRoom;

		public float ranking;

		public int CompareTo(PossibleNullExpansion otherObject)
		{
			return 0;
		}
	}

	public struct ClusterRank
	{
		public FurnitureCluster cluster;

		public float rank;
	}

	[CompilerGenerated]
	private sealed class _003CExeUpdateGeometryAtEndOfFrame_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GenerationController _003C_003E4__this;

		private bool _003Cwait_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CExeUpdateGeometryAtEndOfFrame_003Ed__18(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CLoadGeometryAtEndOfFrame_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GenerationController _003C_003E4__this;

		private bool _003Cwait_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CLoadGeometryAtEndOfFrame_003Ed__20(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003CUnloadOldestRoomsAtEndOfFrame_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public GenerationController _003C_003E4__this;

		private bool _003Cwait_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CUnloadOldestRoomsAtEndOfFrame_003Ed__23(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	private bool updateGeometryActive;

	private List<NewFloor> updateTheseFloors;

	private bool loadGeometryActive;

	private List<NewFloor> loadTheseFloors;

	private bool roomUnloadCheckActive;

	public int oldestRoomUnloadTimer;

	public List<NewRoom> spawnedRooms;

	private static GenerationController _instance;

	public static GenerationController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void UpdateGeometryFloor(NewFloor editFloor, string debug = "")
	{
	}

	[IteratorStateMachine(typeof(_003CExeUpdateGeometryAtEndOfFrame_003Ed__18))]
	private IEnumerator ExeUpdateGeometryAtEndOfFrame()
	{
		return null;
	}

	public void LoadGeometryFloor(NewFloor editFloor)
	{
	}

	[IteratorStateMachine(typeof(_003CLoadGeometryAtEndOfFrame_003Ed__20))]
	private IEnumerator LoadGeometryAtEndOfFrame()
	{
		return null;
	}

	public void LoadGeometryRoom(NewRoom room)
	{
	}

	public void UnloadOldestRooms()
	{
	}

	[IteratorStateMachine(typeof(_003CUnloadOldestRoomsAtEndOfFrame_003Ed__23))]
	private IEnumerator UnloadOldestRoomsAtEndOfFrame()
	{
		return null;
	}

	public void UpdateFloorCeilingFloor(NewFloor editFloor)
	{
	}

	public void UpdateFloorCeilingRoom(NewRoom room)
	{
	}

	public void UpdateWallsFloor(NewFloor editFloor)
	{
	}

	public void UpdateWallsRoom(NewRoom room)
	{
	}

	public void LoadCornersRoom(NewRoom room)
	{
	}

	public void GenerateAddressLayout(NewAddress ad)
	{
	}

	public void ResetLayout(NewAddress ad, out GameObject newDebugParent)
	{
		newDebugParent = null;
	}

	private HashSet<NewRoom> GetUnreachableRooms(List<NewNode> entranceNodes, NewAddress ad)
	{
		return null;
	}

	private List<PossibleRoomLocation> GetPossibleRoomLocations(NewAddress address, RoomTypePreset config, List<NewNode> possibleNodes, List<NewNode> entranceNodes, List<NewNode> mainEntranceNodes, List<NewNode> edgeNodes, Transform debugParent)
	{
		return null;
	}

	private bool RoomMinimumShapeCheck(ref List<NewNode> nodes, Vector2 minimumShape, GenerationDebugController debug)
	{
		return false;
	}

	private bool RoomMinimumShapeCheck(ref HashSet<NewNode> nodes, Vector2 minimumShape, GenerationDebugController debug, bool nodesMustBeUnoccupied = false)
	{
		return false;
	}

	private bool TesselationShapeCheck(ref List<NewNode> nodes, Vector2 tessShape, GenerationDebugController debugController)
	{
		return false;
	}

	private bool MustAdjoinOneOfCheck(ref List<NewNode> nodes, NewGameLocation thisGameLocation, List<RoomTypePreset> roomTypes, bool includeEntrance, out List<NewNode> internalAdjoiningRoomNodes, GenerationDebugController debug)
	{
		internalAdjoiningRoomNodes = null;
		return false;
	}

	private bool CheckEntranceConnection(ref List<NewNode> nodes, NewGameLocation thisGameLocation, GenerationDebugController debug)
	{
		return false;
	}

	private void CreateForcedRooms(NewAddress ad)
	{
	}

	private float GetRoomUniformity(List<NewNode> nodes, out int wallCount, out float shapeRatio)
	{
		wallCount = default(int);
		shapeRatio = default(float);
		return 0f;
	}

	private int CalculateRoomEdges(List<NewNode> nodes, out int uniformWallCount, out Vector2 uniformBoundsSize)
	{
		uniformWallCount = default(int);
		uniformBoundsSize = default(Vector2);
		return 0;
	}

	private bool RoomSplitCheck(ref List<NewNode> nodes, GenerationDebugController debug)
	{
		return false;
	}

	private List<NewRoom> ConvertSplitRoom(ref HashSet<NewNode> nodes, NewAddress ad)
	{
		return null;
	}

	private List<NewNode> HallwayPathfind(NewNode origin, NewNode destination, NewAddress address)
	{
		return null;
	}

	public void GenerateGeometry(NewAddress ad)
	{
	}

	public void GenerateLightZones(NewRoom room)
	{
	}

	public void GenerateAddressDecor(NewAddress ad)
	{
	}

	public void FurnishRoom(NewRoom room)
	{
	}

	private bool ClusterCountChecks(FurnitureCluster cluster, NewRoom room, bool enableDebug = false)
	{
		return false;
	}

	public FurnitureClusterLocation GetBestFurnitureClusterLocation(NewRoom room, FurnitureCluster cluster, bool enableDebug = false, bool ignoreLimitations = false)
	{
		return null;
	}

	private int GetAngleForFurnitureFacing(FurnitureCluster.FurnitureFacing facing)
	{
		return 0;
	}

	public bool IsFurniturePlacementValid(NewRoom room, ref Dictionary<NewNode, List<NewNode>> newBlockAccess, ref List<NewNode> newNoPassNodes, ref List<NewNode> newNoAccessNodes, bool printDebug, out List<string> debugOutput, bool ignoreNoPassThrough = false)
	{
		debugOutput = null;
		return false;
	}

	public bool IsFurniturePlacementValidOLD(NewRoom room, ref Dictionary<NewNode, List<NewNode>> newBlockAccess, List<NewNode> newNoPassNodes = null, List<NewNode> newNoAccessNodes = null, bool printDebug = false)
	{
		return false;
	}

	public FurniturePreset PickFurniture(FurnitureClass furnClass, NewRoom room, string randomSeed, bool debug = false, bool ignoreLimitations = false, DesignStylePreset styleOverride = null)
	{
		return null;
	}

	public bool GetValidFurniture(FurnitureClass furnClass, NewRoom room, bool returnList, out List<FurniturePreset> possibleFurniture, bool debug = false, bool ignoreLimitations = false, DesignStylePreset designStyleOverride = null)
	{
		possibleFurniture = null;
		return false;
	}

	public ArtPreset PickArt(ArtPreset.ArtOrientation orientation, NewRoom room)
	{
		return null;
	}

	private bool GetAdjacentNode(NewNode original, Vector2Int offset, out NewNode output)
	{
		output = null;
		return false;
	}

	public List<FurnitureLocation> GetFurnitureInCity(FurnitureClass furnClass)
	{
		return null;
	}

	public List<FurnitureLocation> GetFurnitureInBuilding(NewBuilding building, FurnitureClass furnClass)
	{
		return null;
	}

	public int GetFurnitureInGameLocationCount(NewGameLocation address, FurnitureClass furnClass)
	{
		return 0;
	}

	public int GetFurnitureInRoomCount(NewRoom room, FurnitureClass furnClass)
	{
		return 0;
	}

	public List<FurnitureClusterLocation> GetClustersInCity(FurnitureCluster cluster)
	{
		return null;
	}

	public List<FurnitureClusterLocation> GetClustersInBuilding(NewBuilding building, FurnitureCluster cluster)
	{
		return null;
	}

	public int GetClusterCountInGameLocation(NewGameLocation address, FurnitureCluster cluster)
	{
		return 0;
	}

	public void ClearCache()
	{
	}
}
