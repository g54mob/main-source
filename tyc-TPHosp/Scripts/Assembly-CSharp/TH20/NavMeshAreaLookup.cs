using System.Collections.Generic;
using UnityEngine;

namespace TH20
{
	public class NavMeshAreaLookup
	{
		private class PartitionRoot
		{
			public bool _bInitialised;

			public string _partitionName;

			public Vector3[] _vertices;

			public Rect[] _triangleBounds;

			public PartitionItem _rootPartition;

			public int _totalNumPartitions;

			public int _totalNumPartitionsUnsplit;

			public bool _useGlobalIndices;
		}

		private class PartitionItem
		{
			public int _uniqueID;

			public Rect _partitionRect;

			public bool _bHasBeenSplitProcessed;

			public List<int> _whollyContainedGlobalTriangleIndices;

			public List<PartitionItem> _childPartitions;
		}

		private const float _smallDistance = 0.2f;

		private readonly int[] _indices;

		private readonly Vector3[] _vertices;

		private readonly Vector3[] _verticesExpanded;

		private readonly int[] _islandIDs;

		private readonly Rect[] _triangleBounds;

		private readonly Rect[] _triangleBoundsExpanded;

		private static int _nextUniqueID = 1;

		private const bool _bUseTrianglePartitioning = true;

		private const bool _bUseTrianglePartitioningLog = false;

		private const bool _bUseTrianglePartitioningLogQuery = false;

		private const int _partitionDivisor = 2;

		private const int _maxNumPartitions = 32;

		private const int _minNumTrianglesForSplitting = 100;

		private const float _minPartitionSize = 5f;

		private PartitionRoot _rootPartitionDefault = new PartitionRoot();

		private PartitionRoot _rootPartitionExpanded = new PartitionRoot();

		public Vector3[] Vertices => _vertices;

		public NavMeshAreaLookup(int[] indices, Vector3[] vertices, int[] islandIDs)
		{
			_indices = indices;
			_vertices = vertices;
			_islandIDs = islandIDs;
			int num = _indices.Length / 3;
			_verticesExpanded = new Vector3[num * 3];
			_triangleBounds = new Rect[num];
			_triangleBoundsExpanded = new Rect[num];
			for (int i = 0; i < num; i++)
			{
				int num2 = i * 3;
				Vector3 vector = _vertices[_indices[num2]];
				Vector3 vector2 = _vertices[_indices[num2 + 1]];
				Vector3 vector3 = _vertices[_indices[num2 + 2]];
				Vector3 vector4 = (vector + vector2 + vector3) / 3f;
				_triangleBounds[i] = MathUtils.CalculateRectFromTriangleXZ(vector, vector2, vector3);
				vector += (vector - vector4).normalized * 0.2f;
				vector2 += (vector2 - vector4).normalized * 0.2f;
				vector3 += (vector3 - vector4).normalized * 0.2f;
				_verticesExpanded[num2] = vector;
				_verticesExpanded[num2 + 1] = vector2;
				_verticesExpanded[num2 + 2] = vector3;
				_triangleBoundsExpanded[i] = MathUtils.CalculateRectFromTriangleXZ(vector, vector2, vector3);
			}
		}

		public int IslandIDAtPosition(Vector3 position, AllowDistanceOffNavMesh allowDistanceOffNavMesh = AllowDistanceOffNavMesh.Disallow)
		{
			return IslandIDAtPosition_Partitioning(position, allowDistanceOffNavMesh);
		}

		public int IslandIDAtPosition_Default(Vector3 position, AllowDistanceOffNavMesh allowDistanceOffNavMesh = AllowDistanceOffNavMesh.Disallow)
		{
			Vector2 point = position.Xz();
			if (allowDistanceOffNavMesh == AllowDistanceOffNavMesh.Disallow)
			{
				int num = _indices.Length / 3;
				for (int i = 0; i < num; i++)
				{
					if (_triangleBounds[i].Contains(point))
					{
						int num2 = i * 3;
						Vector3 p = _vertices[_indices[num2]];
						Vector3 p2 = _vertices[_indices[num2 + 1]];
						Vector3 p3 = _vertices[_indices[num2 + 2]];
						if (MathUtils.PosIsInTriangleXZ(position, p, p2, p3))
						{
							return _islandIDs[i];
						}
					}
				}
			}
			else
			{
				int num3 = _verticesExpanded.Length / 3;
				for (int j = 0; j < num3; j++)
				{
					if (_triangleBoundsExpanded[j].Contains(point))
					{
						int num4 = j * 3;
						Vector3 p4 = _verticesExpanded[num4];
						Vector3 p5 = _verticesExpanded[num4 + 1];
						Vector3 p6 = _verticesExpanded[num4 + 2];
						if (MathUtils.PosIsInTriangleXZ(position, p4, p5, p6))
						{
							return _islandIDs[j];
						}
					}
				}
			}
			return -1;
		}

		public int IslandIDAtCoord(GridCoord coord, AllowDistanceOffNavMesh allowDistanceOffNavMesh = AllowDistanceOffNavMesh.Disallow)
		{
			return IslandIDAtPosition(coord.ToWorldPosition(), allowDistanceOffNavMesh);
		}

		private void InitialisePartitionDefault()
		{
			InitialisePartitionItems(ref _rootPartitionDefault, "Default", _vertices, _triangleBounds, bUseGlobalIndices: true);
		}

		private void InitialisePartitionExpanded()
		{
			InitialisePartitionItems(ref _rootPartitionExpanded, "Expanded", _verticesExpanded, _triangleBoundsExpanded, bUseGlobalIndices: false);
		}

		private void InitialisePartitionItems(ref PartitionRoot root, string partitionName, Vector3[] vertices, Rect[] triangleBounds, bool bUseGlobalIndices)
		{
			PartitionLogSeparator();
			ResetPartition(ref root);
			root._bInitialised = true;
			root._partitionName = partitionName;
			root._vertices = vertices;
			root._triangleBounds = triangleBounds;
			root._useGlobalIndices = bUseGlobalIndices;
			root._rootPartition = CreatePartition(ref root);
			int num = _indices.Length / 3;
			for (int i = 0; i < num; i++)
			{
				root._rootPartition._whollyContainedGlobalTriangleIndices.Add(i);
			}
			root._rootPartition._partitionRect = DeterminePartitionTrianglesBoundingRect(root, ref root._rootPartition);
			while (!IsSplittingComplete(ref root))
			{
				ProcessSplitPartition(ref root, ref root._rootPartition);
			}
		}

		private void ResetPartition(ref PartitionRoot root)
		{
			if (root != null)
			{
				root._partitionName = string.Empty;
				root._rootPartition = null;
				root._vertices = null;
				root._totalNumPartitions = 0;
				root._totalNumPartitionsUnsplit = 0;
				root._useGlobalIndices = true;
			}
		}

		private PartitionItem CreatePartition(ref PartitionRoot root)
		{
			PartitionItem partitionItem = new PartitionItem();
			partitionItem._uniqueID = _nextUniqueID++;
			partitionItem._partitionRect = default(Rect);
			partitionItem._bHasBeenSplitProcessed = false;
			partitionItem._whollyContainedGlobalTriangleIndices = new List<int>();
			partitionItem._childPartitions = new List<PartitionItem>();
			root._totalNumPartitions++;
			root._totalNumPartitionsUnsplit++;
			return partitionItem;
		}

		private List<PartitionItem> GetFlatPartitionsList(PartitionRoot root)
		{
			List<PartitionItem> retPartitionsList = new List<PartitionItem>();
			GetFlatPartitionsListItems(root, ref root._rootPartition, ref retPartitionsList);
			return retPartitionsList;
		}

		private void GetFlatPartitionsListItems(PartitionRoot root, ref PartitionItem partition, ref List<PartitionItem> retPartitionsList)
		{
			retPartitionsList.Add(partition);
			foreach (PartitionItem childPartition in partition._childPartitions)
			{
				PartitionItem partition2 = childPartition;
				GetFlatPartitionsListItems(root, ref partition2, ref retPartitionsList);
			}
		}

		private Rect DeterminePartitionTrianglesBoundingRect(PartitionRoot root, ref PartitionItem partition)
		{
			Rect result = default(Rect);
			if (partition._whollyContainedGlobalTriangleIndices.Count > 0)
			{
				float num = 1000000f;
				float num2 = 1000000f;
				float num3 = -1000000f;
				float num4 = -1000000f;
				int i = 0;
				for (int count = partition._whollyContainedGlobalTriangleIndices.Count; i < count; i++)
				{
					int num5 = partition._whollyContainedGlobalTriangleIndices[i] * 3;
					for (int j = 0; j < 3; j++)
					{
						int num6 = (root._useGlobalIndices ? _indices[num5 + j] : (num5 + j));
						Vector3 vector = root._vertices[num6];
						if (vector.x < num)
						{
							num = vector.x;
						}
						if (vector.z < num2)
						{
							num2 = vector.z;
						}
						if (vector.x > num3)
						{
							num3 = vector.x;
						}
						if (vector.z > num4)
						{
							num4 = vector.z;
						}
					}
				}
				result.xMin = num;
				result.xMax = num3;
				result.yMin = num2;
				result.yMax = num4;
			}
			return result;
		}

		private void ProcessSplitPartition(ref PartitionRoot root, ref PartitionItem partition)
		{
			if (IsSplittingComplete(ref root))
			{
				return;
			}
			if (partition._bHasBeenSplitProcessed)
			{
				int i = 0;
				for (int count = partition._childPartitions.Count; i < count; i++)
				{
					PartitionItem partition2 = partition._childPartitions[i];
					ProcessSplitPartition(ref root, ref partition2);
				}
			}
			else
			{
				SplitPartition(ref root, ref partition);
			}
		}

		private void SplitPartition(ref PartitionRoot root, ref PartitionItem parentPartition)
		{
			bool flag = false;
			int num = 0;
			if (parentPartition._whollyContainedGlobalTriangleIndices.Count >= 100)
			{
				float num2 = (parentPartition._partitionRect.xMax - parentPartition._partitionRect.xMin) / 2f;
				float num3 = (parentPartition._partitionRect.yMax - parentPartition._partitionRect.yMin) / 2f;
				if (num2 >= 5f && num3 >= 5f)
				{
					flag = true;
					for (int i = 0; i < 2; i++)
					{
						for (int j = 0; j < 2; j++)
						{
							PartitionItem partitionItem = CreatePartition(ref root);
							float x = parentPartition._partitionRect.xMin + (float)i * num2;
							float y = parentPartition._partitionRect.yMin + (float)j * num3;
							partitionItem._partitionRect.x = x;
							partitionItem._partitionRect.y = y;
							partitionItem._partitionRect.width = num2;
							partitionItem._partitionRect.height = num3;
							parentPartition._childPartitions.Add(partitionItem);
						}
					}
					int count = parentPartition._whollyContainedGlobalTriangleIndices.Count;
					int count2 = parentPartition._childPartitions.Count;
					int num4 = 0;
					List<int> list = new List<int>();
					for (int k = 0; k < count; k++)
					{
						int num5 = parentPartition._whollyContainedGlobalTriangleIndices[k] * 3;
						bool flag2 = false;
						for (int l = 0; l < count2; l++)
						{
							PartitionItem partitionItem2 = parentPartition._childPartitions[l];
							bool flag3 = true;
							for (int m = 0; m < 3; m++)
							{
								int num6 = (root._useGlobalIndices ? _indices[num5 + m] : (num5 + m));
								Vector3 point = root._vertices[num6];
								if (!partitionItem2._partitionRect.Contains(point))
								{
									flag3 = false;
									break;
								}
							}
							if (flag3)
							{
								flag2 = true;
								num4++;
								partitionItem2._whollyContainedGlobalTriangleIndices.Add(parentPartition._whollyContainedGlobalTriangleIndices[k]);
								break;
							}
						}
						if (!flag2)
						{
							list.Add(parentPartition._whollyContainedGlobalTriangleIndices[k]);
						}
					}
					if (list.Count > 0)
					{
						parentPartition._whollyContainedGlobalTriangleIndices.Clear();
						parentPartition._whollyContainedGlobalTriangleIndices = list;
					}
					_ = 0;
					int num7 = parentPartition._childPartitions.RemoveAll((PartitionItem childPartition) => childPartition._whollyContainedGlobalTriangleIndices.Count <= 0);
					root._totalNumPartitions -= num7;
					root._totalNumPartitionsUnsplit -= num7;
					int num8 = 0;
					foreach (PartitionItem childPartition in parentPartition._childPartitions)
					{
						PartitionItem partition = childPartition;
						Rect rect = DeterminePartitionTrianglesBoundingRect(root, ref partition);
						bool flag4 = false;
						if (partition._partitionRect.xMin < rect.xMin)
						{
							flag4 = true;
							partition._partitionRect.xMin = rect.xMin;
						}
						if (partition._partitionRect.xMax > rect.xMax)
						{
							flag4 = true;
							partition._partitionRect.xMax = rect.xMax;
						}
						if (partition._partitionRect.yMin < rect.yMin)
						{
							flag4 = true;
							partition._partitionRect.yMin = rect.yMin;
						}
						if (partition._partitionRect.yMax > rect.yMax)
						{
							flag4 = true;
							partition._partitionRect.yMax = rect.yMax;
						}
						if (flag4)
						{
							num8++;
						}
					}
					num = parentPartition._childPartitions.Count;
				}
			}
			parentPartition._bHasBeenSplitProcessed = true;
			root._totalNumPartitionsUnsplit--;
		}

		private bool IsSplittingComplete(ref PartitionRoot root)
		{
			bool result = false;
			if (root._totalNumPartitions >= 32 || root._totalNumPartitionsUnsplit <= 0)
			{
				result = true;
			}
			return result;
		}

		private void PartitionLogSeparator()
		{
		}

		private void PartitionLog(PartitionRoot root, PartitionItem partition, string contextStr, string logStr)
		{
			UnityEngine.Debug.LogFormat("[{0}] PARTITIONING - {1} - PID:{2,3} - {3} - {4}", Time.frameCount, root._partitionName, (partition != null) ? partition._uniqueID.ToString() : "n/a", contextStr, logStr);
		}

		public int IslandIDAtPosition_Partitioning(Vector3 position, AllowDistanceOffNavMesh allowDistanceOffNavMesh = AllowDistanceOffNavMesh.Disallow)
		{
			int num = -1;
			if (allowDistanceOffNavMesh == AllowDistanceOffNavMesh.Disallow)
			{
				if (!_rootPartitionDefault._bInitialised)
				{
					InitialisePartitionDefault();
				}
				return IslandIDAtPosition_PartitioningGeneral(position, _rootPartitionDefault);
			}
			if (!_rootPartitionExpanded._bInitialised)
			{
				InitialisePartitionExpanded();
			}
			return IslandIDAtPosition_PartitioningGeneral(position, _rootPartitionExpanded);
		}

		private int IslandIDAtPosition_PartitioningGeneral(Vector3 position, PartitionRoot root)
		{
			int num = -1;
			int numTests = 0;
			return GetIslandIDAtPositionPartition(position, root, root._rootPartition, ref numTests);
		}

		private int GetIslandIDAtPositionPartition(Vector3 position, PartitionRoot root, PartitionItem partition, ref int numTests)
		{
			int num = -1;
			if (partition._partitionRect.Contains(position))
			{
				num = GetIslandIDAtPositionPartitionTriangles(position, root, partition, ref numTests);
				if (num < 0)
				{
					foreach (PartitionItem childPartition in partition._childPartitions)
					{
						num = GetIslandIDAtPositionPartition(position, root, childPartition, ref numTests);
						if (num >= 0)
						{
							break;
						}
					}
				}
			}
			return num;
		}

		private int GetIslandIDAtPositionPartitionTriangles(Vector3 position, PartitionRoot root, PartitionItem partition, ref int numTests)
		{
			int result = -1;
			if (partition._whollyContainedGlobalTriangleIndices.Count > 0)
			{
				Vector2 point = position.Xz();
				foreach (int whollyContainedGlobalTriangleIndex in partition._whollyContainedGlobalTriangleIndices)
				{
					numTests++;
					if (root._triangleBounds[whollyContainedGlobalTriangleIndex].Contains(point))
					{
						int num = whollyContainedGlobalTriangleIndex * 3;
						Vector3 p;
						Vector3 p2;
						Vector3 p3;
						if (root._useGlobalIndices)
						{
							p = root._vertices[_indices[num]];
							p2 = root._vertices[_indices[num + 1]];
							p3 = root._vertices[_indices[num + 2]];
						}
						else
						{
							p = root._vertices[num];
							p2 = root._vertices[num + 1];
							p3 = root._vertices[num + 2];
						}
						if (MathUtils.PosIsInTriangleXZ(position, p, p2, p3))
						{
							result = _islandIDs[whollyContainedGlobalTriangleIndex];
							break;
						}
					}
				}
			}
			return result;
		}

		public void GetIslandTriangles(int islandID, List<int> triangles)
		{
			for (int i = 0; i < _islandIDs.Length; i++)
			{
				if (_islandIDs[i] == islandID)
				{
					int num = i * 3;
					triangles.Add(_indices[num]);
					triangles.Add(_indices[num + 1]);
					triangles.Add(_indices[num + 2]);
				}
			}
		}

		public void GetIslandBoundaryLineList(int islandID, List<int> indices)
		{
			List<int> list = new List<int>();
			GetIslandTriangles(islandID, list);
			foreach (NavMeshHelpers.Edge item in NavMeshHelpers.GetEdges(list.ToArray()).FindBoundary().SortEdges())
			{
				indices.Add(item.v1);
				indices.Add(item.v2);
			}
		}

		public Rect DetermineTrianglesBoundingRect(AllowDistanceOffNavMesh allowDistanceOffNavMesh = AllowDistanceOffNavMesh.Disallow)
		{
			Rect result = default(Rect);
			float num = 1000000f;
			float num2 = 1000000f;
			float num3 = -1000000f;
			float num4 = -1000000f;
			if (allowDistanceOffNavMesh == AllowDistanceOffNavMesh.Disallow)
			{
				int i = 0;
				for (int num5 = _indices.Length / 3; i < num5; i++)
				{
					int j = 0;
					int num6 = i * 3;
					for (; j < 3; j++)
					{
						Vector3 vector = _vertices[_indices[num6 + j]];
						if (vector.x < num)
						{
							num = vector.x;
						}
						if (vector.z < num2)
						{
							num2 = vector.z;
						}
						if (vector.x > num3)
						{
							num3 = vector.x;
						}
						if (vector.z > num4)
						{
							num4 = vector.z;
						}
					}
				}
			}
			else
			{
				int k = 0;
				for (int num7 = _verticesExpanded.Length / 3; k < num7; k++)
				{
					int l = 0;
					int num8 = k * 3;
					for (; l < 3; l++)
					{
						Vector3 vector2 = _verticesExpanded[num8 + l];
						if (vector2.x < num)
						{
							num = vector2.x;
						}
						if (vector2.z < num2)
						{
							num2 = vector2.z;
						}
						if (vector2.x > num3)
						{
							num3 = vector2.x;
						}
						if (vector2.z > num4)
						{
							num4 = vector2.z;
						}
					}
				}
			}
			result.xMin = num;
			result.xMax = num3;
			result.yMin = num2;
			result.yMax = num4;
			return result;
		}
	}
}
