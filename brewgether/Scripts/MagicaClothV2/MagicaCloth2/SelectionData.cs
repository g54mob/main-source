using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace MagicaCloth2
{
	[Serializable]
	public class SelectionData : IValid
	{
		[BurstCompile]
		private struct TransformPositionJob : IJobParallelFor
		{
			public float4x4 transformMatrix;

			public NativeArray<float3> localPositions;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct CreateGridMapJob : IJob
		{
			public bool move;

			public bool fix;

			public bool ignore;

			public bool invalid;

			public NativeParallelMultiHashMap<int3, int> gridMap;

			public float gridSize;

			[ReadOnly]
			public NativeArray<float3> positions;

			[ReadOnly]
			public NativeArray<VertexAttribute> attribute;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct ConvertSelectionJob : IJobParallelFor
		{
			public float gridSize;

			public float radius;

			[ReadOnly]
			public NativeArray<float3> toPositions;

			[WriteOnly]
			public NativeArray<VertexAttribute> toAttributes;

			[ReadOnly]
			public NativeParallelMultiHashMap<int3, int> gridMap;

			[ReadOnly]
			public NativeArray<float3> fromPositions;

			[ReadOnly]
			public NativeArray<VertexAttribute> fromAttributes;

			public void Execute(int vindex)
			{
			}
		}

		public float3[] positions;

		public VertexAttribute[] attributes;

		public float maxConnectionDistance;

		public bool userEdit;

		public int Count => 0;

		public SelectionData()
		{
		}

		public SelectionData(int cnt)
		{
		}

		public SelectionData(VirtualMesh vmesh, float4x4 transformMatrix)
		{
		}

		public bool IsValid()
		{
			return false;
		}

		public bool IsUserEdit()
		{
			return false;
		}

		public SelectionData Clone()
		{
			return null;
		}

		public bool Compare(SelectionData sdata)
		{
			return false;
		}

		public void AddRange(float3[] addPositions, VertexAttribute[] addAttributes = null)
		{
		}

		public void Fill(VertexAttribute attr)
		{
		}

		public NativeArray<float3> GetPositionNativeArray()
		{
			return default(NativeArray<float3>);
		}

		public NativeArray<float3> GetPositionNativeArray(float4x4 transformMatrix)
		{
			return default(NativeArray<float3>);
		}

		public NativeArray<VertexAttribute> GetAttributeNativeArray()
		{
			return default(NativeArray<VertexAttribute>);
		}

		public static GridMap<int> CreateGridMapRun(float gridSize, in NativeArray<float3> positions, in NativeArray<VertexAttribute> attributes, bool move = true, bool fix = true, bool ignore = true, bool invalid = true)
		{
			return null;
		}

		public void Merge(SelectionData from)
		{
		}

		public void ConvertFrom(SelectionData from)
		{
		}
	}
}
