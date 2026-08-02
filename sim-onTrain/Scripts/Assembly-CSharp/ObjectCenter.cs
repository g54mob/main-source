using UnityEngine;

public class ObjectCenter : MonoBehaviour
{
	public GrabbableObject grabbableObject;

	public BoxCollider coll;

	private static readonly Collider[] hitCollidersBuffer = new Collider[32];

	public bool isRoof;

	public bool IsRemoveValid(Collider excludeCollider = null)
	{
		Vector3 center = base.transform.position + coll.center;
		Vector3 halfExtents = coll.size * 0.5f;
		int num = Physics.OverlapBoxNonAlloc(center, halfExtents, hitCollidersBuffer, base.transform.rotation);
		GrabbableObject grabbableObject = null;
		if (excludeCollider != null)
		{
			grabbableObject = excludeCollider.GetComponentInParent<GrabbableObject>();
		}
		int num2 = 0;
		for (int i = 0; i < num; i++)
		{
			Collider collider = hitCollidersBuffer[i];
			if (collider.transform == base.transform || collider.transform.IsChildOf(base.transform) || base.transform.IsChildOf(collider.transform) || (this.grabbableObject != null && collider.transform.IsChildOf(this.grabbableObject.transform)))
			{
				continue;
			}
			WallController component2;
			if (collider.TryGetComponent<GroundController>(out var _))
			{
				GrabbableObject componentInParent = collider.GetComponentInParent<GrabbableObject>();
				if (!(grabbableObject != null) || !(componentInParent == grabbableObject))
				{
					num2++;
				}
			}
			else if (collider.TryGetComponent<WallController>(out component2))
			{
				GrabbableObject componentInParent2 = collider.GetComponentInParent<GrabbableObject>();
				if (!(grabbableObject != null) || !(componentInParent2 == grabbableObject))
				{
					num2++;
				}
			}
		}
		return num2 <= 0;
	}
}
