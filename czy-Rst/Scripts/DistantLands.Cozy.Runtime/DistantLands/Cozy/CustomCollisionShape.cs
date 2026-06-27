using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DistantLands.Cozy
{
	[ExecuteAlways]
	public class CustomCollisionShape : MonoBehaviour
	{
		public MeshCollider trigger;

		public Color displayColor = new Color(1f, 1f, 1f, 1f);

		public List<Vector3> bounds = new List<Vector3>
		{
			new Vector3(-5f, 0f, 5f),
			new Vector3(5f, 0f, 5f),
			new Vector3(5f, 0f, -5f),
			new Vector3(-5f, 0f, -5f)
		};

		public float height = 10f;

		private void OnEnable()
		{
			if (!trigger)
			{
				CheckTrigger();
			}
		}

		private void OnDisable()
		{
			if (trigger.gameObject.activeInHierarchy)
			{
				Object.DestroyImmediate(trigger);
			}
		}

		public void CheckTrigger()
		{
			trigger = base.gameObject.AddComponent<MeshCollider>();
			trigger.sharedMesh = BuildZoneCollider();
			trigger.convex = true;
			trigger.isTrigger = true;
		}

		public Mesh BuildZoneCollider()
		{
			Mesh mesh = new Mesh();
			mesh.name = base.name + " Custom Trigger Mesh";
			List<Vector3> list = new List<Vector3>();
			List<int> list2 = new List<int>();
			foreach (Vector3 bound in bounds)
			{
				list.Add(bound);
				list.Add(new Vector3(bound.x, height, bound.z));
			}
			for (int i = 0; i < bounds.Count; i++)
			{
				if (i == 0)
				{
					list2.Add(0);
					list2.Add(list.Count - 1);
					list2.Add(list.Count - 2);
					list2.Add(0);
					list2.Add(1);
					list2.Add(list.Count - 1);
				}
				else
				{
					int num = i * 2;
					list2.Add(num);
					list2.Add(num - 1);
					list2.Add(num - 2);
					list2.Add(num);
					list2.Add(num + 1);
					list2.Add(num - 1);
				}
			}
			for (int j = 0; j < list.Count - 4; j += 2)
			{
				list2.Add(0);
				list2.Add(j + 2);
				list2.Add(j + 4);
				list2.Add(1);
				list2.Add(j + 3);
				list2.Add(j + 5);
			}
			mesh.SetVertices(list);
			mesh.SetTriangles(list2, 0, calculateBounds: true);
			mesh.RecalculateNormals();
			return mesh;
		}

		private void OnDrawGizmos()
		{
			if ((bool)trigger && bounds.Count >= 3)
			{
				for (int i = 0; i < bounds.Count; i++)
				{
					Gizmos.color = new Color(displayColor.r, displayColor.g, displayColor.b, 0.3f);
					Gizmos.DrawSphere(TransformToLocalSpace(bounds[i]), 0.2f);
					Vector3 zero = Vector3.zero;
					zero = ((i != 0) ? bounds[i - 1] : bounds.Last());
					Gizmos.color = new Color(displayColor.r, displayColor.g, displayColor.b, 1f);
					Gizmos.DrawLine(TransformToLocalSpace(bounds[i]), TransformToLocalSpace(zero));
				}
				for (int j = 0; j < bounds.Count; j++)
				{
					Gizmos.color = new Color(displayColor.r, displayColor.g, displayColor.b, 0.5f);
					Gizmos.DrawSphere(TransformToLocalSpace(bounds[j]) + Vector3.up * height, 0.2f);
					Vector3 zero2 = Vector3.zero;
					zero2 = ((j != 0) ? bounds[j - 1] : bounds.Last());
					Gizmos.color = new Color(displayColor.r, displayColor.g, displayColor.b, 1f);
					Gizmos.DrawLine(TransformToLocalSpace(bounds[j]) + Vector3.up * height, TransformToLocalSpace(zero2) + Vector3.up * height);
					Gizmos.DrawLine(TransformToLocalSpace(bounds[j]), TransformToLocalSpace(bounds[j]) + Vector3.up * height);
					Gizmos.color = new Color(displayColor.r, displayColor.g, displayColor.b, 0.3f);
					Gizmos.DrawLine((TransformToLocalSpace(bounds[j]) + TransformToLocalSpace(zero2)) / 2f, (TransformToLocalSpace(bounds[j]) + TransformToLocalSpace(zero2)) / 2f + Vector3.up * height);
				}
				Gizmos.DrawMesh(trigger.sharedMesh, -1, base.transform.position, Quaternion.identity, Vector3.one);
			}
		}

		private Vector3 TransformToLocalSpace(Vector3 pos)
		{
			return pos.x * base.transform.right + pos.y * base.transform.up + pos.z * base.transform.forward + base.transform.position;
		}
	}
}
