using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace FSG.MeshAnimator
{
	public struct ExposedTransformCrossfade
	{
		public struct LerpMatrix4x4Job : IJobParallelFor
		{
			[ReadOnly]
			public NativeArray<Matrix4x4> from;

			[ReadOnly]
			public NativeArray<Matrix4x4> to;

			[ReadOnly]
			public float delta;

			public NativeArray<Matrix4x4> output;

			public void Execute(int i)
			{
			}
		}

		public int framesNeeded;

		public int currentFrame;

		public bool isFading;

		public float endTime;

		public MeshFrameDataBase fromFrame;

		public MeshFrameDataBase toFrame;

		public LerpMatrix4x4Job[] exposedTransformJobs;

		public JobHandle[] exposedTransformJobHandles;

		public NativeArray<Matrix4x4> fromMatrix;

		public NativeArray<Matrix4x4> toMatrix;

		public NativeArray<Matrix4x4>[] outputMatrix;

		private bool isReset;

		public void Reset(bool destroying)
		{
		}

		public void StartCrossfade(MeshFrameDataBase fromFrame, MeshFrameDataBase toFrame)
		{
		}

		public void ReturnFrame(bool destroying)
		{
		}
	}
}
