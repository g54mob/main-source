using System;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Simulator.GameWorld
{
	public class ReserveDesk_HUDPopupModule : HUDPopupModule
	{
		[SerializeField]
		private InputHint m_inputHint;

		[Header("Game State")]
		[SerializeField]
		private TextMeshProUGUI m_shopTitleText;

		[SerializeField]
		private Localize m_dayLocalize;

		[SerializeField]
		private TextMeshProUGUI m_shopLevelText;

		[SerializeField]
		private Image m_xpSlider;

		[SerializeField]
		private TextMeshProUGUI m_moneyText;

		[Header("Tabs")]
		[SerializeField]
		private List<NavToggle> m_tabsToggles;

		[SerializeField]
		private List<ReserveDesk_HUDTab> m_tabsContent;

		[SerializeField]
		private ObjectActivator m_tabActivator;

		public override EHUDPopupModuleType Type => EHUDPopupModuleType.RESERVE;

		public int CurrentlyOpenTab { get; private set; } = -1;

		public static event Action Closed;

		protected override void OnEnable()
		{
			base.OnEnable();
			foreach (NavToggle tabsToggle in m_tabsToggles)
			{
				tabsToggle.Toggle.onValueChanged.AddListener(OnTabToggleValueChanged);
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			foreach (NavToggle tabsToggle in m_tabsToggles)
			{
				tabsToggle.Toggle.onValueChanged.RemoveListener(OnTabToggleValueChanged);
			}
		}

		protected override void OnSetActive()
		{
			base.OnSetActive();
			base.NavBox.SetActive();
			UpdateContent();
			OnTabToggleValueChanged(on: true);
			Shop.NameChanged += UpdateShopName;
			GameState.MoneyAmountChanged += OnMoneyAmountChanged;
			GameState.ShopLevelChanged += OnShopLevelChanged;
			m_inputHint.enabled = TransientManager<InputManager>.Instance.CurrentDevice == EInputDeviceType.GAMEPAD;
			InputManager.DeviceChanged += OnDeviceChanged;
		}

		protected override void OnSetInactive()
		{
			base.OnSetInactive();
			base.NavBox.SetInactive();
			m_tabActivator.DeactivateCurrent();
			CurrentlyOpenTab = -1;
			Shop.NameChanged -= UpdateShopName;
			GameState.MoneyAmountChanged -= OnMoneyAmountChanged;
			GameState.ShopLevelChanged -= OnShopLevelChanged;
			InputManager.DeviceChanged -= OnDeviceChanged;
			m_inputHint.enabled = false;
			ReserveDesk_HUDPopupModule.Closed?.Invoke();
		}

		protected virtual void UpdateContent()
		{
			UpdateShopName();
			m_dayLocalize.TermSuffix = " " + World.TimeController.DateElapsed.GetTotalDays();
			m_dayLocalize.OnLocalize(Force: true);
			UpdateShopLevel();
			UpdateMoney();
		}

		private void OpenTab(int type)
		{
			if (CurrentlyOpenTab != type)
			{
				CurrentlyOpenTab = type;
				ReserveDesk_HUDTab reserveDesk_HUDTab = m_tabsContent[CurrentlyOpenTab];
				m_tabActivator.Activate(reserveDesk_HUDTab);
				if ((bool)reserveDesk_HUDTab.NavBox)
				{
					reserveDesk_HUDTab.NavBox.SelectFirstChild();
				}
				else
				{
					base.NavBox.ResumeSelection();
				}
			}
		}

		protected virtual void OnTabToggleValueChanged(bool on)
		{
			if (!on)
			{
				return;
			}
			for (int i = 0; i < m_tabsToggles.Count; i++)
			{
				if (m_tabsToggles[i].Toggle.isOn)
				{
					OpenTab(i);
				}
			}
		}

		private void UpdateShopName()
		{
			m_shopTitleText.text = World.Shop.ShopName;
		}

		private void OnShopLevelChanged(int _)
		{
			UpdateShopLevel();
		}

		private void UpdateShopLevel()
		{
			m_shopLevelText.text = GameState.ShopLevel.ToString();
			m_xpSlider.fillAmount = World.GameState.GetNormalizedShopXP();
		}

		private void OnMoneyAmountChanged(float _)
		{
			UpdateMoney();
		}

		private void UpdateMoney()
		{
			m_moneyText.text = GameState.MoneyAmount.ToStringMoneyFormat();
		}

		private void OnDeviceChanged(EInputDeviceType device)
		{
			m_inputHint.enabled = device == EInputDeviceType.GAMEPAD;
		}
	}
}
