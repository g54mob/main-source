using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	public class UI_MarketStoreCartItem : NavBox
	{
		[Header("UI Components")]
		[SerializeField]
		protected SimulatorText m_productNameText;

		[SerializeField]
		protected TextMeshProUGUI m_quantityText;

		[SerializeField]
		protected Button m_removeUnitButton;

		[SerializeField]
		protected Button m_addUnitButton;

		[SerializeField]
		protected TextMeshProUGUI m_priceText;

		[SerializeField]
		protected TextMeshProUGUI m_totalText;

		[SerializeField]
		protected Button m_removeButton;

		public BaseShopBoxData Data { get; private set; }

		public bool DataIsExtension { get; private set; }

		public event Action<BaseShopBoxData> RemovedUnit;

		public event Action<BaseShopBoxData> AddedUnit;

		public event Action<BaseShopBoxData> RemovedProduct;

		protected override void OnEnable()
		{
			base.OnEnable();
			m_removeButton.onClick.AddListener(OnRemoveProduct);
			m_addUnitButton.onClick.AddListener(OnAddUnit);
			m_removeUnitButton.onClick.AddListener(OnRemoveUnit);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			m_removeButton.onClick.RemoveListener(OnRemoveProduct);
			m_addUnitButton.onClick.RemoveListener(OnAddUnit);
			m_removeUnitButton.onClick.RemoveListener(OnRemoveUnit);
		}

		public virtual void SetData(BaseShopBoxData data)
		{
			Data = data;
			DataIsExtension = data is ExtensionShopBoxData;
			m_productNameText.SetTerm(data.NameTerm);
			m_priceText.text = World.MarketStore.GetDataPrice(data).ToStringMoneyFormat();
			if (DataIsExtension)
			{
				m_removeUnitButton.interactable = false;
				m_addUnitButton.interactable = false;
			}
		}

		public virtual void UpdateQuantity(int quantity)
		{
			m_quantityText.text = quantity.ToString();
			m_totalText.text = (World.MarketStore.GetDataPrice(Data) * (float)quantity).ToStringMoneyFormat();
		}

		protected virtual void OnRemoveUnit()
		{
			this.RemovedUnit?.Invoke(Data);
		}

		protected virtual void OnAddUnit()
		{
			this.AddedUnit?.Invoke(Data);
		}

		protected virtual void OnRemoveProduct()
		{
			this.RemovedProduct?.Invoke(Data);
		}
	}
}
