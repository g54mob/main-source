using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;

namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	[BurstCompile]
	internal struct TriangulationJob<T, T2, TBig, TTransform, TUtils> : IJob where T : struct, IComparable<T> where T2 : struct where TBig : struct, IComparable<TBig> where TTransform : struct, ITransform<TTransform, T, T2> where TUtils : struct, IUtils<T, T2, TBig>
	{
		private NativeArray<T2> inputPositions;

		[NativeDisableContainerSafetyRestriction]
		private NativeArray<int> constraints;

		[NativeDisableContainerSafetyRestriction]
		private NativeArray<ConstraintType> constraintTypes;

		[NativeDisableContainerSafetyRestriction]
		private NativeArray<T2> holeSeeds;

		private NativeList<T2> outputPositions;

		private NativeList<int> triangles;

		private NativeList<int> halfedges;

		private NativeList<HalfedgeState> constrainedHalfedges;

		private NativeReference<Status> status;

		private readonly Args args;

		public TriangulationJob(InputData<T2> input, OutputData<T2> output, Args args)
		{
			inputPositions = default(NativeArray<T2>);
			constraints = default(NativeArray<int>);
			constraintTypes = default(NativeArray<ConstraintType>);
			holeSeeds = default(NativeArray<T2>);
			outputPositions = default(NativeList<T2>);
			triangles = default(NativeList<int>);
			halfedges = default(NativeList<int>);
			constrainedHalfedges = default(NativeList<HalfedgeState>);
			status = default(NativeReference<Status>);
			this.args = default(Args);
		}

		public TriangulationJob(Triangulator<T2> @this)
		{
			inputPositions = default(NativeArray<T2>);
			constraints = default(NativeArray<int>);
			constraintTypes = default(NativeArray<ConstraintType>);
			holeSeeds = default(NativeArray<T2>);
			outputPositions = default(NativeList<T2>);
			triangles = default(NativeList<int>);
			halfedges = default(NativeList<int>);
			constrainedHalfedges = default(NativeList<HalfedgeState>);
			status = default(NativeReference<Status>);
			args = default(Args);
		}

		public void Execute()
		{
		}
	}
}
