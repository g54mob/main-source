using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine.Jobs;

namespace Plugins.PhaserPort.physics.arcade.jobs
{
	[BurstCompile]
	public struct PostBodyUpdateJob : IJobParallelForTransform
	{
		[ReadOnly]
		public NativeArray<bool> _enabledArray;

		[ReadOnly]
		public NativeArray<float2> _positionArray;

		[ReadOnly]
		public NativeArray<float2> _previousFrameArray;

		[ReadOnly]
		public NativeArray<float2> _deltaMaxArray;

		[ReadOnly]
		public NativeArray<bool> _movesArray;

		public NativeArray<int> _facingArray;

		[ReadOnly]
		public NativeArray<bool> _allowRotationArray;

		[ReadOnly]
		public NativeArray<float> _deltaZArray;

		public void Execute(int index, TransformAccess transform)
		{
		}
	}
}
