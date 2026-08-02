using UnityEngine;

namespace Rowlan.Yapp
{
	public class BoundsUtils
	{
		private static Bounds zeroBounds = new Bounds(Vector3.zero, Vector3.zero);

		public static bool GetBounds(Transform transform, out Bounds localBounds, out Bounds worldBounds)
		{
			MeshFilter component = transform.GetComponent<MeshFilter>();
			MeshRenderer component2 = transform.GetComponent<MeshRenderer>();
			if ((bool)component && (bool)component2)
			{
				localBounds = component.sharedMesh.bounds;
				worldBounds = component2.bounds;
				return true;
			}
			SkinnedMeshRenderer component3 = transform.GetComponent<SkinnedMeshRenderer>();
			if ((bool)component3)
			{
				localBounds = component3.sharedMesh.bounds;
				worldBounds = component3.bounds;
				return true;
			}
			localBounds = zeroBounds;
			worldBounds = zeroBounds;
			return false;
		}

		public static Bounds CalculateBounds(GameObject gameObject)
		{
			Bounds result = new Bounds(gameObject.transform.position, Vector3.zero);
			Renderer[] componentsInChildren = gameObject.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				if (renderer is SkinnedMeshRenderer)
				{
					SkinnedMeshRenderer skinnedMeshRenderer = renderer as SkinnedMeshRenderer;
					Mesh mesh = new Mesh();
					skinnedMeshRenderer.BakeMesh(mesh);
					Vector3[] vertices = mesh.vertices;
					for (int j = 0; j <= vertices.Length - 1; j++)
					{
						vertices[j] = skinnedMeshRenderer.transform.TransformPoint(vertices[j]);
					}
					mesh.vertices = vertices;
					mesh.RecalculateBounds();
					Bounds bounds = mesh.bounds;
					result.Encapsulate(bounds);
				}
				else
				{
					result.Encapsulate(renderer.bounds);
				}
			}
			return result;
		}
	}
}
