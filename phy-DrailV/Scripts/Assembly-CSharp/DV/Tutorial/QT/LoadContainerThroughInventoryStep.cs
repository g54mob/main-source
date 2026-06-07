using DV.CabControls;
using DV.Game.Tutorial.ItemTracker;
using DV.InventorySystem;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class LoadContainerThroughInventoryStep : AQuickTutorialStep
	{
		public delegate ItemBase SingleItemProvider();

		public delegate ItemBase[] ItemArrayProvider();

		private ItemArrayProvider itemsProvider;

		private SingleItemProvider containerProvider;

		private string message;

		private bool oneIsEnough;

		private ItemBase[] itemsToLoad;

		private ItemBase targetContainer;

		private AItemContainer container;

		private ItemPointer pointer;

		public LoadContainerThroughInventoryStep(string message, ItemBase[] itemsToLoad, ItemBase targetContainer, bool oneIsEnough, bool shouldRecheck = true)
			: base("", null, Vector3.zero, shouldRecheck)
		{
			this.message = message;
			this.itemsToLoad = itemsToLoad;
			this.targetContainer = targetContainer;
			container = this.targetContainer.GetComponent<AItemContainer>();
			this.oneIsEnough = oneIsEnough;
		}

		public LoadContainerThroughInventoryStep(string message, ItemArrayProvider itemsProvider, ItemBase targetContainer, bool oneIsEnough, bool shouldRecheck = true)
			: base("", null, Vector3.zero, shouldRecheck)
		{
			this.message = message;
			this.itemsProvider = itemsProvider;
			this.targetContainer = targetContainer;
			container = this.targetContainer.GetComponent<AItemContainer>();
			this.oneIsEnough = oneIsEnough;
		}

		public LoadContainerThroughInventoryStep(string message, ItemBase[] itemsToLoad, SingleItemProvider containerProvider, bool oneIsEnough, bool shouldRecheck = true)
			: base("", null, Vector3.zero, shouldRecheck)
		{
			this.message = message;
			this.itemsToLoad = itemsToLoad;
			this.containerProvider = containerProvider;
			this.oneIsEnough = oneIsEnough;
		}

		public LoadContainerThroughInventoryStep(string message, ItemArrayProvider itemsProvider, SingleItemProvider containerProvider, bool oneIsEnough, bool shouldRecheck = true)
			: base("", null, Vector3.zero, shouldRecheck)
		{
			this.message = message;
			this.itemsProvider = itemsProvider;
			this.containerProvider = containerProvider;
			this.oneIsEnough = oneIsEnough;
		}

		protected override void InternalMakeCurrent()
		{
			base.InternalMakeCurrent();
			if (itemsProvider != null)
			{
				itemsToLoad = itemsProvider();
			}
			if (containerProvider != null)
			{
				targetContainer = containerProvider();
				container = targetContainer.GetComponent<AItemContainer>();
			}
			pointer = new ItemPointer(itemsToLoad, container, ItemTracker.TargetZoneType.Container, message, localizeMessage: false);
		}

		protected override void InternalDeactivate()
		{
			base.InternalDeactivate();
			if (pointer != null)
			{
				pointer.Dispose();
				pointer = null;
			}
		}

		protected override bool InternalCheck()
		{
			int num = 0;
			int num2 = 0;
			ItemBase[] array = itemsToLoad;
			foreach (ItemBase itemBase in array)
			{
				if ((bool)itemBase)
				{
					num++;
					if (itemBase.IsWithin(container))
					{
						num2++;
					}
				}
			}
			if (!oneIsEnough)
			{
				return num2 == num;
			}
			return num2 > 0;
		}
	}
}
