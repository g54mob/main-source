using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace DV
{
	[BurstCompile]
	public struct ComputeBoundsJob : IJob
	{
		[ReadOnly]
		public NativeList<Vector3> allPositions;

		[WriteOnly]
		public NativeArray<Bounds> bounds;

		public ComputeBoundsJob(NativeList<Vector3> allPositions, NativeArray<Bounds> bounds)
		{
			this.allPositions = allPositions;
			this.bounds = bounds;
		}

		public void Execute()
		{
			Vector3 size = new Vector3(1.7f, 1.7f, 1.7f);
			Bounds value = default(Bounds);
			for (int i = 0; i < allPositions.Length; i++)
			{
				Bounds bounds = new Bounds(allPositions[i], size);
				if (i == 0)
				{
					value = bounds;
				}
				else
				{
					value.Encapsulate(bounds);
				}
			}
			this.bounds[0] = value;
		}
	}
}
