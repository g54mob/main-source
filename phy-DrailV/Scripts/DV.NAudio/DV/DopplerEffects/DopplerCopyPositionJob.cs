using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using UnityEngine.Jobs;

namespace DV.DopplerEffects
{
	[BurstCompile]
	public struct DopplerCopyPositionJob : IJobParallelForTransform
	{
		[DeallocateOnJobCompletion]
		public NativeArray<Entity> entities;

		[NativeDisableParallelForRestriction]
		public ComponentDataFromEntity<Doppler.DopplerData> dopplerDataFromEntity;

		public void Execute(int index, TransformAccess transform)
		{
			Entity entity = entities[index];
			Doppler.DopplerData value = dopplerDataFromEntity[entity];
			value.newPos = transform.position;
			dopplerDataFromEntity[entity] = value;
		}
	}
}
