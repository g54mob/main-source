using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace TMPEffects.Extensions
{
	public static class AnimationCurveUtility
	{
		internal static class CubicBezierFitter
		{
			private const int MAX_DATA_COUNT = 100000;

			private const float MIN_ERROR = 1E-06f;

			public static List<Vector2> FitCurve(Vector2[] d, float error)
			{
				return null;
			}

			private static void FitCubic(Vector2[] d, int first, int last, Vector2 tHat1, Vector2 tHat2, float error, List<Vector2> result)
			{
			}

			private static Vector2[] GenerateBezier(Vector2[] d, int first, int last, float[] uPrime, Vector2 tHat1, Vector2 tHat2)
			{
				return null;
			}

			private static float[] Reparameterize(Vector2[] d, int first, int last, float[] u, Vector2[] bezCurve)
			{
				return null;
			}

			private static float NewtonRaphsonRootFind(Vector2[] Q, Vector2 P, float u)
			{
				return 0f;
			}

			private static Vector2 BezierII(int degree, Vector2[] V, float t)
			{
				return default(Vector2);
			}

			private static float B0(float u)
			{
				return 0f;
			}

			private static float B1(float u)
			{
				return 0f;
			}

			private static float B2(float u)
			{
				return 0f;
			}

			private static float B3(float u)
			{
				return 0f;
			}

			private static Vector2 ComputeLeftTangent(Vector2[] d, int end)
			{
				return default(Vector2);
			}

			private static Vector2 ComputeRightTangent(Vector2[] d, int end)
			{
				return default(Vector2);
			}

			private static Vector2 ComputeCenterTangent(Vector2[] d, int center)
			{
				return default(Vector2);
			}

			private static float[] ChordLengthParameterize(Vector2[] d, int first, int last)
			{
				return null;
			}

			private static float ComputeMaxError(Vector2[] d, int first, int last, Vector2[] bezCurve, float[] u, out int splitVector2)
			{
				splitVector2 = default(int);
				return 0f;
			}

			private static float V2Dot(Vector2 a, Vector2 b)
			{
				return 0f;
			}
		}

		private static readonly Vector2[] easeInSinePoints;

		private static readonly Vector2[] easeOutSinePoints;

		private static readonly Vector2[] easeInOutSinePoints;

		public static readonly ReadOnlyCollection<Vector2> EaseInSinePoints;

		public static readonly ReadOnlyCollection<Vector2> EaseOutSinePoints;

		public static readonly ReadOnlyCollection<Vector2> EaseInOutSinePoints;

		private static readonly Vector2[] easeInQuadPoints;

		private static readonly Vector2[] easeOutQuadPoints;

		private static readonly Vector2[] easeInOutQuadPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseInQuadPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseOutQuadPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseInOutQuadPoints;

		private static readonly Vector2[] easeInCubicPoints;

		private static readonly Vector2[] easeOutCubicPoints;

		private static readonly Vector2[] easeInOutCubicPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseInCubicPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseOutCubicPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseInOutCubicPoints;

		private static readonly Vector2[] easeInQuartPoints;

		private static readonly Vector2[] easeOutQuartPoints;

		private static readonly Vector2[] easeInOutQuartPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseInQuartPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseOutQuartPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseInOutQuartPoints;

		private static readonly Vector2[] easeInQuintPoints;

		private static readonly Vector2[] easeOutQuintPoints;

		private static readonly Vector2[] easeInOutQuintPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseInQuintPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseOutQuintPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseInOutQuintPoints;

		private static readonly Vector2[] easeInExpoPoints;

		private static readonly Vector2[] easeOutExpoPoints;

		private static readonly Vector2[] easeInOutExpoPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseInExpoPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseOutExpoPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseInOutExpoPoints;

		private static readonly Vector2[] easeInCircPoints;

		private static readonly Vector2[] easeOutCircPoints;

		private static readonly Vector2[] easeInOutCircPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseInCircPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseOutCircPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseInOutCircPoints;

		private static readonly Vector2[] easeInBackPoints;

		private static readonly Vector2[] easeOutBackPoints;

		private static readonly Vector2[] easeInOutBackPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseInBackPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseOutBackPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseInOutBackPoints;

		private static readonly Vector2[] easeInElasticPoints;

		private static readonly Vector2[] easeOutElasticPoints;

		private static readonly Vector2[] easeInOutElasticPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseInElasticPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseOutElasticPoints;

		public static readonly ReadOnlyCollection<Vector2> EaseInOutElasticPoints;

		private static readonly Vector2[] easeInBouncePoints;

		private static readonly Vector2[] easeOutBouncePoints;

		private static readonly Vector2[] easeInOutBouncePoints;

		public static readonly ReadOnlyCollection<Vector2> EaseInBouncePoints;

		public static readonly ReadOnlyCollection<Vector2> EaseOutBouncePoints;

		public static readonly ReadOnlyCollection<Vector2> EaseInOutBouncePoints;

		public static readonly ReadOnlyDictionary<string, ReadOnlyCollection<Vector2>> NamePointsMapping;

		public static readonly ReadOnlyDictionary<string, Func<AnimationCurve>> NameConstructorMapping;

		public static readonly ReadOnlyDictionary<string, Func<IEnumerable<Vector2>, AnimationCurve>> NameBezierConstructorMapping;

		public static AnimationCurve Copy(this AnimationCurve curve)
		{
			return null;
		}

		public static AnimationCurve InvertCopy(this AnimationCurve curve)
		{
			return null;
		}

		public static AnimationCurve Linear()
		{
			return null;
		}

		public static AnimationCurve EaseInSine()
		{
			return null;
		}

		public static AnimationCurve EaseOutSine()
		{
			return null;
		}

		public static AnimationCurve EaseInOutSine()
		{
			return null;
		}

		public static AnimationCurve EaseInQuad()
		{
			return null;
		}

		public static AnimationCurve EaseOutQuad()
		{
			return null;
		}

		public static AnimationCurve EaseInOutQuad()
		{
			return null;
		}

		public static AnimationCurve EaseInCubic()
		{
			return null;
		}

		public static AnimationCurve EaseOutCubic()
		{
			return null;
		}

		public static AnimationCurve EaseInOutCubic()
		{
			return null;
		}

		public static AnimationCurve EaseInQuart()
		{
			return null;
		}

		public static AnimationCurve EaseOutQuart()
		{
			return null;
		}

		public static AnimationCurve EaseInOutQuart()
		{
			return null;
		}

		public static AnimationCurve EaseInQuint()
		{
			return null;
		}

		public static AnimationCurve EaseOutQuint()
		{
			return null;
		}

		public static AnimationCurve EaseInOutQuint()
		{
			return null;
		}

		public static AnimationCurve EaseInExpo()
		{
			return null;
		}

		public static AnimationCurve EaseOutExpo()
		{
			return null;
		}

		public static AnimationCurve EaseInOutExpo()
		{
			return null;
		}

		public static AnimationCurve EaseInCirc()
		{
			return null;
		}

		public static AnimationCurve EaseOutCirc()
		{
			return null;
		}

		public static AnimationCurve EaseInOutCirc()
		{
			return null;
		}

		public static AnimationCurve EaseInBack()
		{
			return null;
		}

		public static AnimationCurve EaseOutBack()
		{
			return null;
		}

		public static AnimationCurve EaseInOutBack()
		{
			return null;
		}

		public static AnimationCurve EaseInElastic()
		{
			return null;
		}

		public static AnimationCurve EaseOutElastic()
		{
			return null;
		}

		public static AnimationCurve EaseInOutElastic()
		{
			return null;
		}

		public static AnimationCurve EaseInBounce()
		{
			return null;
		}

		public static AnimationCurve EaseOutBounce()
		{
			return null;
		}

		public static AnimationCurve EaseInOutBounce()
		{
			return null;
		}

		public static AnimationCurve Bezier(params Vector2[] points)
		{
			return null;
		}

		public static AnimationCurve Bezier(IEnumerable<Vector2> points)
		{
			return null;
		}

		public static AnimationCurve LinearBezier(Vector2 start, Vector2 end)
		{
			return null;
		}

		public static AnimationCurve LinearBezier(params Vector2[] points)
		{
			return null;
		}

		public static AnimationCurve LinearBezier(IEnumerable<Vector2> points)
		{
			return null;
		}

		public static AnimationCurve QuadraticBezier(Vector2 startPoint, Vector2 controlPoint, Vector2 endPoint)
		{
			return null;
		}

		public static AnimationCurve QuadraticBezier(params Vector2[] points)
		{
			return null;
		}

		public static AnimationCurve QuadraticBezier(IEnumerable<Vector2> points)
		{
			return null;
		}

		public static AnimationCurve CubicBezier(Vector2 startPoint, Vector2 controlPoint0, Vector2 controlPoint1, Vector2 endPoint)
		{
			return null;
		}

		public static AnimationCurve CubicBezier(params Vector2[] points)
		{
			return null;
		}

		public static AnimationCurve CubicBezier(IEnumerable<Vector2> points)
		{
			return null;
		}

		private static void BezierToAnimationCurve(AnimationCurve outCurve, Vector2[] controlPointStrips)
		{
		}

		private static float Tangent(in Vector2 from, in Vector2 to)
		{
			return 0f;
		}

		private static float Weight(in Vector2 from, in Vector2 to, float length)
		{
			return 0f;
		}

		public static AnimationCurve GetInverse(AnimationCurve originalCurve)
		{
			return null;
		}

		public static AnimationCurve Invert(AnimationCurve curve)
		{
			return null;
		}
	}
}
