using AwesomeTechnologies.Vegetation.PersistentStorage;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace AwesomeTechnologies.VegetationSystem
{
	[BurstCompile(CompileSynchronously = true)]
	public struct LoadPersistentStorageToMatrixJob : IJob
	{
		[ReadOnly]
		[DeallocateOnJobCompletion]
		public NativeArray<PersistentVegetationItem> InstanceList;

		public NativeList<MatrixInstance> VegetationInstanceMatrixList;

		public Vector3 VegetationSystemPosition;

		public void Execute()
		{
			for (int i = 0; i < InstanceList.Length; i++)
			{
				MatrixInstance value = new MatrixInstance
				{
					Matrix = Matrix4x4.TRS(InstanceList[i].Position + VegetationSystemPosition, InstanceList[i].Rotation, InstanceList[i].Scale),
					DistanceFalloff = InstanceList[i].DistanceFalloff
				};
				value.DistanceFalloff = InstanceList[i].DistanceFalloff;
				VegetationInstanceMatrixList.Add(value);
			}
		}
	}
}
