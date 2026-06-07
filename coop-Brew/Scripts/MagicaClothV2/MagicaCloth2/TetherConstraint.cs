using System;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

namespace MagicaCloth2
{
	public class TetherConstraint : IDisposable
	{
		[Serializable]
		public class SerializeData : IDataValidate
		{
			[Range(0f, 1f)]
			public float distanceCompression;

			public void DataValidate()
			{
			}

			public SerializeData Clone()
			{
				return null;
			}
		}

		public struct TetherConstraintParams
		{
			public float compressionLimit;

			public float stretchLimit;

			public void Convert(SerializeData sdata, ClothProcess.ClothType clothType)
			{
			}
		}

		public void Dispose()
		{
		}

		internal static void SolverConstraint(DataChunk chunk, ref TeamManager.TeamData tdata, ref ClothParameters param, ref InertiaConstraint.CenterData cdata, ref NativeArray<VertexAttribute> attributes, ref NativeArray<float> vertexDepths, ref NativeArray<int> vertexRootIndices, ref NativeArray<float3> nextPosArray, ref NativeArray<float3> velocityPosArray, ref NativeArray<float> frictionArray, ref NativeArray<float3> stepBasicPositionBuffer)
		{
		}
	}
}
