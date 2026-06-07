using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	public class ShelfLabel : MonoBehaviour, ISensable, IMainInteractable
	{
		[Header("Shelf Label")]
		[SerializeField]
		private Canvas m_canvas;

		[Header("UI Components")]
		[SerializeField]
		private SimulatorText m_productNameText;

		[SerializeField]
		private TextMeshProUGUI m_quantityText;

		[SerializeField]
		private TextMeshProUGUI m_priceText;

		[SerializeField]
		private Image m_itemImage;

		[Space(15f)]
		[SerializeField]
		private Image m_noPriceImage;

		[SerializeField]
		private Image m_soldOutImage;

		[SerializeField]
		private Image m_promoImage;

		[Header("Detection")]
		[SerializeField]
		private Outline m_outline;

		[Header("Input hint")]
		[SerializeField]
		private InputHint m_inputHint;

		public ProductData Data { get; private set; }

		public EShelfLabelState State { get; private set; }

		public static ShelfLabel CurrentlyInspected { get; private set; }

		private void OnEnable()
		{
			InitContent();
			PriceManager.PriceChanged += OnPriceChanged;
			PriceManager.MarketPricesChanged += OnMarketPricesChanged;
		}

		private void OnDisable()
		{
			PriceManager.PriceChanged -= OnPriceChanged;
			PriceManager.MarketPricesChanged -= OnMarketPricesChanged;
		}

		private void InitContent()
		{
			if (Data == null)
			{
				m_itemImage.enabled = false;
				m_priceText.gameObject.SetActive(value: false);
				m_productNameText.gameObject.SetActive(value: false);
				SetQuantity(0);
				SetPrice(-1f);
				SetProductState(EShelfLabelState.NONE);
			}
		}

		public void SetProduct(ProductData data)
		{
			Data = data;
			if (data != null)
			{
				m_itemImage.sprite = data.Sprite;
				m_itemImage.enabled = true;
				m_priceText.gameObject.SetActive(value: true);
				m_productNameText.gameObject.SetActive(value: true);
				m_productNameText.SetTerm(data.NameTerm);
				if (PriceManager.TryGetProductPrice(Data.UID, out var price))
				{
					SetPrice(price);
				}
				else
				{
					SetPrice(-1f);
				}
			}
		}

		public void SetQuantity(int quantity)
		{
			m_quantityText.text = quantity.ToString();
			if (quantity == 0)
			{
				SetProduct(null);
				SetProductState(EShelfLabelState.SOLD_OUT);
			}
		}

		public void SetPrice(float price)
		{
			if (price >= 0f)
			{
				m_priceText.text = price.ToStringMoneyFormat();
				float productMarketPrice = PriceManager.GetProductMarketPrice(Data.UID);
				if (!Mathf.Approximately(price, productMarketPrice) && price < productMarketPrice)
				{
					SetProductState(EShelfLabelState.PROMO);
				}
				else
				{
					SetProductState(EShelfLabelState.PRICED);
				}
			}
			else
			{
				SetProductState(EShelfLabelState.UNPRICED);
			}
		}

		public void SetProductState(EShelfLabelState state)
		{
			State = state;
			switch (state)
			{
			case EShelfLabelState.NONE:
			case EShelfLabelState.PRICED:
				m_noPriceImage.enabled = false;
				m_soldOutImage.enabled = false;
				m_promoImage.enabled = false;
				break;
			case EShelfLabelState.UNPRICED:
				m_priceText.text = "- - -";
				m_noPriceImage.enabled = true;
				m_soldOutImage.enabled = false;
				m_promoImage.enabled = false;
				break;
			case EShelfLabelState.PROMO:
				m_noPriceImage.enabled = false;
				m_soldOutImage.enabled = false;
				m_promoImage.enabled = true;
				break;
			case EShelfLabelState.SOLD_OUT:
				m_noPriceImage.enabled = false;
				m_soldOutImage.enabled = true;
				m_promoImage.enabled = false;
				break;
			}
		}

		public bool CanBeSensed()
		{
			if (Data != null && World.PlayerController.Context == EControllerContext.CHARACTER)
			{
				return World.PlayerCharacter.CharacterContext == EPlayerCharacterContext.NONE;
			}
			return false;
		}

		public void OnSensed()
		{
			m_outline.enabled = true;
			if (m_inputHint != null)
			{
				m_inputHint.enabled = true;
			}
		}

		public void OnUnsensed()
		{
			m_outline.enabled = false;
			if (m_inputHint != null)
			{
				m_inputHint.enabled = false;
			}
		}

		bool IMainInteractable.CanMainInteract(Character character)
		{
			return Data != null;
		}

		void IMainInteractable.OnMainInteractedBy(Character character)
		{
			CurrentlyInspected = this;
			World.HUDPopup.Open(EHUDPopupModuleType.SHELF_LABEL);
		}

		protected virtual void OnPriceChanged(int productUID, float price)
		{
			if (Data != null && Data.UID == productUID)
			{
				SetPrice(price);
			}
		}

		protected virtual void OnMarketPricesChanged()
		{
			if (Data != null && PriceManager.TryGetProductPrice(Data.UID, out var price))
			{
				SetPrice(price);
			}
		}
	}
}
