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
		}

		public static bool TryToOpenMoreOptionsForBrowserOverlayObject()
		{
			return false;
		}

		public static bool TryToOpenMoreOptionsForSearchResultsOverlayObject()
		{
			return false;
		}

		public static bool TryAlternateForBrowserOverlayObject()
		{
			return false;
		}

		public static bool TryAlternateForSearchResultsOverlayObject()
		{
			return false;
		}

		public void MoveSelection(HomeModListItem listItem)
		{
		}

		public void MoveSelection(SearchResultListItem listItem)
		{
		}

		public void Deselect(HomeModListItem listItem)
		{
		}

		public void Deselect(SearchResultListItem listItem)
		{
		}
	}
}
