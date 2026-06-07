using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class MeshDrawer : MonoBehaviour
{
	private void OnDrawGizmos()
	{
		MeshFilter component = GetComponent<MeshFilter>();
		if (component == null)
		{
			return;
		}
		Mesh sharedMesh = component.sharedMesh;
		Gizmos.color = Color.green;
		if (!(sharedMesh == null))
		{
			for (int i = 0; i < sharedMesh.vertexCount; i += 10)
			{
				Gizmos.DrawSphere(base.transform.position + sharedMesh.vertices[i], 2f);
			}
		}
	}
}
