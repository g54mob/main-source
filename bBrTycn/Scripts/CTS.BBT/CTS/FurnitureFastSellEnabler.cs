using CTS.Core;
using CTS.Furnitures;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class FurnitureFastSellEnabler : CTSBehaviour
	{
		[SerializeField]
		private CTSToggle _toggle;

		[SerializeField]
		private CanvasGroupController _toggleCanvas;

		protected override void OnAwake()
		{
			base.OnAwake();
			FurnitureFastSell.FastSellActivated += OnFastSellActivated;
			FurnitureShop.FurnitureShopStatusChanged += OnFurnitureShopStatusChanged;
			FurniturePlacer.SpawningFurniture += OnFurnitureSpawning;
			_toggle.onValueChanged.AddListener(OnToggleValueChanged);
		}

		private void OnDestroy()
		{
			FurnitureFastSell.FastSellActivated -= OnFastSellActivated;
			FurnitureShop.FurnitureShopStatusChanged -= OnFurnitureShopStatusChanged;
			FurniturePlacer.SpawningFurniture -= OnFurnitureSpawning;
		}

		private void OnFurnitureSpawning()
		{
			CTSSingleton<FurnitureFastSell>.Instance.SetActive(value: false);
		}

		private void OnToggleValueChanged(bool isOn)
		{
			if (isOn)
			{
				MonoSingleton<FurniturePlacer>.Instance.TryCancelPlacement();
			}
			CTSSingleton<FurnitureFastSell>.Instance.SetActive(isOn);
		}

		private void OnFastSellActivated()
		{
			_toggle.isOn = CTSSingleton<FurnitureFastSell>.Instance.IsActive;
		}

		private void OnFurnitureShopStatusChanged(bool isOpen)
		{
			if (isOpen)
			{
				_toggleCanvas.QuickShow();
				return;
			}
			_toggleCanvas.QuickHide();
			if (CTSSingleton<FurnitureFastSell>.InstanceExists())
			{
				CTSSingleton<FurnitureFastSell>.Instance.SetActive(value: false);
			}
		}
	}
}
