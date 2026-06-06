using System;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace MagicaCloth2
{
	public class AngleConstraint : IDisposable
	{
		[Serializable]
		public class RestorationSerializeData : IDataValidate
		{
			public bool useAngleRestoration;

			public CurveSerializeData stiffness;

			[Range(0f, 1f)]
			public float velocityAttenuation;

			[Range(0f, 1f)]
			public float gravityFalloff;

			public void DataValidate()
			{
			}

			public RestorationSerializeData Clone()
			{
				return null;
			}
		}

		[Serializable]
		public class LimitSerializeData : IDataValidate
		{
			public bool useAngleLimit;

			public CurveSerializeData limitAngle;

			[Range(0f, 1f)]
			public float stiffness;

			public void DataValidate()
			{
			}

			public LimitSerializeData Clone()
			{
				return null;
			}
		}

		public struct AngleConstraintParams
		{
			public bool useAngleRestoration;

			public float4x4 restorationStiffness;

			public float restorationVelocityAttenuation;

			public float restorationGravityFalloff;

			public bool useAngleLimit;

			public float4x4 limitCurveData;

			public float limitstiffness;

			public void Convert(RestorationSerializeData restorationData, LimitSerializeData limitData)
			{
			}
		}

		public void Dispose()
		{
		}

		public override string ToString()
		{
			return null;
		}

		internal static void SolverConstraint(DataChunk chunk, in float4 simulationPower, ref TeamManager.TeamData tdata, ref ClothParameters param, ref NativeArray<VertexAttribute> attributes, ref NativeArray<float> vertexDepths, ref NativeArray<int> vertexParentIndices, ref NativeArray<ushort> baseLineStartDataIndices, ref NativeArray<ushort> baseLineDataCounts, ref NativeArray<ushort> baseLineData, ref NativeArray<float3> nextPosArray, ref NativeArray<float3> velocityPosArray, ref NativeArray<float> frictionArray, ref NativeArray<float3> stepBasicPositionBuffer, ref NativeArray<quaternion> stepBasicRotationBuffer, ref NativeArray<float> lengthBufferArray, ref NativeArray<float3> localPosBufferArray, ref NativeArray<quaternion> localRotBufferArray, ref NativeArray<quaternion> rotationBufferArray, ref NativeArray<float3> restorationVectorBufferArray)
		{
		}
	}
}
