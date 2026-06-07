using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Flight;
using Assets.Scripts.Flight.Events;
using Cysharp.Threading.Tasks;
using Jundroo.Common.Pool;
using Unity.Mathematics;
using Unity.Profiling;
using UnityEngine;

namespace Assets.Scripts.Environment.Vegetation
{
	public class TreeColliderManager : MonoBehaviour
	{
		[Flags]
		private enum DebugLogFlags
		{
			None = 0,
			TerrainRegistration = 1,
			TopCellsByTreeCount = 2,
			ShowActiveTrees = 4,
			ShowActiveCells = 8,
			All = 0xF
		}

		private struct ActiveTreeData
		{
			public float Distance;

			public float3 Position;

			public TerrainTreeData Terrain;

			public TreeData Tree;

			public ActiveTreeData(TreeData tree, Vector3 position, TerrainTreeData terrain, float distance)
			{
				Tree = tree;
				Position = position;
				Terrain = terrain;
				Distance = distance;
			}
		}

		private struct ActiveTreeDataCell
		{
			public TreeDataCell Cell;

			public int2 CellPosition;

			public float2 LocalPosition;

			public TerrainTreeData Terrain;

			public ActiveTreeDataCell(TreeDataCell cell, int2 cellPosition, TerrainTreeData terrain, float2 localPosition)
			{
				Cell = cell;
				CellPosition = cellPosition;
				Terrain = terrain;
				LocalPosition = localPosition;
			}
		}

		private struct TreeData
		{
			public float ColliderHeight;

			public float3 ColliderOffset;

			public float ColliderRadius;

			public int Id;

			public float3 Position;

			public TreeData(int id, float3 position, float3 colliderOffset, float colliderRadius, float colliderHeight)
			{
				Id = id;
				Position = position;
				ColliderOffset = colliderOffset;
				ColliderRadius = colliderRadius;
				ColliderHeight = colliderHeight;
			}
		}

		private struct TreeDataCell
		{
			public List<TreeData> TreeData;
		}

		private static class Profile
		{
			public static readonly ProfilerMarker FindActiveCells = new ProfilerMarker("TreeColliderManager.FindActiveCells");

			public static readonly ProfilerMarker FindClosestTrees = new ProfilerMarker("TreeColliderManager.FindClosestTrees");

			public static readonly ProfilerMarker FixedUpdate = new ProfilerMarker("TreeColliderManager.FixedUpdate");

			public static readonly ProfilerMarker RebuildTreeData = new ProfilerMarker("TreeColliderManager.RebuildTreeData");

			public static readonly ProfilerMarker UpdateTreeColliders = new ProfilerMarker("TreeColliderManager.UpdateTreeColliders");
		}

		private class PooledTreeCollider
		{
			public int AssignedTreeId;

			public CapsuleCollider Collider;

			public Transform Transform;

			public bool UpdateFlag;

			public PooledTreeCollider(CapsuleCollider collider, Transform transform)
			{
				Collider = collider;
				Transform = transform;
			}
		}

		private class TerrainTreeData
		{
			private static class Profile
			{
				public static readonly ProfilerMarker BuildTreeData = new ProfilerMarker("TerrainTreeData.BuildTreeData");
			}

			private int _cellCountX;

			private int _cellCountZ;

			private float _cellSizeX;

			private float _cellSizeXNormalized;

			private float _cellSizeZ;

			private float _cellSizeZNormalized;

			private float3 _terrainSize;

			private TreeDataCell[] _treeData;

			public float CellSizeX => _cellSizeX;

			public float CellSizeZ => _cellSizeZ;

			public byte Id { get; }

			public bool Initialized { get; private set; }

			public float MaxColliderDistance { get; private set; }

			public bool RebuildTreeData { get; set; }

			public UnityEngine.Terrain Terrain { get; }

			public TerrainVegetationScript TerrainVegetation { get; }

			public TerrainTreeData(byte id, TerrainVegetationScript terrainVegetationScript)
			{
				Id = id;
				TerrainVegetation = terrainVegetationScript;
				Terrain = terrainVegetationScript.Terrain;
			}

			public void BuildTreeData(float maxColliderDistance)
			{
				Initialized = false;
				TerrainData terrainData = Terrain.terrainData;
				TreeColliderData[] colliderData = GetColliderData(terrainData);
				Vector3 size = terrainData.size;
				BuildTreeData(maxColliderDistance, size, colliderData);
			}

			public void BuildTreeDataAsync(float maxColliderDistance)
			{
				Initialized = false;
				TerrainData terrainData = Terrain.terrainData;
				TreeColliderData[] colliderData = GetColliderData(terrainData);
				Vector3 terrainSize = terrainData.size;
				UniTask.RunOnThreadPool(delegate
				{
					BuildTreeData(maxColliderDistance, terrainSize, colliderData);
				}, configureAwait: false).Forget();
			}

			public TreeDataCell? GetCell(int2 pos)
			{
				if (pos.x >= 0 && pos.x < _cellCountX && pos.y >= 0 && pos.y < _cellCountZ)
				{
					return _treeData[pos.y * _cellCountX + pos.x];
				}
				return null;
			}

			public int2 GetCellPosition(float2 pos)
			{
				return new int2((int)(pos.x / _cellSizeX), (int)(pos.y / _cellSizeZ));
			}

			public void LogTopCellsByTreeCount(int count)
			{
				List<int> list = (from x in _treeData
					select x.TreeData.Count into x
					orderby x descending
					select x).ToList();
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("Terrain '" + Terrain.name + "' Top Cells By Tree Count:");
				for (int num = 0; num < count && num != list.Count; num++)
				{
					stringBuilder.AppendLine(list[num].ToString());
				}
				Debug.Log(stringBuilder);
			}

			private void BuildTreeData(float maxColliderDistance, float3 terrainSize, TreeColliderData[] colliderData)
			{
				using (Profile.BuildTreeData.Auto())
				{
					MaxColliderDistance = maxColliderDistance;
					RebuildTreeData = false;
					_terrainSize = terrainSize;
					_cellCountX = Mathf.CeilToInt(_terrainSize.x / MaxColliderDistance);
					_cellCountZ = Mathf.CeilToInt(_terrainSize.z / MaxColliderDistance);
					_cellSizeX = _terrainSize.x / (float)_cellCountX;
					_cellSizeZ = _terrainSize.z / (float)_cellCountZ;
					_cellSizeXNormalized = 1f / (float)_cellCountX;
					_cellSizeZNormalized = 1f / (float)_cellCountZ;
					_treeData = new TreeDataCell[_cellCountX * _cellCountZ];
					for (int i = 0; i < _treeData.Length; i++)
					{
						_treeData[i].TreeData = new List<TreeData>();
					}
					TreeInstance[] treeInstances = TerrainVegetation.TreeInstances;
					int num = treeInstances.Length;
					for (int j = 0; j < num; j++)
					{
						ref TreeInstance reference = ref treeInstances[j];
						TreeColliderData treeColliderData = colliderData[reference.prototypeIndex];
						int id = (Id << 24) | j;
						TreeData item = ((treeColliderData == null) ? new TreeData(id, Vector3.Scale(reference.position, _terrainSize), Vector3.zero, 0f, 0f) : new TreeData(id, Vector3.Scale(reference.position, _terrainSize), treeColliderData.Center, treeColliderData.Radius, treeColliderData.Height));
						int num2 = (int)(reference.position.x / _cellSizeXNormalized);
						int num3 = (int)(reference.position.z / _cellSizeZNormalized) * _cellCountX + num2;
						_treeData[num3].TreeData.Add(item);
					}
					Initialized = true;
				}
			}

			private TreeColliderData[] GetColliderData(TerrainData terrainData)
			{
				TreePrototype[] treePrototypes = terrainData.treePrototypes;
				TreeColliderData[] array = new TreeColliderData[treePrototypes.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = treePrototypes[i].prefab.GetComponent<TreeColliderData>();
					if (array[i] == null)
					{
						Debug.LogError("Tree '" + treePrototypes[i].prefab.name + "' on terrain '" + Terrain.name + "' has no 'TreeColliderData' script.");
					}
				}
				return array;
			}
		}

		private List<PooledTreeCollider> _assignedColliders;

		private List<PooledTreeCollider> _assignedCollidersTemp;

		private Stack<byte> _availableTerrainIds;

		private List<PooledTreeCollider> _colliderPool;

		private List<ActiveTreeData> _collidersToBeAssigned;

		private List<(float3 Position, float3 Size)> _debugActiveCells = new List<(float3, float3)>();

		private List<float3> _debugAllTreePositions = new List<float3>();

		[SerializeField]
		private DebugLogFlags _debugLogFlags;

		private FlightSceneScript _flightSceneScript;

		private int _lastUpdateFrame;

		[SerializeField]
		private float _maxColliderDistance = 50f;

		[SerializeField]
		private int _maxColliders = 50;

		private byte _nextTerrainId;

		private bool _rebuildTreeData;

		private Dictionary<UnityEngine.Terrain, TerrainTreeData> _terrainTreeDatas;

		[SerializeField]
		private int _totalActiveTrees;

		[SerializeField]
		private int _totalCollidableTrees;

		private Stack<PooledTreeCollider> _unassignedColliders;

		public int MaxColliders => _maxColliders;

		public static TreeColliderManager Create(FlightSceneScript flightSceneScript)
		{
			TreeColliderManager treeColliderManager = new GameObject("TreeColliderManager").AddComponent<TreeColliderManager>();
			treeColliderManager.transform.SetParent(flightSceneScript.transform);
			try
			{
				treeColliderManager.Initialize(flightSceneScript);
			}
			catch (Exception exception)
			{
				Debug.LogError("An error occurred initializing the tree collider manager");
				Debug.LogException(exception);
			}
			return treeColliderManager;
		}

		public void RebuildTreeData(TerrainVegetationScript terrainVegetationScript)
		{
			if (_terrainTreeDatas.TryGetValue(terrainVegetationScript.Terrain, out var value))
			{
				_rebuildTreeData = true;
				value.RebuildTreeData = true;
			}
		}

		public void RegisterTerrain(TerrainVegetationScript terrainVegetationScript)
		{
			if (_debugLogFlags.HasFlag(DebugLogFlags.TerrainRegistration))
			{
				Debug.Log($"{Time.frameCount}: Registered Terrain '{terrainVegetationScript.name}' with {terrainVegetationScript.TreeInstances.Length} trees");
			}
			byte num = ((_availableTerrainIds.Count > 0) ? _availableTerrainIds.Pop() : _nextTerrainId++);
			if (num == byte.MaxValue)
			{
				Debug.LogError($"{Time.frameCount}: TreeColliderManager exhausted all terrain IDs. This is likely a bug.");
			}
			TerrainTreeData terrainTreeData = new TerrainTreeData(num, terrainVegetationScript);
			terrainTreeData.BuildTreeDataAsync(_maxColliderDistance);
			if (_debugLogFlags.HasFlag(DebugLogFlags.TopCellsByTreeCount))
			{
				terrainTreeData.LogTopCellsByTreeCount(20);
			}
			_terrainTreeDatas.Add(terrainVegetationScript.Terrain, terrainTreeData);
		}

		public void UnregisterTerrain(TerrainVegetationScript terrainVegetationScript)
		{
			if (_debugLogFlags.HasFlag(DebugLogFlags.TerrainRegistration))
			{
				Debug.Log($"{Time.frameCount}: Unregistered Terrain '{terrainVegetationScript.name}' with {terrainVegetationScript.TreeInstances.Length} trees");
			}
			if (_terrainTreeDatas.TryGetValue(terrainVegetationScript.Terrain, out var value))
			{
				_availableTerrainIds.Push(value.Id);
				_terrainTreeDatas.Remove(terrainVegetationScript.Terrain);
			}
		}

		protected virtual void FixedUpdate()
		{
			using (Profile.FixedUpdate.Auto())
			{
				if (_rebuildTreeData)
				{
					RebuildTreeData();
				}
				bool num = _lastUpdateFrame == Time.frameCount;
				_lastUpdateFrame = Time.frameCount;
				if (num)
				{
					return;
				}
				List<ActiveTreeDataCell> value;
				using (CollectionPool<List<ActiveTreeDataCell>, ActiveTreeDataCell>.Get(out value))
				{
					List<ActiveTreeData> value2;
					using (CollectionPool<List<ActiveTreeData>, ActiveTreeData>.Get(out value2))
					{
						FindActiveCells(value);
						FindClosestTrees(value, value2);
						UpdateTreeColliders(value2);
					}
				}
			}
		}

		protected virtual void OnDestroy()
		{
			GameWorld instance = GameWorld.Instance;
			if (instance != null)
			{
				instance.FloatingOriginChanged -= OnFloatingOriginChanged;
			}
		}

		protected virtual void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.white;
			foreach (float3 debugAllTreePosition in _debugAllTreePositions)
			{
				Gizmos.DrawCube(debugAllTreePosition, new Vector3(2f, 20f, 2f));
			}
			Gizmos.color = new Color(Color.cyan.r, Color.cyan.g, Color.cyan.b, 0.25f);
			foreach (var debugActiveCell in _debugActiveCells)
			{
				Gizmos.DrawCube(new Vector3(debugActiveCell.Position.x, FlightSceneScript.Instance.LocalPlayer.FramePosition.y, debugActiveCell.Position.z), debugActiveCell.Size);
			}
		}

		protected virtual void OnValidate()
		{
			if (_colliderPool != null && _colliderPool.Count != MaxColliders)
			{
				BuildTreeColliderPool();
			}
			if (_terrainTreeDatas != null)
			{
				foreach (TerrainTreeData value in _terrainTreeDatas.Values)
				{
					if (value.MaxColliderDistance != _maxColliderDistance)
					{
						if (_maxColliderDistance < 25f)
						{
							Debug.LogWarning($"Max Collider Distance too small: {_maxColliderDistance}");
							break;
						}
						_rebuildTreeData = true;
						value.RebuildTreeData = true;
					}
				}
			}
			_debugActiveCells.Clear();
			_debugAllTreePositions.Clear();
		}

		private void BuildTreeColliderPool()
		{
			if (_colliderPool == null)
			{
				_colliderPool = new List<PooledTreeCollider>(MaxColliders);
			}
			if (_unassignedColliders == null)
			{
				_unassignedColliders = new Stack<PooledTreeCollider>(MaxColliders);
			}
			if (_assignedColliders == null)
			{
				_assignedColliders = new List<PooledTreeCollider>(MaxColliders);
			}
			if (_assignedCollidersTemp == null)
			{
				_assignedCollidersTemp = new List<PooledTreeCollider>(MaxColliders);
			}
			if (_collidersToBeAssigned == null)
			{
				_collidersToBeAssigned = new List<ActiveTreeData>(MaxColliders);
			}
			for (int i = _colliderPool.Count; i < MaxColliders; i++)
			{
				GameObject obj = new GameObject($"TreeCollider{i:00}");
				CapsuleCollider collider = obj.AddComponent<CapsuleCollider>();
				Transform transform = obj.transform;
				transform.SetParent(base.transform, worldPositionStays: false);
				PooledTreeCollider item = new PooledTreeCollider(collider, transform);
				_colliderPool.Add(item);
			}
			for (int num = _colliderPool.Count - 1; num >= MaxColliders; num--)
			{
				PooledTreeCollider pooledTreeCollider = _colliderPool[num];
				_colliderPool.RemoveAt(num);
				UnityEngine.Object.Destroy(pooledTreeCollider.Transform.gameObject);
			}
			UnassignAllColliders();
		}

		private void FindActiveCells(List<ActiveTreeDataCell> activeCells)
		{
			using (Profile.FindActiveCells.Auto())
			{
				Vector3? vector = FlightSceneScript.Instance?.LocalPlayer?.FramePosition;
				if (!vector.HasValue)
				{
					return;
				}
				foreach (KeyValuePair<UnityEngine.Terrain, TerrainTreeData> terrainTreeData in _terrainTreeDatas)
				{
					if (terrainTreeData.Value.Initialized)
					{
						Vector3 position = terrainTreeData.Key.GetPosition();
						float num = vector.Value.x - position.x;
						float num2 = vector.Value.z - position.z;
						float2 pos = new float2(num, num2);
						Vector3 size = terrainTreeData.Key.terrainData.size;
						float cellSizeX = terrainTreeData.Value.CellSizeX;
						float cellSizeZ = terrainTreeData.Value.CellSizeZ;
						if (num >= 0f - cellSizeX && num <= size.x + cellSizeX && num2 >= 0f - cellSizeZ && num2 <= size.z + cellSizeZ)
						{
							GetActiveCells(activeCells, terrainTreeData.Value, pos);
						}
					}
				}
			}
		}

		private void FindClosestTrees(List<ActiveTreeDataCell> activeCells, List<ActiveTreeData> closestTrees)
		{
			using (Profile.FindClosestTrees.Auto())
			{
				bool flag = _debugLogFlags.HasFlag(DebugLogFlags.ShowActiveCells);
				if (flag)
				{
					_debugActiveCells.Clear();
				}
				bool flag2 = _debugLogFlags.HasFlag(DebugLogFlags.ShowActiveTrees);
				if (flag2)
				{
					_debugAllTreePositions.Clear();
				}
				int num = 0;
				int maxColliders = _maxColliders;
				float maxColliderDistance = _maxColliderDistance;
				float num2 = -1f;
				int num3 = 0;
				foreach (ActiveTreeDataCell activeCell in activeCells)
				{
					float2 localPosition = activeCell.LocalPosition;
					TerrainTreeData terrain = activeCell.Terrain;
					float3 float5 = terrain.Terrain.GetPosition();
					if (flag)
					{
						_debugActiveCells.Add((float5 + new float3(terrain.CellSizeX / 2f, 0f, terrain.CellSizeZ / 2f) + new float3(terrain.CellSizeX * (float)activeCell.CellPosition.x, 600f, terrain.CellSizeZ * (float)activeCell.CellPosition.y), new float3(terrain.CellSizeX, 50f, terrain.CellSizeZ) * 0.98f));
					}
					foreach (TreeData treeDatum in activeCell.Cell.TreeData)
					{
						if (flag2)
						{
							_debugAllTreePositions.Add(treeDatum.Position + float5);
						}
						num++;
						float num4 = math.abs(treeDatum.Position.x - localPosition.x);
						float num5 = math.abs(treeDatum.Position.z - localPosition.y);
						float num6 = num4 + num5;
						if (num6 > maxColliderDistance)
						{
							continue;
						}
						if (num6 > num2)
						{
							if (num3 < maxColliders)
							{
								closestTrees.Add(new ActiveTreeData(treeDatum, float5 + treeDatum.Position, terrain, num6));
								num2 = num6;
								num3++;
							}
							continue;
						}
						for (int num7 = num3 - 1; num7 >= 0; num7--)
						{
							if (num7 == 0 || num6 > closestTrees[num7 - 1].Distance)
							{
								closestTrees.Insert(num7, new ActiveTreeData(treeDatum, float5 + treeDatum.Position, terrain, num6));
								if (num3 == maxColliders)
								{
									closestTrees.RemoveAt(num3);
									num2 = closestTrees[num3 - 1].Distance;
								}
								else
								{
									num3++;
								}
								break;
							}
						}
					}
				}
				_totalActiveTrees = num;
				_totalCollidableTrees = num3;
			}
		}

		private void GetActiveCells(List<ActiveTreeDataCell> activeCells, TerrainTreeData data, float2 pos)
		{
			int2 cellPosition = data.GetCellPosition(pos);
			TreeDataCell? cell = data.GetCell(cellPosition);
			if (cell.HasValue)
			{
				activeCells.Add(new ActiveTreeDataCell(cell.Value, cellPosition, data, pos));
			}
			for (int i = -1; i <= 1; i++)
			{
				for (int j = -1; j <= 1; j++)
				{
					if (j != 0 || i != 0)
					{
						int2 int5 = cellPosition + new int2(j, i);
						cell = data.GetCell(int5);
						if (cell.HasValue)
						{
							activeCells.Add(new ActiveTreeDataCell(cell.Value, int5, data, pos));
						}
					}
				}
			}
		}

		private void Initialize(FlightSceneScript flightSceneScript)
		{
			_flightSceneScript = flightSceneScript;
			_terrainTreeDatas = new Dictionary<UnityEngine.Terrain, TerrainTreeData>();
			_availableTerrainIds = new Stack<byte>();
			BuildTreeColliderPool();
			base.gameObject.AddComponent<IgnoreFloatingOriginScript>();
			GameWorld.Instance.FloatingOriginChanged += OnFloatingOriginChanged;
		}

		private void OnFloatingOriginChanged(object sender, FloatingOriginChangedEventArgs e)
		{
			UnassignAllColliders();
		}

		private void RebuildTreeData()
		{
			using (Profile.RebuildTreeData.Auto())
			{
				_rebuildTreeData = false;
				foreach (TerrainTreeData value in _terrainTreeDatas.Values)
				{
					if (value.RebuildTreeData)
					{
						value.BuildTreeDataAsync(_maxColliderDistance);
					}
				}
			}
		}

		private void UnassignAllColliders()
		{
			_assignedColliders.Clear();
			for (int i = 0; i < _colliderPool.Count; i++)
			{
				_colliderPool[i].Collider.enabled = false;
				_unassignedColliders.Push(_colliderPool[i]);
			}
		}

		private void UpdateTreeColliders(List<ActiveTreeData> trees)
		{
			using (Profile.UpdateTreeColliders.Auto())
			{
				for (int i = 0; i < _assignedColliders.Count; i++)
				{
					_assignedColliders[i].UpdateFlag = false;
				}
				for (int j = 0; j < trees.Count; j++)
				{
					int id = trees[j].Tree.Id;
					PooledTreeCollider pooledTreeCollider = null;
					for (int k = 0; k < _assignedColliders.Count; k++)
					{
						if (_assignedColliders[k].AssignedTreeId == id)
						{
							pooledTreeCollider = _assignedColliders[k];
							break;
						}
					}
					if (pooledTreeCollider == null)
					{
						_collidersToBeAssigned.Add(trees[j]);
					}
					else
					{
						pooledTreeCollider.UpdateFlag = true;
					}
				}
				for (int l = 0; l < _assignedColliders.Count; l++)
				{
					PooledTreeCollider pooledTreeCollider2 = _assignedColliders[l];
					if (pooledTreeCollider2.UpdateFlag)
					{
						_assignedCollidersTemp.Add(pooledTreeCollider2);
						continue;
					}
					pooledTreeCollider2.Collider.enabled = false;
					_unassignedColliders.Push(pooledTreeCollider2);
				}
				for (int m = 0; m < _collidersToBeAssigned.Count; m++)
				{
					if (_unassignedColliders.Count == 0)
					{
						Debug.LogError($"{Time.frameCount}: The TreeColliderManager does not have enough pooled colliders to complete tree assignments.");
						break;
					}
					PooledTreeCollider pooledTreeCollider3 = _unassignedColliders.Pop();
					TreeData tree = _collidersToBeAssigned[m].Tree;
					float3 position = _collidersToBeAssigned[m].Position;
					pooledTreeCollider3.Collider.enabled = true;
					pooledTreeCollider3.Collider.center = tree.ColliderOffset;
					pooledTreeCollider3.Collider.height = tree.ColliderHeight;
					pooledTreeCollider3.Collider.radius = tree.ColliderRadius;
					pooledTreeCollider3.Transform.position = position;
					pooledTreeCollider3.AssignedTreeId = tree.Id;
					pooledTreeCollider3.UpdateFlag = true;
					_assignedCollidersTemp.Add(pooledTreeCollider3);
				}
				_assignedColliders.Clear();
				List<PooledTreeCollider> assignedCollidersTemp = _assignedCollidersTemp;
				List<PooledTreeCollider> assignedColliders = _assignedColliders;
				_assignedColliders = assignedCollidersTemp;
				_assignedCollidersTemp = assignedColliders;
				_collidersToBeAssigned.Clear();
			}
		}
	}
}
