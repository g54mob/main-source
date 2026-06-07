using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class NormalsDebugDisplay : MonoBehaviour
{
	private MeshFilter meshFilter;

	public float normalScale = 1f;

	public void OnDrawGizmos()
	{
		if (meshFilter == null)
		{
			meshFilter = GetComponent<MeshFilter>();
			if (meshFilter == null)
			{
				return;
			}
		}
		for (int i = 0; i < meshFilter.sharedMesh.vertices.Length; i++)
		{
			Gizmos.color = Color.blue;
			Vector3 vector = base.transform.TransformPoint(meshFilter.sharedMesh.vertices[i]);
			Vector3 to = base.transform.TransformVector(meshFilter.sharedMesh.normals[i]) * normalScale + vector;
			Gizmos.DrawLine(vector, to);
		}
	}
}
