using System.Runtime.CompilerServices;
using Unity.Mathematics;

namespace Pug.UnityExtensions
{
	public static class PugGeometry
	{
		public struct AxisAlignedBoundingBox
		{
			public float2 Low;

			public float2 High;

			public readonly float2 Size => High - Low;

			public readonly float2 Center => (Low + High) * 0.5f;

			public AxisAlignedBoundingBox(float2 position1, float2 position2)
			{
				Low = math.min(position1, position2);
				High = math.max(position1, position2);
			}

			public static AxisAlignedBoundingBox FromLowerCornerAndSize(float2 bottomLeft, float2 size)
			{
				return new AxisAlignedBoundingBox(bottomLeft, bottomLeft + size);
			}

			public static AxisAlignedBoundingBox FromCenterAndRadius(float2 center, float radius)
			{
				return new AxisAlignedBoundingBox(center - radius, center + radius);
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public readonly bool Contains(float2 position)
			{
				return math.all((position >= Low) & (position <= High));
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public static bool Overlaps(AxisAlignedBoundingBox a, AxisAlignedBoundingBox b)
			{
				if (a.Low.x <= b.High.x && a.High.x >= b.Low.x && a.Low.y <= b.High.y)
				{
					return a.High.y >= b.Low.y;
				}
				return false;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public readonly bool Overlaps(AxisAlignedBoundingBox other)
			{
				return Overlaps(this, other);
			}

			public readonly float DistanceToPoint(float2 position)
			{
				float2 float5 = Size * 0.5f;
				float2 float6 = Low + float5;
				float2 float7 = math.abs(position - float6);
				float2 float8 = float7 - float5;
				if (math.all(float8 > 0f))
				{
					return math.distance(float7, float5);
				}
				if (float8.x > float8.y)
				{
					return float8.x;
				}
				return float8.y;
			}
		}

		public struct CircleBand
		{
			public float2 Center;

			public float Radius;

			public float Width;

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public readonly bool Overlaps(float2 point)
			{
				float num = math.distance(Center, point);
				if (num <= Radius + Width)
				{
					return num >= Radius - Width;
				}
				return false;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public readonly float DistanceToPoint(float2 point)
			{
				return math.abs(math.distance(Center, point) - Radius) - Width;
			}
		}

		public struct Circle
		{
			public float2 Center;

			public float Radius;

			public float RadiusSq;

			public static Circle FromCenterRadius(float2 center, float radius)
			{
				return new Circle
				{
					Center = center,
					Radius = radius,
					RadiusSq = radius * radius
				};
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public readonly bool Contains(float2 point)
			{
				return math.distancesq(Center, point) <= RadiusSq;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			public readonly bool Overlaps(AxisAlignedBoundingBox aabb)
			{
				float2 float5 = aabb.Size * 0.5f;
				float2 float6 = aabb.Low + float5;
				float2 float7 = math.abs(Center - float6);
				if (math.any(float7 > Radius + float5))
				{
					return false;
				}
				if (math.any(float7 <= float5))
				{
					return true;
				}
				if (math.distancesq(float7, float5) <= RadiusSq)
				{
					return true;
				}
				return false;
			}
		}
	}
}
