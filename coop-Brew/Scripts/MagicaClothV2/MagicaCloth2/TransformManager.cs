using System;
using System.Text;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Jobs;

namespace MagicaCloth2
{
	public class TransformManager : IManager, IDisposable, IValid
	{
		[BurstCompile]
		private struct EnableTransformJob : IJob
		{
			public DataChunk chunk;

			public bool sw;

			public NativeArray<ExBitFlag8> flagList;

			public void Execute()
			{
			}
		}

		[BurstCompile]
		private struct RestoreTransformJob : IJobParallelForTransform
		{
			[NativeDisableParallelForRestriction]
			public NativeReference<bool> existFixedTeam;

			[ReadOnly]
			public NativeArray<ExBitFlag8> flagList;

			[ReadOnly]
			public NativeArray<float3> localPositionArray;

			[ReadOnly]
			public NativeArray<quaternion> localRotationArray;

			[ReadOnly]
			public NativeArray<short> teamIdArray;

			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			public void Execute(int index, TransformAccess transform)
			{
			}
		}

		[BurstCompile]
		private struct RestoreBaseTransformJob : IJobParallelForTransform
		{
			[ReadOnly]
			public NativeArray<ExBitFlag8> flagList;

			[ReadOnly]
			public NativeArray<float3> baseLocalPositionArray;

			[ReadOnly]
			public NativeArray<quaternion> baseLocalRotationArray;

			[ReadOnly]
			public NativeArray<short> teamIdArray;

			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			public void Execute(int index, TransformAccess transform)
			{
			}
		}

		[BurstCompile]
		private struct ReadTransformJob : IJobParallelForTransform
		{
			public int fixedUpdateCount;

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
			public NativeArray<float3> localScaleArray;

			[WriteOnly]
			public NativeArray<float4x4> localToWorldMatrixArray;

			[WriteOnly]
			public NativeArray<float3> baseLocalPositionArray;

			[WriteOnly]
			public NativeArray<quaternion> baseLocalRotationArray;

			[ReadOnly]
			public NativeArray<short> teamIdArray;

			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			public void Execute(int index, TransformAccess transform)
			{
			}
		}

		[BurstCompile]
		private struct WriteTransformJob : IJobParallelForTransform
		{
			[ReadOnly]
			public NativeArray<ExBitFlag8> flagList;

			[ReadOnly]
			public NativeArray<float3> worldPositions;

			[ReadOnly]
			public NativeArray<quaternion> worldRotations;

			[ReadOnly]
			public NativeArray<float3> localPositions;

			[ReadOnly]
			public NativeArray<quaternion> localRotations;

			[ReadOnly]
			public NativeArray<short> teamIdArray;

			[ReadOnly]
			public NativeArray<TeamManager.TeamData> teamDataArray;

			public void Execute(int index, TransformAccess transform)
			{
			}
		}

		[BurstCompile]
		private struct ReadComponentTransformJob : IJobParallelForTransform
		{
			[WriteOnly]
			public NativeArray<float3> positionArray;

			[WriteOnly]
			public NativeArray<float> minScaleArray;

			public void Execute(int index, TransformAccess transform)
			{
			}
		}

		internal const byte Flag_Read = 1;

		internal const byte Flag_WorldRotWrite = 2;

		internal const byte Flag_LocalPosRotWrite = 4;

		internal const byte Flag_Restore = 8;

		internal const byte Flag_Enable = 16;

		internal ExNativeArray<ExBitFlag8> flagArray;

		internal ExNativeArray<float3> initLocalPositionArray;

		internal ExNativeArray<quaternion> initLocalRotationArray;

		internal ExNativeArray<float3> baseLocalPositionArray;

		internal ExNativeArray<quaternion> baseLocalRotationArray;

		internal ExNativeArray<float3> positionArray;

		internal ExNativeArray<quaternion> rotationArray;

		internal ExNativeArray<float3> scaleArray;

		internal ExNativeArray<float3> localPositionArray;

		internal ExNativeArray<quaternion> localRotationArray;

		internal ExNativeArray<float3> localScaleArray;

		internal ExNativeArray<float4x4> localToWorldMatrixArray;

		internal ExNativeArray<short> teamIdArray;

		internal TransformAccessArray transformAccessArray;

		internal ExNativeArray<float3> componentPositionArray;

		internal ExNativeArray<float> componentMinScaleArray;

		internal TransformAccessArray componentTransformAccessArray;

		internal NativeReference<bool> existFixedTeam;

		private bool isValid;

		internal int Count => 0;

		public void Dispose()
		{
		}

		public void EnterdEditMode()
		{
		}

		public void Initialize()
		{
		}

		public bool IsValid()
		{
			return false;
		}

		internal DataChunk AddTransform(VirtualMeshContainer cmesh, int teamId)
		{
			return default(DataChunk);
		}

		internal DataChunk AddTransform(int count, int teamId, Transform t)
		{
			return default(DataChunk);
		}

		internal DataChunk AddTransform(Transform t, ExBitFlag8 flag, int teamId)
		{
			return default(DataChunk);
		}

		internal void SetTransform(Transform t, ExBitFlag8 flag, int index, int teamId)
		{
		}

		internal void CopyTransform(int fromIndex, int toIndex)
		{
		}

		internal void RemoveTransform(DataChunk c)
		{
		}

		internal void EnableTransform(DataChunk c, bool sw)
		{
		}

		internal void EnableTransform(int index, bool sw)
		{
		}

		internal DataChunk Expand(DataChunk c, int newLength)
		{
			return default(DataChunk);
		}

		public JobHandle RestoreTransform(JobHandle jobHandle)
		{
			return default(JobHandle);
		}

		public JobHandle RestoreBaseTransform(JobHandle jobHandle)
		{
			return default(JobHandle);
		}

		public JobHandle ReadTransformSchedule(JobHandle jobHandle)
		{
			return default(JobHandle);
		}

		public JobHandle WriteTransformSchedule(JobHandle jobHandle)
		{
			return default(JobHandle);
		}

		internal int AddComponentTransform(Transform t)
		{
			return 0;
		}

		internal void RemoveComponentTransform(int index)
		{
		}

		internal JobHandle ReadComponentTransform(JobHandle jobHandle)
		{
			return default(JobHandle);
		}

		public void InformationLog(StringBuilder allsb)
		{
		}
	}
}
