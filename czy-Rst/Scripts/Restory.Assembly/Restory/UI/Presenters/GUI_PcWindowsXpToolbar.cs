using System;
using System.Collections.Generic;
using System.Linq;
using Restory.Data.Localization;
using Restory.Data.PC;
using Restory.Gameplay.EmailSystems;
using Restory.Utils;
using UnityEngine;
using Zenject;

namespace Restory.UI.Presenters
{
	public sealed class GUI_PcWindowsXpToolbar : MonoBehaviour
	{
		[SerializeField]
		private GUI_PcWidgets widgets;

		[SerializeField]
		private GUI_PcWindowsXpToolbarButton startButton;

		[SerializeField]
		private Transform applicationButtonsActiveParent;

		[SerializeField]
		private PcAppInfo mailClientAppInfo;

		private readonly List<GUI_PcAppToolbarButton> appButtons = new List<GUI_PcAppToolbarButton>();

		private DiContainer diContainer;

		private LocalizationSystem localizationSystem;

		private EmailService emailService;

		private bool wasMailClientNeverOpened;

		private bool isActivated;

		public event Action OnStartMenuToggleRequested;

		public event Action<PcAppInfo> OnAppOpenRequested;

		[Inject]
		private void Construct(DiContainer diContainer, LocalizationSystem localizationSystem, EmailService emailService)
		{
			this.diContainer = diContainer;
			this.localizationSystem = localizationSystem;
			this.emailService = emailService;
		}

		private void OnDisable()
		{
			if (startButton.MonoShellExists())
			{
				startButton.OnClicked -= ResolveStartButtonClicked;
			}
			foreach (GUI_PcAppToolbarButton appButton in appButtons)
			{
				appButton.OnClicked -= ResolveAppButtonClicked;
			}
			appButtons.Clear();
		}

		public void Activate()
		{
			if (!isActivated)
			{
				isActivated = true;
				widgets.ActivateWidgets();
				startButton.OnClicked += ResolveStartButtonClicked;
				ResolveEmailReadLettersCountChanged();
				emailService.OnContentsChanged += ResolveEmailReadLettersCountChanged;
				emailService.OnLettersReadStatusChanged += ResolveEmailReadLettersCountChanged;
			}
		}

		public void Deactivate()
		{
			if (isActivated)
			{
				isActivated = false;
				startButton.OnClicked -= ResolveStartButtonClicked;
				emailService.OnContentsChanged -= ResolveEmailReadLettersCountChanged;
				emailService.OnLettersReadStatusChanged -= ResolveEmailReadLettersCountChanged;
				widgets.DeactivateWidgets();
			}
		}

		public void CreateAppButton(PcAppInfo appInfo)
		{
			GUI_PcAppToolbarButton gUI_PcAppToolbarButton = diContainer.InstantiatePrefabForComponent<GUI_PcAppToolbarButton>(appInfo.ToolbarButtonPrefab, applicationButtonsActiveParent);
			gUI_PcAppToolbarButton.Init(appInfo, localizationSystem.GetTranslation(appInfo.NameLocalizationKey));
			gUI_PcAppToolbarButton.OnClicked += ResolveAppButtonClicked;
			appButtons.Add(gUI_PcAppToolbarButton);
		}

		public void RemoveAppButton(PcAppInfo appInfo)
		{
			for (int num = appButtons.Count - 1; num >= 0; num--)
			{
				GUI_PcAppToolbarButton gUI_PcAppToolbarButton = appButtons[num];
				if (gUI_PcAppToolbarButton == null)
				{
					appButtons.RemoveAt(num);
				}
				else if (!(gUI_PcAppToolbarButton.AppInfo != appInfo))
				{
					gUI_PcAppToolbarButton.OnClicked -= ResolveAppButtonClicked;
					appButtons.RemoveAt(num);
					UnityEngine.Object.Destroy(gUI_PcAppToolbarButton.gameObject);
				}
			}
		}

		public void SelectAppButton(PcAppInfo appInfo)
		{
			foreach (GUI_PcAppToolbarButton appButton in appButtons)
			{
				appButton.SetState(appButton.AppInfo == appInfo);
			}
			ChangeStartButtonState(isStartMenuOpen: false);
		}

		public void DeselectAppButton(PcAppInfo appInfo)
		{
			foreach (GUI_PcAppToolbarButton appButton in appButtons)
			{
				if (appButton.AppInfo == appInfo)
				{
					appButton.SetState(isApplicationOpen: false);
				}
			}
		}

		public void ChangeStartButtonState(bool isStartMenuOpen)
		{
			startButton.SetState(isStartMenuOpen);
		}

		public void SetFirstMailClientPreviouslyOpenedState(bool wasOpened)
		{
			wasMailClientNeverOpened = !wasOpened;
		}

		private void UpdateUnreadEmailsCountInMailApplicationButton(int unreadMessagesCount)
		{
			GUI_PcAppToolbarButton gUI_PcAppToolbarButton = appButtons.FirstOrDefault((GUI_PcAppToolbarButton button) => button.AppInfo == mailClientAppInfo);
			if (gUI_PcAppToolbarButton == null)
			{
				Debug.LogError($"Mail client application button with app info {mailClientAppInfo} is not found among toolbar buttons");
				return;
			}
			IPcWindowsXpToolbarButtonAdditionalInfoArgument[] array = new IPcWindowsXpToolbarButtonAdditionalInfoArgument[2];
			object obj;
			if (unreadMessagesCount <= 0)
			{
				obj = null;
			}
			else
			{
				IPcWindowsXpToolbarButtonAdditionalInfoArgument pcWindowsXpToolbarButtonAdditionalInfoArgument = new PcWindowsXpToolbarButtonAdditionalInfoNumber
				{
					Number = unreadMessagesCount
				};
				obj = pcWindowsXpToolbarButtonAdditionalInfoArgument;
			}
			array[0] = (IPcWindowsXpToolbarButtonAdditionalInfoArgument)obj;
			object obj2;
			if (!wasMailClientNeverOpened)
			{
				obj2 = null;
			}
			else
			{
				IPcWindowsXpToolbarButtonAdditionalInfoArgument pcWindowsXpToolbarButtonAdditionalInfoArgument = default(PcWindowsXpToolbarButtonAdditionalInfoNeverBeforeOpened);
				obj2 = pcWindowsXpToolbarButtonAdditionalInfoArgument;
			}
			array[1] = (IPcWindowsXpToolbarButtonAdditionalInfoArgument)obj2;
			gUI_PcAppToolbarButton.SetAdditionalInfo(array);
		}

		private void ResolveStartButtonClicked(GUI_PcWindowsXpToolbarButton buttonClicked)
		{
			this.OnStartMenuToggleRequested?.Invoke();
		}

		private void ResolveAppButtonClicked(GUI_PcWindowsXpToolbarButton clickedButton)
		{
			if (clickedButton is GUI_PcAppToolbarButton gUI_PcAppToolbarButton)
			{
				this.OnAppOpenRequested?.Invoke(gUI_PcAppToolbarButton.AppInfo);
			}
		}

		private void ResolveEmailReadLettersCountChanged()
		{
			UpdateUnreadEmailsCountInMailApplicationButton(emailService.GetTotalUnreadLettersCount());
		}
	}
}
