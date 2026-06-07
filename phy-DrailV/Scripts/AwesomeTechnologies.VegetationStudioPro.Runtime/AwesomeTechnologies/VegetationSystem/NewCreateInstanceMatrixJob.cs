using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct NewCreateInstanceMatrixJob : IJob
	{
		[ReadOnly]
		public NativeList<byte> Excluded;

		[ReadOnly]
		public NativeList<float3> Position;

		[ReadOnly]
		public NativeList<quaternion> Rotation;

		[ReadOnly]
		public NativeList<float3> Scale;

		[ReadOnly]
		public NativeList<float> DistanceFalloff;

		public NativeList<MatrixInstance> VegetationInstanceMatrixList;

		public void Execute()
		{
			for (int i = 0; i < Excluded.Length; i++)
			{
				if (Excluded[i] != 1)
				{
					MatrixInstance value = new MatrixInstance
					{
						Matrix = Matrix4x4.TRS(Position[i], Rotation[i], Scale[i]),
						DistanceFalloff = DistanceFalloff[i]
					};
					VegetationInstanceMatrixList.Add(value);
				}
			}
		}
	}
}
