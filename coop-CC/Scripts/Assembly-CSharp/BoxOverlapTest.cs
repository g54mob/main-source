using UnityEngine;

public class BoxOverlapTest : MonoBehaviour
{
	public BoxCollider boxCollider;

	public LayerMask layerMask;

	public Material material;

	private void Update()
	{
		Vector3 center = base.transform.TransformPoint(boxCollider.center);
		Vector3 halfExtents = boxCollider.size / 2f;
		if (Physics.OverlapBox(center, halfExtents, base.transform.rotation, layerMask).Length > 1)
		{
			material.color = Color.green;
		}
		else
		{
			material.color = Color.red;
		}
	}
}
