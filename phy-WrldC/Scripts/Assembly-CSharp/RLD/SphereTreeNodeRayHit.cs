using UnityEngine;

namespace RLD
{
	public class SphereTreeNodeRayHit<T>
	{
		private SphereTreeNode<T> _hitNode;

		private Vector3 _hitPoint;

		private float _hitEnter;

		public SphereTreeNode<T> HitNode => _hitNode;

		public Vector3 HitPoint => _hitPoint;

		public float HitEnter => _hitEnter;

		public SphereTreeNodeRayHit(Ray ray, SphereTreeNode<T> hitNode, float hitEnter)
		{
			_hitNode = hitNode;
			_hitEnter = hitEnter;
			_hitPoint = ray.GetPoint(_hitEnter);
		}
	}
}
