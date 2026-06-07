using System.Collections.Generic;

namespace Slicer2D
{
	public class ComplexSlicer
	{
		public class SliceWithoutHoles
		{
			public static Slice2D Slice(Polygon2D polygon, List<Vector2D> slice, ComplexCollision collisionSlice)
			{
				return null;
			}
		}

		public class SliceWithOneHole
		{
			public static Slice2D Slice(Polygon2D polygon, List<Vector2D> slice, ComplexCollision collisionSlice)
			{
				return null;
			}

			public static Slice2D SliceFromOutsideToHole(Polygon2D polygon, Polygon2D holePoly, List<Vector2D> slice, ComplexCollision collisionSlice)
			{
				return null;
			}

			public static Slice2D SliceIntoSameHole(Polygon2D polygon, Polygon2D holePoly, List<Vector2D> slice, ComplexCollision collisionSlice)
			{
				return null;
			}
		}

		public class SliceWithTwoHoles
		{
			public static Slice2D Slice(Polygon2D polygon, List<Vector2D> slice, ComplexCollision collisionSlice)
			{
				return null;
			}
		}

		public static double precision;

		public static Slice2D Slice(Polygon2D polygon, List<Vector2D> slice)
		{
			return null;
		}

		private static Slice2D MultipleSlice(Polygon2D polygon, List<Vector2D> slice)
		{
			return null;
		}

		private static Slice2D SingleSlice(Polygon2D polygon, ComplexSlicerSplit split)
		{
			return null;
		}
	}
}
