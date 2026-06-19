using UnityEngine;

public class BlobShadowDecal : MonoBehaviour
{
	[SerializeField]
	private Material _material;

	public Material Material => _material;

	private void DrawGizmo(bool selected)
	{
		Color color = new Color(0.70980394f, 0.11372549f, 1f, 1f);
		color.a = (selected ? 0.3f : 0.1f);
		Gizmos.color = color;
		Gizmos.matrix = base.transform.localToWorldMatrix;
		Gizmos.DrawCube(Vector3.zero, Vector3.one);
		color.a = (selected ? 0.5f : 0.2f);
		Gizmos.color = color;
		Gizmos.DrawWireCube(Vector3.zero, Vector3.one);
	}

	public void OnDrawGizmos()
	{
		DrawGizmo(selected: false);
	}

	public void OnDrawGizmosSelected()
	{
		DrawGizmo(selected: true);
	}
}
