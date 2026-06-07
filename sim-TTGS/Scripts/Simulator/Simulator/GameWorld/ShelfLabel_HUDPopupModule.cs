using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	public class ShelfLabel_HUDPopupModule : HUDPopupModule
	{
		[Header("UI Components")]
		[SerializeField]
		protected Image m_itemImage;

		[Space(10f)]
		[SerializeField]
		protected TextMeshProUGUI m_averagePriceText;

		[SerializeField]
		protected TextMeshProUGUI m_marketPriceText;

		[SerializeField]
		protected TMP_InputField m_currentPriceInputField;

		[SerializeField]
		protected TextMeshProUGUI m_marginText;

		[Space(10f)]
		[SerializeField]
		protected Button m_decreasePriceButton;

		[SerializeField]
		protected Button m_increasePriceButton;

		[SerializeField]
		protected Button m_marketPriceButton;

		[SerializeField]
		protected Button m_roundPriceButton;

		[SerializeField]
		protected Button m_validateButton;

		[SerializeField]
		protected Button m_marketHistoryButton;

		[Header("Market History")]
		[SerializeField]
		protected CanvasGroup m_marketHistoryGroup;

		[SerializeField]
		protected Button m_marketHistoryQuitButton;

		[SerializeField]
		protected RectTransform m_graph;

		[SerializeField]
		protected RectTransform m_pointsContainer;

		[SerializeField]
		protected RectTransform m_linesContainer;

		[SerializeField]
		protected RectTransform m_datesContainer;

		[Space(10f)]
		[SerializeField]
		protected Image m_pointTemplate;

		[SerializeField]
		protected Image m_lineTemplate;

		[SerializeField]
		protected TextMeshProUGUI m_dateTemplate;

		[Space(10f)]
		[SerializeField]
		protected TextMeshProUGUI m_historyCurrentPriceText;

		[SerializeField]
		protected TextMeshProUGUI m_historyMinPriceText;

		[SerializeField]
		protected TextMeshProUGUI m_historyMaxPriceText;

		[Header("Tutorial")]
		[SerializeField]
		private TutorialData m_openMiniaturesBoxTutorialData;

		protected List<Image> m_graphPoints = new List<Image>();

		protected List<Image> m_graphLines = new List<Image>();

		protected List<TextMeshProUGUI> m_graphDates = new List<TextMeshProUGUI>();

		public override EHUDPopupModuleType Type => EHUDPopupModuleType.SHELF_LABEL;

		protected ProductData CurrentData { get; set; }

		protected float CurrentPrice { get; set; }

		protected float AveragePrice { get; set; }

		protected override void OnEnable()
		{
			base.OnEnable();
			m_currentPriceInputField.onSubmit.AddListener(OnManuallySetPrice);
			m_currentPriceInputField.onEndEdit.AddListener(OnManuallySetPrice);
			m_decreasePriceButton.onClick.AddListener(OnButton_DecreasePrice);
			m_increasePriceButton.onClick.AddListener(OnButton_IncreasePrice);
			m_marketPriceButton.onClick.AddListener(OnButton_MarketPrice);
			m_roundPriceButton.onClick.AddListener(OnButton_RoundPrice);
			m_validateButton.onClick.AddListener(OnButton_Validate);
			m_marketHistoryButton.onClick.AddListener(OnButton_MarketHistory);
			m_marketHistoryQuitButton.onClick.AddListener(OnButton_QuitMarketHistory);
		}

		protected override void OnDisable()
		{
			m_currentPriceInputField.onSubmit.RemoveListener(OnManuallySetPrice);
			m_currentPriceInputField.onEndEdit.RemoveListener(OnManuallySetPrice);
			m_decreasePriceButton.onClick.RemoveListener(OnButton_DecreasePrice);
			m_increasePriceButton.onClick.RemoveListener(OnButton_IncreasePrice);
			m_marketPriceButton.onClick.RemoveListener(OnButton_MarketPrice);
			m_roundPriceButton.onClick.RemoveListener(OnButton_RoundPrice);
			m_validateButton.onClick.RemoveListener(OnButton_Validate);
			m_marketHistoryButton.onClick.RemoveListener(OnButton_MarketHistory);
			m_marketHistoryQuitButton.onClick.RemoveListener(OnButton_QuitMarketHistory);
		}

		protected override void OnSetActive()
		{
			base.OnSetActive();
			CurrentData = ShelfLabel.CurrentlyInspected.Data;
			InitContent();
			SetMarketHistoryActive(active: false);
		}

		protected virtual void InitContent()
		{
			m_itemImage.sprite = CurrentData.Sprite;
			if (PriceManager.TryGetProductPrice(CurrentData.UID, out var price))
			{
				CurrentPrice = price;
			}
			else
			{
				CurrentPrice = -1f;
			}
			AveragePrice = PriceManager.GetProductAveragePrice(CurrentData.UID);
			UpdateContent();
			UpdateMarketHistory();
		}

		protected virtual void UpdateContent()
		{
			m_averagePriceText.text = "Average price : " + AveragePrice.ToStringMoneyFormat();
			m_marketPriceText.text = "Market price : " + PriceManager.GetProductMarketPrice(CurrentData.UID).ToStringMoneyFormat();
			m_currentPriceInputField.text = ((CurrentPrice > 0f) ? CurrentPrice.ToString("0.00") : "- - -");
			m_marginText.text = "Margin : " + (CurrentPrice - AveragePrice).ToStringMoneyFormat();
			m_validateButton.interactable = CurrentPrice > 0f;
		}

		protected virtual void UpdateMarketHistory()
		{
			PriceManager.ProductMarketHistory productMarketHistory = PriceManager.GetProductMarketHistory(CurrentData.UID);
			int num = productMarketHistory.pastPrices.Length;
			Vector2 vector = new Vector2(Mathf.Min(productMarketHistory.pastPrices), Mathf.Max(productMarketHistory.pastPrices));
			Date date = World.TimeController.Date;
			m_historyCurrentPriceText.text = productMarketHistory.pastPrices[0].ToStringMoneyFormat();
			m_historyCurrentPriceText.rectTransform.anchoredPosition = new Vector2(0f, Mathf.InverseLerp(vector.x, vector.y, productMarketHistory.pastPrices[0]) * m_graph.rect.height);
			m_historyMinPriceText.text = vector.x.ToStringMoneyFormat();
			m_historyMaxPriceText.text = vector.y.ToStringMoneyFormat();
			for (int i = 0; i < num; i++)
			{
				if (m_graphPoints.Count == i)
				{
					CreateNewGraphPoint();
				}
				if (m_graphDates.Count == i)
				{
					CreateNewGraphDate();
				}
				if (m_graphLines.Count == i - 1)
				{
					CreateNewGraphLine();
				}
				float x = (float)(-i) * m_graph.rect.width / (float)(num - 1);
				m_graphPoints[i].enabled = true;
				m_graphPoints[i].rectTransform.anchoredPosition = new Vector2(x, Mathf.InverseLerp(vector.x, vector.y, productMarketHistory.pastPrices[i]) * m_graph.rect.height);
				m_graphDates[i].enabled = true;
				m_graphDates[i].rectTransform.anchoredPosition = new Vector2(x, 0f);
				m_graphDates[i].text = date.ToString();
				if (i > 0)
				{
					Vector2 anchoredPosition = m_graphPoints[i - 1].rectTransform.anchoredPosition;
					Vector2 anchoredPosition2 = m_graphPoints[i].rectTransform.anchoredPosition;
					m_graphLines[i - 1].enabled = true;
					m_graphLines[i - 1].rectTransform.anchoredPosition = (anchoredPosition + anchoredPosition2) / 2f;
					m_graphLines[i - 1].rectTransform.right = anchoredPosition - anchoredPosition2;
					m_graphLines[i - 1].rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, (anchoredPosition - anchoredPosition2).magnitude);
				}
				date = date.Yesterday();
			}
			for (int j = num; j < m_graphPoints.Count; j++)
			{
				m_graphPoints[j].enabled = false;
			}
			for (int k = num; k < m_graphLines.Count; k++)
			{
				m_graphLines[k].enabled = false;
			}
			for (int l = num; l < m_graphDates.Count; l++)
			{
				m_graphDates[l].enabled = false;
			}
		}

		protected virtual void CreateNewGraphPoint()
		{
			Image item = Object.Instantiate(m_pointTemplate, m_pointsContainer);
			m_graphPoints.Add(item);
		}

		protected virtual void CreateNewGraphLine()
		{
			Image item = Object.Instantiate(m_lineTemplate, m_linesContainer);
			m_graphLines.Add(item);
		}

		protected virtual void CreateNewGraphDate()
		{
			TextMeshProUGUI item = Object.Instantiate(m_dateTemplate, m_datesContainer);
			m_graphDates.Add(item);
		}

		protected virtual void SetMarketHistoryActive(bool active)
		{
			m_marketHistoryGroup.alpha = (active ? 1f : 0f);
			m_marketHistoryGroup.blocksRaycasts = active;
			if (active)
			{
				if (m_marketHistoryGroup.TryGetComponent<NavBox>(out var component))
				{
					component.SelectFirstChild();
				}
			}
			else
			{
				base.NavBox.SelectFirstChild();
			}
		}

		protected virtual void OnManuallySetPrice(string priceStr)
		{
			if (float.TryParse(priceStr, out var result))
			{
				CurrentPrice = PriceManager.ClampPrice(PriceManager.GetProductMarketPrice(CurrentData.UID), result);
			}
			UpdateContent();
		}

		protected virtual void OnButton_DecreasePrice()
		{
			float currentPrice = (CurrentPrice *= 0.9f);
			CurrentPrice = PriceManager.ClampPrice(PriceManager.GetProductMarketPrice(CurrentData.UID), currentPrice);
			UpdateContent();
		}

		protected virtual void OnButton_IncreasePrice()
		{
			float currentPrice = (CurrentPrice *= 1.1f);
			CurrentPrice = PriceManager.ClampPrice(PriceManager.GetProductMarketPrice(CurrentData.UID), currentPrice);
			UpdateContent();
		}

		protected virtual void OnButton_MarketPrice()
		{
			CurrentPrice = PriceManager.GetProductMarketPrice(CurrentData.UID);
			UpdateContent();
		}

		protected virtual void OnButton_RoundPrice()
		{
			CurrentPrice = Mathf.Round(CurrentPrice);
			UpdateContent();
		}

		protected virtual void OnButton_Validate()
		{
			PriceManager.SetPrice(CurrentData.UID, CurrentPrice);
			Validate();
			Tutorial.TryShow(m_openMiniaturesBoxTutorialData);
		}

		protected virtual void OnButton_MarketHistory()
		{
			SetMarketHistoryActive(active: true);
		}

		protected virtual void OnButton_QuitMarketHistory()
		{
			SetMarketHistoryActive(active: false);
		}
	}
}
