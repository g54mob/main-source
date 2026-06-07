using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public class GameObjectRayHit
	{
		private GameObject _hitObject;

		private Vector3 _hitPoint;

		private float _hitEnter;

		private Vector3 _hitNormal;

		private Plane _hitPlane;

		private MeshRayHit _meshRayHit;

		public GameObject HitObject => _hitObject;

		public Vector3 HitPoint => _hitPoint;

		public float HitEnter => _hitEnter;

		public Vector3 HitNormal => _hitNormal;

		public Plane HitPlane => _hitPlane;

		public MeshRayHit MeshRayHit => _meshRayHit;

		public static void SortByHitDistance(List<GameObjectRayHit> hits)
		{
			hits.Sort((GameObjectRayHit h0, GameObjectRayHit h1) => h0.HitEnter.CompareTo(h1.HitEnter));
		}

		public static List<GameObjectRayHit> Create(Ray hitRay, IEnumerable<RaycastHit> hits3D)
		{
			List<GameObjectRayHit> list = new List<GameObjectRayHit>(10);
			foreach (RaycastHit item in hits3D)
			{
				list.Add(new GameObjectRayHit(hitRay, item));
			}
			return list;
		}

		public static List<GameObjectRayHit> Create(Ray hitRay, IEnumerable<RaycastHit2D> hits2D)
		{
			List<GameObjectRayHit> list = new List<GameObjectRayHit>(10);
			foreach (RaycastHit2D item in hits2D)
			{
				list.Add(new GameObjectRayHit(hitRay, item));
			}
			return list;
		}

		public GameObjectRayHit(Ray hitRay, RaycastHit hit3D)
		{
			_hitObject = hit3D.collider.gameObject;
			_hitPoint = hit3D.point;
			_hitEnter = hit3D.distance;
			_hitNormal = hit3D.normal;
			_hitPlane = new Plane(_hitNormal, _hitPoint);
		}

		public GameObjectRayHit(Ray hitRay, RaycastHit2D hit2D)
		{
			_hitObject = hit2D.collider.gameObject;
			_hitPoint = hit2D.point;
			_hitEnter = hit2D.distance;
			_hitNormal = hit2D.normal;
			_hitPlane = new Plane(_hitNormal, _hitPoint);
		}

		public GameObjectRayHit(Ray hitRay, GameObject hitObject, Vector3 hitNormal, float hitEnter)
		{
			_hitObject = hitObject;
			_hitPoint = hitRay.GetPoint(hitEnter);
			_hitEnter = hitEnter;
			_hitNormal = hitNormal;
			_hitPlane = new Plane(_hitNormal, _hitPoint);
		}

		public GameObjectRayHit(Ray ray, GameObject hitObject, MeshRayHit meshRayHit)
		{
			_hitObject = hitObject;
			_hitPoint = meshRayHit.HitPoint;
			_hitEnter = meshRayHit.HitEnter;
			_hitNormal = meshRayHit.HitNormal;
			_hitPlane = new Plane(_hitNormal, _hitPoint);
			_meshRayHit = meshRayHit;
		}
	}
}
