using System;
using DG.Tweening;
using Data.FactoryFloor.Resources;
using Data.SaveData.PersistentSOs;
using Presentation.Locators;
using Presentation.UI.Buttons;
using Presentation.UI.Menus.MenuEvents.MenuData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Menus
{
	public class UnlockIslandDialog : UIMenu
	{
		[SerializeField]
		protected UIMenuManagerLocator _uiMenuManagerLocator;

		[SerializeField]
		private CurrencyPersistentSO _currency;

		[SerializeField]
		private GoBackSourceSO _unlockIslandDialogGoBackSource;

		[SerializeField]
		private ResourceDataSO _expansionPermitResourceData;

		[Header("Layout")]
		[SerializeField]
		private Button _bgButton;

		[SerializeField]
		private TMP_Text _headerText;

		[SerializeField]
		private TMP_Text _contentText;

		[SerializeField]
		private Image _mainPanelImage;

		[SerializeField]
		private Sprite _mainPanelDefaultSprite;

		[Header("Buttons")]
		[SerializeField]
		private Button _successButton;

		[SerializeField]
		private ButtonEnabler _successButtonEnabler;

		[SerializeField]
		private TextMeshProUGUI _successButtonText;

		[SerializeField]
		private Button _cancelButton;

		[SerializeField]
		private TextMeshProUGUI _cancelButtonText;

		[Header("Localization")]
		[SerializeField]
		[LocaKey]
		private string _headerLocKey;

		[SerializeField]
		[LocaKey]
		private string _contentBuyLocKey;

		[SerializeField]
		[LocaKey]
		private string _contentCantAffordLocKey;

		[SerializeField]
		[LocaKey]
		private string _contentNotAvaliableLocKey;

		[SerializeField]
		[LocaKey]
		private string _successButtonLocKey;

		[SerializeField]
		[LocaKey]
		private string _cancelButtonLocKey;

		[SerializeField]
		private Color _affordableColor;

		[SerializeField]
		private Color _cantAffordColor;

		[Header("Demo Locked content")]
		[SerializeField]
		private UnlockedIslandsPersistentSO _unlockedIslandsPersistentSO;

		[SerializeField]
		[LocaKey]
		private string _demoBlockedDescriptionLocKey;

		[SerializeField]
		private Sprite _demoBlockedSprite;

		private Action _successCallback;

		private Action _cancelCallback;

		private UnlockIslandDialogDto _dto;

		private void Awake()
		{
			base.gameObject.SetActive(value: false);
			_bgButton.onClick.AddListener(OnPanelPressed);
			LocalizationUtility.OnLanguageUpdate += SetTexts;
			SetTexts();
		}

		private void OnDestroy()
		{
			LocalizationUtility.OnLanguageUpdate -= SetTexts;
			_bgButton.onClick.RemoveListener(OnPanelPressed);
		}

		private void SetTexts()
		{
			_headerText.SetText(LocalizationUtility.GetLocalizedText(_headerLocKey));
			_successButtonText.SetText(LocalizationUtility.GetLocalizedText(_successButtonLocKey));
			_cancelButtonText.SetText(LocalizationUtility.GetLocalizedText(_cancelButtonLocKey));
		}

		public override void ShowMenu(AbstractUIMenuData menuData)
		{
			_dto = menuData as UnlockIslandDialogDto;
			SetButtons(_dto);
			if (_unlockedIslandsPersistentSO.UnlockedIslandCount >= UnlockedIslandsPersistentSO.MAX_DEMO_UNLOCKABLE_ISLAND_COUNT)
			{
				SetLockedInDemoContent();
				base.gameObject.SetActive(value: true);
				return;
			}
			if (!_dto.IsAvaliable)
			{
				SetContentNotAvaliable();
			}
			else if (!_currency.HasEnoughResources(_dto.ResourceCost))
			{
				SetContentCantAfford();
			}
			else
			{
				SetContent();
			}
			base.gameObject.SetActive(value: true);
		}

		private void SetLockedInDemoContent()
		{
			_successButtonEnabler.Interactable = false;
			_cancelButton.gameObject.SetActive(value: true);
			_contentText.SetText(LocalizationUtility.GetLocalizedText(_demoBlockedDescriptionLocKey));
			_contentText.color = _cantAffordColor;
			_mainPanelImage.sprite = _demoBlockedSprite;
		}

		public override void HideMenu()
		{
			base.gameObject.SetActive(value: false);
		}

		private void SetContent()
		{
			_successButtonEnabler.Interactable = true;
			_cancelButton.gameObject.SetActive(value: true);
			string localizedText = LocalizationUtility.GetLocalizedText(_contentBuyLocKey);
			localizedText = string.Format(localizedText, _dto.ResourceCost.GetCost(_expansionPermitResourceData));
			_contentText.SetText(localizedText);
			_contentText.color = _affordableColor;
			_mainPanelImage.sprite = _mainPanelDefaultSprite;
		}

		private void SetContentCantAfford()
		{
			_successButtonEnabler.Interactable = false;
			_cancelButton.gameObject.SetActive(value: true);
			string localizedText = LocalizationUtility.GetLocalizedText(_contentCantAffordLocKey);
			localizedText = string.Format(localizedText, _dto.ResourceCost.GetCost(_expansionPermitResourceData));
			_contentText.SetText(localizedText);
			_contentText.color = _cantAffordColor;
			_mainPanelImage.sprite = _mainPanelDefaultSprite;
		}

		private void SetContentNotAvaliable()
		{
			_successButtonEnabler.Interactable = false;
			_cancelButton.gameObject.SetActive(value: true);
			_contentText.SetText(LocalizationUtility.GetLocalizedText(_contentNotAvaliableLocKey));
			_contentText.color = _cantAffordColor;
			_mainPanelImage.sprite = _mainPanelDefaultSprite;
		}

		private void SetButtons(UnlockIslandDialogDto dto)
		{
			_successCallback = dto.SuccessCallback;
			_successButton.onClick.AddListener(OnSuccessButtonClicked);
			_cancelCallback = dto.CancelCallback;
			_cancelButton.onClick.AddListener(OnCancelButtonClicked);
		}

		private void OnPanelPressed()
		{
			if (!_successButtonEnabler.Interactable)
			{
				RectTransform obj = _successButton.transform as RectTransform;
				obj.DOKill();
				obj.localScale = Vector3.one;
				obj.DOPunchScale(Vector2.one * 0.3f, 0.2f, 4);
			}
		}

		private void OnSuccessButtonClicked()
		{
			_successButton.onClick.RemoveListener(OnSuccessButtonClicked);
			_cancelButton.onClick.RemoveListener(OnCancelButtonClicked);
			_uiMenuManagerLocator.UIMenuManager.GoBack(_unlockIslandDialogGoBackSource);
			_successCallback?.Invoke();
		}

		private void OnCancelButtonClicked()
		{
			_successButton.onClick.RemoveListener(OnSuccessButtonClicked);
			_cancelButton.onClick.RemoveListener(OnCancelButtonClicked);
			_uiMenuManagerLocator.UIMenuManager.GoBack(_unlockIslandDialogGoBackSource);
			_cancelCallback?.Invoke();
		}
	}
}
