using UnityEngine;

namespace RLD
{
	public class XZGridRayHit
	{
		private XZGridCell _hitCell;

		private Vector3 _hitPoint;

		private float _hitEnter;

		private Vector3 _hitNormal;

		private Plane _hitPlane;

		public XZGridCell HitCell => _hitCell;

		public Vector3 HitPoint => _hitPoint;

		public float HitEnter => _hitEnter;

		public Vector3 HitNormal => _hitNormal;

		public Plane HitPlane => _hitPlane;

		public XZGridRayHit(Ray ray, XZGridCell hitCell, float hitEnter)
		{
			_hitCell = hitCell;
			_hitEnter = hitEnter;
			_hitPoint = ray.GetPoint(hitEnter);
			_hitPlane = hitCell.ParentGrid.WorldPlane;
			_hitNormal = _hitPlane.normal;
		}
	}
}
