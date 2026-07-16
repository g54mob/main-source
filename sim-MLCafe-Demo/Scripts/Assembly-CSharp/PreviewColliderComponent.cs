using UnityEngine;

public class PreviewColliderComponent : MonoBehaviour
{
	public Vector3 center;

	public Vector3 size;

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireCube(center, size);
	}
}
