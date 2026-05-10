using CTS.BBT;
using CTS.Core;
using CTS.Furnitures;
using UnityEngine;

namespace CTS
{
	public class BuyMenuSelectionModes : CTSBehaviour
	{
		[SerializeField]
		private OrderedSelectionMode _furnitureSelMode;

		[SerializeField]
		private OrderedSelectionMode _placementSelMode;

		private LockToggle _selectionToggle;

		private bool _buyModeActive;

		private bool _placementModeActive;

		protected override void OnAwake()
		{
			base.OnAwake();
			_selectionToggle = new LockToggle(CTSSingleton<WorldSelector>.Instance);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			FurnitureShop.FurnitureShopStatusChanged += OnFurnitureShopStatusChanged;
			FurniturePlacer.FurniturePickedUp += OnFurniturePickedUp;
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			FurnitureShop.FurnitureShopStatusChanged -= OnFurnitureShopStatusChanged;
			FurniturePlacer.FurniturePickedUp -= OnFurniturePickedUp;
		}

		private void OnFurnitureShopStatusChanged(bool isOpen)
		{
			_selectionToggle.Unlock();
			if (isOpen != _buyModeActive)
			{
				_buyModeActive = isOpen;
				if (_buyModeActive)
				{
					CTSSingleton<SelectionModeList>.Instance.AddMode(_furnitureSelMode);
				}
				else
				{
					CTSSingleton<SelectionModeList>.Instance.RemoveMode(_furnitureSelMode);
				}
			}
		}

		private void OnFurniturePickedUp(Furniture furniture)
		{
			if ((bool)furniture != _placementModeActive)
			{
				_placementModeActive = (object)furniture != null;
				if (_placementModeActive)
				{
					CTSSingleton<SelectionModeList>.Instance.AddMode(_placementSelMode);
					_selectionToggle.Lock();
				}
				else
				{
					CTSSingleton<SelectionModeList>.Instance.RemoveMode(_placementSelMode);
					_selectionToggle.Unlock();
				}
			}
		}
	}
}
