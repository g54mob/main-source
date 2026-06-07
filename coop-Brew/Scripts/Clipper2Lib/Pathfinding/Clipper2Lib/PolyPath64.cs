using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Pathfinding.Clipper2Lib
{
	public class PolyPath64 : PolyPathBase
	{
		public List<Point64>? Polygon { get; private set; }

		public PolyPath64 this[int index] => null;

		public PolyPath64(PolyPathBase? parent = null)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override PolyPathBase AddChild(List<Point64> p)
		{
			return null;
		}

		public PolyPath64 Child(int index)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public double Area()
		{
			return 0.0;
		}
	}
}
