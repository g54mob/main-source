using Unity.Mathematics;
using UnityEngine;

namespace VerletRope
{
	public struct BurstBounds
	{
		private float3 center;

		private float3 extents;

		public float3 min => center - extents;

		public float3 max => center + extents;

		public BurstBounds(float3 center, float3 size)
		{
			this.center = center;
			extents = size * 0.5f;
		}

		public BurstBounds(float3 center)
		{
			this.center = center;
			extents = float3.zero;
		}

		public void Encapsulate(float3 point)
		{
			float3 float5 = math.min(min, point);
			float3 float6 = math.max(max, point);
			extents = (float6 - float5) * 0.5f;
			center = float5 + extents;
		}

		public void Encapsulate(BurstBounds bounds)
		{
			Encapsulate(bounds.center - bounds.extents);
			Encapsulate(bounds.center + bounds.extents);
		}

		public void Expand(float3 amount)
		{
			extents += amount * 0.5f;
		}

		public void Expand(float amount)
		{
			amount *= 0.5f;
			extents += new float3(amount, amount, amount);
		}

		public static implicit operator Bounds(BurstBounds bounds)
		{
			Bounds result = new Bounds(bounds.center, Vector3.zero);
			result.extents = bounds.extents;
			return result;
		}
	}
}
