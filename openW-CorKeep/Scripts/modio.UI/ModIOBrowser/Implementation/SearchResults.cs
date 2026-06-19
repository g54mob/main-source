using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

		private float searchResultsLastAlphaTarget = -1f;

		internal Translation SearchResultsFoundTextTranslation;

		internal Translation SearchResultsNumberOfOtherTagsTranslation;

		internal Translation SearchResultsEndOfResultsHeaderTranslation;

		internal Translation SearchResultsEndOfResultsTextTranslation;

		internal void Open(string searchPhrase)
		{
			ClearButtonNavigation();
			lastUsedSearchPhrase = searchPhrase;
			Navigating.GoToPanel(SearchResultsPanel);
			Refresh();
			SelfInstancingMonoSingleton<SelectionManager>.Instance.SelectView(UiViews.SearchResults);
		}

		internal void OpenWithoutRefreshing()
		{
			SelfInstancingMonoSingleton<SelectionManager>.Instance.SelectView(UiViews.SearchResults);
			Navigating.GoToPanel(SearchResultsPanel);
		}

		internal SearchFilter GetFilter(int page = 0, string searchPhrase = null)
		{
			searchPhrase = searchPhrase ?? lastUsedSearchPhrase;
			SearchFilter searchFilter = new SearchFilter();
			switch (SearchResultsSortByDropdown.value)
			{
			case 0:
				searchFilter.SortBy(SortModsBy.Popular);
				break;
			case 1:
				searchFilter.SortBy(SortModsBy.Downloads);
				break;
			case 2:
				searchFilter.SortBy(SortModsBy.Subscribers);
				break;
			case 3:
				searchFilter.SortBy(SortModsBy.Rating);
				break;
			}
			searchFilter.AddSearchPhrase(searchPhrase);
			foreach (Tag searchFilterTag in SearchPanel.searchFilterTags)
			{
				searchFilter.AddTag(searchFilterTag.name);
			}
			searchFilter.SetPageIndex(page);
			searchFilter.SetPageSize(100);
			return searchFilter;
		}

		public void Refresh()
		{
			SearchResultsMainTag.SetActive(value: false);
			SearchResultsSearchPhrase.SetActive(value: false);
			Translation.Get(SearchResultsFoundTextTranslation, "", SearchResultsFoundText);
			Translation.Get(SearchResultsEndOfResultsHeaderTranslation, "", SearchResultsEndOfResultsHeader);
			Translation.Get(SearchResultsEndOfResultsTextTranslation, "", SearchResultsEndOfResultsText);
			searchResultsStatus = SearchResultsStatus.GettingFirstResults;
			ListItem.HideListItems<SearchResultListItem>();
			SearchResultsNoResultsText.SetActive(value: false);
			SearchResultsEndOfResults.SetActive(value: false);
			ProcessingAnimation.gameObject.SetActive(value: true);
			ModIOUnity.GetMods(GetFilter(), Get);
		}

		public void OnScrollValueChange()
		{
			CheckToLoadMoreModsOrForFooterDisplay();
			OnScrollValueChangeHeaderCheck();
			CheckRefineButtonDisplay();
		}

		private void CheckToLoadMoreModsOrForFooterDisplay()
		{
			if (moreResultsToShow && searchResultsStatus == SearchResultsStatus.RetrievedFirstResults)
			{
				RectTransformOverlap rectTransformOverlap = new RectTransformOverlap(SearchResultsListItemParent as RectTransform);
				RectTransformOverlap rectTransformOverlap2 = new RectTransformOverlap(SelfInstancingMonoSingleton<Home>.Instance.BrowserPanel.transform as RectTransform);
				if (rectTransformOverlap.yMin < 0f && Mathf.Abs(rectTransformOverlap.yMin) < rectTransformOverlap2.height / 2f)
				{
					searchResultsStatus = SearchResultsStatus.GettingMoreResults;
					SelfInstancingMonoSingleton<Home>.Instance.AddPlaceholdersToList<SearchResultListItem>(SearchResultsListItemParent, SearchResultsListItemPrefab, (int)numberOfRemainingResultsToShow);
					ModIOUnity.GetMods(GetFilter(1), Get);
				}
			}
		}

		private void OnScrollValueChangeHeaderCheck()
		{
			float num = -1f;
			num = ((!(SearchResultsScrollBar.value < 1f)) ? ((SearchResultsHeaderBackground.color.a == 0f) ? num : 0f) : ((SearchResultsHeaderBackground.color.a == 1f) ? num : 1f));
			if (num != -1f && num != searchResultsLastAlphaTarget)
			{
				searchResultsLastAlphaTarget = num;
				if (searchResultsHeaderTransition != null)
				{
					StopCoroutine(searchResultsHeaderTransition);
				}
				searchResultsHeaderTransition = ImageTransitions.Alpha(SearchResultsHeaderBackground, num);
				StartCoroutine(searchResultsHeaderTransition);
			}
		}

		private void CheckRefineButtonDisplay()
		{
			if (SearchResultsContentRefineButton.position.y - SearchResultsContentRefineButton.sizeDelta.y * SearchResultsContentRefineButton.pivot.y > (float)Screen.height - SearchResultsHeaderBackground.rectTransform.sizeDelta.y)
			{
				if (SearchResultsContentRefineButton.gameObject.activeSelf)
				{
					SearchResultsContentRefineButton.gameObject.SetActive(value: false);
				}
				if (!SearchResultsHeaderRefineButton.activeSelf)
				{
					SearchResultsHeaderRefineButton.SetActive(value: true);
				}
			}
			else
			{
				if (!SearchResultsContentRefineButton.gameObject.activeSelf)
				{
					SearchResultsContentRefineButton.gameObject.SetActive(value: true);
				}
				if (SearchResultsHeaderRefineButton.activeSelf)
				{
					SearchResultsHeaderRefineButton.SetActive(value: false);
				}
			}
		}

		private void Get(ResultAnd<ModPage> response)
		{
			if (response.result.Succeeded())
			{
				if (searchResultsStatus == SearchResultsStatus.GettingFirstResults)
				{
					searchResultsStatus = SearchResultsStatus.RetrievedFirstResults;
				}
				else if (searchResultsStatus == SearchResultsStatus.GettingMoreResults)
				{
					searchResultsStatus = SearchResultsStatus.RetrievedAllResults;
				}
				string text = Utility.GenerateHumanReadableNumber(response.value.totalSearchResultsFound);
				numberOfRemainingResultsToShow = response.value.totalSearchResultsFound - 100;
				moreResultsToShow = numberOfRemainingResultsToShow > 0;
				HashSet<Tag>.Enumerator enumerator = SearchPanel.searchFilterTags.GetEnumerator();
				if (enumerator.MoveNext())
				{
					SearchResultsMainTagName.text = enumerator.Current.NameTranslated;
					SearchResultsMainTagCategoryName.text = enumerator.Current.CategoryTranslated;
					SearchResultsMainTag.SetActive(value: true);
					Translation.Get(SearchResultsNumberOfOtherTagsTranslation, "and {number} other tags", SearchResultsNumberOfOtherTags, $"{SearchPanel.searchFilterTags.Count - 1}");
					LayoutRebuilder.ForceRebuildLayoutImmediate(SearchResultsMainTag.transform.parent as RectTransform);
				}
				else
				{
					SearchResultsMainTag.SetActive(value: false);
				}
				if (SelfInstancingMonoSingleton<SearchPanel>.Instance.SearchPanelField.text.Length > 0)
				{
					SearchResultsSearchPhrase.SetActive(value: true);
					SearchResultsSearchPhraseText.text = SelfInstancingMonoSingleton<SearchPanel>.Instance.SearchPanelField.text;
				}
				else
				{
					SearchResultsSearchPhrase.SetActive(value: false);
				}
				if (response.value.totalSearchResultsFound == 0L)
				{
					SearchResultsNoResultsText.SetActive(value: true);
					SearchResultsEndOfResults.SetActive(value: false);
				}
				else if (moreResultsToShow && searchResultsStatus == SearchResultsStatus.RetrievedFirstResults)
				{
					SearchResultsEndOfResults.gameObject.SetActive(value: false);
				}
				else
				{
					long num = ((response.value.totalSearchResultsFound > 200) ? 200 : response.value.totalSearchResultsFound);
					Translation.Get(SearchResultsEndOfResultsHeaderTranslation, "You've gone through {number} mods", SearchResultsEndOfResultsHeader, $"{num}");
					Translation.Get(SearchResultsEndOfResultsTextTranslation, "Let's refine your search if you haven't found what you were looking for.", SearchResultsEndOfResultsText);
					SearchResultsNoResultsText.SetActive(value: false);
					SearchResultsEndOfResults.SetActive(value: true);
				}
				if (string.IsNullOrWhiteSpace(lastUsedSearchPhrase))
				{
					Translation.Get(SearchResultsFoundTextTranslation, "{num} Mods found", SearchResultsFoundText, text ?? "");
				}
				else
				{
					Translation.Get(SearchResultsFoundTextTranslation, "{num} Mods found for {lastUsedSearchPhrase}", SearchResultsFoundText, text ?? "", "\"" + lastUsedSearchPhrase + "\"");
				}
				Populate(response.value.modProfiles);
			}
			else
			{
				Translation.Get(SearchResultsFoundTextTranslation, "A problem occurred", SearchResultsFoundText);
			}
			ProcessingAnimation.gameObject.SetActive(value: false);
		}

		private void Populate(ModProfile[] mods)
		{
			for (int i = 0; i < mods.Length; i++)
			{
				ListItem listItem = ListItem.GetListItem<SearchResultListItem>(SearchResultsListItemPrefab, SearchResultsListItemParent, SharedUi.colorScheme);
				listItem.Setup(mods[i]);
				listItem.SetViewportRestraint(SearchResultsListItemParent as RectTransform, null);
				int num = mods.Length % 5;
				num = ((num == 0) ? 5 : num);
				if (i >= mods.Length - num)
				{
					listItem.gameObject.GetComponent<SearchResultListItem>().SetAsLastRowItem();
				}
			}
			ListItem.HideListItems<SearchResultListItem>(placeholdersOnly: true);
			UpdateButtonNavigation();
		}

		private void ClearButtonNavigation()
		{
			Navigation navigation = SearchResultsRefineFilter.navigation;
			navigation.selectOnDown = null;
			SearchResultsRefineFilter.navigation = navigation;
			Navigation navigation2 = SearchResultsFilterBy.navigation;
			navigation2.selectOnDown = null;
			SearchResultsFilterBy.navigation = navigation2;
		}

		private void UpdateButtonNavigation()
		{
			int childrenBegin = 2;
			int childrenEnd = 7;
			List<SearchResultListItem> list = (from x in ListItem
				where x.transform.GetSiblingIndex() > childrenBegin && x.transform.GetSiblingIndex() <= childrenEnd
				orderby x.transform.GetSiblingIndex() descending
				select x).ToList();
			if (list.Count > 0)
			{
				Navigation navigation = SearchResultsRefineFilter.navigation;
				navigation.selectOnDown = list[0].selectable;
				SearchResultsRefineFilter.navigation = navigation;
				Navigation navigation2 = SearchResultsFilterBy.navigation;
				navigation2.selectOnDown = list[0].selectable;
				SearchResultsFilterBy.navigation = navigation2;
			}
		}
	}
}
