using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Pathfinding.Clipper2Lib
{
	public class PolyPathD : PolyPathBase
	{
		internal double Scale { get; set; }

		public PathD? Polygon { get; private set; }

		[IndexerName("Child")]
		public PolyPathD this[int index] => null;

		public PolyPathD(PolyPathBase? parent = null)
		{
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public override PolyPathBase AddChild(List<Point64> p)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public PolyPathBase AddChild(PathD p)
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
