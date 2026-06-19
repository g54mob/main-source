using ModIO.Util;
using UnityEngine;

namespace ModIOBrowser.Implementation
{
	internal class SelectionOverlayHandler : SelfInstancingMonoSingleton<SelectionOverlayHandler>
	{
		[Header("Selection Overlay Objects")]
		[SerializeField]
		private HomeModListItem_Overlay homeModListItemOverlay;

		public SearchResultListItem_Overlay SearchResultListItemOverlay;

		[SerializeField]
		private GameObject CollectionListItemOverlay;

		[SerializeField]
		private GameObject SearchModListItemOverlay;

		public void SetBrowserModListItemOverlayActive(bool state)
		{
			homeModListItemOverlay?.gameObject.SetActive(state);
		}

		public static bool TryToOpenMoreOptionsForBrowserOverlayObject()
		{
			if (SelfInstancingMonoSingleton<SelectionOverlayHandler>.Instance.homeModListItemOverlay.gameObject.activeSelf)
			{
				SelfInstancingMonoSingleton<SelectionOverlayHandler>.Instance.homeModListItemOverlay.ShowMoreOptions();
				return true;
			}
			return false;
		}

		public static bool TryToOpenMoreOptionsForSearchResultsOverlayObject()
		{
			if (SelfInstancingMonoSingleton<SelectionOverlayHandler>.Instance.SearchResultListItemOverlay.gameObject.activeSelf)
			{
				SelfInstancingMonoSingleton<SelectionOverlayHandler>.Instance.SearchResultListItemOverlay.ShowMoreOptions();
				return true;
			}
			return false;
		}

		public static bool TryAlternateForBrowserOverlayObject()
		{
			if (SelfInstancingMonoSingleton<SelectionOverlayHandler>.Instance.homeModListItemOverlay.gameObject.activeSelf)
			{
				SelfInstancingMonoSingleton<SelectionOverlayHandler>.Instance.homeModListItemOverlay.SubscribeButton();
				return true;
			}
			return false;
		}

		public static bool TryAlternateForSearchResultsOverlayObject()
		{
			if (SelfInstancingMonoSingleton<SelectionOverlayHandler>.Instance.SearchResultListItemOverlay.gameObject.activeSelf)
			{
				SelfInstancingMonoSingleton<SelectionOverlayHandler>.Instance.SearchResultListItemOverlay.SubscribeButton();
				return true;
			}
			return false;
		}

		public void MoveSelection(HomeModListItem listItem)
		{
			homeModListItemOverlay.Setup(listItem);
		}

		public void MoveSelection(SearchResultListItem listItem)
		{
			SearchResultListItemOverlay.Setup(listItem);
		}

		public void Deselect(HomeModListItem listItem)
		{
			if (!SelfInstancingMonoSingleton<ModioContextMenu>.Instance.ContextMenu.activeSelf && homeModListItemOverlay != null && homeModListItemOverlay.listItemToReplicate == listItem && !SelfInstancingMonoSingleton<InputNavigation>.Instance.mouseNavigation)
			{
				homeModListItemOverlay?.gameObject.SetActive(value: false);
			}
		}

		public void Deselect(SearchResultListItem listItem)
		{
			if (!SelfInstancingMonoSingleton<ModioContextMenu>.Instance.ContextMenu.activeSelf && SearchResultListItemOverlay != null && SearchResultListItemOverlay.listItemToReplicate == listItem && !SelfInstancingMonoSingleton<InputNavigation>.Instance.mouseNavigation)
			{
				SearchResultListItemOverlay?.gameObject.SetActive(value: false);
			}
		}
	}
}
