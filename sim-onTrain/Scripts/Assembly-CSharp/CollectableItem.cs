using UnityEngine;

public class CollectableItem : CollectableItemBase
{
	private void ChangeName()
	{
		base.gameObject.name = collectableItemData.itemName;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent<PlayerInventory>(out var component))
		{
			if (collectableItemData != null)
			{
				Collect(component);
				DestroyItem();
				Debug.Log("CollectableItemData is " + collectableItemData.itemName);
			}
			else
			{
				Debug.LogWarning("CollectableItemData is null for " + itemName);
			}
		}
	}

	public override bool Weaved()
	{
		return true;
	}
}
