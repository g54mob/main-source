using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace PugWorldGen
{
	public struct ClusterShapeEnumerator : ShapeEnumerator, IEnumerator<int2>, IEnumerator, IDisposable, INativeDisposable
	{
		private int2 center;

		private float2 size;

		private int2 current;

		private float2 spreadChance;

		private Unity.Mathematics.Random rng;

		private NativeList<int2> next;

		private NativeParallelHashSet<int2> visited;

		private bool hasAddedFirst;

		public int2 Current => current + center;

		object IEnumerator.Current => Current;

		public ClusterShapeEnumerator(int2 center, float2 size, float rotation, uint seed, Allocator allocator)
		{
			this.center = center;
			this.size = size;
			rng = new Unity.Mathematics.Random(seed);
			next = new NativeList<int2>(allocator);
			visited = new NativeParallelHashSet<int2>(200, allocator);
			spreadChance = math.normalizesafe(new float2(math.abs(math.cos(0f - rotation) * size.x) + math.abs(math.sin(0f - rotation) * size.y), math.abs(math.sin(0f - rotation) * size.x) + math.abs(math.cos(0f - rotation) * size.y)));
			current = 0;
			hasAddedFirst = false;
		}

		public bool MoveNext()
		{
			if (!hasAddedFirst)
			{
				hasAddedFirst = true;
				next.Add((int2)0);
			}
			else if (next.Length == 0)
			{
				return false;
			}
			int2 int5 = next[next.Length - 1];
			next.RemoveAt(next.Length - 1);
			if (math.all(math.abs(int5) < size))
			{
				int2 value = int5 + new int2(-1, 0);
				int2 value2 = int5 + new int2(1, 0);
				int2 value3 = int5 + new int2(0, -1);
				int2 value4 = int5 + new int2(0, 1);
				if (!visited.Contains(value))
				{
					visited.Add(value);
					if (rng.NextFloat() < spreadChance.x)
					{
						next.Add(in value);
					}
				}
				if (!visited.Contains(value2))
				{
					visited.Add(value2);
					if (rng.NextFloat() < spreadChance.x)
					{
						next.Add(in value2);
					}
				}
				if (!visited.Contains(value3))
				{
					visited.Add(value3);
					if (rng.NextFloat() < spreadChance.y)
					{
						next.Add(in value3);
					}
				}
				if (!visited.Contains(value4))
				{
					visited.Add(value4);
					if (rng.NextFloat() < spreadChance.y)
					{
						next.Add(in value4);
					}
				}
			}
			current = int5;
			if (rng.NextFloat() >= math.lengthsq(int5 / size))
			{
				return MoveNext();
			}
			return true;
		}

		public void Reset()
		{
			current = 0;
			hasAddedFirst = false;
		}

		public void Dispose()
		{
			next.Dispose();
			visited.Dispose();
		}

		public JobHandle Dispose(JobHandle inputDeps)
		{
			return JobHandle.CombineDependencies(next.Dispose(inputDeps), visited.Dispose(inputDeps));
		}
	}
}
