using System.Collections;
using ModIO;
using ModIO.Util;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	public class SearchResults : SelfInstancingMonoSingleton<SearchResults>
	{
		private enum SearchResultsStatus
		{
			GettingFirstResults = 0,
			RetrievedFirstResults = 1,
			GettingMoreResults = 2,
			RetrievedAllResults = 3
		}

		[Header("Search Results Panel")]
		[SerializeField]
		public GameObject SearchResultsPanel;

		[SerializeField]
		private Image SearchResultsHeaderBackground;

		[SerializeField]
		private GameObject SearchResultsHeaderRefineButton;

		[SerializeField]
		private RectTransform SearchResultsContentRefineButton;

		[SerializeField]
		private GameObject SearchResultsListItemPrefab;

		[SerializeField]
		public Transform SearchResultsListItemParent;

		[SerializeField]
		private Scrollbar SearchResultsScrollBar;

		[SerializeField]
		private TMP_Text SearchResultsFoundText;

		[SerializeField]
		private TMP_Text SearchResultsMainTagName;

		[SerializeField]
		private TMP_Text SearchResultsMainTagCategoryName;

		[SerializeField]
		private GameObject SearchResultsMainTag;

		[SerializeField]
		private TMP_Text SearchResultsNumberOfOtherTags;

		[SerializeField]
		private GameObject SearchResultsSearchPhrase;

		[SerializeField]
		private TMP_Text SearchResultsSearchPhraseText;

		[SerializeField]
		private TMP_Dropdown SearchResultsSortByDropdown;

		[SerializeField]
		private GameObject SearchResultsEndOfResults;

		[SerializeField]
		private GameObject SearchResultsNoResultsText;

		[SerializeField]
		private TMP_Text SearchResultsEndOfResultsHeader;

		[SerializeField]
		private TMP_Text SearchResultsEndOfResultsText;

		[SerializeField]
		private Selectable SearchResultsRefineFilter;

		[SerializeField]
		private Selectable SearchResultsFilterBy;

		[SerializeField]
		private GameObject ProcessingAnimation;

		private bool moreResultsToShow;

		private long numberOfRemainingResultsToShow;

		private string lastUsedSearchPhrase;

		private SearchResultsStatus searchResultsStatus;

		private IEnumerator searchResultsHeaderTransition;

		private float searchResultsLastAlphaTarget;

		internal Translation SearchResultsFoundTextTranslation;

		internal Translation SearchResultsNumberOfOtherTagsTranslation;

		internal Translation SearchResultsEndOfResultsHeaderTranslation;

		internal Translation SearchResultsEndOfResultsTextTranslation;

		internal void Open(string searchPhrase)
		{
		}

		internal void OpenWithoutRefreshing()
		{
		}

		internal SearchFilter GetFilter(int page = 0, string searchPhrase = null)
		{
			return null;
		}

		public void Refresh()
		{
		}

		public void OnScrollValueChange()
		{
		}

		private void CheckToLoadMoreModsOrForFooterDisplay()
		{
		}

		private void OnScrollValueChangeHeaderCheck()
		{
		}

		private void CheckRefineButtonDisplay()
		{
		}

		private void Get(ResultAnd<ModPage> response)
		{
		}

		private void Populate(ModProfile[] mods)
		{
		}

		private void ClearButtonNavigation()
		{
		}

		private void UpdateButtonNavigation()
		{
		}
	}
}
