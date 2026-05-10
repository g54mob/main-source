using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;
using CTS.StockInventory;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class UI_StockPopulator : CTSBehaviour
	{
		[SerializeField]
		private StringKey _panelId;

		[SerializeField]
		protected StockItemList _itemsToShow;

		[SerializeField]
		protected UI_StockTypePanel _stockTypePanelPrefab;

		[SerializeField]
		[Inject(false)]
		protected Transform _stockTypePanelContainer;

		[SerializeField]
		protected UI_StockItem _itemPrefab;

		[SerializeField]
		private SerializableDictionary<StringKey<StockType>, PaletteData> _specificLabelColors = new SerializableDictionary<StringKey<StockType>, PaletteData>();

		protected Dictionary<StringKey<StockType>, UI_StockTypePanel> _stockTypePanels = new Dictionary<StringKey<StockType>, UI_StockTypePanel>();

		public static event Action<StringKey> PanelOpened;

		public static event Action<StringKey> PanelClose;

		protected override void OnAwake()
		{
			base.OnAwake();
		}

		private void Start()
		{
			StockItemSO[] items = _itemsToShow.Items;
			foreach (StockItemSO stockItemSO in items)
			{
				if (stockItemSO == null || stockItemSO.GetValidationState == AbsLockableItemSO.ELockState.Removed)
				{
					continue;
				}
				if (!_stockTypePanels.TryGetValue(stockItemSO.StockType, out var value))
				{
					value = CTSFactory.Instantiate(_stockTypePanelPrefab, _stockTypePanelContainer, instantiateInWorldSpace: false, false);
					value.Initialize(stockItemSO.StockType, _itemPrefab);
					value.gameObject.SetActive(value: true);
					if (_specificLabelColors.TryGetValue(stockItemSO.StockType, out var value2))
					{
						value.SetLabelColor(value2);
					}
					_stockTypePanels[stockItemSO.StockType] = value;
				}
				value.CreateItem(stockItemSO);
			}
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			foreach (KeyValuePair<StringKey<StockType>, UI_StockTypePanel> stockTypePanel in _stockTypePanels)
			{
				stockTypePanel.Value.enabled = true;
			}
			UI_StockPopulator.PanelOpened?.Invoke(_panelId);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			foreach (KeyValuePair<StringKey<StockType>, UI_StockTypePanel> stockTypePanel in _stockTypePanels)
			{
				stockTypePanel.Value.enabled = true;
			}
			UI_StockPopulator.PanelClose?.Invoke(_panelId);
		}
	}
}
