using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class CollisionDetectorBounds : MonoBehaviour
	{
		public static List<CollisionDetectorBounds> AllBounds;

		public Vector3 size;

		public Vector3 offset;

		public Bounds Bounds => default(Bounds);

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDrawGizmos()
		{
		}

		public IEnumerable<GameObject> GetCollidingObjects()
		{
			return null;
		}

		public IEnumerable<GameObject> GetCollidingObjects(LayerMask layers)
		{
			return null;
		}
	}
}
