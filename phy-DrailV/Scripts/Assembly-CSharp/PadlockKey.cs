using DV.CabControls;
using DV.CabControls.Spec;
using DV.Interaction;
using DV.Shops;
using UnityEngine;

[RequireComponent(typeof(Item))]
public class PadlockKey : MonoBehaviour
{
	public PadlockKeyType keyType;

	public ItemBase Item { get; private set; }

	private void Start()
	{
		base.gameObject.AddComponent<KeyUse>();
		Item = GetComponent<ItemBase>();
	}

	public void KeyUsed()
	{
		ShopRestocker componentInParent = GetComponentInParent<ShopRestocker>();
		if (componentInParent != null)
		{
			componentInParent.restockOnItemDestroyed = false;
		}
	}
}
