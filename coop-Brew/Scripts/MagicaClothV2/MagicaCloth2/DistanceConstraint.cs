using System;
using Unity.Collections;
using Unity.Mathematics;

namespace MagicaCloth2
{
	public class DistanceConstraint : IDisposable
	{
		[Serializable]
		public class SerializeData : IDataValidate
		{
			public CurveSerializeData stiffness;

			public void DataValidate()
			{
			}

			public SerializeData Clone()
			{
				return null;
			}
		}

		public struct DistanceConstraintParams
		{
			public float4x4 restorationStiffness;

			public float velocityAttenuation;

			public void Convert(SerializeData sdata, ClothProcess.ClothType clothType)
			{
			}
		}

		[Serializable]
		public class ConstraintData : IValid
		{
			public ResultCode result;

			public uint[] indexArray;

			public ushort[] dataArray;

			public float[] distanceArray;

			public bool IsValid()
			{
				return false;
			}
		}

		public const int TypeCount = 2;

		public ExNativeArray<uint> indexArray;

		public ExNativeArray<ushort> dataArray;

		public ExNativeArray<float> distanceArray;

		public int DataCount => 0;

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

		internal void Register(ClothProcess cprocess)
		{
		}

		internal void Exit(ClothProcess cprocess)
		{
		}

		internal static void SolverConstraint(DataChunk chunk, float4 simulationPower, ref TeamManager.TeamData tdata, ref ClothParameters param, ref NativeArray<VertexAttribute> attributes, ref NativeArray<float> depthArray, ref NativeArray<float3> nextPosArray, ref NativeArray<float3> basePosArray, ref NativeArray<float3> velocityPosArray, ref NativeArray<float> frictionArray, ref NativeArray<uint> indexArray, ref NativeArray<ushort> dataArray, ref NativeArray<float> distanceArray)
		{
		}
	}
}
