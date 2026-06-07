using Unity.Collections;

namespace andywiecko.BurstTriangulator
{
	public class InputData<T2> where T2 : struct
	{
		public NativeArray<T2> Positions { get; set; }

		public NativeArray<int> ConstraintEdges { get; set; }

		public NativeArray<ConstraintType> ConstraintEdgeTypes { get; set; }

		public NativeArray<T2> HoleSeeds { get; set; }
	}
}
