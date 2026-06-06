using Pathfinding.Collections;
using Unity.Collections;
using Unity.Mathematics;

namespace Pathfinding.Jobs
{
	public readonly struct Slice3D
	{
		public readonly int3 outerSize;

		public readonly IntBounds slice;

		public int length => 0;

		public (int, int, int) outerStrides => default((int, int, int));

		public (int, int, int) innerStrides => default((int, int, int));

		public int outerStartIndex => 0;

		public bool coversEverything => false;

		public Slice3D(IntBounds outer, IntBounds slice)
		{
			outerSize = default(int3);
			this.slice = default(IntBounds);
		}

		public Slice3D(int3 outerSize, IntBounds slice)
		{
			this.outerSize = default(int3);
			this.slice = default(IntBounds);
		}

		public void AssertMatchesOuter<T>(UnsafeSpan<T> values) where T : struct
		{
		}

		public void AssertMatchesOuter<T>(NativeArray<T> values) where T : struct
		{
		}

		public void AssertMatchesInner<T>(NativeArray<T> values) where T : struct
		{
		}

		public void AssertSameSize(Slice3D other)
		{
		}

		public int InnerCoordinateToOuterIndex(int x, int y, int z)
		{
			return 0;
		}
	}
}
