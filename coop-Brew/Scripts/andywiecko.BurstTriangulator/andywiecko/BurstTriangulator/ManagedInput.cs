using System;

namespace andywiecko.BurstTriangulator
{
	[Obsolete("Use AsNativeArray(out Handle) instead! You can learn more in the project manual.")]
	public class ManagedInput<T2> where T2 : struct
	{
		public T2[] Positions { get; set; }

		public int[] ConstraintEdges { get; set; }

		public T2[] HoleSeeds { get; set; }

		public static implicit operator InputData<T2>(ManagedInput<T2> input)
		{
			return null;
		}
	}
}
