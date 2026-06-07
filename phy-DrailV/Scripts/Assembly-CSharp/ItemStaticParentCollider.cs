using UnityEngine;

public class ItemStaticParentCollider : MonoBehaviour
{
	[SerializeField]
	private ItemStaticParent staticParent;

	public ItemStaticParent StaticParent => staticParent;

	private void Awake()
	{
		if (staticParent == null)
		{
			Debug.LogError("ItemStaticParentCollider: Reference to ItemStaticParent not set on " + base.name + "! This should not happen. Destroying self.", base.gameObject);
			Object.Destroy(this);
		}
	}
}
