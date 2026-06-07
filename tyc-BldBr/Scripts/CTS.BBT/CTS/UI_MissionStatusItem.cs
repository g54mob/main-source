using CTS.BBT;
using CTS.Core;
using UnityEngine;

namespace CTS
{
	public class UI_MissionStatusItem : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private UI_StockItemReferences _refs;

		[InjectScope(EGetScope.Parent)]
		[SerializeField]
		[Inject(false)]
		private SoftReference<ShopBasket> _basket;

		private StockItemSO _itemData;

		private MissionBasket Basket => _basket.Value as MissionBasket;

		protected override void OnAwake()
		{
			base.OnAwake();
			_refs.QualityContainer.gameObject.SetActive(value: false);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			Basket.BasketValidated += OnBasketValidated;
			RefreshInfos();
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			MissionBasket basket = Basket;
			if ((bool)basket)
			{
				basket.BasketValidated -= OnBasketValidated;
			}
		}

		public void Initialize(StockItemSO itemSo)
		{
			_itemData = itemSo;
			_refs.IconImage.overrideSprite = _itemData.Icon;
		}

		private void OnBasketValidated(ShopBasket.BasketValidation basketValidation)
		{
			RefreshInfos();
		}

		private void RefreshInfos()
		{
			if (Basket.CurrentMissionStatus.TryGetValue(_itemData, out var value))
			{
				_refs.MinMaxText.text = value.RequiredCount.ToString();
				if (value.CurrentCount > 0)
				{
					_refs.CountContainer.gameObject.SetActive(value: true);
					_refs.CountText.text = value.CurrentCount.ToString();
				}
				else
				{
					_refs.CountContainer.gameObject.SetActive(value: false);
				}
			}
		}
	}
}
