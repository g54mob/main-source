using UnityEngine;
using Zenject;

namespace UniversalInventorySystem
{
	public abstract class DropBehaviour : MonoBehaviour, IDropBehaviour
	{
		[Inject]
		private InventoryHandler inventoryHandler;

		public virtual void OnEnable()
		{
			inventoryHandler.OnDropItem += OnDropItem;
		}

		public virtual void OnDestroy()
		{
			inventoryHandler.OnDropItem -= OnDropItem;
		}

		public abstract void OnDropItem(object sender, InventoryHandler.DropItemEventArgs e);
	}
}
