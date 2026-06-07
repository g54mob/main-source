using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct CreateInstanceMatrixJob : IJob
	{
		[ReadOnly]
		public NativeList<VegetationInstance> InstanceList;

		public NativeList<MatrixInstance> VegetationInstanceMatrixList;

		public void Execute()
		{
			for (int i = 0; i < InstanceList.Length; i++)
			{
				if (InstanceList[i].Excluded != 1)
				{
					MatrixInstance value = new MatrixInstance
					{
						Matrix = Matrix4x4.TRS(InstanceList[i].Position, InstanceList[i].Rotation, InstanceList[i].Scale),
						DistanceFalloff = InstanceList[i].DistanceFalloff
					};
					VegetationInstanceMatrixList.Add(value);
				}
			}
		}
	}
}
