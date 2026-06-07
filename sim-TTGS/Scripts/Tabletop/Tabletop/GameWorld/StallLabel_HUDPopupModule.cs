using Simulator;
using TMPro;
using Tabletop.Preview3D;
using UnityEngine;
using UnityEngine.UI;

namespace Tabletop.GameWorld
{
	public class StallLabel_HUDPopupModule : TabletopHUDPopupModule
	{
		[Header("UI Components")]
		[SerializeField]
		private RawImage m_miniatureImage;

		[SerializeField]
		private SimulatorText m_miniatureNameText;

		[SerializeField]
		private TextMeshProUGUI m_marketPriceText;

		[SerializeField]
		protected TMP_InputField m_currentPriceInputField;

		[SerializeField]
		private TextMeshProUGUI m_paintingBonusText;

		[Space(10f)]
		[SerializeField]
		private Button m_increasePercentageButton;

		[SerializeField]
		private Button m_decreasePercentageButton;

		[SerializeField]
		private Button m_marketPriceButton;

		[SerializeField]
		private Button m_roundPriceButton;

		[SerializeField]
		private Button m_validateButton;

		private bool m_hasSetPrice;

		private float m_displayedPricePercentage;

		private float m_currentMarketPrice;

		private float m_currentPaintBonus;

		public override ETabletopHUDPopupModuleType ActualType => ETabletopHUDPopupModuleType.STALL_LABEL;

		protected override void OnEnable()
		{
			base.OnEnable();
			m_currentPriceInputField.onSubmit.AddListener(OnManuallySetPrice);
			m_increasePercentageButton.onClick.AddListener(OnButton_IncreasePercentage);
			m_decreasePercentageButton.onClick.AddListener(OnButton_DecreasePercentage);
			m_marketPriceButton.onClick.AddListener(OnButton_MarketPrice);
			m_roundPriceButton.onClick.AddListener(OnButton_RoundPrice);
			m_validateButton.onClick.AddListener(OnButton_Validate);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			m_currentPriceInputField.onSubmit.RemoveListener(OnManuallySetPrice);
			m_increasePercentageButton.onClick.RemoveListener(OnButton_IncreasePercentage);
			m_decreasePercentageButton.onClick.RemoveListener(OnButton_DecreasePercentage);
			m_marketPriceButton.onClick.RemoveListener(OnButton_MarketPrice);
			m_roundPriceButton.onClick.RemoveListener(OnButton_RoundPrice);
			m_validateButton.onClick.RemoveListener(OnButton_Validate);
		}

		protected override void OnSetActive()
		{
			base.OnSetActive();
			MiniatureProduct product = StallLabel.CurrentlyInspected.Product;
			int miniatureUID = -product.ProductData.UID;
			m_hasSetPrice = TabletopPriceManager.TryGetMiniatureMarketPricePercentage(product.ProductData.UID, product.Painted, out m_displayedPricePercentage);
			m_currentMarketPrice = TabletopPriceManager.GetMiniatureProductMarketPrice(product.ProductData.UID, product.Painted);
			m_currentPaintBonus = product.PaintBonus;
			UpdateContent();
			TabletopPreview3DManager.Instance.FocusMiniature(miniatureUID, highlightMissingPieces: false);
			TabletopPreview3DManager.Instance.PaintFocusedMiniature((!product.Painted) ? ECollectionPaintingMode.NO_PAINT : ECollectionPaintingMode.BEST_SCORE);
		}

		protected override void OnSetInactive()
		{
			base.OnSetInactive();
			TabletopPreview3DManager.Instance.Unfocus();
		}

		private void UpdateContent()
		{
			if (StallLabel.CurrentlyInspected.Product != null)
			{
				m_miniatureImage.uvRect = TabletopPreview3DManager.Instance.GetFocusedMiniatureRect();
				m_miniatureNameText.SetTerm(StallLabel.CurrentlyInspected.Product.ProductData.NameTerm);
				m_marketPriceText.text = m_currentMarketPrice.ToStringMoneyFormat();
				m_currentPriceInputField.interactable = true;
				m_currentPriceInputField.text = (m_hasSetPrice ? (m_currentMarketPrice * m_displayedPricePercentage).ToString("0.00") : "- - -");
				if (m_currentPaintBonus > 0f)
				{
					_ = m_currentPaintBonus;
				}
				m_paintingBonusText.text = "+" + m_currentPaintBonus.ToString("0.0") + "%";
				m_validateButton.interactable = m_hasSetPrice;
				m_increasePercentageButton.interactable = m_hasSetPrice;
				m_decreasePercentageButton.interactable = m_hasSetPrice;
				m_roundPriceButton.interactable = m_hasSetPrice;
			}
			else
			{
				m_miniatureImage.uvRect = TabletopPreview3DManager.Instance.GetFocusedMiniatureRect();
				m_currentPriceInputField.interactable = false;
				m_validateButton.interactable = false;
				m_increasePercentageButton.interactable = false;
				m_decreasePercentageButton.interactable = false;
				m_roundPriceButton.interactable = false;
			}
		}

		protected virtual void OnManuallySetPrice(string priceStr)
		{
			if (float.TryParse(priceStr, out var result))
			{
				m_displayedPricePercentage = result / m_currentMarketPrice;
				m_hasSetPrice = true;
			}
			UpdateContent();
		}

		private void OnButton_IncreasePercentage()
		{
			float num = m_currentMarketPrice * m_displayedPricePercentage;
			num *= 1.1f;
			m_displayedPricePercentage = num / m_currentMarketPrice;
			UpdateContent();
		}

		private void OnButton_DecreasePercentage()
		{
			float num = m_currentMarketPrice * m_displayedPricePercentage;
			num *= 0.9f;
			m_displayedPricePercentage = num / m_currentMarketPrice;
			UpdateContent();
		}

		private void OnButton_MarketPrice()
		{
			m_displayedPricePercentage = 1f;
			m_hasSetPrice = true;
			UpdateContent();
		}

		protected virtual void OnButton_RoundPrice()
		{
			float f = m_currentMarketPrice * m_displayedPricePercentage;
			f = Mathf.Round(f);
			m_displayedPricePercentage = f / m_currentMarketPrice;
			UpdateContent();
		}

		private void OnButton_Validate()
		{
			MiniatureProduct product = StallLabel.CurrentlyInspected.Product;
			if (product != null)
			{
				TabletopPriceManager.SetMiniatureMarketPricePercentage(product.ProductData.UID, product.Painted, m_displayedPricePercentage);
			}
			Validate();
		}
	}
}
