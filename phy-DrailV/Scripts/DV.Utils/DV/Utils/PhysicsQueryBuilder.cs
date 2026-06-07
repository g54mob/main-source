using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DV.Utils
{
	public static class PhysicsQueryBuilder
	{
		public struct QueryResults : IEnumerator<RaycastHitDV>, IEnumerator, IDisposable, IEnumerable<RaycastHitDV>, IEnumerable
		{
			private int length;

			private int current;

			public int Length => length;

			public RaycastHitDV[] UnderlyingArray => hits;

			public RaycastHitDV this[int i]
			{
				get
				{
					if (i < 0 || i >= length)
					{
						throw new IndexOutOfRangeException();
					}
					return hits[i];
				}
			}

			public RaycastHitDV Current => hits[current];

			object IEnumerator.Current => Current;

			public QueryResults(int length)
			{
				this.length = length;
				current = -1;
			}

			public bool TryGetFirst(out RaycastHitDV hit)
			{
				if (length == 0)
				{
					hit = default(RaycastHitDV);
					return false;
				}
				hit = this[0];
				return true;
			}

			public bool MoveNext()
			{
				current++;
				return current < length;
			}

			public QueryResults Where(Predicate<RaycastHitDV> predicate)
			{
				if (predicate == null)
				{
					return this;
				}
				int num = 0;
				int num2 = length;
				for (int i = 0; i < num2; i++)
				{
					RaycastHitDV raycastHitDV = hits[i];
					if (predicate(raycastHitDV))
					{
						hits[i - num] = raycastHitDV;
						continue;
					}
					num++;
					length--;
				}
				return this;
			}

			public void Reset()
			{
				current = -1;
			}

			public void Dispose()
			{
			}

			public IEnumerator<RaycastHitDV> GetEnumerator()
			{
				return this;
			}

			IEnumerator IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}

		private static RaycastHit[] results = new RaycastHit[10];

		private static Collider[] colliders = new Collider[10];

		private static RaycastHitDV[] hits = new RaycastHitDV[10];

		private static SphereCollider hackSphereCollider;

		public static QueryResults SphereCast(Vector3 origin, float radius, Vector3 direction, float distance, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.Ignore)
		{
			int num = Physics.SphereCastNonAlloc(origin, radius, direction, results, distance, layerMask, queryTriggerInteraction);
			if (RaycastUtils.SortDistanceAndExpandCache(ref results, num))
			{
				num = Physics.SphereCastNonAlloc(origin, radius, direction, results, distance, layerMask, queryTriggerInteraction);
				RaycastUtils.SortDistanceAndExpandCache(ref results, num);
			}
			CopyResultsIntoHits(num);
			return new QueryResults(num).Where((RaycastHitDV h) => h.distance != 0f);
		}

		public static QueryResults Raycast(Vector3 origin, Vector3 direction, float distance, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.Ignore)
		{
			if (results == null || results.Length == 0)
			{
				results = new RaycastHit[10];
			}
			int num = Physics.RaycastNonAlloc(origin, direction, results, distance, layerMask, queryTriggerInteraction);
			if (RaycastUtils.SortDistanceAndExpandCache(ref results, num))
			{
				num = Physics.RaycastNonAlloc(origin, direction, results, distance, layerMask, queryTriggerInteraction);
				RaycastUtils.SortDistanceAndExpandCache(ref results, num);
			}
			CopyResultsIntoHits(num);
			return new QueryResults(num);
		}

		public static QueryResults Boxcast(Vector3 center, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float distance, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.Ignore)
		{
			if (results == null || results.Length == 0)
			{
				results = new RaycastHit[10];
			}
			int num = Physics.BoxCastNonAlloc(center, halfExtents, direction, results, orientation, distance, layerMask, queryTriggerInteraction);
			if (RaycastUtils.SortDistanceAndExpandCache(ref results, num))
			{
				num = Physics.BoxCastNonAlloc(center, halfExtents, direction, results, orientation, distance, layerMask, queryTriggerInteraction);
				RaycastUtils.SortDistanceAndExpandCache(ref results, num);
			}
			CopyResultsIntoHits(num);
			return new QueryResults(num).Where((RaycastHitDV h) => h.distance != 0f);
		}

		public static QueryResults OverlapSphere(Vector3 origin, float radius, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.Ignore)
		{
			if (colliders == null || colliders.Length == 0)
			{
				colliders = new Collider[10];
			}
			int num = Physics.OverlapSphereNonAlloc(origin, radius, colliders, layerMask, queryTriggerInteraction);
			if (RaycastUtils.ExtendOnCacheFull(ref colliders, num))
			{
				num = Physics.OverlapSphereNonAlloc(origin, radius, colliders, layerMask, queryTriggerInteraction);
				RaycastUtils.SortDistanceAndExpandCache(ref results, num);
			}
			if (hackSphereCollider == null)
			{
				hackSphereCollider = new GameObject("Hack sphere collider (ignore)").AddComponent<SphereCollider>();
				hackSphereCollider.gameObject.SetActive(value: false);
			}
			RaycastUtils.ExtendOnCacheFull(ref hits, num);
			for (int i = 0; i < num; i++)
			{
				Collider collider = colliders[i];
				Vector3 vector;
				if (collider is MeshCollider)
				{
					hackSphereCollider.radius = radius;
					hackSphereCollider.gameObject.SetActive(value: true);
					int layer = collider.gameObject.layer;
					collider.gameObject.layer = hackSphereCollider.gameObject.layer;
					vector = ((!Physics.ComputePenetration(collider, collider.transform.position, collider.transform.rotation, hackSphereCollider, origin, Quaternion.identity, out var direction, out var distance)) ? origin : (origin + direction * (distance + radius)));
					hackSphereCollider.gameObject.SetActive(value: false);
					collider.gameObject.layer = layer;
				}
				else
				{
					vector = collider.ClosestPoint(origin);
				}
				hits[i] = new RaycastHitDV(collider, vector, Vector3.Normalize(origin - vector), Vector3.Distance(origin, vector));
			}
			return new QueryResults(num);
		}

		public static QueryResults OverlapBox(Vector3 origin, Vector3 halfExtents, Quaternion rotation, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.Ignore)
		{
			if (colliders == null || colliders.Length == 0)
			{
				colliders = new Collider[10];
			}
			int num = Physics.OverlapBoxNonAlloc(origin, halfExtents, colliders, rotation, layerMask, queryTriggerInteraction);
			if (RaycastUtils.ExtendOnCacheFull(ref colliders, num))
			{
				num = Physics.OverlapBoxNonAlloc(origin, halfExtents, colliders, rotation, layerMask, queryTriggerInteraction);
				RaycastUtils.SortDistanceAndExpandCache(ref results, num);
			}
			CopyCollidersIntoHits(origin, num);
			return new QueryResults(num);
		}

		public static QueryResults OverlapCapsule(Vector3 point1, Vector3 point2, float radius, LayerMask layerMask, QueryTriggerInteraction queryTriggerInteraction = QueryTriggerInteraction.Ignore)
		{
			if (colliders == null || colliders.Length == 0)
			{
				colliders = new Collider[10];
			}
			int num = Physics.OverlapCapsuleNonAlloc(point1, point2, radius, colliders, layerMask, queryTriggerInteraction);
			if (RaycastUtils.ExtendOnCacheFull(ref colliders, num))
			{
				num = Physics.OverlapCapsuleNonAlloc(point1, point2, radius, colliders, layerMask, queryTriggerInteraction);
				RaycastUtils.SortDistanceAndExpandCache(ref results, num);
			}
			CopyCollidersIntoHits((point1 + point2) / 2f, num);
			return new QueryResults(num);
		}

		private static void CopyResultsIntoHits(int hitCount)
		{
			RaycastUtils.ExtendOnCacheFull(ref hits, hitCount);
			for (int i = 0; i < hitCount; i++)
			{
				hits[i] = new RaycastHitDV(results[i]);
			}
		}

		private static void CopyCollidersIntoHits(Vector3 origin, int hitCount)
		{
			RaycastUtils.ExtendOnCacheFull(ref hits, hitCount);
			for (int i = 0; i < hitCount; i++)
			{
				Collider collider = colliders[i];
				if (collider is MeshCollider meshCollider && !meshCollider.convex)
				{
					hits[i] = new RaycastHitDV(collider, origin, default(Vector3), 0f);
					continue;
				}
				Vector3 vector = collider.ClosestPoint(origin);
				hits[i] = new RaycastHitDV(collider, vector, Vector3.Normalize(origin - vector), Vector3.Distance(origin, vector));
			}
		}
	}
}
