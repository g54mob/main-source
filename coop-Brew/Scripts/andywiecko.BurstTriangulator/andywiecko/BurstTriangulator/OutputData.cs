using System;
using Unity.Collections;

namespace andywiecko.BurstTriangulator
{
	public class OutputData<T2> where T2 : struct
	{
		private readonly Triangulator<T2> owner;

		public NativeList<T2> Positions => default(NativeList<T2>);

		public NativeList<int> Triangles => default(NativeList<int>);

		public NativeReference<Status> Status => default(NativeReference<Status>);

		public NativeList<int> Halfedges => default(NativeList<int>);

		public NativeList<HalfedgeState> ConstrainedHalfedges => default(NativeList<HalfedgeState>);

		[Obsolete("This will be converted into internal ctor.")]
		public OutputData(Triangulator<T2> owner)
		{
		}
	}
}
