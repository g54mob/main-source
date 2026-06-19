using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
				Vector2 tHat = ComputeLeftTangent(d, 0);
				Vector2 tHat2 = ComputeRightTangent(d, d.Length - 1);
				List<Vector2> result = new List<Vector2>
				{
					new Vector2(0f, 0f)
				};
				FitCubic(d, 0, d.Length - 1, tHat, tHat2, error, result);
				return result;
			}

			private static void FitCubic(Vector2[] d, int first, int last, Vector2 tHat1, Vector2 tHat2, float error, List<Vector2> result)
			{
				int num = 4;
				error = Mathf.Max(error, 1E-06f);
				float num2 = error * error;
				Vector2[] array;
				if (last - first + 1 == 2)
				{
					float num3 = (d[first] - d[last]).magnitude / 3f;
					array = new Vector2[4];
					array[0] = d[first];
					array[3] = d[last];
					array[1] = tHat1 * num3 + array[0];
					array[2] = tHat2 * num3 + array[3];
					result.Add(array[1]);
					result.Add(array[2]);
					result.Add(array[3]);
					return;
				}
				float[] array2 = ChordLengthParameterize(d, first, last);
				array = GenerateBezier(d, first, last, array2, tHat1, tHat2);
				float num4 = ComputeMaxError(d, first, last, array, array2, out var splitVector);
				if (num4 < error)
				{
					result.Add(array[1]);
					result.Add(array[2]);
					result.Add(array[3]);
					return;
				}
				if (num4 < num2)
				{
					for (int i = 0; i < num; i++)
					{
						float[] array3 = Reparameterize(d, first, last, array2, array);
						array = GenerateBezier(d, first, last, array3, tHat1, tHat2);
						num4 = ComputeMaxError(d, first, last, array, array3, out splitVector);
						if (num4 < error)
						{
							result.Add(array[1]);
							result.Add(array[2]);
							result.Add(array[3]);
							return;
						}
						array2 = array3;
					}
				}
				Vector2 vector = ComputeCenterTangent(d, splitVector);
				FitCubic(d, first, splitVector, tHat1, vector, error, result);
				vector = -vector;
				FitCubic(d, splitVector, last, vector, tHat2, error, result);
			}

			private static Vector2[] GenerateBezier(Vector2[] d, int first, int last, float[] uPrime, Vector2 tHat1, Vector2 tHat2)
			{
				Vector2[,] array = new Vector2[100000, 2];
				float[,] array2 = new float[2, 2];
				float[] array3 = new float[2];
				Vector2[] array4 = new Vector2[4];
				int num = last - first + 1;
				for (int i = 0; i < num; i++)
				{
					Vector2 vector = tHat1;
					Vector2 vector2 = tHat2;
					vector *= B1(uPrime[i]);
					vector2 *= B2(uPrime[i]);
					array[i, 0] = vector;
					array[i, 1] = vector2;
				}
				array2[0, 0] = 0f;
				array2[0, 1] = 0f;
				array2[1, 0] = 0f;
				array2[1, 1] = 0f;
				array3[0] = 0f;
				array3[1] = 0f;
				for (int i = 0; i < num; i++)
				{
					array2[0, 0] += V2Dot(array[i, 0], array[i, 0]);
					array2[0, 1] += V2Dot(array[i, 0], array[i, 1]);
					array2[1, 0] = array2[0, 1];
					array2[1, 1] += V2Dot(array[i, 1], array[i, 1]);
					Vector2 b = d[first + i] - (d[first] * B0(uPrime[i]) + (d[first] * B1(uPrime[i]) + (d[last] * B2(uPrime[i]) + d[last] * B3(uPrime[i]))));
					array3[0] += V2Dot(array[i, 0], b);
					array3[1] += V2Dot(array[i, 1], b);
				}
				float num2 = array2[0, 0] * array2[1, 1] - array2[1, 0] * array2[0, 1];
				float num3 = array2[0, 0] * array3[1] - array2[1, 0] * array3[0];
				float num4 = array3[0] * array2[1, 1] - array3[1] * array2[0, 1];
				float num5 = ((num2 == 0f) ? 0f : (num4 / num2));
				float num6 = ((num2 == 0f) ? 0f : (num3 / num2));
				float magnitude = (d[first] - d[last]).magnitude;
				float num7 = 1E-06f * magnitude;
				if (num5 < num7 || num6 < num7)
				{
					float num8 = magnitude / 3f;
					array4[0] = d[first];
					array4[3] = d[last];
					array4[1] = tHat1 * num8 + array4[0];
					array4[2] = tHat2 * num8 + array4[3];
					return array4;
				}
				array4[0] = d[first];
				array4[3] = d[last];
				array4[1] = tHat1 * num5 + array4[0];
				array4[2] = tHat2 * num6 + array4[3];
				return array4;
			}

			private static float[] Reparameterize(Vector2[] d, int first, int last, float[] u, Vector2[] bezCurve)
			{
				float[] array = new float[last - first + 1];
				for (int i = first; i <= last; i++)
				{
					array[i - first] = NewtonRaphsonRootFind(bezCurve, d[i], u[i - first]);
				}
				return array;
			}

			private static float NewtonRaphsonRootFind(Vector2[] Q, Vector2 P, float u)
			{
				Vector2[] array = new Vector2[3];
				Vector2[] array2 = new Vector2[2];
				Vector2 vector = BezierII(3, Q, u);
				for (int i = 0; i <= 2; i++)
				{
					array[i].x = (Q[i + 1].x - Q[i].x) * 3f;
					array[i].y = (Q[i + 1].y - Q[i].y) * 3f;
				}
				for (int i = 0; i <= 1; i++)
				{
					array2[i].x = (array[i + 1].x - array[i].x) * 2f;
					array2[i].y = (array[i + 1].y - array[i].y) * 2f;
				}
				Vector2 vector2 = BezierII(2, array, u);
				Vector2 vector3 = BezierII(1, array2, u);
				float num = (vector.x - P.x) * vector2.x + (vector.y - P.y) * vector2.y;
				float num2 = vector2.x * vector2.x + vector2.y * vector2.y + (vector.x - P.x) * vector3.x + (vector.y - P.y) * vector3.y;
				if (num2 == 0f)
				{
					return u;
				}
				return u - num / num2;
			}

			private static Vector2 BezierII(int degree, Vector2[] V, float t)
			{
				Vector2[] array = new Vector2[degree + 1];
				for (int i = 0; i <= degree; i++)
				{
					array[i] = V[i];
				}
				for (int i = 1; i <= degree; i++)
				{
					for (int j = 0; j <= degree - i; j++)
					{
						array[j].x = (1f - t) * array[j].x + t * array[j + 1].x;
						array[j].y = (1f - t) * array[j].y + t * array[j + 1].y;
					}
				}
				return array[0];
			}

			private static float B0(float u)
			{
				float num = 1f - u;
				return num * num * num;
			}

			private static float B1(float u)
			{
				float num = 1f - u;
				return 3f * u * (num * num);
			}

			private static float B2(float u)
			{
				float num = 1f - u;
				return 3f * u * u * num;
			}

			private static float B3(float u)
			{
				return u * u * u;
			}

			private static Vector2 ComputeLeftTangent(Vector2[] d, int end)
			{
				Vector2 result = d[end + 1] - d[end];
				result.Normalize();
				return result;
			}

			private static Vector2 ComputeRightTangent(Vector2[] d, int end)
			{
				Vector2 result = d[end - 1] - d[end];
				result.Normalize();
				return result;
			}

			private static Vector2 ComputeCenterTangent(Vector2[] d, int center)
			{
				Vector2 result = default(Vector2);
				Vector2 vector = d[center - 1] - d[center];
				Vector2 vector2 = d[center] - d[center + 1];
				result.x = (vector.x + vector2.x) / 2f;
				result.y = (vector.y + vector2.y) / 2f;
				result.Normalize();
				return result;
			}

			private static float[] ChordLengthParameterize(Vector2[] d, int first, int last)
			{
				float[] array = new float[last - first + 1];
				array[0] = 0f;
				for (int i = first + 1; i <= last; i++)
				{
					array[i - first] = array[i - first - 1] + (d[i - 1] - d[i]).magnitude;
				}
				for (int i = first + 1; i <= last; i++)
				{
					array[i - first] /= array[last - first];
				}
				return array;
			}

			private static float ComputeMaxError(Vector2[] d, int first, int last, Vector2[] bezCurve, float[] u, out int splitVector2)
			{
				splitVector2 = (last - first + 1) / 2;
				float num = 0f;
				for (int i = first + 1; i < last; i++)
				{
					float sqrMagnitude = (BezierII(3, bezCurve, u[i - first]) - d[i]).sqrMagnitude;
					if (sqrMagnitude >= num)
					{
						num = sqrMagnitude;
						splitVector2 = i;
					}
				}
				return num;
			}

			private static float V2Dot(Vector2 a, Vector2 b)
			{
				return a.x * b.x + a.y * b.y;
			}
		}

		private static readonly Vector2[] easeInSinePoints = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(0.36078f, -0.000436f),
			new Vector2(0.673486f, 0.486554f),
			new Vector2(1f, 1f)
		};

		private static readonly Vector2[] easeOutSinePoints = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(0.330931f, 0.520737f),
			new Vector2(0.641311f, 1.000333f),
			new Vector2(1f, 1f)
		};

		private static readonly Vector2[] easeInOutSinePoints = new Vector2[7]
		{
			new Vector2(0f, 0f),
			new Vector2(0.18039f, -0.000217f),
			new Vector2(0.336743f, 0.243277f),
			new Vector2(0.5f, 0.5f),
			new Vector2(0.665465f, 0.760338f),
			new Vector2(0.820656f, 1.000167f),
			new Vector2(1f, 1f)
		};

		public static readonly ReadOnlyCollection<Vector2> EaseInSinePoints = Array.AsReadOnly(easeInSinePoints);

		public static readonly ReadOnlyCollection<Vector2> EaseOutSinePoints = Array.AsReadOnly(easeOutSinePoints);

		public static readonly ReadOnlyCollection<Vector2> EaseInOutSinePoints = Array.AsReadOnly(easeInOutSinePoints);

		private static readonly Vector2[] easeInQuadPoints = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(0.333333f, 0f),
			new Vector2(0.666667f, 0.333333f),
			new Vector2(1f, 1f)
		};

		private static readonly Vector2[] easeOutQuadPoints = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(0.333333f, 0.666667f),
			new Vector2(0.666667f, 1f),
			new Vector2(1f, 1f)
		};

		private static readonly Vector2[] easeInOutQuadPoints = new Vector2[7]
		{
			new Vector2(0f, 0f),
			new Vector2(0.166667f, 0f),
			new Vector2(0.333333f, 0.166667f),
			new Vector2(0.5f, 0.5f),
			new Vector2(0.666667f, 0.833333f),
			new Vector2(0.833333f, 1f),
			new Vector2(1f, 1f)
		};

		public static readonly ReadOnlyCollection<Vector2> EaseInQuadPoints = Array.AsReadOnly(easeInQuadPoints);

		public static readonly ReadOnlyCollection<Vector2> EaseOutQuadPoints = Array.AsReadOnly(easeOutQuadPoints);

		public static readonly ReadOnlyCollection<Vector2> EaseInOutQuadPoints = Array.AsReadOnly(easeInOutQuadPoints);

		private static readonly Vector2[] easeInCubicPoints = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(0.333333f, 0f),
			new Vector2(0.666667f, 0f),
			new Vector2(1f, 1f)
		};

		private static readonly Vector2[] easeOutCubicPoints = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(0.333333f, 1f),
			new Vector2(0.666667f, 1f),
			new Vector2(1f, 1f)
		};

		private static readonly Vector2[] easeInOutCubicPoints = new Vector2[7]
		{
			new Vector2(0f, 0f),
			new Vector2(0.166667f, 0f),
			new Vector2(0.333333f, 0f),
			new Vector2(0.5f, 0.5f),
			new Vector2(0.666667f, 1f),
			new Vector2(0.833333f, 1f),
			new Vector2(1f, 1f)
		};

		public static readonly ReadOnlyCollection<Vector2> EaseInCubicPoints = Array.AsReadOnly(easeInCubicPoints);

		public static readonly ReadOnlyCollection<Vector2> EaseOutCubicPoints = Array.AsReadOnly(easeOutCubicPoints);

		public static readonly ReadOnlyCollection<Vector2> EaseInOutCubicPoints = Array.AsReadOnly(easeInOutCubicPoints);

		private static readonly Vector2[] easeInQuartPoints = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(0.434789f, 0.006062f),
			new Vector2(0.730901f, -0.07258f),
			new Vector2(1f, 1f)
		};

		private static readonly Vector2[] easeOutQuartPoints = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(0.269099f, 1.072581f),
			new Vector2(0.565211f, 0.993938f),
			new Vector2(1f, 1f)
		};

		private static readonly Vector2[] easeInOutQuartPoints = new Vector2[7]
		{
			new Vector2(0f, 0f),
			new Vector2(0.217394f, 0.003031f),
			new Vector2(0.365451f, -0.036291f),
			new Vector2(0.5f, 0.5f),
			new Vector2(0.634549f, 1.03629f),
			new Vector2(0.782606f, 0.996969f),
			new Vector2(1f, 1f)
		};

		public static readonly ReadOnlyCollection<Vector2> EaseInQuartPoints = Array.AsReadOnly(easeInQuartPoints);

		public static readonly ReadOnlyCollection<Vector2> EaseOutQuartPoints = Array.AsReadOnly(easeOutQuartPoints);

		public static readonly ReadOnlyCollection<Vector2> EaseInOutQuartPoints = Array.AsReadOnly(easeInOutQuartPoints);

		private static readonly Vector2[] easeInQuintPoints = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(0.519568f, 0.012531f),
			new Vector2(0.774037f, -0.118927f),
			new Vector2(1f, 1f)
		};

		private static readonly Vector2[] easeOutQuintPoints = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(0.225963f, 1.11926f),
			new Vector2(0.481099f, 0.987469f),
			new Vector2(1f, 1f)
		};

		private static readonly Vector2[] easeInOutQuintPoints = new Vector2[7]
		{
			new Vector2(0f, 0f),
			new Vector2(0.259784f, 0.006266f),
			new Vector2(0.387018f, -0.059463f),
			new Vector2(0.5f, 0.5f),
			new Vector2(0.612982f, 1.05963f),
			new Vector2(0.740549f, 0.993734f),
			new Vector2(1f, 1f)
		};

		public static readonly ReadOnlyCollection<Vector2> EaseInQuintPoints = Array.AsReadOnly(easeInQuintPoints);

		public static readonly ReadOnlyCollection<Vector2> EaseOutQuintPoints = Array.AsReadOnly(easeOutQuintPoints);

		public static readonly ReadOnlyCollection<Vector2> EaseInOutQuintPoints = Array.AsReadOnly(easeInOutQuintPoints);

		private static readonly Vector2[] easeInExpoPoints = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(0.636963f, 0.0199012f),
			new Vector2(0.844333f, -0.0609379f),
			new Vector2(1f, 1f)
		};

		private static readonly Vector2[] easeOutExpoPoints = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(0.155667f, 1.060938f),
			new Vector2(0.363037f, 0.980099f),
			new Vector2(1f, 1f)
		};

		private static readonly Vector2[] easeInOutExpoPoints = new Vector2[7]
		{
			new Vector2(0f, 0f),
			new Vector2(0.318482f, 0.009951f),
			new Vector2(0.422167f, -0.030469f),
			new Vector2(0.5f, 0.5f),
			new Vector2(0.577833f, 1.030469f),
			new Vector2(0.681518f, 0.9900494f),
			new Vector2(1f, 1f)
		};

		public static readonly ReadOnlyCollection<Vector2> EaseInExpoPoints = Array.AsReadOnly(easeInExpoPoints);

		public static readonly ReadOnlyCollection<Vector2> EaseOutExpoPoints = Array.AsReadOnly(easeOutExpoPoints);

		public static readonly ReadOnlyCollection<Vector2> EaseInOutExpoPoints = Array.AsReadOnly(easeInOutExpoPoints);

		private static readonly Vector2[] easeInCircPoints = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(0.55403f, 0.001198f),
			new Vector2(0.998802f, 0.449801f),
			new Vector2(1f, 1f)
		};

		private static readonly Vector2[] easeOutCircPoints = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(0.001198f, 0.553198f),
			new Vector2(0.445976f, 0.998802f),
			new Vector2(1f, 1f)
		};

		private static readonly Vector2[] easeInOutCircPoints = new Vector2[7]
		{
			new Vector2(0f, 0f),
			new Vector2(0.277013f, 0.000599f),
			new Vector2(0.499401f, 0.223401f),
			new Vector2(0.5f, 0.5f),
			new Vector2(0.500599f, 0.776599f),
			new Vector2(0.722987f, 0.999401f),
			new Vector2(1f, 1f)
		};

		public static readonly ReadOnlyCollection<Vector2> EaseInCircPoints = Array.AsReadOnly(easeInCircPoints);

		public static readonly ReadOnlyCollection<Vector2> EaseOutCircPoints = Array.AsReadOnly(easeOutCircPoints);

		public static readonly ReadOnlyCollection<Vector2> EaseInOutCircPoints = Array.AsReadOnly(easeInOutCircPoints);

		private static readonly Vector2[] easeInBackPoints = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(0.333333f, 0f),
			new Vector2(0.666667f, -0.567193f),
			new Vector2(1f, 1f)
		};

		private static readonly Vector2[] easeOutBackPoints = new Vector2[4]
		{
			new Vector2(0f, 0f),
			new Vector2(0.333333f, 1.567193f),
			new Vector2(0.666667f, 1f),
			new Vector2(1f, 1f)
		};

		private static readonly Vector2[] easeInOutBackPoints = new Vector2[7]
		{
			new Vector2(0f, 0f),
			new Vector2(0.166667f, 0f),
			new Vector2(0.333333f, -0.432485f),
			new Vector2(0.5f, 0.5f),
			new Vector2(0.666667f, 1.432485f),
			new Vector2(0.833333f, 1f),
			new Vector2(1f, 1f)
		};

		public static readonly ReadOnlyCollection<Vector2> EaseInBackPoints = Array.AsReadOnly(easeInBackPoints);

		public static readonly ReadOnlyCollection<Vector2> EaseOutBackPoints = Array.AsReadOnly(easeOutBackPoints);

		public static readonly ReadOnlyCollection<Vector2> EaseInOutBackPoints = Array.AsReadOnly(easeInOutBackPoints);

		private static readonly Vector2[] easeInElasticPoints = new Vector2[13]
		{
			new Vector2(0f, 0f),
			new Vector2(0.175f, 0.00250747f),
			new Vector2(0.173542f, 0f),
			new Vector2(0.175f, 0f),
			new Vector2(0.4425f, -0.0184028f),
			new Vector2(0.3525f, 0.05f),
			new Vector2(0.475f, 0f),
			new Vector2(0.735f, -0.143095f),
			new Vector2(0.6575f, 0.383333f),
			new Vector2(0.775f, 0f),
			new Vector2(0.908125f, -0.586139f),
			new Vector2(0.866875f, -0.666667f),
			new Vector2(1f, 1f)
		};

		private static readonly Vector2[] easeOutElasticPoints = new Vector2[13]
		{
			new Vector2(0f, 0f),
			new Vector2(0.133125f, 1.666667f),
			new Vector2(0.091875f, 1.586139f),
			new Vector2(0.225f, 1f),
			new Vector2(0.3425f, 0.616667f),
			new Vector2(0.265f, 1.143095f),
			new Vector2(0.525f, 1f),
			new Vector2(0.6475f, 0.95f),
			new Vector2(0.5575f, 1.0184028f),
			new Vector2(0.825f, 1f),
			new Vector2(0.826458f, 1f),
			new Vector2(0.825f, 0.9974925f),
			new Vector2(1f, 1f)
		};

		private static readonly Vector2[] easeInOutElasticPoints = new Vector2[25]
		{
			new Vector2(0f, 0f),
			new Vector2(0.0875f, 0.001254f),
			new Vector2(0.086771f, 0f),
			new Vector2(0.0875f, 0f),
			new Vector2(0.22125f, -0.009201f),
			new Vector2(0.17625f, 0.025f),
			new Vector2(0.2375f, 0f),
			new Vector2(0.3675f, -0.071548f),
			new Vector2(0.32875f, 0.191667f),
			new Vector2(0.3875f, 0f),
			new Vector2(0.454063f, -0.29307f),
			new Vector2(0.433438f, -0.333334f),
			new Vector2(0.5f, 0.5f),
			new Vector2(0.5665625f, 1.333334f),
			new Vector2(0.5459375f, 1.29307f),
			new Vector2(0.6125f, 1f),
			new Vector2(0.67125f, 0.808334f),
			new Vector2(0.6325f, 1.071548f),
			new Vector2(0.7625f, 1f),
			new Vector2(0.82375f, 0.975f),
			new Vector2(0.77875f, 1.009201f),
			new Vector2(0.9125f, 1f),
			new Vector2(0.913229f, 1f),
			new Vector2(0.9125f, 0.9987463f),
			new Vector2(1f, 1f)
		};

		public static readonly ReadOnlyCollection<Vector2> EaseInElasticPoints = Array.AsReadOnly(easeInElasticPoints);

		public static readonly ReadOnlyCollection<Vector2> EaseOutElasticPoints = Array.AsReadOnly(easeOutElasticPoints);

		public static readonly ReadOnlyCollection<Vector2> EaseInOutElasticPoints = Array.AsReadOnly(easeInOutElasticPoints);

		private static readonly Vector2[] easeInBouncePoints = new Vector2[13]
		{
			new Vector2(0f, 0f),
			new Vector2(0.030303f, 0.020833f),
			new Vector2(0.060606f, 0.020833f),
			new Vector2(0.0909f, 0f),
			new Vector2(0.151515f, 0.083333f),
			new Vector2(0.212121f, 0.083333f),
			new Vector2(0.2727f, 0f),
			new Vector2(0.393939f, 0.333333f),
			new Vector2(0.515152f, 0.333333f),
			new Vector2(0.6364f, 0f),
			new Vector2(0.757576f, 0.666667f),
			new Vector2(0.878788f, 1f),
			new Vector2(1f, 1f)
		};

		private static readonly Vector2[] easeOutBouncePoints = new Vector2[13]
		{
			new Vector2(0f, 0f),
			new Vector2(0.121212f, 0f),
			new Vector2(0.242424f, 0.333333f),
			new Vector2(0.3636f, 1f),
			new Vector2(0.484848f, 0.666667f),
			new Vector2(0.60606f, 0.666667f),
			new Vector2(0.7273f, 1f),
			new Vector2(0.787879f, 0.916667f),
			new Vector2(0.848485f, 0.916667f),
			new Vector2(0.9091f, 1f),
			new Vector2(0.939394f, 47f / 48f),
			new Vector2(32f / 33f, 47f / 48f),
			new Vector2(1f, 1f)
		};

		private static readonly Vector2[] easeInOutBouncePoints = new Vector2[25]
		{
			new Vector2(0f, 0f),
			new Vector2(0.015152f, 0.010417f),
			new Vector2(0.030303f, 0.010417f),
			new Vector2(0.0455f, 0f),
			new Vector2(0.075758f, 0.041667f),
			new Vector2(0.106061f, 0.041667f),
			new Vector2(0.1364f, 0f),
			new Vector2(0.19697f, 0.166667f),
			new Vector2(0.257576f, 0.166667f),
			new Vector2(0.3182f, 0f),
			new Vector2(0.378788f, 0.333333f),
			new Vector2(0.439394f, 0.5f),
			new Vector2(0.5f, 0.5f),
			new Vector2(0.560606f, 0.5f),
			new Vector2(0.621212f, 0.666667f),
			new Vector2(0.6818f, 1f),
			new Vector2(0.742424f, 0.833333f),
			new Vector2(0.80303f, 0.833333f),
			new Vector2(0.8636f, 1f),
			new Vector2(0.893939f, 0.958333f),
			new Vector2(0.924242f, 0.958333f),
			new Vector2(0.955f, 1f),
			new Vector2(32f / 33f, 0.989583f),
			new Vector2(0.984848f, 0.989583f),
			new Vector2(1f, 1f)
		};

		public static readonly ReadOnlyCollection<Vector2> EaseInBouncePoints = Array.AsReadOnly(easeInBouncePoints);

		public static readonly ReadOnlyCollection<Vector2> EaseOutBouncePoints = Array.AsReadOnly(easeOutBouncePoints);

		public static readonly ReadOnlyCollection<Vector2> EaseInOutBouncePoints = Array.AsReadOnly(easeInOutBouncePoints);

		public static readonly ReadOnlyDictionary<string, ReadOnlyCollection<Vector2>> NamePointsMapping = new ReadOnlyDictionary<string, ReadOnlyCollection<Vector2>>(new Dictionary<string, ReadOnlyCollection<Vector2>>
		{
			{ "easeinsine", EaseInSinePoints },
			{ "easeoutsine", EaseOutSinePoints },
			{ "easeinoutsine", EaseInOutSinePoints },
			{ "easein-sine", EaseInSinePoints },
			{ "easeout-sine", EaseOutSinePoints },
			{ "easeinout-sine", EaseInOutSinePoints },
			{ "easeinquad", EaseInQuadPoints },
			{ "easeoutquad", EaseOutQuadPoints },
			{ "easeinoutquad", EaseInOutQuadPoints },
			{ "easein-quad", EaseInQuadPoints },
			{ "easeout-quad", EaseOutQuadPoints },
			{ "easeinout-quad", EaseInOutQuadPoints },
			{ "easeincubic", EaseInCubicPoints },
			{ "easeoutcubic", EaseOutCubicPoints },
			{ "easeinoutcubic", EaseInOutCubicPoints },
			{ "easein-cubic", EaseInCubicPoints },
			{ "easeout-cubic", EaseOutCubicPoints },
			{ "easeinout-cubic", EaseInOutCubicPoints },
			{ "easeinquart", EaseInQuartPoints },
			{ "easeoutquart", EaseOutQuartPoints },
			{ "easeinoutquart", EaseInOutQuartPoints },
			{ "easein-quart", EaseInQuartPoints },
			{ "easeout-quart", EaseOutQuartPoints },
			{ "easeinout-quart", EaseInOutQuartPoints },
			{ "easeinquint", EaseInQuintPoints },
			{ "easeoutquint", EaseOutQuintPoints },
			{ "easeinoutquint", EaseInOutQuintPoints },
			{ "easein-quint", EaseInQuintPoints },
			{ "easeout-quint", EaseOutQuintPoints },
			{ "easeinout-quint", EaseInOutQuintPoints },
			{ "easeinexpo", EaseInExpoPoints },
			{ "easeoutexpo", EaseOutExpoPoints },
			{ "easeinoutexpo", EaseInOutExpoPoints },
			{ "easein-expo", EaseInExpoPoints },
			{ "easeout-expo", EaseOutExpoPoints },
			{ "easeinout-expo", EaseInOutExpoPoints },
			{ "easeincirc", EaseInCircPoints },
			{ "easeoutcirc", EaseOutCircPoints },
			{ "easeinoutcirc", EaseInOutCircPoints },
			{ "easein-circ", EaseInCircPoints },
			{ "easeout-circ", EaseOutCircPoints },
			{ "easeinout-circ", EaseInOutCircPoints },
			{ "easeinback", EaseInBackPoints },
			{ "easeoutback", EaseOutBackPoints },
			{ "easeinoutback", EaseInOutBackPoints },
			{ "easein-back", EaseInBackPoints },
			{ "easeout-back", EaseOutBackPoints },
			{ "easeinout-back", EaseInOutBackPoints },
			{ "easeinelastic", EaseInElasticPoints },
			{ "easeoutelastic", EaseOutElasticPoints },
			{ "easeinoutelastic", EaseInOutElasticPoints },
			{ "easein-elastic", EaseInElasticPoints },
			{ "easeout-elastic", EaseOutElasticPoints },
			{ "easeinout-elastic", EaseInOutElasticPoints },
			{ "easeinbounce", EaseInBouncePoints },
			{ "easeoutbounce", EaseOutBouncePoints },
			{ "easeinoutbounce", EaseInOutBouncePoints },
			{ "easein-bounce", EaseInBouncePoints },
			{ "easeout-bounce", EaseOutBouncePoints },
			{ "easeinout-bounce", EaseInOutBouncePoints }
		});

		public static readonly ReadOnlyDictionary<string, Func<AnimationCurve>> NameConstructorMapping = new ReadOnlyDictionary<string, Func<AnimationCurve>>(new Dictionary<string, Func<AnimationCurve>>
		{
			{ "easeinsine", EaseInSine },
			{ "easeoutsine", EaseOutSine },
			{ "easeinoutsine", EaseInOutSine },
			{ "easein-sine", EaseInSine },
			{ "easeout-sine", EaseOutSine },
			{ "easeinout-sine", EaseInOutSine },
			{ "easeinquad", EaseInQuad },
			{ "easeoutquad", EaseOutQuad },
			{ "easeinoutquad", EaseInOutQuad },
			{ "easein-quad", EaseInQuad },
			{ "easeout-quad", EaseOutQuad },
			{ "easeinout-quad", EaseInOutQuad },
			{ "easeincubic", EaseInCubic },
			{ "easeoutcubic", EaseOutCubic },
			{ "easeinoutcubic", EaseInOutCubic },
			{ "easein-cubic", EaseInCubic },
			{ "easeout-cubic", EaseOutCubic },
			{ "easeinout-cubic", EaseInOutCubic },
			{ "easeinquart", EaseInQuart },
			{ "easeoutquart", EaseOutQuart },
			{ "easeinoutquart", EaseInOutQuart },
			{ "easein-quart", EaseInQuart },
			{ "easeout-quart", EaseOutQuart },
			{ "easeinout-quart", EaseInOutQuart },
			{ "easeinquint", EaseInQuint },
			{ "easeoutquint", EaseOutQuint },
			{ "easeinoutquint", EaseInOutQuint },
			{ "easein-quint", EaseInQuint },
			{ "easeout-quint", EaseOutQuint },
			{ "easeinout-quint", EaseInOutQuint },
			{ "easeinexpo", EaseInExpo },
			{ "easeoutexpo", EaseOutExpo },
			{ "easeinoutexpo", EaseInOutExpo },
			{ "easein-expo", EaseInExpo },
			{ "easeout-expo", EaseOutExpo },
			{ "easeinout-expo", EaseInOutExpo },
			{ "easeincirc", EaseInCirc },
			{ "easeoutcirc", EaseOutCirc },
			{ "easeinoutcirc", EaseInOutCirc },
			{ "easein-circ", EaseInCirc },
			{ "easeout-circ", EaseOutCirc },
			{ "easeinout-circ", EaseInOutCirc },
			{ "easeinback", EaseInBack },
			{ "easeoutback", EaseOutBack },
			{ "easeinoutback", EaseInOutBack },
			{ "easein-back", EaseInBack },
			{ "easeout-back", EaseOutBack },
			{ "easeinout-back", EaseInOutBack },
			{ "easeinelastic", EaseInElastic },
			{ "easeoutelastic", EaseOutElastic },
			{ "easeinoutelastic", EaseInOutElastic },
			{ "easein-elastic", EaseInElastic },
			{ "easeout-elastic", EaseOutElastic },
			{ "easeinout-elastic", EaseInOutElastic },
			{ "easeinbounce", EaseInBounce },
			{ "easeoutbounce", EaseOutBounce },
			{ "easeinoutbounce", EaseInOutBounce },
			{ "easein-bounce", EaseInBounce },
			{ "easeout-bounce", EaseOutBounce },
			{ "easeinout-bounce", EaseInOutBounce },
			{ "linear", Linear }
		});

		public static readonly ReadOnlyDictionary<string, Func<IEnumerable<Vector2>, AnimationCurve>> NameBezierConstructorMapping = new ReadOnlyDictionary<string, Func<IEnumerable<Vector2>, AnimationCurve>>(new Dictionary<string, Func<IEnumerable<Vector2>, AnimationCurve>>
		{
			{ "linear", LinearBezier },
			{ "quadratic", QuadraticBezier },
			{ "cubic", CubicBezier },
			{ "linear-bezier", LinearBezier },
			{ "quadratic-bezier", QuadraticBezier },
			{ "cubic-bezier", CubicBezier },
			{ "linearbezier", LinearBezier },
			{ "quadraticbezier", QuadraticBezier },
			{ "cubicbezier", CubicBezier }
		});

		public static AnimationCurve Copy(this AnimationCurve curve)
		{
			AnimationCurve animationCurve = new AnimationCurve();
			animationCurve.CopyFrom(curve);
			return animationCurve;
		}

		public static AnimationCurve InvertCopy(this AnimationCurve curve)
		{
			return Invert(curve);
		}

		public static AnimationCurve Linear()
		{
			return LinearBezier(new Vector2(0f, 0f), new Vector2(1f, 1f));
		}

		public static AnimationCurve EaseInSine()
		{
			return CubicBezier(easeInSinePoints);
		}

		public static AnimationCurve EaseOutSine()
		{
			return CubicBezier(easeOutSinePoints);
		}

		public static AnimationCurve EaseInOutSine()
		{
			return CubicBezier(easeInOutSinePoints);
		}

		public static AnimationCurve EaseInQuad()
		{
			return CubicBezier(easeInQuadPoints);
		}

		public static AnimationCurve EaseOutQuad()
		{
			return CubicBezier(easeOutQuadPoints);
		}

		public static AnimationCurve EaseInOutQuad()
		{
			return CubicBezier(easeInOutQuadPoints);
		}

		public static AnimationCurve EaseInCubic()
		{
			return CubicBezier(easeInCubicPoints);
		}

		public static AnimationCurve EaseOutCubic()
		{
			return CubicBezier(easeOutCubicPoints);
		}

		public static AnimationCurve EaseInOutCubic()
		{
			return CubicBezier(easeInOutCubicPoints);
		}

		public static AnimationCurve EaseInQuart()
		{
			return CubicBezier(easeInQuartPoints);
		}

		public static AnimationCurve EaseOutQuart()
		{
			return CubicBezier(easeOutQuartPoints);
		}

		public static AnimationCurve EaseInOutQuart()
		{
			return CubicBezier(easeInOutQuartPoints);
		}

		public static AnimationCurve EaseInQuint()
		{
			return CubicBezier(easeInQuintPoints);
		}

		public static AnimationCurve EaseOutQuint()
		{
			return CubicBezier(easeOutQuintPoints);
		}

		public static AnimationCurve EaseInOutQuint()
		{
			return CubicBezier(easeInOutQuintPoints);
		}

		public static AnimationCurve EaseInExpo()
		{
			return CubicBezier(easeInExpoPoints);
		}

		public static AnimationCurve EaseOutExpo()
		{
			return CubicBezier(easeOutExpoPoints);
		}

		public static AnimationCurve EaseInOutExpo()
		{
			return CubicBezier(easeInOutExpoPoints);
		}

		public static AnimationCurve EaseInCirc()
		{
			return CubicBezier(easeInCircPoints);
		}

		public static AnimationCurve EaseOutCirc()
		{
			return CubicBezier(easeOutCircPoints);
		}

		public static AnimationCurve EaseInOutCirc()
		{
			return CubicBezier(easeInOutCircPoints);
		}

		public static AnimationCurve EaseInBack()
		{
			return CubicBezier(easeInBackPoints);
		}

		public static AnimationCurve EaseOutBack()
		{
			return CubicBezier(easeOutBackPoints);
		}

		public static AnimationCurve EaseInOutBack()
		{
			return CubicBezier(easeInOutBackPoints);
		}

		public static AnimationCurve EaseInElastic()
		{
			return CubicBezier(easeInElasticPoints);
		}

		public static AnimationCurve EaseOutElastic()
		{
			return CubicBezier(easeOutElasticPoints);
		}

		public static AnimationCurve EaseInOutElastic()
		{
			return CubicBezier(easeInOutElasticPoints);
		}

		public static AnimationCurve EaseInBounce()
		{
			return CubicBezier(easeInBouncePoints);
		}

		public static AnimationCurve EaseOutBounce()
		{
			return CubicBezier(easeOutBouncePoints);
		}

		public static AnimationCurve EaseInOutBounce()
		{
			return CubicBezier(easeInOutBouncePoints);
		}

		public static AnimationCurve Bezier(params Vector2[] points)
		{
			int num = points.Length;
			if (num >= 4 && (num - 4) % 3 == 0)
			{
				return CubicBezier(points);
			}
			if (num >= 3 && (num - 3) % 2 == 0)
			{
				return QuadraticBezier(points);
			}
			return LinearBezier(points);
		}

		public static AnimationCurve Bezier(IEnumerable<Vector2> points)
		{
			return Bezier(points.ToArray());
		}

		public static AnimationCurve LinearBezier(Vector2 start, Vector2 end)
		{
			Keyframe keyframe = new Keyframe(start.x, start.y, 0f, 0f, 0f, 0f);
			Keyframe keyframe2 = new Keyframe(end.x, end.y, 0f, 0f, 0f, 0f);
			return new AnimationCurve(keyframe, keyframe2);
		}

		public static AnimationCurve LinearBezier(params Vector2[] points)
		{
			if (points.Length < 2)
			{
				throw new ArgumentException();
			}
			Keyframe[] array = new Keyframe[points.Length];
			for (int i = 0; i < points.Length; i++)
			{
				Vector2 vector = points[i];
				array[i] = new Keyframe(vector.x, vector.y, 0f, 0f, 0f, 0f);
			}
			return new AnimationCurve(array);
		}

		public static AnimationCurve LinearBezier(IEnumerable<Vector2> points)
		{
			return LinearBezier(points.ToArray());
		}

		public static AnimationCurve QuadraticBezier(Vector2 startPoint, Vector2 controlPoint, Vector2 endPoint)
		{
			Vector2 controlPoint2 = startPoint + 2f / 3f * (controlPoint - startPoint);
			Vector2 controlPoint3 = endPoint + 2f / 3f * (controlPoint - endPoint);
			return CubicBezier(startPoint, controlPoint2, controlPoint3, endPoint);
		}

		public static AnimationCurve QuadraticBezier(params Vector2[] points)
		{
			int num = points.Length;
			if (points == null || num < 3 || (num > 3 && (num - 3) % 2 != 0))
			{
				throw new ArgumentException();
			}
			int num2 = 1 + (num - 3) / 2;
			Vector2[] array = new Vector2[num + num2];
			int num3 = 0;
			for (int i = 0; i < num; i++)
			{
				if (i % 2 == 1)
				{
					Vector2 vector = points[i - 1] + 2f / 3f * (points[i] - points[i - 1]);
					Vector2 vector2 = points[i + 1] + 2f / 3f * (points[i] - points[i + 1]);
					array[i + num3++] = vector;
					array[i + num3] = vector2;
				}
				else
				{
					array[i + num3] = points[i];
				}
			}
			return CubicBezier(array);
		}

		public static AnimationCurve QuadraticBezier(IEnumerable<Vector2> points)
		{
			return QuadraticBezier(points.ToArray());
		}

		public static AnimationCurve CubicBezier(Vector2 startPoint, Vector2 controlPoint0, Vector2 controlPoint1, Vector2 endPoint)
		{
			AnimationCurve animationCurve = new AnimationCurve();
			BezierToAnimationCurve(animationCurve, new Vector2[4] { startPoint, controlPoint0, controlPoint1, endPoint });
			return animationCurve;
		}

		public static AnimationCurve CubicBezier(params Vector2[] points)
		{
			if (points == null || points.Length < 4 || (points.Length > 4 && (points.Length - 4) % 3 != 0))
			{
				throw new ArgumentException();
			}
			AnimationCurve animationCurve = new AnimationCurve();
			BezierToAnimationCurve(animationCurve, points);
			return animationCurve;
		}

		public static AnimationCurve CubicBezier(IEnumerable<Vector2> points)
		{
			return CubicBezier(points.ToArray());
		}

		private static void BezierToAnimationCurve(AnimationCurve outCurve, Vector2[] controlPointStrips)
		{
			if (controlPointStrips.Length < 4)
			{
				throw new ArgumentException("The number of control point strips should more than 4!");
			}
			if ((controlPointStrips.Length - 4) % 3 != 0)
			{
				throw new ArgumentException("The number of control point strips N should be (N-4)%3==0");
			}
			int num = 1 + (controlPointStrips.Length - 4) / 3;
			Keyframe[] array = new Keyframe[num + 1];
			array[0] = new Keyframe(controlPointStrips[0].x, controlPointStrips[0].y)
			{
				weightedMode = WeightedMode.Both
			};
			for (int i = 0; i < num; i++)
			{
				int num2 = i * 3;
				array[i].outTangent = Tangent(in controlPointStrips[num2], in controlPointStrips[num2 + 1]);
				float length = controlPointStrips[num2 + 3].x - controlPointStrips[num2].x;
				array[i].outWeight = Weight(in controlPointStrips[num2], in controlPointStrips[num2 + 1], length);
				array[i + 1] = new Keyframe(controlPointStrips[num2 + 3].x, controlPointStrips[num2 + 3].y)
				{
					inTangent = Tangent(in controlPointStrips[num2 + 2], in controlPointStrips[num2 + 3]),
					inWeight = Weight(in controlPointStrips[num2 + 2], in controlPointStrips[num2 + 3], length),
					weightedMode = WeightedMode.Both
				};
			}
			if (outCurve == null)
			{
				outCurve = new AnimationCurve();
			}
			outCurve.keys = array;
		}

		private static float Tangent(in Vector2 from, in Vector2 to)
		{
			Vector2 vector = to - from;
			return vector.y / vector.x;
		}

		private static float Weight(in Vector2 from, in Vector2 to, float length)
		{
			return (to.x - from.x) / length;
		}

		public static AnimationCurve GetInverse(AnimationCurve originalCurve)
		{
			AnimationCurve animationCurve = new AnimationCurve();
			for (int num = originalCurve.keys.Length - 1; num >= 0; num--)
			{
				Keyframe key = originalCurve.keys[num];
				key.time = Mathf.Lerp(1f, 0f, key.time);
				float inWeight = key.inWeight;
				key.inWeight = key.outWeight;
				key.outWeight = inWeight;
				key.inTangent *= -1f;
				key.outTangent *= -1f;
				animationCurve.AddKey(key);
			}
			return animationCurve;
		}

		public static AnimationCurve Invert(AnimationCurve curve)
		{
			List<Keyframe> list = new List<Keyframe>(curve.keys);
			for (int num = curve.keys.Length - 1; num >= 0; num--)
			{
				curve.RemoveKey(num);
			}
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				Keyframe key = list[num2];
				key.time = Mathf.Lerp(1f, 0f, key.time);
				float inWeight = key.inWeight;
				key.inWeight = key.outWeight;
				key.outWeight = inWeight;
				key.inTangent *= -1f;
				key.outTangent *= -1f;
				curve.AddKey(key);
			}
			return curve;
		}
	}
}
