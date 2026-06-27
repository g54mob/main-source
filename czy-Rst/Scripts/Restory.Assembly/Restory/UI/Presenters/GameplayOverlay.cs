using Restory.ObjectPools;
using Restory.UI.Presenters.Inventory;
using Restory.UI.Views.GameplayOverlay;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters
{
	public sealed class GameplayOverlay : MonoBehaviour, ICleanableComponent
	{
		[SerializeField]
		private GameplayOverlayView view;

		private InventoryPanel inventoryPanel;

		public InventoryPanel InventoryPanel => inventoryPanel;

		[Inject]
		private void Construct(InventoryPanel inventoryPanel)
		{
			this.inventoryPanel = inventoryPanel;
		}

		void ICleanableComponent.Clean()
		{
		}
	}
}
