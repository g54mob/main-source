using System.Collections.Generic;
using UnityEngine;

public class MapManager : Singleton<MapManager>
{
	[SerializeField]
	[Header("玩家的基地位置")]
	private List<IPlayerStartPoint> list_PlayerOrigins;

	private Obj_FireSource playerMainOrigin;

	[SerializeField]
	private List<MonsterSpawner> list_Spawners;

	private List<AMonsterBase> list_PathAviliableCheckMonsters;

	private Vector3 monsterPos;

	public Obj_FireSource PlayerMainOrigin => null;

	protected override void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnInitializeEnvSceneBindings(GameSceneReferenceHandler refHandler)
	{
	}

	public bool IsPathBlocked()
	{
		return false;
	}

	public void RegisterPlayerOrigin(IPlayerStartPoint origin, bool isMainOrigin)
	{
	}

	public void UnregisterPlayerOrigin(IPlayerStartPoint origin)
	{
	}

	public bool IsAnyPlayerOriginRegistered()
	{
		return false;
	}

	public IPlayerStartPoint GetClosestPlayerOrigin(Vector3 from)
	{
		return null;
	}

	public bool IsTooCloseToPlayer(Vector3 position, float rangeLimit)
	{
		return false;
	}

	private void OnGridObjectChanged(GameObject obj)
	{
	}

	private void OnGridObjectChangedInBound(Bounds bounds)
	{
	}

	private void OnGraphUpdated(AstarPath script)
	{
	}

	public bool CheckPathBlockedByObject(List<Collider> list_Colliders, bool alwaysRevert = false)
	{
		return false;
	}

	public void ChangeSpawnPointPosition(int index, Vector3 newPosition)
	{
	}

	public bool CheckIsPathAvaliable(Vector3 from, Vector3 to)
	{
		return false;
	}

	public void RegisterPathAviliableCheckMonster(AMonsterBase monster)
	{
	}

	public void UnregisterPathAviliableCheckMonster(AMonsterBase monster)
	{
	}

	public bool CheckPathBlockedByObject(List<Collider> list_Colliders, Vector3 startPos, Vector3 endPos, bool alwaysRevert = false, bool updatePlacementPath = true)
	{
		return false;
	}

	public List<Vector3> GetAllPathPoints()
	{
		return null;
	}

	public bool IsPointOnAnyPath(Vector3Int position)
	{
		return false;
	}

	public List<Vector3> GetAllPathPointsInRange(Vector3 center, float range)
	{
		return null;
	}

	public Vector3 GetNearestPathPoint(Vector3 from)
	{
		return default(Vector3);
	}

	public List<MonsterSpawner> GetSpawners()
	{
		return null;
	}

	public int GetSpawnerCount()
	{
		return 0;
	}

	public MonsterSpawner GetSpawnerByIndex(int index)
	{
		return null;
	}
}
