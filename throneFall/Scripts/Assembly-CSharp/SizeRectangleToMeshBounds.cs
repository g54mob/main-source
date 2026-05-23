using Shapes;
using UnityEngine;

[RequireComponent(typeof(Rectangle))]
public class SizeRectangleToMeshBounds : MonoBehaviour
{
	public float xMargin = 1f;

	public float yMargin = 1f;

	public MeshFilter meshFilter;

	[ContextMenu("RESIZE")]
	private void OnEnable()
	{
		Rectangle component = GetComponent<Rectangle>();
		component.Height = meshFilter.sharedMesh.bounds.size.y + 2f * yMargin;
		component.Width = meshFilter.sharedMesh.bounds.size.x + 2f * xMargin;
	}
}
