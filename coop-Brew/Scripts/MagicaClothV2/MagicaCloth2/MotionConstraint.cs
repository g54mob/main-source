using System;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace MagicaCloth2
{
	public class MotionConstraint : IDisposable
	{
		[Serializable]
		public class SerializeData : IDataValidate
		{
			public bool useMaxDistance;

			public CurveSerializeData maxDistance;

			public bool useBackstop;

			[Range(0.1f, 10f)]
			public float backstopRadius;

			public CurveSerializeData backstopDistance;

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

		public struct MotionConstraintParams
		{
			public bool useMaxDistance;

			public float4x4 maxDistanceCurveData;

			public bool useBackstop;

			public float backstopRadius;

			public float4x4 backstopDistanceCurveData;

			public float stiffness;

			public void Convert(SerializeData sdata, ClothProcess.ClothType clothType)
			{
			}
		}

		public void Dispose()
		{
		}

		internal static void SolverConstraint(DataChunk chunk, ref TeamManager.TeamData tdata, ref ClothParameters param, ref NativeArray<VertexAttribute> attributes, ref NativeArray<float> vertexDepths, ref NativeArray<float3> basePosArray, ref NativeArray<quaternion> baseRotArray, ref NativeArray<float3> nextPosArray, ref NativeArray<float3> velocityPosArray, ref NativeArray<float> frictionArray, ref NativeArray<float3> collisionNormalArray)
		{
		}
	}
}
