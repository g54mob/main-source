using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace MagicaCloth2
{
	public static class JobUtility
	{
		[BurstCompile]
		private struct FillJob<T> : IJobParallelFor where T : struct
		{
			public T value;

			[WriteOnly]
			public NativeArray<T> array;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct FillJob2<T> : IJobParallelFor where T : struct
		{
			public T value;

			public int startIndex;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<T> array;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct FillRefJob<T> : IJob where T : struct
		{
			public T value;

			[WriteOnly]
			public NativeReference<T> reference;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct SerialNumberJob : IJobParallelFor
		{
			[WriteOnly]
			public NativeArray<int> array;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		private struct ConvertHashSetToListJob<T> : IJob where T : struct, IEquatable<T>
		{
			[ReadOnly]
			public NativeParallelHashSet<T> hashSet;

			[WriteOnly]
			public NativeList<T> list;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct ConvertHashSetKeyToListJob<T> : IJob where T : struct, IEquatable<T>
		{
			[ReadOnly]
			public NativeParallelHashSet<T> hashSet;

			[WriteOnly]
			public NativeList<T> list;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct CalcAABBJob : IJob
		{
			public int length;

			[ReadOnly]
			public NativeArray<float3> positions;

			public NativeReference<AABB> outAABB;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct CalcAABBDeferJob : IJob
		{
			[ReadOnly]
			public NativeList<float3> positions;

			public NativeReference<AABB> outAABB;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct CalcUVJob : IJobParallelFor
		{
			[ReadOnly]
			public NativeArray<float3> positions;

			[ReadOnly]
			public NativeReference<AABB> aabb;

			[WriteOnly]
			public NativeArray<float2> uvs;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		public struct AddIntDataCopyJob : IJobParallelFor
		{
			public int dstOffset;

			public int addData;

			[ReadOnly]
			public NativeArray<int> srcData;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<int> dstData;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		public struct AddInt2DataCopyJob : IJobParallelFor
		{
			public int dstOffset;

			public int2 addData;

			[ReadOnly]
			public NativeArray<int2> srcData;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<int2> dstData;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		public struct AddInt3DataCopyJob : IJobParallelFor
		{
			public int dstOffset;

			public int3 addData;

			[ReadOnly]
			public NativeArray<int3> srcData;

			[NativeDisableParallelForRestriction]
			[WriteOnly]
			public NativeArray<int3> dstData;

			public void Execute(int index)
			{
			}
		}

		[BurstCompile]
		public struct TransformPositionJob : IJobParallelFor
		{
			public float4x4 toM;

			public NativeArray<float3> positions;

			public void Execute(int vindex)
			{
			}
		}

		[BurstCompile]
		public struct TransformPositionJob2 : IJobParallelFor
		{
			public float4x4 toM;

			[ReadOnly]
			public NativeArray<float3> srcPositions;

			[WriteOnly]
			public NativeArray<float3> dstPositions;

			public void Execute(int vindex)
			{
			}
		}

		[BurstCompile]
		private struct ConvertArrayToMapJob<TData> : IJob where TData : struct
		{
			[ReadOnly]
			public NativeArray<uint> indexArray;

			[ReadOnly]
			public NativeArray<TData> dataArray;

			[WriteOnly]
			public NativeParallelMultiHashMap<int, TData> map;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct ClearReferenceJob : IJob
		{
			public NativeReference<int> reference;

			public void Execute()
			{
			}
		}

		public static JobHandle Fill(NativeArray<int> array, int length, int value, JobHandle dependsOn = default(JobHandle))
		{
			return default(JobHandle);
		}

		public static JobHandle Fill(NativeArray<Vector4> array, int length, Vector4 value, JobHandle dependsOn = default(JobHandle))
		{
			return default(JobHandle);
		}

		public static JobHandle Fill(NativeArray<VirtualMeshBoneWeight> array, int length, VirtualMeshBoneWeight value, JobHandle dependsOn = default(JobHandle))
		{
			return default(JobHandle);
		}

		public static JobHandle Fill(NativeArray<byte> array, int length, byte value, JobHandle dependsOn = default(JobHandle))
		{
			return default(JobHandle);
		}

		public static void FillRun(NativeArray<int> array, int length, int value)
		{
		}

		public static void FillRun(NativeArray<Vector4> array, int length, Vector4 value)
		{
		}

		public static void FillRun(NativeArray<quaternion> array, int length, quaternion value)
		{
		}

		public static void FillRun(NativeArray<VirtualMeshBoneWeight> array, int length, VirtualMeshBoneWeight value)
		{
		}

		public static JobHandle Fill(NativeArray<int> array, int startIndex, int length, int value, JobHandle dependsOn = default(JobHandle))
		{
			return default(JobHandle);
		}

		public static JobHandle Fill(NativeReference<int> reference, int value, JobHandle dependsOn = default(JobHandle))
		{
			return default(JobHandle);
		}

		public static JobHandle SerialNumber(NativeArray<int> array, int length, JobHandle dependsOn = default(JobHandle))
		{
			return default(JobHandle);
		}

		public static void SerialNumberRun(NativeArray<int> array, int length)
		{
		}

		public static JobHandle ConvertHashSetToNativeList(NativeParallelHashSet<int> hashSet, NativeList<int> list, JobHandle dependsOn = default(JobHandle))
		{
			return default(JobHandle);
		}

		public static JobHandle ConvertHashSetKeyToNativeList(NativeParallelHashSet<int2> hashSet, NativeList<int2> keyList, JobHandle dependsOn = default(JobHandle))
		{
			return default(JobHandle);
		}

		public static JobHandle ConvertHashSetKeyToNativeList(NativeParallelHashSet<int4> hashSet, NativeList<int4> keyList, JobHandle dependsOn = default(JobHandle))
		{
			return default(JobHandle);
		}

		public static JobHandle CalcAABB(NativeArray<float3> positions, int length, NativeReference<AABB> outAABB, JobHandle dependsOn = default(JobHandle))
		{
			return default(JobHandle);
		}

		public static void CalcAABBRun(NativeArray<float3> positions, int length, NativeReference<AABB> outAABB)
		{
		}

		public static JobHandle CalcAABB(NativeList<float3> positions, NativeReference<AABB> outAABB, JobHandle dependsOn = default(JobHandle))
		{
			return default(JobHandle);
		}

		public static void CalcAABBRun(NativeList<float3> positions, NativeReference<AABB> outAABB)
		{
		}

		private static AABB CalcAABBInternal(in NativeArray<float3> positions, int length)
		{
			return default(AABB);
		}

		public static JobHandle CalcUVWithSphereMapping(NativeArray<float3> positions, int length, NativeReference<AABB> aabb, NativeArray<float2> outUVs, JobHandle dependsOn = default(JobHandle))
		{
			return default(JobHandle);
		}

		public static void CalcUVWithSphereMappingRun(NativeArray<float3> positions, int length, NativeReference<AABB> aabb, NativeArray<float2> outUVs)
		{
		}

		public static JobHandle TransformPosition(NativeArray<float3> positions, int length, in float4x4 toM, JobHandle dependsOn = default(JobHandle))
		{
			return default(JobHandle);
		}

		public static void TransformPositionRun(NativeArray<float3> positions, int length, in float4x4 toM)
		{
		}

		public static JobHandle TransformPosition(NativeArray<float3> srcPositions, NativeArray<float3> dstPositions, int length, in float4x4 toM, JobHandle dependsOn = default(JobHandle))
		{
			return default(JobHandle);
		}

		public static void TransformPositionRun(NativeArray<float3> srcPositions, NativeArray<float3> dstPositions, int length, in float4x4 toM)
		{
		}

		public static NativeParallelMultiHashMap<int, ushort> ToNativeMultiHashMap(in NativeArray<uint> indexArray, in NativeArray<ushort> dataArray)
		{
			return default(NativeParallelMultiHashMap<int, ushort>);
		}

		public static JobHandle ClearReference(NativeReference<int> reference, JobHandle jobHandle)
		{
			return default(JobHandle);
		}
	}
}
