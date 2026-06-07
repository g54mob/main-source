using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace Placemaker.Graphs
{
	public class Graph : MonoBehaviour
	{
		private enum LoadState
		{
			Begin = 0,
			RemoveExistingVoxels = 1,
			ClearQubes = 2,
			LoadNewVoxels = 3,
			ApplyActions = 4
		}

		[SerializeField]
		private WorldMaster master;

		[SerializeField]
		[HideInInspector]
		public Transform qubePool;

		[HideInInspector]
		[SerializeField]
		public Transform corners;

		[HideInInspector]
		[SerializeField]
		public Transform cornerPool;

		[HideInInspector]
		[SerializeField]
		public Transform squares;

		[SerializeField]
		[HideInInspector]
		public Transform squarePool;

		[SerializeField]
		[HideInInspector]
		public Transform looseVoxels;

		[SerializeField]
		[HideInInspector]
		public Transform voxelPool;

		[SerializeField]
		private uint qubeIterator;

		[SerializeField]
		private uint cornerIterator;

		[SerializeField]
		private uint squareIterator;

		[SerializeField]
		private uint voxelIterator;

		[SerializeField]
		private uint totalVoxelCount;

		public Dictionary<int2, Corner> cornerDict;

		public Dictionary<int2, Square> squareDict;

		private Dictionary<int2x2, Square.Relation> edgeDict;

		[SerializeField]
		private List<Corner> cornerIntegrationQueue;

		[SerializeField]
		private List<Corner> cornerFlowQueue;

		[SerializeField]
		private List<Qube> qubeUpdateQueue;

		[SerializeField]
		public Bounds shadowMeshBounds;

		[SerializeField]
		private List<int> shadowMeshIndexes;

		[SerializeField]
		private int shadowMeshIndexIterator;

		public const int maxVertsCount = 65535;

		public const int quadPerShadowMeshCount = 16383;

		[Space]
		[SerializeField]
		public int boundsHeight;

		[SerializeField]
		public int3x2 bounds;

		[SerializeField]
		public int3x2 border;

		[SerializeField]
		public int3x2 genBounds;

		[SerializeField]
		public int3x2 viewBounds;

		public int maxHeight;

		[SerializeField]
		public BoxCollider groundCollider;

		public System.Action onBoundsUpdated;

		public System.Action onEmptyBoundsLoaded;

		public const int maxHeightMin = 64;

		public const int maxHeightMax = 256;

		public const ushort borderExtentMin = 256;

		public const ushort borderExtentMax = 512;

		public const ushort genExtent = 96;

		[SerializeField]
		private bool boundsUpdated;

		[SerializeField]
		private bool recalculateHexBounds;

		[SerializeField]
		private bool recalculateHeightBounds;

		private LoadState loadState;

		private static readonly int gridViewMinId;

		private static readonly int gridViewMaxId;

		private static readonly int gridBorderMinId;

		private static readonly int gridBorderMaxId;

		public bool anyVoxels => false;

		public void OnStart()
		{
		}

		private void OnEnable()
		{
		}

		public Qube.Relation6 GetQubeRelation6(Qube qube, byte mask)
		{
			return default(Qube.Relation6);
		}

		public Qube.Relation GetQubeRelation(Qube qube, sbyte index)
		{
			return default(Qube.Relation);
		}

		public bool IterateFocus()
		{
			return false;
		}

		private static (int, int) GetMaxExtents(int3x2 bounds, int height)
		{
			return default((int, int));
		}

		public void SetEmptyBoundsCenter(int2 centerPos)
		{
		}

		public bool Iterate()
		{
			return false;
		}

		public bool IterateRefillPools()
		{
			return false;
		}

		private Corner GetNewCorner(Transform parent)
		{
			return null;
		}

		private Corner GetOrCreateCorner(int2 hexPos)
		{
			return null;
		}

		public bool CheckVoxel(int2 hexPos, int height)
		{
			return false;
		}

		private Voxel GetNewVoxel(Transform parent)
		{
			return null;
		}

		private Qube GetNewQube(Transform parent)
		{
			return null;
		}

		private Square GetNewSquare(Transform parent)
		{
			return null;
		}

		private bool IntegrateCorner(Corner voxelCorner)
		{
			return false;
		}

		public void ApplyAction(Action action, bool playEffect)
		{
		}

		public bool IsCoordinateAllowed(int2 hexPos, int height)
		{
			return false;
		}

		public Voxel AddVoxel(int2 hexPos, byte height, VoxelType voxelType, bool instantIntegration)
		{
			return null;
		}

		private void IntegrateVoxel(Voxel voxel, Corner corner)
		{
		}

		public void RemoveVoxel(Voxel voxel)
		{
		}

		public void PaintVoxel(Voxel voxel, VoxelType newType, Corner corner = null)
		{
		}

		public void QubeUpdated(Qube qube)
		{
		}

		public int BinaryTreeSearchVoxel(Transform cornerTransform, int height)
		{
			return 0;
		}

		public int BinaryTreeSearchCorner(int2 hexPos0)
		{
			return 0;
		}

		public int BinaryTreeSearchSquare(Vector3 pos)
		{
			return 0;
		}

		public void Test()
		{
		}

		public void Save(SaveData saveData)
		{
		}

		public void BeginLoad(SaveData saveData)
		{
		}

		public bool IterateLoad(SaveData saveData)
		{
			return false;
		}

		public (Qube, Square, Vector2, Vector2, Vector2, Vector2, int) GetQubeWithContext(Vector3 worldPos)
		{
			return default((Qube, Square, Vector2, Vector2, Vector2, Vector2, int));
		}

		public Vector3 SampleNormal(Vector3 worldPos)
		{
			return default(Vector3);
		}

		public (Vector3, float) SampleNormalCoverage(Vector3 worldPos)
		{
			return default((Vector3, float));
		}

		public (Vector3, float) SampleNormalCoverage(Vector3 worldPos, Transform qubeChild)
		{
			return default((Vector3, float));
		}

		public (Vector3, float) SampleNormalCoverage(Vector3 worldPos, Qube qube)
		{
			return default((Vector3, float));
		}

		public (Vector3, float) SampleNormalDistance(Vector3 worldPos)
		{
			return default((Vector3, float));
		}

		public (Vector3, float) SampleNormalDistance2(Vector3 worldPos)
		{
			return default((Vector3, float));
		}

		private void OnDrawGizmos()
		{
		}
	}
}
