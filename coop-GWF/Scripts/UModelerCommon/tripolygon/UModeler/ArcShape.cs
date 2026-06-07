using System.Collections.Generic;
using UnityEngine;

namespace tripolygon.UModeler
{
	public class ArcShape
	{
		public Vector3 center;

		public Vector3 normal;

		public Vector3 from;

		public float angle;

		public float radius;

		public int segment_count;

		public Quaternion rot;

		private List<Vector2> arcPoints_;

		public PlaneEx plane => new PlaneEx(normal, center);

		public ArcShape Clone()
		{
			return new ArcShape
			{
				center = center,
				normal = normal,
				from = from,
				angle = angle,
				radius = radius,
				segment_count = segment_count,
				rot = rot
			};
		}

		public void Invalidate()
		{
			arcPoints_ = null;
		}

		public bool Raycast(Ray ray, out float t, float hit_width = 0.02f)
		{
			return RayHit(ray.origin, ray.direction, out t, hit_width);
		}

		public bool RayHit(Vector3 origin, Vector3 dir, out float t, float hit_width = 0.02f)
		{
			t = 0f;
			if (arcPoints_ == null)
			{
				MathUtil.CreatePointsOnArc(this, out arcPoints_);
			}
			PlaneEx planeEx = plane;
			for (int i = 0; i < arcPoints_.Count - 1; i++)
			{
				if (new Edge(planeEx.FromPlaneCoord(arcPoints_[i]), planeEx.FromPlaneCoord(arcPoints_[i + 1])).RayHit(origin, dir, out t, hit_width))
				{
					return true;
				}
			}
			return false;
		}

		public float CalculateAngle(Vector3 pos, Vector3 from)
		{
			return 57.29578f * MathUtil.ComputeAngleOnDisc(plane.ToPlaneCoord((pos - center).normalized), plane.ToPlaneCoord(from).normalized);
		}
	}
}
