using System;
using I2.Loc;
using TMPro;
using Tabletop;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	public class ReserveDesk_HUDTab_Gestion : ReserveDesk_HUDTab
	{
		[Header("Shop Name")]
		[SerializeField]
		private NavInputField m_nameInputField;

		[SerializeField]
		private NavButton m_nameValidateButton;

		[Header("Score")]
		[SerializeField]
		private RectTransform m_scoreStarsContainer;

		[SerializeField]
		private Sprite m_fullStarSprite;

		[SerializeField]
		private TextMeshProUGUI m_scoreValueText;

		[SerializeField]
		private TextMeshProUGUI m_enteringShopScoreBonusText;

		[SerializeField]
		private Color m_enteringBonusPositiveColor;

		[SerializeField]
		private Color m_enteringBonusNegativeColor;

		[Header("Extensions")]
		[SerializeField]
		[TermsPopup("")]
		private string m_extensionTerm;

		[SerializeField]
		[TermsPopup("")]
		private string m_extensionTooExpensiveTerm;

		[SerializeField]
		[TermsPopup("")]
		private string m_extensionLevelInsufficientTerm;

		[SerializeField]
		[TermsPopup("")]
		private string m_extensionMaxTerm;

		[Header("Shop Extension")]
		[SerializeField]
		private GameObject m_shopExtensionShopLevelContainer;

		[SerializeField]
		private TextMeshProUGUI m_shopExtensionShopLevelText;

		[SerializeField]
		private Image m_shopExtensionImage;

		[SerializeField]
		private Sprite m_shopExtensionDefaultSprite;

		[SerializeField]
		private Sprite m_shopExtensionDisabledSprite;

		[SerializeField]
		private Localize m_shopExtensionLevelText;

		[SerializeField]
		private TextMeshProUGUI m_shopExtensionCostText;

		[SerializeField]
		private NavButton m_shopExtensionButton;

		[Header("Reserve Extension")]
		[SerializeField]
		private GameObject m_reserveExtensionShopLevelContainer;

		[SerializeField]
		private TextMeshProUGUI m_reserveExtensionShopLevelText;

		[SerializeField]
		private Image m_reserveExtensionImage;

		[SerializeField]
		private Sprite m_reserveExtensionDefaultSprite;

		[SerializeField]
		private Sprite m_reserveExtensionDisabledSprite;

		[SerializeField]
		private Localize m_reserveExtensionLevelText;

		[SerializeField]
		private TextMeshProUGUI m_reserveExtensionCostText;

		[SerializeField]
		private NavButton m_reserveExtensionButton;

		[Header("Bills")]
		[SerializeField]
		private GameObject m_billsContainer;

		[SerializeField]
		private GameObject m_billsPayedContainer;

		[SerializeField]
		private TextMeshProUGUI m_rentUnpayedDaysText;

		[SerializeField]
		private TextMeshProUGUI m_rentDueText;

		[SerializeField]
		private Button m_rentPayButton;

		[SerializeField]
		private TextMeshProUGUI m_elecUnpayedDaysText;

		[SerializeField]
		private TextMeshProUGUI m_elecDueText;

		[SerializeField]
		private Button m_elecPayButton;

		[Space(10f)]
		[SerializeField]
		private TextMeshProUGUI m_totalBillsText;

		[SerializeField]
		private Button m_payAllBillsButton;

		private bool IsBillPayed
		{
			get
			{
				if (World.BillsManager.RentBill.DueAmount == 0f)
				{
					return World.BillsManager.ElecBill.DueAmount == 0f;
				}
				return false;
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			m_nameInputField.InputField.onSubmit.AddListener(OnShopNameValueChanged);
			m_nameInputField.InputField.onSelect.AddListener(OnInputField_Selected);
			m_nameInputField.InputField.onDeselect.AddListener(OnInputField_Deselected);
			m_nameValidateButton.Button.onClick.AddListener(OnButton_Validate);
			m_shopExtensionButton.Button.onClick.AddListener(OnButton_ExtendShop);
			m_shopExtensionButton.InteractabilityChanged += OnExtensionInteractabilityChanged;
			m_reserveExtensionButton.Button.onClick.AddListener(OnButton_ExtendReserve);
			m_reserveExtensionButton.InteractabilityChanged += OnExtensionInteractabilityChanged;
			m_rentPayButton.onClick.AddListener(OnButton_PayRent);
			m_elecPayButton.onClick.AddListener(OnButton_PayElec);
			m_payAllBillsButton.onClick.AddListener(OnButton_PayAllBills);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			m_nameInputField.InputField.onSubmit.RemoveListener(OnShopNameValueChanged);
			m_nameInputField.InputField.onSelect.RemoveListener(OnInputField_Selected);
			m_nameInputField.InputField.onDeselect.RemoveListener(OnInputField_Deselected);
			m_nameValidateButton.Button.onClick.RemoveListener(OnButton_Validate);
			m_shopExtensionButton.Button.onClick.RemoveListener(OnButton_ExtendShop);
			m_reserveExtensionButton.Button.onClick.RemoveListener(OnButton_ExtendReserve);
			m_rentPayButton.onClick.RemoveListener(OnButton_PayRent);
			m_elecPayButton.onClick.RemoveListener(OnButton_PayElec);
			m_payAllBillsButton.onClick.RemoveListener(OnButton_PayAllBills);
		}

		protected override void OnSetActive()
		{
			UpdateContent();
			GameState.MoneyAmountChanged += OnMoneyAmountChanged;
			GameState.ShopLevelChanged += OnShopLevelChanged;
			ScoreManager.ScoreChanged += OnScoreChanged;
			ShopExtensionSystem.ShopExtensionBought += OnShopExtensionBought;
			ShopExtensionSystem.ReserveExtensionBought += OnReserveExtensionBought;
			World.BillsManager.RentBill.OnPay += UpdateBills;
			World.BillsManager.ElecBill.OnPay += UpdateBills;
		}

		protected override void OnSetInactive()
		{
			GameState.MoneyAmountChanged -= OnMoneyAmountChanged;
			GameState.ShopLevelChanged -= OnShopLevelChanged;
			ScoreManager.ScoreChanged -= OnScoreChanged;
			ShopExtensionSystem.ShopExtensionBought -= OnShopExtensionBought;
			ShopExtensionSystem.ReserveExtensionBought -= OnReserveExtensionBought;
			World.BillsManager.RentBill.OnPay -= UpdateBills;
			World.BillsManager.ElecBill.OnPay -= UpdateBills;
		}

		protected virtual void UpdateContent()
		{
			UpdateName();
			UpdateScore();
			UpdateShopExtension();
			UpdateReserveExtension();
			UpdateBills();
		}

		protected virtual void UpdateName()
		{
			m_nameInputField.InputField.text = World.Shop.ShopName;
		}

		protected virtual void UpdateScore()
		{
			Image[] componentsInChildren = m_scoreStarsContainer.GetComponentsInChildren<Image>();
			int num = (int)MathF.Round((float)World.ScoreManager.CurrentScore / (float)ScoreSettings.MaxScore * (float)componentsInChildren.Length);
			for (int i = 0; i < num; i++)
			{
				componentsInChildren[i].sprite = m_fullStarSprite;
			}
			m_scoreValueText.text = World.ScoreManager.CurrentScore.ToString();
			float computedValue = ScoreSettings.EnteringShopPercentageOnScoreChanged.GetComputedValue(0f);
			m_enteringShopScoreBonusText.text = computedValue.ToStringPercentFormat();
			if (computedValue > 0f)
			{
				m_enteringShopScoreBonusText.color = m_enteringBonusPositiveColor;
			}
			else if (computedValue < 0f)
			{
				m_enteringShopScoreBonusText.color = m_enteringBonusNegativeColor;
			}
		}

		protected virtual void UpdateShopExtension()
		{
			float currentShopExtensionPrice = ShopExtensionSettings.GetCurrentShopExtensionPrice();
			bool flag = GameState.MoneyAmount < currentShopExtensionPrice;
			bool flag2 = GameState.ShopLevel < ShopExtensionSettings.GetCurrentShopExtensionShopLevel();
			bool flag3 = ShopExtensionSettings.CanExtendShop();
			m_shopExtensionShopLevelContainer.SetActive(flag2);
			m_shopExtensionShopLevelText.text = ShopExtensionSettings.GetCurrentShopExtensionShopLevel().ToString();
			if (flag || flag2)
			{
				m_shopExtensionImage.sprite = m_shopExtensionDisabledSprite;
			}
			else
			{
				m_shopExtensionImage.sprite = m_shopExtensionDefaultSprite;
			}
			int shopExtensionMarketStoreLevel = ShopExtensionSettings.GetShopExtensionMarketStoreLevel(ShopExtensionSystem.ShopExtensionLevel);
			int shopExtensionMarketStoreLevel2 = ShopExtensionSettings.GetShopExtensionMarketStoreLevel(ShopExtensionSettings.ShopExtensionMaxLevel);
			m_shopExtensionLevelText.TermSuffix = " " + shopExtensionMarketStoreLevel + "/" + shopExtensionMarketStoreLevel2;
			m_shopExtensionLevelText.OnLocalize(Force: true);
			m_shopExtensionCostText.gameObject.SetActive(!flag2);
			if (flag3)
			{
				m_shopExtensionCostText.text = currentShopExtensionPrice.ToStringMoneyFormat();
			}
			else
			{
				m_shopExtensionCostText.text = "-";
			}
			m_shopExtensionButton.SetInteractable(!flag && !flag2 && flag3);
			if (flag2)
			{
				m_shopExtensionButton.Text.SetTerm(m_extensionLevelInsufficientTerm);
			}
			else if (flag)
			{
				m_shopExtensionButton.Text.SetTerm(m_extensionTooExpensiveTerm);
			}
			else if (!flag3)
			{
				m_shopExtensionButton.Text.SetTerm(m_extensionMaxTerm);
			}
			else
			{
				m_shopExtensionButton.Text.SetTerm(m_extensionTerm);
			}
		}

		protected virtual void UpdateReserveExtension()
		{
			float currentReserveExtensionPrice = ShopExtensionSettings.GetCurrentReserveExtensionPrice();
			bool flag = GameState.MoneyAmount < currentReserveExtensionPrice;
			bool flag2 = GameState.ShopLevel < ShopExtensionSettings.GetCurrentReserveExtensionShopLevel();
			bool flag3 = ShopExtensionSettings.CanExtendReserve();
			m_reserveExtensionShopLevelContainer.SetActive(flag2);
			m_reserveExtensionShopLevelText.text = ShopExtensionSettings.GetCurrentReserveExtensionShopLevel().ToString();
			if (flag || flag2)
			{
				m_reserveExtensionImage.sprite = m_reserveExtensionDisabledSprite;
			}
			else
			{
				m_reserveExtensionImage.sprite = m_reserveExtensionDefaultSprite;
			}
			int reserveExtensionMarketStoreLevel = ShopExtensionSettings.GetReserveExtensionMarketStoreLevel(ShopExtensionSystem.ReserveExtensionLevel);
			int reserveExtensionMarketStoreLevel2 = ShopExtensionSettings.GetReserveExtensionMarketStoreLevel(ShopExtensionSettings.ReserveExtensionMaxLevel);
			m_reserveExtensionLevelText.TermSuffix = " " + reserveExtensionMarketStoreLevel + "/" + reserveExtensionMarketStoreLevel2;
			m_reserveExtensionLevelText.OnLocalize(Force: true);
			m_reserveExtensionCostText.gameObject.SetActive(!flag2);
			if (flag3)
			{
				m_reserveExtensionCostText.text = currentReserveExtensionPrice.ToStringMoneyFormat();
			}
			else
			{
				m_reserveExtensionCostText.text = "-";
			}
			m_reserveExtensionButton.SetInteractable(!flag && !flag2 && flag3);
			if (flag2)
			{
				m_reserveExtensionButton.Text.SetTerm(m_extensionLevelInsufficientTerm);
			}
			else if (flag)
			{
				m_reserveExtensionButton.Text.SetTerm(m_extensionTooExpensiveTerm);
			}
			else if (!flag3)
			{
				m_reserveExtensionButton.Text.SetTerm(m_extensionMaxTerm);
			}
			else
			{
				m_reserveExtensionButton.Text.SetTerm(m_extensionTerm);
			}
		}

		protected virtual void UpdateBills()
		{
			bool isBillPayed = IsBillPayed;
			m_billsContainer.SetActive(!isBillPayed);
			m_billsPayedContainer.SetActive(isBillPayed);
			m_rentUnpayedDaysText.text = World.BillsManager.RentBill.UnpaidDays.ToString();
			m_rentDueText.text = World.BillsManager.RentBill.DueAmount.ToStringMoneyFormat();
			m_elecUnpayedDaysText.text = World.BillsManager.ElecBill.UnpaidDays.ToString();
			m_elecDueText.text = World.BillsManager.ElecBill.DueAmount.ToStringMoneyFormat();
			m_totalBillsText.text = (World.BillsManager.RentBill.DueAmount + World.BillsManager.ElecBill.DueAmount).ToStringMoneyFormat();
		}

		private void OnShopNameValueChanged(string name)
		{
			if (TransientManager<InputManager>.Instance.CurrentDevice == EInputDeviceType.KEYBOARD)
			{
				SetName(name);
				m_nameInputField.Select();
			}
		}

		private void OnInputField_Selected(string str)
		{
			InputManager.InputFieldFocused = true;
		}

		private void OnInputField_Deselected(string str)
		{
			InputManager.InputFieldFocused = false;
		}

		private void OnButton_Validate()
		{
			SetName(m_nameInputField.InputField.text);
		}

		private void SetName(string newName)
		{
			if (ProfanityManager.ProfanityFilter.ContainsProfanity(newName))
			{
				m_nameInputField.InputField.text = World.Shop.ShopName;
			}
			else
			{
				World.Shop.ShopName = newName;
			}
		}

		protected virtual void OnScoreChanged(int previousScore, int currentScore)
		{
			UpdateScore();
		}

		protected virtual void OnShopExtensionBought(int shopExtensionLevel)
		{
			UpdateShopExtension();
		}

		protected virtual void OnReserveExtensionBought(int reserveExtensionLevel)
		{
			UpdateReserveExtension();
		}

		protected virtual void OnButton_ExtendShop()
		{
			float currentShopExtensionPrice = ShopExtensionSettings.GetCurrentShopExtensionPrice();
			if (World.GameState.ConsumeMoney(currentShopExtensionPrice))
			{
				ShopExtensionSystem.BuyNextShopExtension();
			}
		}

		protected virtual void OnButton_ExtendReserve()
		{
			float currentReserveExtensionPrice = ShopExtensionSettings.GetCurrentReserveExtensionPrice();
			if (World.GameState.ConsumeMoney(currentReserveExtensionPrice))
			{
				ShopExtensionSystem.BuyNextReserveExtension();
			}
		}

		protected virtual void OnButton_PayRent()
		{
			if (World.BillsManager.RentBill.TryPay() && IsBillPayed)
			{
				base.NavBox.SelectFirstChild();
			}
		}

		protected virtual void OnButton_PayElec()
		{
			if (World.BillsManager.ElecBill.TryPay() && IsBillPayed)
			{
				base.NavBox.SelectFirstChild();
			}
		}

		protected virtual void OnButton_PayAllBills()
		{
			World.BillsManager.RentBill.TryPay();
			World.BillsManager.ElecBill.TryPay();
			base.NavBox.SelectFirstChild();
		}

		private void OnExtensionInteractabilityChanged(bool interactable)
		{
			if (!interactable)
			{
				base.NavBox.SelectFirstChild(searchForFirstElement: true);
			}
		}

		private void OnMoneyAmountChanged(float _)
		{
			UpdateShopExtension();
			UpdateReserveExtension();
			UpdateBills();
		}

		private void OnShopLevelChanged(int _)
		{
			UpdateShopExtension();
			UpdateReserveExtension();
		}
	}
}
