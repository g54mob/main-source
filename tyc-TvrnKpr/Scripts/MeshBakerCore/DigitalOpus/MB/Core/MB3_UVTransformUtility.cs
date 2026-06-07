using UnityEngine;

namespace DigitalOpus.MB.Core
{
	public class MB3_UVTransformUtility
	{
		public static void Test()
		{
		}

		public static float TransformX(DRect r, double x)
		{
			return 0f;
		}

		public static DRect CombineTransforms(ref DRect r1, ref DRect r2)
		{
			return default(DRect);
		}

		public static Rect CombineTransforms(ref Rect r1, ref Rect r2)
		{
			return default(Rect);
		}

		public static DRect InverseTransform(ref DRect t)
		{
			return default(DRect);
		}

		public static DRect GetShiftTransformToFitBinA(ref DRect A, ref DRect B)
		{
			return default(DRect);
		}

		public static DRect GetEncapsulatingRectShifted(ref DRect uvRect1, ref DRect willBeIn)
		{
			return default(DRect);
		}

		public static DRect GetEncapsulatingRect(ref DRect uvRect1, ref DRect uvRect2)
		{
			return default(DRect);
		}

		public static bool RectContainsShifted(ref DRect bucket, ref DRect tryFit)
		{
			return false;
		}

		public static bool RectContainsShifted(ref Rect bucket, ref Rect tryFit)
		{
			return false;
		}

		public static bool LineSegmentContainsShifted(float bucketOffset, float bucketLength, float tryFitOffset, float tryFitLength)
		{
			return false;
		}

		public static bool RectContains(ref DRect bigRect, ref DRect smallToTestIfFits)
		{
			return false;
		}

		public static bool RectContains(ref Rect bigRect, ref Rect smallToTestIfFits)
		{
			return false;
		}

		public static Vector2 TransformPoint(ref DRect r, Vector2 p)
		{
			return default(Vector2);
		}

		public static DVector2 TransformPoint(ref DRect r, DVector2 p)
		{
			return default(DVector2);
		}
	}
}
