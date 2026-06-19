using System;
using System.Collections.Generic;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class MarketingCampaignMenu : AnimatedMenuBase, IPauseTimeMenu
	{
		[SerializeField]
		private Button _generalTab;

		[SerializeField]
		private Button _illnessTab;

		[SerializeField]
		private Button _recruitmentTab;

		[SerializeField]
		private Button _generalButton;

		[SerializeField]
		private Button _illnessButton;

		[SerializeField]
		private Button _recruitmentButton;

		[SerializeField]
		private Button _generalTabInner;

		[SerializeField]
		private Button _illnessTabInner;

		[SerializeField]
		private Button _recruitmentTabInner;

		[SerializeField]
		private GameObject _listContents;

		[SerializeField]
		private GameObject _listItemPrefab;

		[SerializeField]
		private float _listItemHeight = 60f;

		[SerializeField]
		private TMP_Text _campaignNameText;

		[SerializeField]
		private TMP_Text _campaignDescriptionText;

		[SerializeField]
		private TMP_Text _durationText;

		[SerializeField]
		private Slider _durationSlider;

		[SerializeField]
		private TMP_Text _costText;

		[SerializeField]
		private TMP_Text _costTextLabel;

		[SerializeField]
		private Color[] _costTextColors = new Color[2]
		{
			Color.white,
			Color.red
		};

		[SerializeField]
		private DynamicButton _launchButton;

		[SerializeField]
		private ButtonAnimator _launchButtonAnimator;

		[SerializeField]
		private TMP_Text _launchButtonText;

		[SerializeField]
		private float _nonSelectedFolderAlpha = 0.5f;

		private Level _level;

		private MarketingCampaignComponent _campaignComponent;

		private MarketingCampaignDefinition _selectedCampaign;

		private int _duration;

		private int _cost;

		private readonly List<GameObject> _campaignItems = new List<GameObject>();

		public void Setup(MarketingCampaignComponent campaignComponent, Level level)
		{
			_level = level;
			_campaignComponent = campaignComponent;
			_launchButton.onPrimaryDown.AddListener(LaunchCampaign);
			_generalButton.onClick.AddListener(delegate
			{
				OnSelectCampaignCategory(MarketingCampaignType.General, _generalButton);
			});
			_illnessButton.onClick.AddListener(delegate
			{
				OnSelectCampaignCategory(MarketingCampaignType.Illness, _illnessButton);
			});
			_recruitmentButton.onClick.AddListener(delegate
			{
				OnSelectCampaignCategory(MarketingCampaignType.Recruitment, _recruitmentButton);
			});
			_durationSlider.onValueChanged.AddListener(DurationChanged);
			OnSelectCampaignCategory(MarketingCampaignType.General, _generalButton);
			HUDEvents hUDEvents = _level.HUDEvents;
			hUDEvents.OnMenuOpen = (Action<MenuBase>)Delegate.Combine(hUDEvents.OnMenuOpen, new Action<MenuBase>(OnMenuOpen));
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Combine(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
			_level.HospitalHUDManager.HideRibbonMenu();
			_level.HospitalHUDManager.HideAllInfoMenus();
			HospitalHUDManager hospitalHUDManager = _level.HospitalHUDManager;
			hospitalHUDManager.OnRibbonMenuEnterMode = (Action<RibbonMenu.Mode>)Delegate.Combine(hospitalHUDManager.OnRibbonMenuEnterMode, new Action<RibbonMenu.Mode>(OnRibbonMenuEnterMode));
			LocalizationManager.OnLocalizeEvent += OnLocalize;
		}

		public override void Destroy()
		{
			HUDEvents hUDEvents = _level.HUDEvents;
			hUDEvents.OnMenuOpen = (Action<MenuBase>)Delegate.Remove(hUDEvents.OnMenuOpen, new Action<MenuBase>(OnMenuOpen));
			FinanceManager financeManager = _level.FinanceManager;
			financeManager.OnBalanceUpdated = (Action<int>)Delegate.Remove(financeManager.OnBalanceUpdated, new Action<int>(OnBalanceUpdated));
			HospitalHUDManager hospitalHUDManager = _level.HospitalHUDManager;
			hospitalHUDManager.OnRibbonMenuEnterMode = (Action<RibbonMenu.Mode>)Delegate.Remove(hospitalHUDManager.OnRibbonMenuEnterMode, new Action<RibbonMenu.Mode>(OnRibbonMenuEnterMode));
			LocalizationManager.OnLocalizeEvent -= OnLocalize;
		}

		private void OnLocalize()
		{
			OnSelectCampaign(_selectedCampaign, null);
			RefreshUI();
		}

		private void OnMenuOpen(MenuBase menuBase)
		{
			if (menuBase != this)
			{
				if (base.isActiveAndEnabled)
				{
					CloseMenu();
				}
				else
				{
					CloseMenuImmediately();
				}
			}
		}

		private void OnRibbonMenuEnterMode(RibbonMenu.Mode mode)
		{
			CloseMenu();
		}

		private void LaunchCampaign()
		{
			_campaignComponent.StartCampaign(_selectedCampaign, _duration);
			CloseMenu();
		}

		private void OnBalanceUpdated(int balance)
		{
			RefreshUI();
		}

		private void DurationChanged(float value)
		{
			_duration = Mathf.Clamp((int)value, _selectedCampaign.MinDuration, _selectedCampaign.MaxDuration);
			RefreshUI();
		}

		private void OnSelectCampaignCategory(MarketingCampaignType type, Button button)
		{
			List<MarketingCampaignDefinition> campaigns = _level.MarketingManager.GetCampaigns(type);
			_campaignItems.ClearAndDestroy();
			for (int i = 0; i < campaigns.Count; i++)
			{
				MarketingCampaignDefinition campaign = campaigns[i];
				GameObject gameObject = UnityEngine.Object.Instantiate(_listItemPrefab, _listContents.transform, worldPositionStays: false);
				MarketingCampaignListItem campaignItem = gameObject.GetComponent<MarketingCampaignListItem>();
				campaignItem.Name.text = campaign.NameLocalised.Translation;
				campaignItem.Button.onClick.AddListener(delegate
				{
					OnSelectCampaign(campaign, campaignItem.Button);
				});
				_campaignItems.Add(gameObject);
			}
			if (_campaignItems.Count == 0)
			{
				OnSelectCampaign(null, null);
			}
			else
			{
				OnSelectCampaign(campaigns[0], _campaignItems[0].GetComponent<MarketingCampaignListItem>().Button);
			}
			GameObjectUtils.SetInteractable(_generalButton, interactable: true);
			GameObjectUtils.SetInteractable(_illnessButton, interactable: true);
			GameObjectUtils.SetInteractable(_recruitmentButton, interactable: true);
			GameObjectUtils.SetInteractable(button, interactable: false);
			GameObjectUtils.SetActive(_generalTabInner.gameObject, isActive: false);
			GameObjectUtils.SetActive(_illnessTabInner.gameObject, isActive: false);
			GameObjectUtils.SetActive(_recruitmentTabInner.gameObject, isActive: false);
			switch (type)
			{
			case MarketingCampaignType.General:
				GameObjectUtils.SetActive(_generalTabInner.gameObject, isActive: true);
				break;
			case MarketingCampaignType.Illness:
				GameObjectUtils.SetActive(_illnessTabInner.gameObject, isActive: true);
				break;
			case MarketingCampaignType.Recruitment:
				GameObjectUtils.SetActive(_recruitmentTabInner.gameObject, isActive: true);
				break;
			}
			Button button2 = _generalTab;
			switch (type)
			{
			case MarketingCampaignType.General:
				button2 = _generalTab;
				break;
			case MarketingCampaignType.Illness:
				button2 = _illnessTab;
				break;
			case MarketingCampaignType.Recruitment:
				button2 = _recruitmentTab;
				break;
			}
			button2.transform.SetAsLastSibling();
			SetCampaignCategoryTabTransparency(_generalTab.gameObject, _nonSelectedFolderAlpha);
			SetCampaignCategoryTabTransparency(_illnessTab.gameObject, _nonSelectedFolderAlpha);
			SetCampaignCategoryTabTransparency(_recruitmentTab.gameObject, _nonSelectedFolderAlpha);
			SetCampaignCategoryTabTransparency(button2.gameObject, 1f);
			ScrollRect componentInParent = _listContents.GetComponentInParent<ScrollRect>();
			if (componentInParent != null)
			{
				componentInParent.verticalNormalizedPosition = 1f;
				componentInParent.content.sizeDelta = new Vector2(componentInParent.content.sizeDelta.x, (float)_campaignItems.Count * _listItemHeight);
			}
		}

		private void SetCampaignCategoryTabTransparency(GameObject tabObject, float alphaValue)
		{
			if (tabObject != null)
			{
				Image[] componentsInChildren = tabObject.GetComponentsInChildren<Image>();
				foreach (Image obj in componentsInChildren)
				{
					Color color = obj.color;
					color.a = alphaValue;
					obj.color = color;
				}
				TMP_Text[] componentsInChildren2 = tabObject.GetComponentsInChildren<TMP_Text>();
				foreach (TMP_Text obj2 in componentsInChildren2)
				{
					Color color2 = obj2.color;
					color2.a = alphaValue;
					obj2.color = color2;
				}
			}
		}

		private void OnSelectCampaign(MarketingCampaignDefinition campaign, Button button)
		{
			_selectedCampaign = campaign;
			if (campaign == null)
			{
				EnableCampaignDetails(enable: false);
				return;
			}
			EnableCampaignDetails(enable: true);
			OnBalanceUpdated(0);
			_campaignNameText.text = campaign.NameLocalised.Translation;
			_campaignDescriptionText.text = campaign.DescriptionLocalised.Translation;
			_durationSlider.minValue = campaign.MinDuration;
			_durationSlider.maxValue = campaign.MaxDuration;
			DurationChanged(_durationSlider.value);
			if (!(button != null))
			{
				return;
			}
			foreach (GameObject campaignItem in _campaignItems)
			{
				MarketingCampaignListItem component = campaignItem.GetComponent<MarketingCampaignListItem>();
				GameObjectUtils.SetInteractable(component.Button, interactable: true);
				component.Name.color = ((component.Button == button) ? Color.black : Color.white);
			}
			GameObjectUtils.SetInteractable(button, interactable: false);
		}

		private void RefreshUI()
		{
			if (_selectedCampaign != null)
			{
				_cost = _selectedCampaign.LaunchCost + _duration * _selectedCampaign.MonthlySpend;
				bool flag = _level.FinanceManager.CanAfford(_cost);
				string text = ScriptLocalization.Menu_Marketing.Duration_CS;
				string text2 = StringUtils.FormatCurrency(_cost);
				LocalisationParams.Set("MONTHS", _duration);
				LocalisationParams.Localise(ref text);
				_costText.text = text2;
				_costText.color = _costTextColors[(!flag) ? 1u : 0u];
				_durationText.text = text;
				SetLaunchButtonState(flag);
			}
		}

		private void EnableCampaignDetails(bool enable)
		{
			SetLaunchButtonState(enable);
			GameObjectUtils.SetActive(_durationText.gameObject, enable);
			GameObjectUtils.SetActive(_durationSlider.gameObject, enable);
			GameObjectUtils.SetActive(_campaignNameText.gameObject, enable);
			GameObjectUtils.SetActive(_campaignDescriptionText.gameObject, enable);
			GameObjectUtils.SetActive(_costText.gameObject, enable);
			GameObjectUtils.SetActive(_costTextLabel.gameObject, enable);
		}

		private void SetLaunchButtonState(bool enable)
		{
			if (_launchButton.interactable != enable)
			{
				_launchButton.interactable = enable;
				_launchButtonAnimator.CurrentState = ((!enable) ? ButtonAnimator.State.Unselectable : ButtonAnimator.State.Selectable);
				if (enable)
				{
					_launchButtonText.alpha = 1f;
				}
				else
				{
					_launchButtonText.alpha = 0.5f;
				}
			}
		}
	}
}
