using System.Collections;
using System.Collections.Generic;
using ModIO;
using ModIO.Util;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	public class Home : SelfInstancingMonoSingleton<Home>
	{
		[Header("Browse Panel")]
		public GameObject BrowserPanel;

		[SerializeField]
		private Transform BrowserPanelContent;

		[SerializeField]
		private ModListRow[] BrowserPanelModListRows;

		[SerializeField]
		private Image BrowserPanelHeaderBackground;

		[SerializeField]
		private Scrollbar BrowserPanelContentScrollBar;

		private IEnumerator browserHeaderTransition;

		private float browserHeaderLastAlphaTarget;

		private Dictionary<GameObject, HashSet<ListItem>> cachedModListItemsByRow;

		[SerializeField]
		[Header("Browse Panel Featured Set")]
		private FeaturedModListItem[] featuredSlotListItems;

		[SerializeField]
		private RectTransform[] featuredSlotPositions;

		[SerializeField]
		private TMP_Text featuredSelectedName;

		[SerializeField]
		private TMP_Text featuredSelectedSubscribeButtonText;

		[SerializeField]
		private Transform featuredSelectedMoreOptionsButtonPosition;

		[SerializeField]
		private GameObject browserFeaturedSlotSelectionHighlightBorder;

		[SerializeField]
		private Image browserFeaturedSlotBackplate;

		[SerializeField]
		private GameObject browserFeaturedSlotInfo;

		[SerializeField]
		private GameObject featuredOptionsButtons;

		[SerializeField]
		private ScrollRect scrollRect;

		internal bool isFeaturedItemSelected;

		private ModProfile[] featuredProfiles;

		private int featuredIndex;

		[Header("Settings")]
		[SerializeField]
		private Selectable browserFeaturedSlotSelection;

		internal Translation featuredSubscribeTranslation;

		public static bool IsOn()
		{
			return false;
		}

		public void Open()
		{
		}

		public void SelectFeaturedMod()
		{
		}

		public void OpenMoreOptionsForFeaturedSlot()
		{
		}

		public void SubscribeToFeaturedMod()
		{
		}

		public void PageFeaturedRow(bool right)
		{
		}

		internal void HideFeaturedHighlight()
		{
		}

		internal void ShowFeaturedHighlight()
		{
		}

		private void RefreshSelectedFeaturedModDetails()
		{
		}

		private void RefreshFeaturedCarouselProgressTabs()
		{
		}

		private void UpdateFeaturedSubscribeButtonText(ModId id)
		{
		}

		internal void RefreshHomePanel()
		{
		}

		private void ClearRowListItems()
		{
		}

		internal void AddPlaceholdersToList<T>(Transform list, GameObject prefab, int placeholders)
		{
		}

		internal void AddModListItemToRowDictionaryCache(ListItem item, GameObject row)
		{
		}

		private void ClearModListItemRowDictionary()
		{
		}

		private void AddModProfilesToFeaturedCarousel(ResultAnd<ModPage> response)
		{
		}

		public void OnScrollValueChange()
		{
		}

		public void FeaturedItemSelect(bool state)
		{
		}

		internal static void ModManagementEvent(ModManagementEventType type, ModId id, Result eventResult)
		{
		}

		internal static void UpdateProgressState(ProgressHandle handle)
		{
		}

		public void RefreshModListItems()
		{
		}

		public void ResetScrollRect()
		{
		}

		public int GetIndex(int current, int length, int change)
		{
			return 0;
		}

		public static int GetPreviousIndex(int current, int length)
		{
			return 0;
		}

		public static int GetNextIndex(int current, int length)
		{
			return 0;
		}
	}
}
