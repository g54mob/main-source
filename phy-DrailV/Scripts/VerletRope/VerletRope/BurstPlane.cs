using Unity.Mathematics;

namespace VerletRope
{
	public readonly struct BurstPlane
	{
		public readonly float3 normal;

		public readonly float distance;

		public BurstPlane(float3 a, float3 b, float3 c)
		{
			normal = math.normalize(math.cross(b - a, c - a));
			distance = 0f - math.dot(normal, a);
		}

		public bool GetSide(float3 point)
		{
			return math.dot(normal, point) + distance > 0f;
		}
	}
}
