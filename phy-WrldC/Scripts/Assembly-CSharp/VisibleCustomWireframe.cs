using UnityEngine;

public class VisibleCustomWireframe : MonoBehaviour
{
	[SerializeField]
	private Color color = Color.gray;

	private Vector3 wireframeSize;

	public void SetWireframeSize(Vector3 size)
	{
		wireframeSize = size;
	}

	private void OnDrawGizmos()
	{
		_ = wireframeSize;
		Gizmos.color = color;
		Gizmos.DrawWireCube(base.transform.position, wireframeSize);
	}
}
