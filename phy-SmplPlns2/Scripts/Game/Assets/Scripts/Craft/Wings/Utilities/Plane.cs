using Unity.Mathematics;

namespace Assets.Scripts.Craft.Wings.Utilities
{
	public struct Plane
	{
		public float3 normal;

		public float value;

		public Plane(float3 normal, float value)
		{
			float num = math.length(normal);
			this.normal = normal / num;
			this.value = value * num;
		}

		public Plane(float3 normal, float3 point)
		{
			this.normal = math.normalize(normal);
			value = math.dot(point, this.normal);
		}

		public Plane(float3 a, float3 b, float3 c)
			: this(math.cross(b - a, c - a), a)
		{
		}

		public readonly float Distance(float3 pos)
		{
			return math.dot(pos, normal) - value;
		}

		public readonly bool IsAbove(float3 pos)
		{
			return math.dot(pos, normal) > value;
		}

		public readonly float3 Project(float3 pos)
		{
			return pos + (value - math.dot(pos, normal)) * normal;
		}

		public readonly bool Raycast(float3 rayOrigin, float3 rayVector, out float t)
		{
			float num = math.dot(rayOrigin, normal) - value;
			float num2 = 0f - math.dot(rayVector, normal);
			if (math.abs(num2) < 1.1920929E-07f)
			{
				t = 0f;
				return false;
			}
			t = num / num2;
			return t >= 0f;
		}
	}
}
