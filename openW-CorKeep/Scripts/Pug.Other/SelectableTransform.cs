using UnityEngine;

public class SelectableTransform : MonoBehaviour
{
	[Min(0f)]
	public float size = 0.5f;

	public bool showBasis;

	private void OnDrawGizmos()
	{
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.color = Color.yellow;
		Gizmos.DrawCube(Vector3.zero, Vector3.one * size * 0.25f);
		if (showBasis)
		{
			Gizmos.color = Color.red;
			Gizmos.DrawLine(Vector3.zero, Vector3.right * size);
			Gizmos.color = Color.green;
			Gizmos.DrawLine(Vector3.zero, Vector3.up * size);
			Gizmos.color = Color.blue;
			Gizmos.DrawLine(Vector3.zero, Vector3.forward * size);
		}
	}
}
