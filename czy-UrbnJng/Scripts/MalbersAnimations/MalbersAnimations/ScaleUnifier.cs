using UnityEngine;

namespace MalbersAnimations
{
	[ExecuteInEditMode]
	public class ScaleUnifier : MonoBehaviour
	{
		[Tooltip("Name of the New Mesh")]
		public string meshName = "NewMesh";

		[Tooltip("Folder path in which the new mesh will be saved")]
		public string folderPath = "Assets/";

		public void UnifyScale()
		{
			if (!TryGetComponent<MeshFilter>(out var component))
			{
				Debug.LogError("MeshFilter component not found.");
				return;
			}
			Mesh sharedMesh = component.sharedMesh;
			if (sharedMesh == null)
			{
				Debug.LogError("Original mesh not found.");
				return;
			}
			Mesh mesh = DuplicateMesh(sharedMesh);
			Vector3[] vertices = mesh.vertices;
			Vector3 localScale = base.transform.localScale;
			for (int i = 0; i < vertices.Length; i++)
			{
				vertices[i] = Vector3.Scale(vertices[i], localScale);
			}
			mesh.vertices = vertices;
			mesh.RecalculateBounds();
			mesh.RecalculateNormals();
			component.sharedMesh = mesh;
			base.transform.localScale = Vector3.one;
			Debug.LogWarning(base.gameObject.name + ": <color=orange>Check the collider and reset or modify if needed.</color>", this);
		}

		private Mesh DuplicateMesh(Mesh originalMesh)
		{
			return new Mesh
			{
				vertices = originalMesh.vertices,
				normals = originalMesh.normals,
				uv = originalMesh.uv,
				triangles = originalMesh.triangles,
				colors = originalMesh.colors,
				tangents = originalMesh.tangents,
				uv2 = originalMesh.uv2,
				uv3 = originalMesh.uv3,
				uv4 = originalMesh.uv4,
				bindposes = originalMesh.bindposes,
				boneWeights = originalMesh.boneWeights
			};
		}
	}
}
