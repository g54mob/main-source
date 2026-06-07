using UnityEngine;

namespace RLD
{
	public class MeshRayHit
	{
		private int _hitTriangleIndex;

		private Vector3 _hitPoint;

		private float _hitEnter;

		private Vector3 _hitNormal;

		public int HitTriangleIndex => _hitTriangleIndex;

		public Vector3 HitPoint => _hitPoint;

		public float HitEnter => _hitEnter;

		public Vector3 HitNormal => _hitNormal;

		public MeshRayHit(Ray ray, int hitTriangleIndex, float hitEnter, Vector3 hitNormal)
		{
			_hitTriangleIndex = hitTriangleIndex;
			_hitPoint = ray.GetPoint(hitEnter);
			_hitEnter = hitEnter;
			_hitNormal = Vector3.Normalize(hitNormal);
		}
	}
}
