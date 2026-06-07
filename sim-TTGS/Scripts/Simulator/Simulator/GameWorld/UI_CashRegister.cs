using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	public class UI_CashRegister : MonoBehaviour
	{
		[Header("Cash Register")]
		[SerializeField]
		private Canvas m_canvas;

		[SerializeField]
		private ObjectStackActivator m_stackActivator;

		[Header("Products Page")]
		[SerializeField]
		private GameObject m_productsPage;

		[Space(10f)]
		[SerializeField]
		private TextMeshProUGUI m_productsPriceText;

		[SerializeField]
		private RectTransform m_productsListContainer;

		[SerializeField]
		private GameObject m_productPrefab;

		[Header("Change Page")]
		[SerializeField]
		private GameObject m_changePage;

		[SerializeField]
		private Image m_changePageBackgroundImage;

		[SerializeField]
		private Sprite m_changePageBaseBackgroundSprite;

		[SerializeField]
		private Sprite m_changePageErrorBackgroundSprite;

		[SerializeField]
		private Sprite m_changePageValidBackgroundSprite;

		[Space(10f)]
		[SerializeField]
		private TextMeshProUGUI m_receivingText;

		[SerializeField]
		private TextMeshProUGUI m_totalPriceText;

		[SerializeField]
		private TextMeshProUGUI m_changeText;

		[SerializeField]
		private Color m_changeErrorTextColor;

		private Dictionary<BoughtProductInfo, int> m_productsDico = new Dictionary<BoughtProductInfo, int>();

		private Dictionary<BoughtProductInfo, UI_CashRegisterProduct> m_productsUIElements = new Dictionary<BoughtProductInfo, UI_CashRegisterProduct>();

		private void OnEnable()
		{
			m_stackActivator.Init(m_productsPage);
			m_productsDico.Clear();
			m_productsPriceText.enabled = false;
		}

		private void UpdateProductsDisplay()
		{
			if (CashRegisterTransaction.HasCurrent(out var transaction) && transaction.CheckedProductsCost > 0f)
			{
				m_productsPriceText.enabled = true;
				m_productsPriceText.text = transaction.CheckedProductsCost.ToStringMoneyFormat();
			}
			else
			{
				m_productsPriceText.enabled = false;
			}
			foreach (var (boughtProductInfo2, num2) in m_productsDico)
			{
				if (m_productsUIElements.TryGetValue(boughtProductInfo2, out var value))
				{
					value.UpdateUnitCount(num2);
				}
				else
				{
					InstantiateProductUI(boughtProductInfo2, num2);
				}
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(m_productsListContainer);
		}

		private void UpdateChangeDisplay()
		{
			if (CashRegisterTransaction.HasCurrent(out var transaction))
			{
				m_receivingText.text = transaction.MoneyTaken.ToStringMoneyFormat();
				m_totalPriceText.text = transaction.CheckedProductsCost.ToStringMoneyFormat();
				float currentMoneyToReturn = transaction.GetCurrentMoneyToReturn();
				m_changeText.text = currentMoneyToReturn.ToStringMoneyFormat();
				if (transaction.IsTransactionValid())
				{
					m_changePageBackgroundImage.sprite = m_changePageValidBackgroundSprite;
					m_changeText.color = Color.black;
				}
				else if (currentMoneyToReturn > 0f)
				{
					m_changePageBackgroundImage.sprite = m_changePageBaseBackgroundSprite;
					m_changeText.color = Color.black;
				}
				else
				{
					m_changePageBackgroundImage.sprite = m_changePageErrorBackgroundSprite;
					m_changeText.color = m_changeErrorTextColor;
				}
			}
		}

		public void CheckProduct(Product product)
		{
			AddProductToDico(product.GetBoughtProductInfo());
			UpdateProductsDisplay();
		}

		public void ShowChange()
		{
			m_stackActivator.Activate(m_changePage);
			UpdateChangeDisplay();
		}

		public void UpdateChangeReturned()
		{
			UpdateChangeDisplay();
		}

		public void Clear()
		{
			ClearProductListElements();
			m_stackActivator.Back();
			UpdateProductsDisplay();
		}

		private void AddProductToDico(BoughtProductInfo productInfo)
		{
			if (m_productsDico.ContainsKey(productInfo))
			{
				m_productsDico[productInfo]++;
			}
			else
			{
				m_productsDico[productInfo] = 1;
			}
		}

		private void InstantiateProductUI(BoughtProductInfo productInfo, int quantity)
		{
			UI_CashRegisterProduct component = Object.Instantiate(m_productPrefab, m_productsListContainer).GetComponent<UI_CashRegisterProduct>();
			component.Init(productInfo, quantity);
			m_productsUIElements.Add(productInfo, component);
		}

		private void ClearProductListElements()
		{
			for (int num = m_productsListContainer.childCount - 1; num >= 0; num--)
			{
				Object.Destroy(m_productsListContainer.GetChild(num).gameObject);
			}
			m_productsDico.Clear();
			m_productsUIElements.Clear();
		}
	}
}
