using System.ComponentModel;
using DV.CabControls;
using DV.Common;
using DV.Interaction.Inputs;
using DV.InventorySystem;
using DV.Utils;
using UnityEngine;

namespace DV.UI.Inventory
{
	public class InventoryProvider : AInventoryProvider
	{
		public override DV.InventorySystem.Inventory Inventory => SingletonBehaviour<DV.InventorySystem.Inventory>.Instance;

		public override bool IsEssentialItemsGetterAllowed => Globals.G.GameParams.EssentialItemsGetterAllowed;

		public override bool IsGameInitialized
		{
			get
			{
				if (SingletonBehaviour<StartingItemsController>.Instance.itemsLoaded)
				{
					return SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance;
				}
				return false;
			}
		}

		public override bool IsInventoryOpenKeyDown => InputManager.NewPlayer.GetButtonDown(InputManager.Actions.InventoryOpen);

		public override bool IsInventoryCloseKeyDown => IsInventoryOpenKeyDown;

		public override bool IsBeltSnappable(IInventoryItemSpec spec)
		{
			GameObject gameObject = spec?.GetGameObject();
			ItemBase itemBase = ((gameObject != null) ? gameObject.GetComponent<ItemBase>() : null);
			if (itemBase != null)
			{
				return itemBase.IsBeltSnappable;
			}
			return false;
		}

		protected override void Awake()
		{
			base.Awake();
			Globals.G.GameParams.PropertyChanged += OnGameParamsChanged;
		}

		private void OnDestroy()
		{
			Globals.G.GameParams.PropertyChanged -= OnGameParamsChanged;
		}

		private void OnGameParamsChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e.PropertyName == "EssentialItemsGetterAllowed")
			{
				IsEssentialItemsGetterAllowedChanged_Fire();
			}
		}
	}
}
