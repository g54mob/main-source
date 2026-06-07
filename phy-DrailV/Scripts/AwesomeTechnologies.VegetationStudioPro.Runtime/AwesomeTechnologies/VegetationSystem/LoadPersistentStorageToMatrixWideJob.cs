using AwesomeTechnologies.Vegetation.PersistentStorage;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct LoadPersistentStorageToMatrixWideJob : IJobParallelForDefer
	{
		[ReadOnly]
		[DeallocateOnJobCompletion]
		public NativeArray<PersistentVegetationItem> InstanceList;

		public NativeArray<MatrixInstance> VegetationInstanceMatrixList;

		public Vector3 VegetationSystemPosition;

		public void Execute(int index)
		{
			MatrixInstance value = new MatrixInstance
			{
				Matrix = Matrix4x4.TRS(InstanceList[index].Position + VegetationSystemPosition, InstanceList[index].Rotation, InstanceList[index].Scale),
				DistanceFalloff = InstanceList[index].DistanceFalloff
			};
			value.DistanceFalloff = InstanceList[index].DistanceFalloff;
			VegetationInstanceMatrixList[index] = value;
		}
	}
}
