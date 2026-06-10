using System;
using System.Collections.Generic;
using ModIO;
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
		private TMP_Text fileSize;

		[SerializeField]
		private Button unsubscribeButton;

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

		internal static Dictionary<ModId, CollectionModListItem> listItems;

		private void OnEnable()
		{
		}

		private void OnDestroy()
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		public void OnDeselect(BaseEventData eventData)
		{
		}

		public override void PlaceholderSetup()
		{
		}

		public override void Select()
		{
		}

		public override void SetViewportRestraint(RectTransform content, RectTransform viewport)
		{
		}

		public override void Setup(CollectionProfile profile)
		{
		}

		private void SetupSubscribedStatusText()
		{
		}

		private void SetupEnableDisableToggle()
		{
		}

		private void SetupNavigationBetweenToggleAndListItem()
		{
		}

		private void ToggleModEnabled(bool enabled)
		{
		}

		public void SetNavigationAbove(Selectable above)
		{
		}

		public void ConnectNavigationToItemBelow(CollectionModListItem below)
		{
		}

		private void EnableMod()
		{
		}

		private void DisabledMod()
		{
		}

		private void SetupInstallationStatusText()
		{
		}

		private void AddToStaticDictionaryCache()
		{
		}

		private void Hydrate()
		{
		}

		public void OpenModDetailsForThisProfile()
		{
		}

		private void RemoveFromStaticDictionaryCache()
		{
		}

		private void SetIcon(ResultAnd<Texture2D> textureAnd)
		{
		}

		private void SetDisabledStateOverlay()
		{
		}

		public void ShowMoreOptions()
		{
		}

		private void ForceUninstall()
		{
		}

		public void UnsubscribeButton()
		{
		}

		internal void UpdateStatus(ModManagementEventType updatedStatus)
		{
		}

		internal void UpdateProgressState(ProgressHandle handle)
		{
		}
	}
}
