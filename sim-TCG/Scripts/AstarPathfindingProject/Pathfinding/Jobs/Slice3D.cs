using Pathfinding.Util;
using Unity.Collections;
using Unity.Mathematics;

namespace Pathfinding.Jobs
{
	public readonly struct Slice3D
	{
		public readonly int3 outerSize;

		public readonly IntBounds slice;

		public int length => slice.size.x * slice.size.y * slice.size.z;

		public (int, int, int) outerStrides => (1, outerSize.x * outerSize.z, outerSize.x);

		public (int, int, int) innerStrides => (1, slice.size.x * slice.size.z, slice.size.x);

		public int outerStartIndex
		{
			get
			{
				var (num, num2, num3) = outerStrides;
				return slice.min.x * num + slice.min.y * num2 + slice.min.z * num3;
			}
		}

		public bool coversEverything => math.all(slice.size == outerSize);

		public Slice3D(IntBounds outer, IntBounds slice)
			: this(outer.size, slice.Offset(-outer.min))
		{
		}

		public Slice3D(int3 outerSize, IntBounds slice)
		{
			this.outerSize = outerSize;
			this.slice = slice;
		}

		public void AssertMatchesOuter<T>(UnsafeSpan<T> values) where T : unmanaged
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
			var (num, num2, num3) = outerStrides;
			return (x + slice.min.x) * num + (y + slice.min.y) * num2 + (z + slice.min.z) * num3;
		}
	}
}
