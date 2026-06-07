using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Mathematics;

namespace Assets.Scripts.Craft.MeshGen
{
	public static class MathUtils
	{
		public struct Cubic
		{
			public float4 coefficients;

			public readonly Quadratic Gradient => new Quadratic
			{
				coefficients = coefficients.yzw * math.float3(1f, 2f, 3f)
			};

			public readonly float this[float x] => math.dot(Polynomial4(x), coefficients);

			public Cubic(float a, float b, float c, float d)
			{
				coefficients = math.float4(a, b, c, d);
			}
		}

		public struct Linear
		{
			public float2 coefficients;

			public readonly float Gradient => coefficients.y;

			public readonly float this[float x] => math.dot(Polynomial2(x), coefficients);

			public Linear(float a, float b)
			{
				coefficients = math.float2(a, b);
			}

			public readonly float Solve(float y)
			{
				return (y - coefficients.x) / coefficients.y;
			}
		}

		public struct Quadratic
		{
			public float3 coefficients;

			public readonly Linear Gradient => new Linear(coefficients.y, 2f * coefficients.z);

			public readonly float this[float x] => math.dot(Polynomial3(x), coefficients);

			public Quadratic(float a, float b, float c)
			{
				coefficients = math.float3(a, b, c);
			}

			public static Quadratic Fit(float3 x, float3 y)
			{
				float3 float5 = math.mul(math.inverse(math.float3x3(1f, x, x * x)), y);
				return new Quadratic
				{
					coefficients = float5
				};
			}

			public static Quadratic Fit(float2 a, float2 b, float2 c)
			{
				return Fit(math.float3(a.x, b.x, c.x), math.float3(a.y, b.y, c.y));
			}

			public readonly float2 Solve(float y)
			{
				float z = coefficients.z;
				float y2 = coefficients.y;
				float num = coefficients.x - y;
				float num2 = y2 * y2 - 4f * z * num;
				if (num2 < 0f)
				{
					return float.NaN;
				}
				if (num2 == 0f)
				{
					return (0f - y2) / (2f * z);
				}
				return (0f - y2 + math.sign(z) * math.sqrt(num2) * math.float2(-1f, 1f)) / (2f * z);
			}
		}

		public struct Spline
		{
			public enum WrapMode
			{
				Clamp = 0,
				Loop = 1,
				PingPong = 2,
				Extrapolate = 3
			}

			[ReadOnly]
			public NativeSlice<float4> data;

			public bool forceSmooth;

			public WrapMode postWrapMode;

			public WrapMode preWrapMode;

			public float Sample(float x)
			{
				return SampleNoWrap(WrapX(x));
			}

			public float SampleNoWrap(float x)
			{
				int length = data.Length;
				switch (length)
				{
				case 0:
					return 0f;
				case 1:
				{
					float4 float7 = data[0];
					return float7.y + (WrapX(x) - float7.x) * float7.w;
				}
				default:
				{
					int num = math.clamp(BinarySearch(data.Slice().SliceWithStride<float>(0), x), 0, length - 2);
					int index = num + 1;
					float4 float5 = data[num];
					float4 float6 = data[index];
					float w = float5.w;
					float num2 = (forceSmooth ? float6.w : float6.z);
					float num3 = math.unlerp(float5.x, float6.x, x);
					float num4 = 1f - num3;
					float num5 = w * (float6.x - float5.x) - (float6.y - float5.y);
					float num6 = (0f - num2) * (float6.x - float5.x) + (float6.y - float5.y);
					return num4 * float5.y + num3 * float6.y + num3 * num4 * (num4 * num5 + num3 * num6);
				}
				}
			}

			public float WrapX(float x)
			{
				float x2 = data[0].x;
				ref NativeSlice<float4> reference = ref data;
				float x3 = reference[reference.Length - 1].x;
				float num = x3 - x2;
				if (x < x2)
				{
					return preWrapMode switch
					{
						WrapMode.Loop => x3 - math.fmod(x - x2, num), 
						WrapMode.PingPong => Pingpong(x - x2, num), 
						WrapMode.Extrapolate => x, 
						_ => x2, 
					};
				}
				if (x > x3)
				{
					return postWrapMode switch
					{
						WrapMode.Loop => x2 + math.fmod(x - x3, num), 
						WrapMode.PingPong => Pingpong(x - x2, num), 
						WrapMode.Extrapolate => x, 
						_ => x3, 
					};
				}
				return x;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Bezier(float a, float b, float c, float t)
		{
			return math.lerp(math.lerp(a, b, t), math.lerp(b, c, t), t);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 Bezier(float2 a, float2 b, float2 c, float t)
		{
			return math.lerp(math.lerp(a, b, t), math.lerp(b, c, t), t);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Bezier(float a, float b, float c, float d, float t)
		{
			return math.lerp(Bezier(a, b, c, t), Bezier(b, c, d, t), t);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 Bezier(float2 a, float2 b, float2 c, float2 d, float t)
		{
			return math.lerp(Bezier(a, b, c, t), Bezier(b, c, d, t), t);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 Bezier(float3 a, float3 b, float3 c, float t)
		{
			return math.lerp(math.lerp(a, b, t), math.lerp(b, c, t), t);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 Bezier(float3 a, float3 b, float3 c, float3 d, float t)
		{
			return math.lerp(Bezier(a, b, c, t), Bezier(b, c, d, t), t);
		}

		public static int BinarySearch(NativeSlice<float> array, float x)
		{
			if (array.Length == 0)
			{
				return -1;
			}
			if (array.Length == 1)
			{
				if (!(array[0] <= x))
				{
					return -1;
				}
				return 0;
			}
			int num = 0;
			int num2 = array.Length - 1;
			int result = -1;
			while (num <= num2)
			{
				int num3 = num + (num2 - num) / 2;
				if (array[num3] <= x)
				{
					result = num3;
					num = num3 + 1;
				}
				else
				{
					num2 = num3 - 1;
				}
			}
			return result;
		}

		public static float3 ClampMagnitude(float3 vec, float max)
		{
			float num = math.lengthsq(vec);
			if (num > max * max)
			{
				return max * math.rsqrt(num) * vec;
			}
			return vec;
		}

		public static RigidTransform GetTransformInMirroredXSpace(RigidTransform transform)
		{
			transform.pos.x = 0f - transform.pos.x;
			transform.rot.value.yz = -transform.rot.value.yz;
			return transform;
		}

		public static RigidTransform GetTransformInMirroredYSpace(RigidTransform transform)
		{
			transform.pos.y = 0f - transform.pos.y;
			transform.rot.value.xz = -transform.rot.value.xz;
			return transform;
		}

		public static RigidTransform GetTransformInMirroredZSpace(RigidTransform transform)
		{
			transform.pos.z = 0f - transform.pos.z;
			transform.rot.value.xy = -transform.rot.value.xy;
			return transform;
		}

		public static float InverseBezier(float a, float b, float c, float x, float tmin, float tmax)
		{
			float2 float5 = new Quadratic(a, 2f * (b - a), a - 2f * b + c).Solve(x);
			if (float.IsNaN(float5.x))
			{
				return float.NaN;
			}
			if (float5.x >= tmin)
			{
				if (float5.x <= tmax)
				{
					return float5.x;
				}
				return tmax;
			}
			if (float5.y >= tmin)
			{
				return float5.y;
			}
			return tmin;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float Pingpong(float x, float p)
		{
			return math.abs(x - 2f * p * math.floor(0.5f * (1f + x / p)));
		}

		public static float Repeat(float x, float length)
		{
			return math.clamp(x - math.floor(x / length) * length, 0f, length);
		}

		public static RigidTransform RotateAround(this RigidTransform transform, quaternion rotation, float3 around)
		{
			transform.pos -= around;
			transform.pos = math.mul(rotation, transform.pos);
			transform.rot = math.mul(rotation, transform.rot);
			transform.pos += around;
			return transform;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float ScaleAround(float value, float scale, float around)
		{
			return (value - around) * scale + around;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float2 ScaleAround(float2 value, float scale, float2 around)
		{
			return (value - around) * scale + around;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float3 ScaleAround(float3 value, float scale, float3 around)
		{
			return (value - around) * scale + around;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static void ToAngleAxis(this quaternion quat, out float angle, out float3 axis)
		{
			float4 value = quat.value;
			angle = 2f * math.acos(value.w);
			axis = value.xyz * math.rsqrt(1f - value.w * value.w);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static float TrapezoidCentreT(float a, float b, float h)
		{
			return (1f / 3f * a + 2f / 3f * b) / (a + b);
		}

		public static float TrapezoidCentroid(float a, float b, float h, float aPos, float bPos)
		{
			return math.lerp(aPos, bPos, TrapezoidCentreT(a, b, h));
		}

		public static float2 TrapezoidCentroid(float a, float b, float h, float2 aPos, float2 bPos)
		{
			return math.lerp(aPos, bPos, TrapezoidCentreT(a, b, h));
		}

		public static float3 TrapezoidCentroid(float a, float b, float h, float3 aPos, float3 bPos)
		{
			return math.lerp(aPos, bPos, TrapezoidCentreT(a, b, h));
		}

		public static float4 TrapezoidCentroid(float a, float b, float h, float4 aPos, float4 bPos)
		{
			return math.lerp(aPos, bPos, TrapezoidCentreT(a, b, h));
		}

		public static RigidTransform Transform(this RigidTransform parent, RigidTransform child)
		{
			return math.mul(parent, child);
		}

		public static float3 Transform(float4x3 matrix, float2 vector)
		{
			return math.mul(matrix, math.float3(vector, 1f)).xyz;
		}

		public static RigidTransform Inverse(this RigidTransform rt)
		{
			quaternion obj = math.inverse(rt.rot);
			return new RigidTransform(obj, math.mul(obj, -rt.pos));
		}

		public static void RemoveNaN(ref float v)
		{
			v = math.select(v, 0f, math.isnan(v));
		}

		public static void RemoveNaN(ref float2 v)
		{
			v = math.select(v, 0f, math.isnan(v));
		}

		public static void RemoveNaN(ref float3 v)
		{
			v = math.select(v, 0f, math.isnan(v));
		}

		public static void RemoveNaN(ref float4 v)
		{
			v = math.select(v, 0f, math.isnan(v));
		}

		public static void RemoveNaN(ref float3x3 v)
		{
			v.c0 = math.select(v.c0, 0f, math.isnan(v.c0));
			v.c1 = math.select(v.c1, 0f, math.isnan(v.c1));
			v.c2 = math.select(v.c2, 0f, math.isnan(v.c2));
		}

		private static float2 Polynomial2(float x)
		{
			return math.float2(1f, x);
		}

		private static float3 Polynomial3(float x)
		{
			return math.float3(1f, x, x * x);
		}

		private static float4 Polynomial4(float x)
		{
			float4 result = default(float4);
			result.x = 1f;
			result.y = x;
			result.z = x * x;
			result.w = result.z * x;
			return result;
		}
	}
}
