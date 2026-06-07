using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(BoxCollider))]
public class VisibleCollider : MonoBehaviour
{
	public Color color = Color.blue;

	private BoxCollider boxCollider;

	private void Awake()
	{
		boxCollider = GetComponent<BoxCollider>();
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = color;
		Gizmos.DrawWireCube(base.transform.position, boxCollider.bounds.size);
	}
}
