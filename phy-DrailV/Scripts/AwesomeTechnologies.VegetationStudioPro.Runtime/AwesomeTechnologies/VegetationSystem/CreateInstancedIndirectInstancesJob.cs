using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile]
	public struct CreateInstancedIndirectInstancesJob : IJobParallelFor
	{
		[ReadOnly]
		public NativeArray<MatrixInstance> InstanceList;

		public NativeArray<InstancedIndirectInstance> IndirectInstanceList;

		public void Execute(int index)
		{
			InstancedIndirectInstance value = new InstancedIndirectInstance
			{
				ControlData = new Vector4(InstanceList[index].DistanceFalloff, 0f, 0f),
				Matrix = InstanceList[index].Matrix
			};
			IndirectInstanceList[index] = value;
		}
	}
}
