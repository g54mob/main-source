using System.Collections.Generic;

namespace Slicer2D
{
	public class LinearSlicer
	{
		public class SliceVertexToVertex
		{
			public static Slice2D Slice(Polygon2D polygon, Pair2D slice)
			{
				return null;
			}

			public static bool Get(Polygon2D polygon, Pair2D slice)
			{
				return false;
			}
		}

		public class SliceVertexToIntersection
		{
			public static Slice2D Slice(Polygon2D polygon, Pair2D slice, Vector2D vertex)
			{
				return null;
			}

			public static Vector2D Get(Polygon2D polygon, Pair2D slice)
			{
				return null;
			}
		}

		public class SliceWithoutHoles
		{
			public static Slice2D Slice(Polygon2D polygon, Pair2D slice)
			{
				return null;
			}
		}

		public class SliceWithTwoHoles
		{
			public static Slice2D Slice(Polygon2D polygon, Pair2D slice, Polygon2D holeA, Polygon2D holeB)
			{
				return null;
			}
		}

		public class SliceWithOneHole
		{
			public static Slice2D Slice(Polygon2D polygon, Pair2D slice, Polygon2D holeA, Polygon2D holeB)
			{
				return null;
			}
		}

		public static float precision;

		public static Slice2D Slice(Polygon2D polygon, Pair2D slice)
		{
			return null;
		}

		private static Slice2D MultipleSlice(Polygon2D polygon, Pair2D slice)
		{
			return null;
		}

		public static List<Pair2D> GetSplitSlices(Polygon2D polygon, Pair2D slice)
		{
			return null;
		}

		private static Slice2D SingleSlice(Polygon2D polygon, Pair2D slice)
		{
			return null;
		}
	}
}
