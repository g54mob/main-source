using System.Collections.Generic;
using UnityEngine;

public class KillOnTouch : MonoBehaviour
{
	public LayerMask layerMask;

	public BoxCollider boxCollider;

	public TagManager.ETag mustHaveTag;

	private void Update()
	{
		Vector3 center = boxCollider.bounds.center;
		Vector3 size = boxCollider.bounds.size;
		foreach (Collider item in new List<Collider>(Physics.OverlapBox(orientation: base.transform.rotation, center: center, halfExtents: size / 2f, layerMask: layerMask)))
		{
			TaggedObject componentInParent = item.GetComponentInParent<TaggedObject>();
			if (componentInParent != null && componentInParent.Tags.Contains(mustHaveTag))
			{
				componentInParent.Hp.TakeDamage(1E+13f);
			}
		}
	}
}
