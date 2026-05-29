using System;
using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;
using CTS.StockInventory;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace CTS
{
	public class UI_StockTypePanel : CTSBehaviour, IGive<StringKey<StockType>>
	{
		[SerializeField]
		[Inject(false)]
		protected TMP_Text _textComponent;

		[SerializeField]
		[Inject(false)]
		private Transform _itemsContainer;

		[SerializeField]
		private bool _displayStockCount;

		[SerializeField]
		private GameObject _stockCountCountainer;

		[SerializeField]
		private bool _updateNameFromStockType = true;

		protected UI_StockItem _itemPrefab;

		protected StringKey<StockType> _stockType;

		public Dictionary<StockItemSO, UI_StockItem> Items { get; } = new Dictionary<StockItemSO, UI_StockItem>();

		protected override void OnAwake()
		{
			base.OnAwake();
			if (!_displayStockCount)
			{
				_stockCountCountainer.gameObject.SetActive(value: false);
			}
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			if (_updateNameFromStockType)
			{
				LocalizationSettings.SelectedLocaleChanged += OnLanguageChanged;
				OnLanguageChanged(null);
			}
		}

		private void OnLanguageChanged(Locale obj)
		{
			if (_updateNameFromStockType)
			{
				_textComponent.SetText(Stocks.GetStockName(_stockType));
			}
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			LocalizationSettings.SelectedLocaleChanged -= OnLanguageChanged;
		}

		public void Initialize(StringKey<StockType> stockType, UI_StockItem itemPrefab)
		{
			_itemPrefab = itemPrefab;
			_stockType = stockType;
		}

		public void SetLabelColor(Color color)
		{
			_textComponent.color = color;
		}

		public void CreateItem(StockItemSO item)
		{
			if (item.StockType != _stockType)
			{
				throw new Exception("Item cannot go in this stock type");
			}
			if (Items.ContainsKey(item))
			{
				throw new Exception("Item is already listed");
			}
			UI_StockItem uI_StockItem = CTSFactory.Instantiate(_itemPrefab, _itemsContainer, instantiateInWorldSpace: false, false);
			uI_StockItem.Initialize(item, _stockType);
			uI_StockItem.gameObject.SetActive(value: true);
		}

		StringKey<StockType> IGive<StringKey<StockType>>.Get()
		{
			return _stockType;
		}
	}
}
