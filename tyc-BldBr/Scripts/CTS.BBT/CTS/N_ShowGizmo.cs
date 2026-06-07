using System.Collections.Generic;
using UnityEngine;

namespace CTS
{
	public class N_ShowGizmo : MonoBehaviour
	{
		public Mesh meshGizmo;

		public float scale;

		public Color c;

		private void OnDrawGizmos()
		{
			Gizmos.color = c;
			Gizmos.DrawWireMesh(meshGizmo, 0, base.transform.position, base.transform.rotation, new Vector3(scale, scale, scale));
		}

		private void OnDrawGizmosSelected()
		{
			Bounds bounds = new Bounds(base.transform.position, Vector3.zero);
			List<Renderer> list = new List<Renderer>();
			list.AddRange(GetComponentsInChildren<Renderer>());
			if (list.Count > 0)
			{
				foreach (Renderer item in list)
				{
					bounds.Encapsulate(item.bounds);
				}
			}
			Gizmos.DrawWireCube(new Vector3(bounds.center.x, 0f, bounds.center.z), new Vector3(bounds.size.x, 0.01f, bounds.size.z));
		}
	}
}
