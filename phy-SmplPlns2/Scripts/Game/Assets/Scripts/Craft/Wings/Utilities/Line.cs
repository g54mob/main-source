using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Utilities
{
	public struct Line
	{
		public float2 normal;

		public float value;

		public Line(float2 normal, float value)
		{
			float num = math.length(normal);
			this.normal = normal / num;
			this.value = value * num;
		}

		public Line(float2 normal, float2 point)
		{
			this.normal = math.normalize(normal);
			value = math.dot(point, this.normal);
		}

		public static Line FromPoints(float2 a, float2 b)
		{
			return new Line((a - b).yx * math.float2(-1f, 1f), a);
		}

		public readonly float Distance(float2 pos)
		{
			return math.dot(pos, normal) - value;
		}

		public readonly bool IsAbove(float2 pos)
		{
			return math.dot(pos, normal) > value;
		}

		public readonly float2 Project(float2 pos)
		{
			return pos + (value - math.dot(pos, normal)) * normal;
		}
	}
}
