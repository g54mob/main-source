using ModIO.Util;
using ModIOBrowser.Implementation;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ModIOBrowser
{
	internal static class Navigating
	{
		internal static void Cancel()
		{
			if (SelfInstancingMonoSingleton<ModioContextMenu>.Instance.ContextMenu.activeSelf)
			{
				SelfInstancingMonoSingleton<ModioContextMenu>.Instance.Close();
			}
			else if (MultiTargetDropdown.currentMultiTargetDropdown != null)
			{
				MultiTargetDropdown.currentMultiTargetDropdown.Hide();
				MultiTargetDropdown.currentMultiTargetDropdown = null;
			}
			else if (SelfInstancingMonoSingleton<SearchPanel>.Instance.SearchPanelGameObject.activeSelf)
			{
				SelfInstancingMonoSingleton<SearchPanel>.Instance.Close();
			}
			else if (SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.AuthenticationPanel.activeSelf)
			{
				SelfInstancingMonoSingleton<Authentication>.Instance.Close();
			}
			else if (SelfInstancingMonoSingleton<DownloadQueue>.Instance.DownloadQueuePanel.activeSelf)
			{
				SelfInstancingMonoSingleton<DownloadQueue>.Instance.ToggleDownloadQueuePanel();
			}
			else if (SelfInstancingMonoSingleton<Details>.Instance.ModDetailsPanel.activeSelf)
			{
				SelfInstancingMonoSingleton<Details>.Instance.Close();
			}
			else if (SelfInstancingMonoSingleton<Collection>.Instance.uninstallConfirmationPanel.activeSelf)
			{
				SelfInstancingMonoSingleton<Collection>.Instance.CloseUninstallConfirmation();
			}
			else if (Browser.currentFocusedPanel != SelfInstancingMonoSingleton<Home>.Instance.BrowserPanel)
			{
				SelfInstancingMonoSingleton<Home>.Instance.Open();
			}
			else
			{
				Browser.Close();
			}
		}

		internal static void Alternate()
		{
			if (SelfInstancingMonoSingleton<SearchPanel>.Instance.SearchPanelGameObject.activeSelf)
			{
				SelfInstancingMonoSingleton<SearchPanel>.Instance.ApplyFilter();
			}
			else if (Home.IsOn())
			{
				if (!SelectionOverlayHandler.TryAlternateForBrowserOverlayObject() && SelfInstancingMonoSingleton<Home>.Instance.isFeaturedItemSelected)
				{
					SelfInstancingMonoSingleton<Home>.Instance.SubscribeToFeaturedMod();
				}
			}
			else if (SelfInstancingMonoSingleton<Details>.Instance.ModDetailsPanel.activeSelf)
			{
				SelfInstancingMonoSingleton<Details>.Instance.SubscribeButtonPress();
			}
			else if (Collection.IsOn())
			{
				if (SelfInstancingMonoSingleton<Collection>.Instance.currentSelectedCollectionListItem != null)
				{
					SelfInstancingMonoSingleton<Collection>.Instance.currentSelectedCollectionListItem.UnsubscribeButton();
				}
			}
			else if (SelfInstancingMonoSingleton<SearchResults>.Instance.SearchResultsPanel.activeSelf)
			{
				SelectionOverlayHandler.TryAlternateForSearchResultsOverlayObject();
			}
		}

		internal static void Options()
		{
			if (SelfInstancingMonoSingleton<ModioContextMenu>.Instance.ContextMenu.activeSelf)
			{
				SelfInstancingMonoSingleton<ModioContextMenu>.Instance.Close();
			}
			else if (SelfInstancingMonoSingleton<SearchResults>.Instance.SearchResultsPanel.activeSelf)
			{
				SelectionOverlayHandler.TryToOpenMoreOptionsForSearchResultsOverlayObject();
			}
			else if (Collection.IsOn())
			{
				if (SelfInstancingMonoSingleton<Collection>.Instance.currentSelectedCollectionListItem != null)
				{
					SelfInstancingMonoSingleton<Collection>.Instance.currentSelectedCollectionListItem.ShowMoreOptions();
				}
			}
			else if (SelfInstancingMonoSingleton<SearchPanel>.Instance.SearchPanelGameObject.activeSelf)
			{
				SearchPanel.searchFilterTags.Clear();
				SelfInstancingMonoSingleton<SearchPanel>.Instance.SearchPanelField.text = "";
				SelfInstancingMonoSingleton<SearchPanel>.Instance.SetupTags();
			}
			else if (Home.IsOn() && !SelectionOverlayHandler.TryToOpenMoreOptionsForBrowserOverlayObject() && SelfInstancingMonoSingleton<Home>.Instance.isFeaturedItemSelected)
			{
				SelfInstancingMonoSingleton<Home>.Instance.OpenMoreOptionsForFeaturedSlot();
			}
		}

		internal static void TabLeft()
		{
			if (SelfInstancingMonoSingleton<SearchPanel>.Instance.SearchPanelGameObject.activeSelf)
			{
				TagJumpToSelection.GoToPreviousSelection();
			}
			else if (SelfInstancingMonoSingleton<Details>.Instance.ModDetailsPanel.activeSelf)
			{
				SelfInstancingMonoSingleton<Details>.Instance.GalleryImageTransition(showNext: false);
			}
			else if (Home.IsOn() || Collection.IsOn())
			{
				ToggleBetweenBrowserAndCollection();
			}
		}

		internal static void TabRight()
		{
			if (SelfInstancingMonoSingleton<SearchPanel>.Instance.SearchPanelGameObject.activeSelf)
			{
				TagJumpToSelection.GoToNextSelection();
			}
			else if (SelfInstancingMonoSingleton<Details>.Instance.ModDetailsPanel.activeSelf)
			{
				SelfInstancingMonoSingleton<Details>.Instance.GalleryImageTransition(showNext: true);
			}
			else if (Home.IsOn() || Collection.IsOn())
			{
				ToggleBetweenBrowserAndCollection();
			}
		}

		internal static void MenuInput()
		{
			OpenMenuProfile();
		}

		internal static void Scroll(float direction)
		{
			if (SelfInstancingMonoSingleton<Details>.Instance.ModDetailsPanel.activeSelf && !SelfInstancingMonoSingleton<Reporting>.Instance.Panel.activeSelf && EventSystem.current.currentSelectedGameObject == SelfInstancingMonoSingleton<Details>.Instance.ModDetailsScrollToggleGameObject)
			{
				Vector3 position = SelfInstancingMonoSingleton<Details>.Instance.ModDetailsContentRect.position;
				position.y += direction * (100f * Time.fixedDeltaTime) * -1f;
				SelfInstancingMonoSingleton<Details>.Instance.ModDetailsContentRect.position = position;
			}
		}

		internal static void GoToPanel(GameObject panel)
		{
			CloseAll();
			panel?.SetActive(value: true);
			Browser.currentFocusedPanel = panel;
		}

		internal static void CloseAll()
		{
			if (Home.IsOn())
			{
				SelfInstancingMonoSingleton<Home>.Instance.BrowserPanel.SetActive(value: false);
			}
			if (Collection.IsOn())
			{
				SelfInstancingMonoSingleton<Collection>.Instance.CollectionPanel.SetActive(value: false);
			}
			if (Details.IsOn())
			{
				SelfInstancingMonoSingleton<Details>.Instance.ModDetailsPanel.SetActive(value: false);
			}
			if (SelfInstancingMonoSingleton<SearchPanel>.Instance.SearchPanelGameObject.activeSelf)
			{
				SelfInstancingMonoSingleton<SearchPanel>.Instance.SearchPanelGameObject.SetActive(value: false);
			}
			if (SelfInstancingMonoSingleton<SearchResults>.Instance.SearchResultsPanel.activeSelf)
			{
				SelfInstancingMonoSingleton<SearchResults>.Instance.SearchResultsPanel.SetActive(value: false);
				SelfInstancingMonoSingleton<SelectionOverlayHandler>.Instance.SearchResultListItemOverlay.gameObject.SetActive(value: false);
			}
			if (SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.AuthenticationPanel.activeSelf)
			{
				SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.AuthenticationPanel.SetActive(value: false);
			}
			if (SelfInstancingMonoSingleton<DownloadQueue>.Instance.DownloadQueuePanel.activeSelf)
			{
				SelfInstancingMonoSingleton<DownloadQueue>.Instance.DownloadQueuePanel.SetActive(value: false);
			}
			if (SelfInstancingMonoSingleton<ModioContextMenu>.Instance.ContextMenu.activeSelf)
			{
				SelfInstancingMonoSingleton<ModioContextMenu>.Instance.ContextMenu.SetActive(value: false);
			}
			if (SelfInstancingMonoSingleton<Reporting>.Instance.Panel.activeSelf)
			{
				SelfInstancingMonoSingleton<Reporting>.Instance.Panel.SetActive(value: false);
			}
		}

		public static void OpenMenuProfile()
		{
			if (!SelfInstancingMonoSingleton<Authentication>.Instance.IsAuthenticated)
			{
				if (SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.AuthenticationPanel.activeSelf)
				{
					SelfInstancingMonoSingleton<Authentication>.Instance.Close();
				}
				else
				{
					SelfInstancingMonoSingleton<AuthenticationPanels>.Instance.Open();
				}
			}
			else
			{
				SelfInstancingMonoSingleton<DownloadQueue>.Instance.ToggleDownloadQueuePanel();
			}
		}

		public static void ToggleBetweenBrowserAndCollection()
		{
			if (Home.IsOn())
			{
				SelfInstancingMonoSingleton<Collection>.Instance.Open();
			}
			else
			{
				SelfInstancingMonoSingleton<Home>.Instance.Open();
			}
		}
	}
}
