using System.Collections.Generic;
using UnityEngine;

public class PoolMgr : MonoBehaviour
{
	public static PoolMgr I;

	[NamedArray(typeof(GridPieceType))]
	public SerializedObjectPool<GridPieceObj>[] PiecePool;

	public ObjectPool<EnemyMeshController>[][] EnemyMeshPool;

	[NamedArray(typeof(PickupType))]
	public SerializedObjectPool<PickupObj>[] PickupPool;

	[NamedArray(typeof(BuildingType))]
	public SerializedObjectPool<BuildingMeshObj>[] BuildingMeshPool;

	[NamedArray(typeof(BuildingType))]
	public SerializedObjectPool<BaseScaffoldObj>[] BuildingScaffoldPool;

	public SerializedObjectPool<BaseScaffoldObj> GenericScaffoldPool;

	public SerializedObjectPool<BaseScaffoldObj> GenericScaffoldPool1x1;

	public FastPool<BallObj> BallPool;

	[NamedArray(typeof(ArrowType))]
	public SerializedObjectPool<ArrowObj>[] ArrowPool;

	[NamedArray(typeof(ObstacleType))]
	public SerializedObjectPool<ObstacleObj>[] ObstaclePool;

	[NamedArray(typeof(PetType))]
	public SerializedObjectPool<PetObj>[] PetPool;

	public SerializedObjectPool<BlockingCloudObj> BlockingCloudPool;

	public Dictionary<Collider2D, ArrowObj> ArrowColDict;

	public SerializedObjectPool<TurretObj> TurretPool;

	public SerializedObjectPool<MosquitoObj> MosquitoPool;

	public SerializedObjectPool<GridPieceMarker> MarkerPool;

	public SerializedObjectPool<GridPieceShadow> ShadowPool;

	public SerializedObjectPool<BuildingObj> BuildingPool;

	public SerializedObjectPool<BaseWallPiece> BaseWallPool;

	public SerializedObjectPool<ChunkCoverObj> ChunkCoverPool;

	public SerializedObjectPool<ChunkCoverObj> ChunkVerticalCoverPool;

	public SerializedObjectPool<ChunkCoverObj> ChunkHorizontalCoverPool;

	public SerializedObjectPool<ChunkCoverObj> ChunkCornerCoverPool;

	[NamedArray(typeof(ArrowType))]
	public ArrowBatchRenderSettings[] ArrowBatchSettings;

	private Matrix4x4[][] _arrowMatrix;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void LateUpdate()
	{
	}

	private void OnSceneAboutToChange()
	{
	}

	private void OnValidate()
	{
	}

	public void InitPiecePool(GridPieceObj p)
	{
	}

	public void RemovePiece(GridPieceObj p)
	{
	}

	public ArrowObj CreateArrow(ArrowType t, GridPieceInst shooter, Vector2 dir)
	{
		return null;
	}

	public ArrowObj CreateArrow(ArrowType t, GridPieceInst shooter, Vector2 dir, Vector3 pos)
	{
		return null;
	}

	public void RemoveArrow(ArrowObj ao)
	{
	}

	public bool HasAnyProjectile()
	{
		return false;
	}

	public void RemoveBuilding(BuildingObj b)
	{
	}

	public GridPieceMarker CreateMarker(GridPieceObj p, Vector3 pos, bool shouldFollow)
	{
		return null;
	}

	public void RemoveMarker(GridPieceMarker p)
	{
	}

	public BlockingCloudObj CreateBlockingCloud()
	{
		return null;
	}

	public void RemoveBlockingCloud(BlockingCloudObj bc)
	{
	}

	public PetObj CreatePet(int idx, PetBattleInst p)
	{
		return null;
	}

	public void RemovePet(PetObj p)
	{
	}

	public BuildingMeshObj CreateBuildingMesh(BuildingObj b)
	{
		return null;
	}

	public void RemoveBuildingMesh(BuildingMeshObj bMesh)
	{
	}

	public void InitEnemyMeshPool(LevelType lvl, GridPieceInfo pInf, EnemyMeshController mc)
	{
	}

	public EnemyMeshController CreateEnemyMesh(GridPieceInfo pInf, Transform ownerXfm, LevelType lvl)
	{
		return null;
	}

	private GridPieceType GetTgtEnemyMeshType(GridPieceType t)
	{
		return default(GridPieceType);
	}

	public EnemyMeshController CreateEnemyMesh(GridPieceObj p, LevelType lvl)
	{
		return null;
	}

	public void RemoveEnemyMesh(EnemyMeshController m)
	{
	}

	public void RemoveEnemyMesh(GridPieceObj p)
	{
	}

	public BaseScaffoldObj CreateScaffold(BuildingObj b)
	{
		return null;
	}

	public void RemoveScaffold(BaseScaffoldObj bMesh)
	{
	}

	public GridPieceShadow CreateShadow(GridPieceObj p)
	{
		return null;
	}

	public void RemoveShadow(GridPieceShadow shadow)
	{
	}

	public void SpawnMosquito(MosquitoType t, HeroInst h, Vector3 hitPos)
	{
	}
}
