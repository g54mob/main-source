using UnityEngine;

public class FreezePositionOnEnable : MonoBehaviour
{
	private Transform oldParent;

	private void OnEnable()
	{
		if (oldParent == null)
		{
			oldParent = base.transform.parent;
		}
		base.transform.SetParent(null);
		base.transform.position = oldParent.position;
		base.transform.rotation = oldParent.rotation;
	}

	private void Update()
	{
		if (!oldParent.gameObject.activeInHierarchy)
		{
			base.transform.SetParent(oldParent);
		}
	}
}
