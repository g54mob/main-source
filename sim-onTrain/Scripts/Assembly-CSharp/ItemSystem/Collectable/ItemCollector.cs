using UnityEngine;

namespace ItemSystem.Collectable
{
	public class ItemCollector : MonoBehaviour
	{
		public PlayerInventory inventory;

		private void OnTriggerEnter(Collider other)
		{
			if (other.TryGetComponent<CollectableItem>(out var component))
			{
				inventory.AddItemInventory(component.collectableItemData, 1);
				component.DestroyItem();
			}
		}
	}
}
