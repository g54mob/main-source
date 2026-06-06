using System;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace MagicaCloth2
{
	public class TriangleBendingConstraint : IDisposable
	{
		public enum Method
		{
			None = 0,
			DihedralAngle = 1,
			DirectionDihedralAngle = 2
		}

		[Serializable]
		public class SerializeData : IDataValidate
		{
			[Range(0f, 1f)]
			public float stiffness;

			public void DataValidate()
			{
			}

			public SerializeData Clone()
			{
				return null;
			}
		}

		public struct TriangleBendingConstraintParams
		{
			public Method method;

			public float stiffness;

			public void Convert(SerializeData sdata)
			{
			}
		}

		[Serializable]
		public class ConstraintData : IValid
		{
			public ResultCode result;

			public ulong[] trianglePairArray;

			public float[] restAngleOrVolumeArray;

			public sbyte[] signOrVolumeArray;

			public int writeBufferCount;

			public uint[] writeDataArray;

			public uint[] writeIndexArray;

			public bool IsValid()
			{
				return false;
			}
		}

		private const sbyte VOLUME_SIGN = 100;

		public ExNativeArray<ulong> trianglePairArray;

		public ExNativeArray<float> restAngleOrVolumeArray;

		public ExNativeArray<sbyte> signOrVolumeArray;

		private const float VolumeScale = 1000f;

		public void Dispose()
		{
		}

		public override string ToString()
		{
			return null;
		}

		public static ConstraintData CreateData(VirtualMesh proxyMesh, in ClothParameters parameters)
		{
			return null;
		}

		private static void InitVolume(VirtualMesh proxyMesh, int v0, int v1, int v2, int v3, out float volumeRest, out sbyte signFlag)
		{
			volumeRest = default(float);
			signFlag = default(sbyte);
		}

		private static void InitDihedralAngle(VirtualMesh proxyMesh, int v0, int v1, int v2, int v3, out float restAngle, out sbyte signFlag)
		{
			restAngle = default(float);
			signFlag = default(sbyte);
		}

		internal void Register(ClothProcess cprocess)
		{
		}

		internal void Exit(ClothProcess cprocess)
		{
		}

		internal static void SolverConstraint(DataChunk chunk, in float4 simulationPower, ref TeamManager.TeamData tdata, ref ClothParameters param, ref NativeArray<VertexAttribute> attributes, ref NativeArray<float> depthArray, ref NativeArray<float3> nextPosArray, ref NativeArray<float> frictionArray, ref NativeArray<ulong> trianglePairArray, ref NativeArray<float> restAngleOrVolumeArray, ref NativeArray<sbyte> signOrVolumeArray, ref NativeArray<float3> tempVectorBufferA, ref NativeArray<int> tempCountBuffer)
		{
		}

		internal static void SumConstraint(DataChunk chunk, ref TeamManager.TeamData tdata, ref ClothParameters param, ref NativeArray<VertexAttribute> attributes, ref NativeArray<float3> nextPosArray, ref NativeArray<float3> tempVectorBufferA, ref NativeArray<int> tempCountBuffer)
		{
		}

		private static bool CalcVolume(in float3x4 nextPosBuffer, in float4 invMassBuffer, float volumeRest, float stiffness, ref float3x4 addPosBuffer)
		{
			return false;
		}

		private static bool CalcDihedralAngle(float sign, in float3x4 nextPosBuffer, in float4 invMassBuffer, float restAngle, float stiffness, ref float3x4 addPosBuffer)
		{
			return false;
		}
	}
}
