using Unity.Collections;

namespace andywiecko.BurstTriangulator.LowLevel.Unsafe
{
	public struct InputData<T2> where T2 : struct
	{
		public NativeArray<T2> Positions;

		public NativeArray<int> ConstraintEdges;

		public NativeArray<ConstraintType> ConstraintEdgeTypes;

		public NativeArray<T2> HoleSeeds;
	}
}
