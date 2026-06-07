using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GridSystem : Singleton<GridSystem>
{
	public class TerritoryOverride
	{
		public int id;

		public Vector3Int position;
	}

	public enum eTerritoryType
	{
		NONE = 0,
		PLAYER = 1,
		ENEMY = 2
	}

	public interface IIdBasedObjectData
	{
		int Id { get; }

		Vector3Int Position { get; set; }

		object TargetObject { get; }
	}

	[Serializable]
	public class IdBasedObjectData<T> : IIdBasedObjectData
	{
		public int id;

		public T targetObject;

		public Vector3Int position;

		public int Id => 0;

		public Vector3Int Position
		{
			get
			{
				return default(Vector3Int);
			}
			set
			{
			}
		}

		public object TargetObject => null;
	}

	[CompilerGenerated]
	private sealed class _003CGetIDBasedObjectDataList_003Ed__93<T> : IEnumerable<IdBasedObjectData<T>>, IEnumerable, IEnumerator<IdBasedObjectData<T>>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private IdBasedObjectData<T> _003C_003E2__current;

		private int _003C_003El__initialThreadId;

		public GridSystem _003C_003E4__this;

		private List<IIdBasedObjectData> _003Clist_003E5__2;

		private int _003Ci_003E5__3;

		IdBasedObjectData<T> IEnumerator<IdBasedObjectData<T>>.Current
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
		public _003CGetIDBasedObjectDataList_003Ed__93(int _003C_003E1__state)
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

		[DebuggerHidden]
		IEnumerator<IdBasedObjectData<T>> IEnumerable<IdBasedObjectData<T>>.GetEnumerator()
		{
			return null;
		}

		[DebuggerHidden]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}
	}

	[SerializeField]
	private Grid grid;

	[SerializeField]
	private Obj_GridInputControl gridInputController;

	[SerializeField]
	private Dictionary<Vector3Int, PlayerInteractableObjectData> dic_PlayerInteractableObjectData;

	[SerializeField]
	private Dictionary<Vector3Int, Obj_TetrisBlock> dic_TetrisPosition;

	[SerializeField]
	private Dictionary<Vector3Int, AGridObject> dic_GridObjects;

	[SerializeField]
	private Dictionary<Vector3Int, ABaseTower> dic_TowerPosition;

	[SerializeField]
	private Dictionary<Vector3Int, AGridObject> dic_TetrisBlockingGrids;

	[SerializeField]
	private Dictionary<Vector3Int, eTerritoryType> dic_Territory;

	[SerializeField]
	private List<TerritoryOverride> list_TerritoryOverride;

	[SerializeField]
	private Dictionary<Vector3Int, Obj_AncientMech_Base> dic_AncientMechConnectPositions;

	[SerializeField]
	private List<IVisionObject> list_VisionObjects;

	private Mesh territoryMesh_Player;

	private Mesh territoryMesh_Enemy;

	private List<Vector3Int> playerTerritory;

	private List<Vector3Int> enemyTerritory;

	private List<Vector3Int> lastUpdateEnemyTerritory;

	private MeshRenderer territoryMeshRenderer_Player;

	private MeshRenderer territoryMeshRenderer_Enemy;

	private bool isTerritoryChanged;

	private ParticleSystem vfx_TerritoryClear;

	private static int GroundLayer;

	private static int PathObstacleLayer;

	private static int GroundAndObstacleMask;

	private float checkUpdateTerritoryInterval;

	private float checkUpdateTerritoryTimer;

	private Dictionary<Type, List<IIdBasedObjectData>> dic_IDBasedObjectData;

	protected override void Awake()
	{
	}

	private void Update()
	{
	}

	private void OnDestroy()
	{
	}

	public bool IsGraphWalkableAtPosition(Vector3 position)
	{
		return false;
	}

	public bool IsGraphWalkableAtPosition(Vector3Int position)
	{
		return false;
	}

	public Vector3 GetGridPos(Vector3 position)
	{
		return default(Vector3);
	}

	public Vector3Int GetGridCell(Vector3 position)
	{
		return default(Vector3Int);
	}

	public (bool, Vector3Int) GetRandomEmptyGridCell(Vector3 center, int rangeX = 30, int rangeZ = 30, List<Vector3Int> excludeList = null)
	{
		return default((bool, Vector3Int));
	}

	public void RegisterPlayerInteractableObject(APlayerInteractableObjects interactableObject, Vector3Int pos, int priority = 0)
	{
	}

	public void UnregisterPlayerInteractableObject(APlayerInteractableObjects interactableObject, Vector3Int pos)
	{
	}

	public APlayerInteractableObjects GetTopPriorityPlayerInteractableObjectAtPosition(Vector3 position)
	{
		return null;
	}

	public List<APlayerInteractableObjects> GetPlayerInteractableObjectsAtPosition(Vector3 position)
	{
		return null;
	}

	public bool IsHaveAnyPlayerInteractableObjectAtPosition(Vector3 position)
	{
		return false;
	}

	public bool IsHaveAnyPlayerInteractableObjectAtPosition(Vector3Int position)
	{
		return false;
	}

	public void RegisterTetris(Obj_TetrisBlock block)
	{
	}

	public void UnregisterTetris(Obj_TetrisBlock block)
	{
	}

	public void UnregisterTetrisPiece(Vector3Int pos)
	{
	}

	public Obj_TetrisBlock GetTetrisAtPosition(Vector3 position)
	{
		return null;
	}

	public bool IsHaveTetrisAtPosition(Vector3 position)
	{
		return false;
	}

	public bool IsHaveTetrisAtPosition(Vector3Int position)
	{
		return false;
	}

	public bool IsHaveAnyPlatformAtPosition(Vector3 position)
	{
		return false;
	}

	public bool IsHaveAnyPlatformAtPosition(Vector3Int position)
	{
		return false;
	}

	public void RegisterGridObject(AGridObject gridObject, Vector3Int pos)
	{
	}

	public void UnregisterGridObject(AGridObject gridObject, Vector3Int pos)
	{
	}

	public bool MoveRegisteredGridObject(AGridObject gridObject, Vector3Int from, Vector3Int to)
	{
		return false;
	}

	public bool IsHaveGridObjectAtPosition(Vector3Int pos)
	{
		return false;
	}

	public bool IsHaveGridObjectAtPosition(Vector3 position)
	{
		return false;
	}

	public AGridObject GetGridObjectAtPosition(Vector3 position)
	{
		return null;
	}

	public List<AGridObject> GetGridObjectsInRange(Vector3 position, float range)
	{
		return null;
	}

	public List<AGridObject> GetAllGridObjects()
	{
		return null;
	}

	public void RegisterTetrisBlockingGrid(AGridObject gridObject)
	{
	}

	public void RegisterTetrisBlockingGridWithOverridePos(AGridObject gridObject, Vector3 overridePos)
	{
	}

	public void UnregisterTetrisBlockingGrid(AGridObject gridObject)
	{
	}

	public bool IsRegisteredTetrisBlockingGrid(AGridObject gridObject)
	{
		return false;
	}

	public bool IsHaveTetrisBlockingGridAtPosition(Vector3 position)
	{
		return false;
	}

	public void RegisterTower(ABaseTower tower)
	{
	}

	public void UnregisterTower(ABaseTower tower)
	{
	}

	public ABaseTower GetTowerAtPosition(Vector3 position)
	{
		return null;
	}

	public ABaseTower GetTowerAtPosition(Vector3Int position)
	{
		return null;
	}

	public bool IsHaveTowerAtPosition(Vector3 position)
	{
		return false;
	}

	public bool IsHaveTowerAtPosition(Vector3Int position)
	{
		return false;
	}

	public bool CanSpawnObjectAtPosition(Vector3Int position)
	{
		return false;
	}

	public List<Vector3Int> GetAllGridPositionsBetween(Vector3Int startPos, Vector3Int endPos)
	{
		return null;
	}

	public List<Vector3Int> GetAllGridPositionsBetweenStraightLine(Vector3Int startPos, Vector3Int endPos)
	{
		return null;
	}

	public eTerritoryType GetTerritoryAtPosition(Vector3 position)
	{
		return default(eTerritoryType);
	}

	public void SetTerritoryAtPosition(Vector3 position, eTerritoryType territory)
	{
	}

	public void OverrideTerritory(int id, Vector3Int pos)
	{
	}

	public void UnoverrideTerritory(int id)
	{
	}

	public void UpdateTerritory(bool isImmediate)
	{
	}

	public bool IsInEnemyTerritory(Vector3 position)
	{
		return false;
	}

	public void RegisterAncientMechConnectPosition(Vector3Int pos, Obj_AncientMech_Base ancientMech)
	{
	}

	public void UnregisterAncientMechConnectPosition(Vector3Int pos, Obj_AncientMech_Base ancientMech)
	{
	}

	public bool IsHaveAncientMechConnectPosition(Vector3Int pos)
	{
		return false;
	}

	public Obj_AncientMech_Base GetAncientMechAtPosition(Vector3Int pos)
	{
		return null;
	}

	public void RegisterVisionObject(IVisionObject visionObject, float overrideRange = -1f)
	{
	}

	public void UnregisterVisionObject(IVisionObject visionObject)
	{
	}

	public bool IsPositionInVision(Vector3 pos, float targetRadius = 0f)
	{
		return false;
	}

	public void RegisterIDBasedObjectData<T>(int id, T targetObject, Vector3Int position)
	{
	}

	public bool UnregisterIDBasedObjectData<T>(int id)
	{
		return false;
	}

	public bool MoveIDBasedObjectData<T>(int id, Vector3Int newPosition)
	{
		return false;
	}

	public bool IsHaveObjectAt(Vector3Int position)
	{
		return false;
	}

	public bool IsHaveObjectAt<T>(Vector3Int position)
	{
		return false;
	}

	public T GetObjectAt<T>(Vector3Int position)
	{
		return default(T);
	}

	[IteratorStateMachine(typeof(_003CGetIDBasedObjectDataList_003Ed__93<>))]
	public IEnumerable<IdBasedObjectData<T>> GetIDBasedObjectDataList<T>()
	{
		return null;
	}

	private void DestroyMesh()
	{
	}

	public void CheckUpdateTerritory()
	{
	}

	public void DrawTerritoryMesh()
	{
	}

	public static Mesh CreateAreaMesh_V2(List<Vector3Int> points)
	{
		return null;
	}

	public static Mesh CreateAreaMesh(List<Vector3Int> points)
	{
		return null;
	}

	private static bool IsOuterCell(Vector3Int point, HashSet<Vector3Int> pointSet)
	{
		return false;
	}

	private static bool IsIntegerVertex(Vector3 vertex)
	{
		return false;
	}

	public static Mesh CreateAreaMesh_V1(List<Vector3Int> points)
	{
		return null;
	}

	private static void CountVertex(Dictionary<Vector3, int> vertexShareCount, Vector3 vertex)
	{
	}

	private static void AddQuad(List<Vector3> vertices, List<int> triangles, Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4)
	{
	}

	private static void SetVertexColors(List<Vector3> vertices, Dictionary<Vector3, int> countMap, List<Color> colors)
	{
	}

	public static void DrawAreaOutline(List<Vector3Int> area, Color color)
	{
	}
}
