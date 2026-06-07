#define ENABLE_DEBUG_LOGS
using System;
using System.Collections.Generic;
using Data.FeatureFlags.Validators;
using Data.Quests.SubQuestEvents;
using Data.Variables;
using Data.Variables.Milestones;
using Events;
using Events.UI.Overlays;
using Integrations;
using Presentation.Locators;
using Presentation.UI.Menus.MenuEvents;
using Presentation.UI.Menus.MenuEvents.ModalDialogData;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;
using Utils.Enums;

namespace Presentation.UI
{
	public class MainMenu : MonoBehaviour
	{
		[SerializeField]
		private Button _quitButton;

		[SerializeField]
		private TextMeshProUGUI _versionTextfield;

		[SerializeField]
		private BoolVariableSO _showUserName;

		[SerializeField]
		private BaseEvent _finishedLoadingSaveEvent;

		[SerializeField]
		private ShowUIMenuEvent _showUIMenuEvent;

		[SerializeField]
		private FeatureFlagValidator _demoFeaturesValidator;

		[SerializeField]
		private IntegrationManagerLocator _integrationManagerLocator;

		[SerializeField]
		private Image _logoImage;

		[SerializeField]
		private Sprite _supportersEditionLogo;

		[SerializeField]
		private GameObject _supporterEditionLabel;

		[Header("Extra Modals")]
		[SerializeField]
		private ShowModalDialogEvent _showModalDialogEvent;

		[SerializeField]
		private List<ModelDialogPageContent> _pages = new List<ModelDialogPageContent>();

		[SerializeField]
		private SupportersEditionModalVariableSO _supportersEditionModalVariable;

		[SerializeField]
		[LocaKey]
		private string _gdprTitle = "IntroScreen.GDPRDisclaimer";

		[SerializeField]
		private GDPRModalVariableSO _gDPRModalVariableSO;

		private void Awake()
		{
			_versionTextfield.SetText("v" + Application.version);
			_quitButton.onClick.AddListener(OnQuitButtonClicked);
			_showUserName.ValueChanged += UpdateUserNameUI;
			UpdateUserNameUI(_showUserName.Value);
			UpdateRichPresence();
			IPlatformHandler platform = _integrationManagerLocator.Integration.Platform;
			platform.OnPlatformReady = (Action)Delegate.Combine(platform.OnPlatformReady, new Action(OnIntegrationsReady));
			IntegrationManager integration = _integrationManagerLocator.Integration;
			integration.OnSocialPlatformsReady = (Action)Delegate.Combine(integration.OnSocialPlatformsReady, new Action(OnSocialPlatformsReady));
		}

		private void Start()
		{
			_finishedLoadingSaveEvent.Fire();
			if (_integrationManagerLocator.Integration.IsSupportersEdition())
			{
				_supporterEditionLabel.SetActive(value: true);
				ShowSupportersEditionAssets();
				ShowGDPRModal();
				_gDPRModalVariableSO.SetValue(value: true);
			}
			else
			{
				_supporterEditionLabel.SetActive(value: false);
				ShowGDPRModal();
			}
		}

		private void ShowGDPRModal()
		{
			if (_gDPRModalVariableSO.Value)
			{
				this.Log("Skipping GDPR modal, because it was already shown!", "ShowGDPRModal", 78);
				return;
			}
			UIModaldialogData data = new UIModaldialogData(new ModalDialogDto(new ModalDialogContent[1]
			{
				new ModalDialogContent(string.Empty, _gdprTitle)
			}, Sizes.M, delegate
			{
				_gDPRModalVariableSO.SetValue(value: true);
			}));
			_showModalDialogEvent.Fire(data);
		}

		private void ShowSupportersEditionAssets()
		{
			_logoImage.overrideSprite = _supportersEditionLogo;
			if (!_supportersEditionModalVariable.Value)
			{
				ShowSupportersEditionModal();
			}
		}

		private void ShowSupportersEditionModal()
		{
			ModalDialogContent[] array = new ModalDialogContent[_pages.Count];
			for (int i = 0; i < _pages.Count; i++)
			{
				array[i] = new ModalDialogContent(_pages[i].TitleKey, _pages[i].TextKey, _pages[i].VideoName, _pages[i].Sprite, _pages[i].ExtraTextKey);
			}
			UIModaldialogData data = new UIModaldialogData(new ModalDialogDto(array, Sizes.L, delegate
			{
				_supportersEditionModalVariable.SetValue(value: true);
			}));
			_showModalDialogEvent.Fire(data);
		}

		private void OnIntegrationsReady()
		{
			UpdateUserNameUI(_showUserName.Value);
		}

		private void OnSocialPlatformsReady()
		{
			UpdateRichPresence();
		}

		private void UpdateRichPresence()
		{
			_integrationManagerLocator.Integration.UpdateSocialPresenceIdleInMainMenu();
		}

		private void OnDestroy()
		{
			_quitButton.onClick.RemoveListener(OnQuitButtonClicked);
			_showUserName.ValueChanged -= UpdateUserNameUI;
			IPlatformHandler platform = _integrationManagerLocator.Integration.Platform;
			platform.OnPlatformReady = (Action)Delegate.Remove(platform.OnPlatformReady, new Action(OnIntegrationsReady));
		}

		private void UpdateUserNameUI(bool value)
		{
			_versionTextfield.SetText((value ? (_integrationManagerLocator.Integration.Platform.GetUserName() + " <br> ") : string.Empty) + "v" + Application.version);
		}

		private void OnQuitButtonClicked()
		{
			MenuModalDialogDto dto = new MenuModalDialogDto("General.ExitWarning", Sizes.S, ApplicationUtils.QuitApplication, showCancelButton: true)
			{
				OverrideSuccessButtonTextKey = "ModalGeneric.YesButton",
				OverrideCancelButtonTextKey = "ModalGeneric.NoButton"
			};
			_showModalDialogEvent.Fire(new UIMenuModalDialogData(dto));
		}
	}
}
