using System;
using System.Collections.Generic;
using Gh.Tk;
using UnityEngine;

namespace Gh
{
	public static class RaycastObject
	{
		public static float DefaultMaxDistance;

		private static RaycastHit[] _hits;

		private static float _distance;

		public static GameObject RaycastNonAllocEntity(int world)
		{
			return null;
		}

		public static GameObject RaycastNonAlloc(LayerMask layerMask, bool includeTriggerCollider)
		{
			return null;
		}

		public static RaycastHit? RaycastNonAllocWithHit(LayerMask layerMask, bool includeTriggerCollider)
		{
			return null;
		}

		public static RaycastHit? RaycastNonAlloc(Camera camera, LayerMask layerMask, bool includeTriggerCollider, string[] tagsToExclude = null, IEnumerable<Collider> collidersToExclude = null, Vector2? mousePosition = null, Func<RaycastHit, bool> filter = null)
		{
			return null;
		}

		public static RaycastHit? RaycastNonAlloc(Vector3 start, Vector3 end, LayerMask layerMask, GameObjectX filterGox, Transform filterTransform = null)
		{
			return null;
		}
	}
}
