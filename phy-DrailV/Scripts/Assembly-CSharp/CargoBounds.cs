using UnityEngine;

public class CargoBounds : MonoBehaviour
{
	public Vector3 center;

	public Vector3 size;

	private void OnDrawGizmos()
	{
		if (!Application.isPlaying)
		{
			Gizmos.color = Color.green;
			Gizmos.matrix = base.transform.localToWorldMatrix;
			Gizmos.DrawCube(center, size);
		}
	}
}
