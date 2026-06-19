using System;
using System.Collections.Generic;
using ModIO;
using ModIO.Util;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	internal class CollectionModListItem : ListItem, ISelectHandler, IEventSystemHandler, IDeselectHandler
	{
		private CollectionProfile profile;

		[SerializeField]
		private Button listItemButton;

		[SerializeField]
		private Image image;

		[SerializeField]
		private GameObject imageBackground;

		[SerializeField]
		private TMP_Text title;

		[SerializeField]
		private GameObject progressBar;

		[SerializeField]
		private Image progressBarFill;

		[SerializeField]
		private TMP_Text progressBarText;

		[SerializeField]
		private TMP_Text progressBarPercentageText;

		[SerializeField]
		private TMP_Text subscriptionStatus;

		[SerializeField]
		private TMP_Text installStatus;

		[SerializeField]
		private TMP_Text dependencyStatus;

		[SerializeField]
		private TMP_Text fileSize;

		[SerializeField]
		public Button unsubscribeButton;

		[SerializeField]
		private TMP_Text otherSubscribersText;

		[SerializeField]
		private Button moreOptionsButton;

		[SerializeField]
		private GameObject failedToLoadLogo;

		[SerializeField]
		private GameObject errorInstalling;

		[SerializeField]
		private TMP_Text errorInstallingText;

		[SerializeField]
		private Transform contextMenuPosition;

		[SerializeField]
		private MultiTargetToggle enabledOrDisabledToggle;

		private ViewportRestraint togglesViewportRestraint;

		[SerializeField]
		private GameObject disabledBlackOverlay;

		public Action imageLoaded;

		private RectTransform rectTransform;

		private Translation subscriptionStatusTranslation;

		private Translation installStatusTranslation;

		private Translation progressBarTextTranslation;

		private Translation otherSubscribersTextTranslation;

		private Translation errorInstallingTextTranslation;

		private Translation dependencyTranslation;

		internal static Dictionary<ModId, CollectionModListItem> listItems = new Dictionary<ModId, CollectionModListItem>();

		private void OnEnable()
		{
			rectTransform = base.transform as RectTransform;
		}

		private void OnDestroy()
		{
			RemoveFromStaticDictionaryCache();
		}

		public void OnSelect(BaseEventData eventData)
		{
			SelfInstancingMonoSingleton<Collection>.Instance.currentSelectedCollectionListItem = this;
		}

		public void OnDeselect(BaseEventData eventData)
		{
			if (SelfInstancingMonoSingleton<Collection>.Instance.currentSelectedCollectionListItem == this)
			{
				SelfInstancingMonoSingleton<Collection>.Instance.currentSelectedCollectionListItem = null;
			}
		}

		public override void PlaceholderSetup()
		{
			base.PlaceholderSetup();
			failedToLoadLogo.SetActive(value: false);
			imageBackground.gameObject.SetActive(value: false);
			title.text = string.Empty;
		}

		public override void Select()
		{
			SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(listItemButton);
		}

		public override void SetViewportRestraint(RectTransform content, RectTransform viewport)
		{
			base.SetViewportRestraint(content, viewport);
			if (togglesViewportRestraint == null)
			{
				togglesViewportRestraint = enabledOrDisabledToggle.gameObject.AddComponent<ViewportRestraint>();
			}
			togglesViewportRestraint.DefaultViewportContainer = content;
			togglesViewportRestraint.Viewport = viewport;
			togglesViewportRestraint.PercentPaddingVertical = 0.35f;
			viewportRestraint.PercentPaddingVertical = 0.35f;
		}

		public override void Setup(CollectionProfile profile)
		{
			base.Setup();
			this.profile = profile;
			SetupEnableDisableToggle();
			SetupSubscribedStatusText();
			SetupInstallationStatusText();
			SetupDependencyStatusText();
			SetupNavigationBetweenToggleAndListItem();
			unsubscribeButton.gameObject.SetActive(profile.subscribed);
			progressBar.SetActive(value: false);
			Hydrate();
		}

		private void SetupSubscribedStatusText()
		{
			if (profile.subscribed)
			{
				Translation.Get(subscriptionStatusTranslation, "Subscribed", subscriptionStatus);
				subscriptionStatus.color = scheme.PositiveAccent;
			}
			else
			{
				Translation.Get(subscriptionStatusTranslation, "Installed", subscriptionStatus);
				subscriptionStatus.color = scheme.Inactive1;
				Translation.Get(otherSubscribersTextTranslation, "{subcount} other users", otherSubscribersText, $"{profile.subscribers}");
			}
			otherSubscribersText.transform.parent.gameObject.SetActive(!profile.subscribed);
		}

		private void SetupDependencyStatusText()
		{
			if (Collection.IsDependencyForOtherMods(profile.modProfile.id))
			{
				TMP_Text componentInChildren = unsubscribeButton.GetComponentInChildren<TMP_Text>();
				Translation.Get(dependencyTranslation, "Dependency", componentInChildren);
				unsubscribeButton.GetComponent<Image>().color = scheme.NegativeAccent;
			}
			else
			{
				TMP_Text componentInChildren2 = unsubscribeButton.GetComponentInChildren<TMP_Text>();
				Translation.Get(dependencyTranslation, "Unsubscribe", componentInChildren2);
				unsubscribeButton.GetComponent<Image>().color = scheme.Inactive1;
			}
		}

		private void SetupEnableDisableToggle()
		{
			if (profile.subscribed)
			{
				enabledOrDisabledToggle.onValueChanged.RemoveAllListeners();
				enabledOrDisabledToggle.isOn = profile.enabled;
				enabledOrDisabledToggle.interactable = true;
				enabledOrDisabledToggle.onValueChanged.AddListener(ToggleModEnabled);
			}
			else
			{
				enabledOrDisabledToggle.interactable = false;
			}
			enabledOrDisabledToggle.DoStateTransition();
		}

		private void SetupNavigationBetweenToggleAndListItem()
		{
			Navigation navigation = listItemButton.navigation;
			navigation.selectOnLeft = (enabledOrDisabledToggle.interactable ? enabledOrDisabledToggle : null);
			listItemButton.navigation = navigation;
			navigation = enabledOrDisabledToggle.navigation;
			navigation.selectOnRight = listItemButton;
			enabledOrDisabledToggle.navigation = navigation;
		}

		private void ToggleModEnabled(bool enabled)
		{
			if (enabled)
			{
				EnableMod();
			}
			else
			{
				DisabledMod();
			}
			SetDisabledStateOverlay();
			enabledOrDisabledToggle.DoStateTransition();
		}

		public void SetNavigationAbove(Selectable above)
		{
			Navigation navigation = listItemButton.navigation;
			navigation.selectOnUp = above;
			listItemButton.navigation = navigation;
			navigation = enabledOrDisabledToggle.navigation;
			navigation.selectOnUp = above;
			enabledOrDisabledToggle.navigation = navigation;
		}

		public void ConnectNavigationToItemBelow(CollectionModListItem below)
		{
			Navigation navigation = listItemButton.navigation;
			navigation.selectOnDown = below.listItemButton;
			listItemButton.navigation = navigation;
			navigation = enabledOrDisabledToggle.navigation;
			navigation.selectOnDown = (below.enabledOrDisabledToggle.interactable ? ((Selectable)below.enabledOrDisabledToggle) : ((Selectable)below.listItemButton));
			enabledOrDisabledToggle.navigation = navigation;
			navigation = below.listItemButton.navigation;
			navigation.selectOnUp = listItemButton;
			below.listItemButton.navigation = navigation;
			navigation = below.enabledOrDisabledToggle.navigation;
			navigation.selectOnUp = (enabledOrDisabledToggle.interactable ? ((Selectable)enabledOrDisabledToggle) : ((Selectable)listItemButton));
			below.enabledOrDisabledToggle.navigation = navigation;
		}

		private void EnableMod()
		{
			if (ModIOUnity.EnableMod(profile.modProfile.id))
			{
				profile.enabled = true;
			}
		}

		private void DisabledMod()
		{
			if (ModIOUnity.DisableMod(profile.modProfile.id))
			{
				profile.enabled = false;
			}
		}

		private void SetupInstallationStatusText()
		{
			if (!profile.subscribed)
			{
				Translation.Get(installStatusTranslation, "Installed", installStatus);
			}
			else if (profile.installationStatus == "Problem occurred")
			{
				installStatus.gameObject.SetActive(value: false);
				errorInstalling.SetActive(value: true);
				if (SelfInstancingMonoSingleton<Collection>.Instance.notEnoughSpaceForTheseMods.Contains(profile.modProfile.id))
				{
					Translation.Get(errorInstallingTextTranslation, "Full storage", errorInstallingText);
				}
				else
				{
					Translation.Get(errorInstallingTextTranslation, "Error", errorInstallingText);
				}
			}
			else
			{
				installStatus.gameObject.SetActive(value: true);
				errorInstalling.SetActive(value: false);
				Translation.Get(installStatusTranslation, profile.installationStatus, installStatus);
			}
		}

		private void AddToStaticDictionaryCache()
		{
			if (listItems.ContainsKey(profile.modProfile.id))
			{
				listItems[profile.modProfile.id] = this;
			}
			else
			{
				listItems.Add(profile.modProfile.id, this);
			}
		}

		private void Hydrate()
		{
			AddToStaticDictionaryCache();
			failedToLoadLogo.SetActive(value: false);
			imageBackground.gameObject.SetActive(value: false);
			string text = profile.modProfile.name;
			title.text = text;
			fileSize.text = Utility.GenerateHumanReadableStringForBytes(profile.modProfile.archiveFileSize);
			ModIOUnity.DownloadTexture(profile.modProfile.logoImage_320x180, SetIcon);
			base.gameObject.SetActive(value: true);
			base.transform.SetAsLastSibling();
			SetDisabledStateOverlay();
			RedrawRectTransform();
		}

		public void OpenModDetailsForThisProfile()
		{
			if (!isPlaceholder)
			{
				SelfInstancingMonoSingleton<Details>.Instance.Open(profile.modProfile, SelfInstancingMonoSingleton<Collection>.Instance.Open);
			}
		}

		private void RemoveFromStaticDictionaryCache()
		{
			if (listItems.ContainsKey(profile.modProfile.id))
			{
				listItems.Remove(profile.modProfile.id);
			}
		}

		private void SetIcon(ResultAnd<Texture2D> textureAnd)
		{
			if (textureAnd.result.Succeeded() && textureAnd.value != null)
			{
				SelfInstancingMonoSingleton<QueueRunner>.Instance.AddSpriteCreation(textureAnd.value, delegate(Sprite sprite)
				{
					imageBackground.gameObject.SetActive(value: true);
					image.sprite = sprite;
				});
			}
			else
			{
				failedToLoadLogo.SetActive(value: true);
			}
			imageLoaded?.Invoke();
		}

		private void SetDisabledStateOverlay()
		{
			disabledBlackOverlay.SetActive(profile.subscribed && !profile.enabled);
		}

		public void ShowMoreOptions()
		{
			List<ContextMenuOption> list = new List<ContextMenuOption>();
			list.Add(new ContextMenuOption
			{
				nameTranslationReference = "Vote up",
				action = delegate
				{
					ModIOUnity.RateMod(profile.modProfile.id, ModRating.Positive, delegate
					{
					});
					SelfInstancingMonoSingleton<ModioContextMenu>.Instance.Close();
				}
			});
			list.Add(new ContextMenuOption
			{
				nameTranslationReference = "Vote down",
				action = delegate
				{
					ModIOUnity.RateMod(profile.modProfile.id, ModRating.Negative, delegate
					{
					});
					SelfInstancingMonoSingleton<ModioContextMenu>.Instance.Close();
				}
			});
			list.Add(new ContextMenuOption
			{
				nameTranslationReference = "Report",
				action = delegate
				{
					SelfInstancingMonoSingleton<ModioContextMenu>.Instance.Close();
					SelfInstancingMonoSingleton<Reporting>.Instance.Open(profile.modProfile, selectable);
				}
			});
			if (!profile.subscribed && !Collection.IsDependencyForOtherMods(profile.modProfile.id))
			{
				list.Add(new ContextMenuOption
				{
					nameTranslationReference = "Uninstall",
					action = delegate
					{
						SelfInstancingMonoSingleton<ModioContextMenu>.Instance.Close();
						ForceUninstall();
					}
				});
			}
			SelfInstancingMonoSingleton<ModioContextMenu>.Instance.Open(contextMenuPosition, list, listItemButton);
		}

		private void ForceUninstall()
		{
			if (ModIOUnity.ForceUninstallMod(profile.modProfile.id).Succeeded())
			{
				SelfInstancingMonoSingleton<Notifications>.Instance.AddNotificationToQueue(new Notifications.QueuedNotice
				{
					title = "Uninstalled",
					description = "Uninstalled the mod '" + profile.modProfile.name + "'",
					positiveAccent = true
				});
				base.gameObject.SetActive(value: false);
			}
			else
			{
				SelfInstancingMonoSingleton<Notifications>.Instance.AddNotificationToQueue(new Notifications.QueuedNotice
				{
					title = "Failed to uninstall",
					description = "Failed to uninstall the mod '" + profile.modProfile.name + "'",
					positiveAccent = false
				});
			}
		}

		public void UnsubscribeButton()
		{
			if (Collection.IsDependencyForOtherMods(profile.modProfile.id))
			{
				SelfInstancingMonoSingleton<Notifications>.Instance.AddNotificationToQueue(new Notifications.QueuedNotice
				{
					title = "",
					description = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("UnsubscribeDepText"),
					positiveAccent = false
				});
			}
			else
			{
				SelfInstancingMonoSingleton<Collection>.Instance.OpenUninstallConfirmation(profile.modProfile);
			}
		}

		internal void UpdateStatus(ModManagementEventType updatedStatus)
		{
			progressBar.SetActive(value: false);
			errorInstalling.SetActive(value: false);
			installStatus.gameObject.SetActive(value: true);
			switch (updatedStatus)
			{
			case ModManagementEventType.InstallStarted:
				Translation.Get(installStatusTranslation, "Installing", installStatus);
				SelfInstancingMonoSingleton<Collection>.Instance.RefreshList();
				break;
			case ModManagementEventType.Installed:
				Translation.Get(installStatusTranslation, "Installed", installStatus);
				SelfInstancingMonoSingleton<Collection>.Instance.RefreshList();
				break;
			case ModManagementEventType.InstallFailed:
				installStatus.gameObject.SetActive(value: false);
				errorInstalling.SetActive(value: true);
				SelfInstancingMonoSingleton<Collection>.Instance.RefreshList();
				break;
			case ModManagementEventType.DownloadStarted:
				Translation.Get(installStatusTranslation, "Downloading", installStatus);
				SelfInstancingMonoSingleton<Collection>.Instance.RefreshList();
				break;
			case ModManagementEventType.Downloaded:
				Translation.Get(installStatusTranslation, "Ready to install", installStatus);
				SelfInstancingMonoSingleton<Collection>.Instance.RefreshList();
				break;
			case ModManagementEventType.DownloadFailed:
				installStatus.gameObject.SetActive(value: false);
				errorInstalling.SetActive(value: true);
				SelfInstancingMonoSingleton<Collection>.Instance.RefreshList();
				break;
			case ModManagementEventType.UninstallStarted:
				Translation.Get(installStatusTranslation, "Uninstalling", installStatus);
				SelfInstancingMonoSingleton<Collection>.Instance.RefreshList();
				break;
			case ModManagementEventType.Uninstalled:
				Translation.Get(installStatusTranslation, "Uninstalled", installStatus);
				SelfInstancingMonoSingleton<Collection>.Instance.RefreshList();
				break;
			case ModManagementEventType.UninstallFailed:
				installStatus.gameObject.SetActive(value: false);
				errorInstalling.SetActive(value: true);
				SelfInstancingMonoSingleton<Collection>.Instance.RefreshList();
				break;
			case ModManagementEventType.UpdateStarted:
				Translation.Get(installStatusTranslation, "Updating", installStatus);
				SelfInstancingMonoSingleton<Collection>.Instance.RefreshList();
				break;
			case ModManagementEventType.Updated:
				Translation.Get(installStatusTranslation, "Updated", installStatus);
				SelfInstancingMonoSingleton<Collection>.Instance.RefreshList();
				break;
			case ModManagementEventType.UpdateFailed:
				installStatus.gameObject.SetActive(value: false);
				errorInstalling.SetActive(value: true);
				SelfInstancingMonoSingleton<Collection>.Instance.RefreshList();
				break;
			}
		}

		internal void UpdateProgressState(ProgressHandle handle)
		{
			if (handle == null || handle.Completed)
			{
				progressBar.SetActive(value: false);
				return;
			}
			progressBarFill.fillAmount = handle.Progress;
			switch (handle.OperationType)
			{
			case ModManagementOperationType.None_AlreadyInstalled:
				progressBar.SetActive(value: false);
				installStatus.gameObject.SetActive(value: true);
				Translation.Get(installStatusTranslation, "Installed", installStatus);
				break;
			case ModManagementOperationType.None_ErrorOcurred:
				progressBar.SetActive(value: false);
				installStatus.gameObject.SetActive(value: false);
				errorInstalling.SetActive(value: true);
				break;
			case ModManagementOperationType.Install:
				progressBar.SetActive(value: true);
				installStatus.gameObject.SetActive(value: false);
				progressBarPercentageText.text = $"{(int)(handle.Progress * 100f)}%";
				Translation.Get(progressBarTextTranslation, "Installing...", progressBarText);
				break;
			case ModManagementOperationType.Download:
				progressBar.SetActive(value: true);
				installStatus.gameObject.SetActive(value: false);
				progressBarPercentageText.text = $"{(int)(handle.Progress * 100f)}%";
				Translation.Get(progressBarTextTranslation, "Downloading...", progressBarText);
				break;
			case ModManagementOperationType.Uninstall:
				progressBar.SetActive(value: false);
				installStatus.gameObject.SetActive(value: true);
				Translation.Get(progressBarTextTranslation, "Uninstalling", progressBarText);
				break;
			case ModManagementOperationType.Update:
				progressBar.SetActive(value: true);
				installStatus.gameObject.SetActive(value: false);
				progressBarPercentageText.text = $"{(int)(handle.Progress * 100f)}%";
				Translation.Get(progressBarTextTranslation, "Updating...", progressBarText);
				break;
			}
		}
	}
}
