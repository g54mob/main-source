using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace LeTai.Asset.TranslucentImage
{
	[BurstCompile(FloatMode = FloatMode.Fast)]
	internal struct ActiveRegionMergeJob : IJob
	{
		[ReadOnly]
		public NativeList<ActiveRegion> activeRegions;

		[ReadOnly]
		public NativeList<Matrix4x4> vpMatrices;

		public Vector2 screenSize;

		public Rect viewport;

		public NativeArray<Rect> merged;

		public void Execute()
		{
		}
	}
}
