using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	public static class ObjectSnap
	{
		public static void Snap(GameObject root, Vector3 pivot, Vector3 dest)
		{
			Transform transform = root.transform;
			Vector3 vector = transform.position - pivot;
			transform.position = dest + vector;
		}

		public static void Snap(List<GameObject> roots, Vector3 pivot, Vector3 dest)
		{
			foreach (GameObject root in roots)
			{
				Snap(root, pivot, dest);
			}
		}
	}
}
