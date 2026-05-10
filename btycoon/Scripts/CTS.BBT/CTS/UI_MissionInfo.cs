using System.Collections.Generic;
using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class UI_MissionInfo : CTSBehaviour
	{
		[InjectScope(EGetScope.Parent)]
		[SerializeField]
		[Inject(false)]
		private SoftReference<ShopBasket> _basket;

		[SerializeField]
		private StockItemList _stockItemList;

		[SerializeField]
		private UI_MissionStatusItem _prefab;

		[SerializeField]
		private RectTransform _contentTransform;

		private readonly Dictionary<StockItemSO, UI_MissionStatusItem> _items = new Dictionary<StockItemSO, UI_MissionStatusItem>();

		protected MissionBasket Basket => _basket.Value as MissionBasket;

		protected override void OnAwake()
		{
			base.OnAwake();
			StockItemSO[] items = _stockItemList.Items;
			foreach (StockItemSO stockItemSO in items)
			{
				UI_MissionStatusItem uI_MissionStatusItem = CTSFactory.Instantiate(_prefab, _contentTransform, instantiateInWorldSpace: false, false);
				uI_MissionStatusItem.Initialize(stockItemSO);
				_items.Add(stockItemSO, uI_MissionStatusItem);
			}
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			MissionBasket.MissionStarted += UpdateCurrentMission;
			UpdateCurrentMission(Basket);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			MissionBasket.MissionStarted -= UpdateCurrentMission;
		}

		private void UpdateCurrentMission(MissionBasket basket)
		{
			if (basket != Basket)
			{
				return;
			}
			StockItemSO key;
			foreach (KeyValuePair<StockItemSO, UI_MissionStatusItem> item in _items)
			{
				item.Deconstruct(out key, out var value);
				value.gameObject.SetActive(value: false);
			}
			if (!Basket.HasMission())
			{
				return;
			}
			foreach (KeyValuePair<StockItemSO, MissionBasket.MissionItemCapacity> item2 in Basket.CurrentMissionStatus)
			{
				item2.Deconstruct(out key, out var _);
				StockItemSO key2 = key;
				if (_items.TryGetValue(key2, out var value3))
				{
					value3.gameObject.SetActive(value: true);
				}
			}
		}
	}
}
