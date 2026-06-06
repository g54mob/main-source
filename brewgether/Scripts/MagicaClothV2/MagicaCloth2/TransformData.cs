using System;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

namespace MagicaCloth2
{
	public class TransformData : IDisposable
	{
		[BurstCompile]
		private struct RestoreTransformJob : IJobParallelForTransform
		{
			public int count;

			[ReadOnly]
			public NativeArray<ExBitFlag8> flagList;

			[ReadOnly]
			public NativeArray<float3> localPositionArray;

			[ReadOnly]
			public NativeArray<quaternion> localRotationArray;

			public void Execute(int index, TransformAccess transform)
			{
			}
		}

		[BurstCompile]
		private struct ReadTransformJob : IJobParallelForTransform
		{
			[ReadOnly]
			public NativeArray<ExBitFlag8> flagList;

			[WriteOnly]
			public NativeArray<float3> positionArray;

			[WriteOnly]
			public NativeArray<quaternion> rotationArray;

			[WriteOnly]
			public NativeArray<float3> scaleList;

			[WriteOnly]
			public NativeArray<float3> localPositionArray;

			[WriteOnly]
			public NativeArray<quaternion> localRotationArray;

			[WriteOnly]
			public NativeArray<quaternion> inverseRotationArray;

			public void Execute(int index, TransformAccess transform)
			{
			}
		}

		[Serializable]
		public class ShareSerializationData
		{
			public ExSimpleNativeArray<ExBitFlag8>.SerializationData flagArray;

			public ExSimpleNativeArray<float3>.SerializationData initLocalPositionArray;

			public ExSimpleNativeArray<quaternion>.SerializationData initLocalRotationArray;
		}

		[Serializable]
		public class UniqueSerializationData : ITransform
		{
			public Transform[] transformArray;

			public void GetUsedTransform(HashSet<Transform> transformSet)
			{
			}

			public void ReplaceTransform(Dictionary<MagicaObjectId, Transform> replaceDict)
			{
			}
		}

		internal List<Transform> transformList;

		internal ExSimpleNativeArray<ExBitFlag8> flagArray;

		internal ExSimpleNativeArray<float3> initLocalPositionArray;

		internal ExSimpleNativeArray<quaternion> initLocalRotationArray;

		internal ExSimpleNativeArray<float3> positionArray;

		internal ExSimpleNativeArray<quaternion> rotationArray;

		internal ExSimpleNativeArray<quaternion> inverseRotationArray;

		internal ExSimpleNativeArray<float3> scaleArray;

		internal ExSimpleNativeArray<float3> localPositionArray;

		internal ExSimpleNativeArray<quaternion> localRotationArray;

		internal ExSimpleNativeArray<MagicaObjectId> idArray;

		internal ExSimpleNativeArray<MagicaObjectId> parentIdArray;

		internal List<MagicaObjectId> rootIdList;

		private bool isDirty;

		internal TransformAccessArray transformAccessArray;

		private Queue<int> emptyStack;

		public int Count => 0;

		public int RootCount => 0;

		public bool IsDirty => false;

		public bool IsEmpty => false;

		public TransformData()
		{
		}

		public TransformData(int capacity)
		{
		}

		public void Init(int capacity)
		{
		}

		public void Dispose()
		{
		}

		public int AddTransform(Transform t, MagicaObjectId tid, MagicaObjectId pid, byte flag = 1, bool checkDuplicate = true)
		{
			return 0;
		}

		public int AddTransform(TransformRecord record, MagicaObjectId pid, byte flag = 1, bool checkDuplicate = true)
		{
			return 0;
		}

		public int AddTransform(TransformData srcData, int srcIndex, bool checkDuplicate = true)
		{
			return 0;
		}

		public int[] AddTransformRange(List<Transform> tlist, List<MagicaObjectId> idList, List<MagicaObjectId> pidList, int copyCount = 0)
		{
			return null;
		}

		public int[] AddTransformRange(TransformData stdata, int copyCount = 0)
		{
			return null;
		}

		public int[] AddTransformRange(List<Transform> tlist, List<MagicaObjectId> idList, List<MagicaObjectId> pidList, List<MagicaObjectId> rootIds, NativeArray<float3> localPositions, NativeArray<quaternion> localRotations, NativeArray<float3> positions, NativeArray<quaternion> rotations, NativeArray<float3> scales, NativeArray<quaternion> inverseRotations)
		{
			return null;
		}

		public void RemoveTransformIndex(int index)
		{
		}

		public int ReplaceTransform(int index, Transform t, MagicaObjectId tid, MagicaObjectId pid, byte flag = 1)
		{
			return 0;
		}

		private int ReferenceIndexOf<T>(List<T> list, T item) where T : class
		{
			return 0;
		}

		public void UpdateWorkData()
		{
		}

		public JobHandle RestoreTransform(int count, JobHandle jobHandle = default(JobHandle))
		{
			return default(JobHandle);
		}

		public JobHandle ReadTransform(JobHandle jobHandle = default(JobHandle))
		{
			return default(JobHandle);
		}

		public void ReadTransformRun()
		{
		}

		public void OrganizeReductionTransform(VirtualMesh vmesh, ReductionWorkData workData)
		{
		}

		public Transform GetTransformFromIndex(int index)
		{
			return null;
		}

		public int GetTransformIndexFormId(MagicaObjectId id)
		{
			return 0;
		}

		public MagicaObjectId GetTransformIdFromIndex(int index)
		{
			return default(MagicaObjectId);
		}

		public MagicaObjectId GetParentIdFromIndex(int index)
		{
			return default(MagicaObjectId);
		}

		public float4x4 GetLocalToWorldMatrix(int index)
		{
			return default(float4x4);
		}

		public float4x4 GetWorldToLocalMatrix(int index)
		{
			return default(float4x4);
		}

		public override string ToString()
		{
			return null;
		}

		public ShareSerializationData ShareSerialize()
		{
			return null;
		}

		public static TransformData ShareDeserialize(ShareSerializationData sdata)
		{
			return null;
		}

		public UniqueSerializationData UniqueSerialize()
		{
			return null;
		}
	}
}
