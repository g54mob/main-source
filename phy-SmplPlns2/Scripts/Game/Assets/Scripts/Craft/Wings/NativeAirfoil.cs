using System;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings
{
	public struct NativeAirfoil : IDisposable
	{
		public struct ReadOnly
		{
			[ReadOnly]
			public NativeArray<float2> BottomPoints;

			public bool LeadingSmooth;

			[ReadOnly]
			public NativeArray<float2> TopPoints;

			public bool TrailingSmooth;

			public float LeadingEdgeRadius;

			public readonly float SampleBottom(float x)
			{
				return SampleY(x, BottomPoints);
			}

			public readonly float SampleTop(float x)
			{
				return SampleY(x, TopPoints);
			}

			public readonly float SampleCamber(float x)
			{
				return 0.5f * (SampleY(x, BottomPoints) + SampleY(x, TopPoints));
			}

			internal void RenderToImpl(in CrossSection section)
			{
				bool leadingSmooth = LeadingSmooth;
				bool trailingSmooth = TrailingSmooth;
				bool flag = math.all(TopPoints[0] == BottomPoints[0]);
				ref NativeArray<float2> topPoints = ref TopPoints;
				float2 obj = topPoints[topPoints.Length - 1];
				ref NativeArray<float2> bottomPoints = ref BottomPoints;
				bool flag2 = math.all(obj == bottomPoints[bottomPoints.Length - 1]);
				int num = TopPoints.Length + BottomPoints.Length;
				if (flag)
				{
					num--;
				}
				if (flag2)
				{
					num--;
				}
				section.Points.Resize(num, NativeArrayOptions.UninitializedMemory);
				section.Points.Clear();
				for (int i = 0; i < TopPoints.Length; i++)
				{
					PointFlags flags = PointFlags.Smooth;
					if ((!leadingSmooth && i == 0) || (!trailingSmooth && i == TopPoints.Length - 1))
					{
						flags = PointFlags.None;
					}
					section.Points.Add(new Point(TopPoints[i], flags));
				}
				for (int num2 = BottomPoints.Length - 1; num2 >= 0; num2--)
				{
					if ((!flag || num2 != 0) && (!flag2 || num2 != BottomPoints.Length - 1))
					{
						PointFlags flags2 = PointFlags.Smooth;
						if ((!leadingSmooth && num2 == 0) || (!trailingSmooth && num2 == BottomPoints.Length - 1))
						{
							flags2 = PointFlags.None;
						}
						section.Points.Add(new Point(BottomPoints[num2], flags2));
					}
				}
			}
		}

		[BurstCompile]
		private struct InterpolateJob : IJob
		{
			[ReadOnly]
			public NativeAirfoil A;

			[ReadOnly]
			public NativeAirfoil B;

			public NativeAirfoil Out;

			[ReadOnly]
			public float T;

			public void Execute()
			{
				InterpolateArray(A.TopPoints, B.TopPoints, T, Out.TopPoints);
				InterpolateArray(A.BottomPoints, B.BottomPoints, T, Out.BottomPoints);
			}

			private static void InterpolateArray(NativeArray<float2> a, NativeArray<float2> b, float t, NativeArray<float2> res)
			{
				if (a.Length == b.Length)
				{
					for (int i = 0; i < a.Length; i++)
					{
						res[i] = math.lerp(a[i], b[i], t);
					}
					return;
				}
				if (res.Length == b.Length)
				{
					NativeArray<float2> nativeArray = b;
					NativeArray<float2> nativeArray2 = a;
					a = nativeArray;
					b = nativeArray2;
					t = 1f - t;
				}
				int j = 0;
				for (int k = 0; k < a.Length; k++)
				{
					float2 float5;
					for (float5 = a[k]; float5.x < b[j + 1].x && j + 2 < b.Length; j++)
					{
					}
					float2 float6 = b[j];
					float2 float7 = b[j + 1];
					float end = math.lerp(float6.y, float7.y, math.unlerp(float6.x, float7.x, float5.x));
					res[k] = math.float2(float5.x, math.lerp(float5.y, end, t));
				}
			}
		}

		[BurstCompile]
		private struct RenderNativeAirfoilJob : IJob
		{
			public CrossSection section;

			public void Execute()
			{
				section.Airfoil.RenderToImpl(in section);
			}
		}

		public NativeArray<float2> BottomPoints;

		public bool LeadingSmooth;

		public NativeArray<float2> TopPoints;

		public bool TrailingSmooth;

		public float LeadingEdgeRadius;

		public bool IsCreated
		{
			get
			{
				if (TopPoints.IsCreated)
				{
					return BottomPoints.IsCreated;
				}
				return false;
			}
		}

		public NativeAirfoil(int length, Allocator allocator)
		{
			TopPoints = new NativeArray<float2>(length, allocator);
			BottomPoints = new NativeArray<float2>(length, allocator);
			LeadingSmooth = true;
			TrailingSmooth = false;
			LeadingEdgeRadius = 0f;
		}

		public static implicit operator ReadOnly(NativeAirfoil af)
		{
			return new ReadOnly
			{
				TopPoints = af.TopPoints,
				BottomPoints = af.BottomPoints,
				LeadingSmooth = af.LeadingSmooth,
				TrailingSmooth = af.TrailingSmooth,
				LeadingEdgeRadius = af.LeadingEdgeRadius
			};
		}

		public static int GetIndex(float x, NativeArray<float2> a)
		{
			return BinSearch(a, x, 0, a.Length - 1);
		}

		public void Dispose()
		{
			if (TopPoints.IsCreated)
			{
				TopPoints.Dispose();
			}
			if (BottomPoints.IsCreated)
			{
				BottomPoints.Dispose();
			}
		}

		public void EnsureCapacity(int requiredSamples, Allocator allocator)
		{
			if (!IsCreated || TopPoints.Length != requiredSamples)
			{
				if (IsCreated)
				{
					Dispose();
				}
				this = new NativeAirfoil(requiredSamples, allocator);
			}
		}

		public void InterpolateFrom(NativeAirfoil a, NativeAirfoil b, float t, Allocator allocator)
		{
			bool flag = t < 0.5f;
			EnsureCapacity(flag ? a.TopPoints.Length : b.TopPoints.Length, allocator);
			LeadingEdgeRadius = math.lerp(a.LeadingEdgeRadius, b.LeadingEdgeRadius, t);
			new InterpolateJob
			{
				A = a,
				B = b,
				T = t,
				Out = this
			}.Run();
		}

		public void RenderTo(ref CrossSection section)
		{
			section.Airfoil = this;
			new RenderNativeAirfoilJob
			{
				section = section
			}.Run();
		}

		public float SampleBottom(float x)
		{
			return SampleY(x, BottomPoints);
		}

		public float SampleTop(float x)
		{
			return SampleY(x, TopPoints);
		}

		private static int BinSearch(NativeArray<float2> a, float x, int start, int end)
		{
			if (start == end)
			{
				return start;
			}
			if (start + 1 == end)
			{
				if (!(a[end].x >= x))
				{
					return start;
				}
				return end;
			}
			int num = (start + end) / 2;
			if (a[num].x >= x)
			{
				return BinSearch(a, x, num, end);
			}
			return BinSearch(a, x, start, num - 1);
		}

		private static float SampleY(float x, NativeArray<float2> a)
		{
			int index = GetIndex(x, a);
			if (index == a.Length - 1)
			{
				return a[index].y;
			}
			return math.lerp(a[index].y, a[index + 1].y, math.unlerp(a[index].x, a[index + 1].x, x));
		}
	}
}
