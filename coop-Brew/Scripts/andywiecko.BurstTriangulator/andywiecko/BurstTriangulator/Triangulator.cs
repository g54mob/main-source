using System;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace andywiecko.BurstTriangulator
{
	public class Triangulator : IDisposable
	{
		private readonly Triangulator<double2> impl;

		public TriangulationSettings Settings => null;

		public InputData<double2> Input
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public OutputData<double2> Output => null;

		public Triangulator(int capacity, Allocator allocator)
		{
		}

		public Triangulator(Allocator allocator)
		{
		}

		public void Dispose()
		{
		}

		public void Run()
		{
		}

		public JobHandle Schedule(JobHandle dependencies = default(JobHandle))
		{
			return default(JobHandle);
		}
	}
	public class Triangulator<T2> : IDisposable where T2 : struct
	{
		internal NativeList<T2> outputPositions;

		internal NativeList<int> triangles;

		internal NativeList<int> halfedges;

		internal NativeList<HalfedgeState> constrainedHalfedges;

		internal NativeReference<Status> status;

		public TriangulationSettings Settings { get; }

		public InputData<T2> Input { get; set; }

		public OutputData<T2> Output { get; }

		public Triangulator(int capacity, Allocator allocator)
		{
		}

		public Triangulator(Allocator allocator)
		{
		}

		public void Dispose()
		{
		}
	}
}
