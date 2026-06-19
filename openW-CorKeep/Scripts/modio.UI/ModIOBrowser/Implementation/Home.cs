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

		private float browserHeaderLastAlphaTarget = -1f;

		private Dictionary<GameObject, HashSet<ListItem>> cachedModListItemsByRow = new Dictionary<GameObject, HashSet<ListItem>>();

		[Header("Browse Panel Featured Set")]
		[SerializeField]
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
			if (SelfInstancingMonoSingleton<Home>.Instance != null)
			{
				return SelfInstancingMonoSingleton<Home>.Instance.BrowserPanel.activeSelf;
			}
			return false;
		}

		public void Open()
		{
			Navigating.GoToPanel(SelfInstancingMonoSingleton<Home>.Instance.BrowserPanel);
			SelfInstancingMonoSingleton<SelectionManager>.Instance.SelectView(UiViews.Browse);
			SelfInstancingMonoSingleton<NavBar>.Instance.UpdateNavbarSelection();
		}

		public void SelectFeaturedMod()
		{
			if (featuredProfiles != null && featuredProfiles.Length > featuredIndex)
			{
				SelfInstancingMonoSingleton<Details>.Instance.Open(featuredProfiles[featuredIndex], Open);
			}
		}

		public void OpenMoreOptionsForFeaturedSlot()
		{
			if (SelfInstancingMonoSingleton<Home>.Instance.featuredProfiles == null || SelfInstancingMonoSingleton<Home>.Instance.featuredProfiles.Length == 0)
			{
				return;
			}
			List<ContextMenuOption> list = new List<ContextMenuOption>();
			list.Add(new ContextMenuOption
			{
				nameTranslationReference = "Vote up",
				action = delegate
				{
					if (SelfInstancingMonoSingleton<Home>.Instance.featuredProfiles != null && SelfInstancingMonoSingleton<Home>.Instance.featuredProfiles.Length > SelfInstancingMonoSingleton<Home>.Instance.featuredIndex)
					{
						ModIOUnity.RateMod(SelfInstancingMonoSingleton<Home>.Instance.featuredProfiles[SelfInstancingMonoSingleton<Home>.Instance.featuredIndex].id, ModRating.Positive, delegate
						{
						});
						SelfInstancingMonoSingleton<ModioContextMenu>.Instance.Close();
					}
				}
			});
			list.Add(new ContextMenuOption
			{
				nameTranslationReference = "Vote down",
				action = delegate
				{
					if (SelfInstancingMonoSingleton<Home>.Instance.featuredProfiles != null && SelfInstancingMonoSingleton<Home>.Instance.featuredProfiles.Length > SelfInstancingMonoSingleton<Home>.Instance.featuredIndex)
					{
						ModIOUnity.RateMod(SelfInstancingMonoSingleton<Home>.Instance.featuredProfiles[SelfInstancingMonoSingleton<Home>.Instance.featuredIndex].id, ModRating.Negative, delegate
						{
						});
						SelfInstancingMonoSingleton<ModioContextMenu>.Instance.Close();
					}
				}
			});
			list.Add(new ContextMenuOption
			{
				nameTranslationReference = "Report",
				action = delegate
				{
					SelfInstancingMonoSingleton<ModioContextMenu>.Instance.Close();
					SelfInstancingMonoSingleton<Reporting>.Instance.Open(SelfInstancingMonoSingleton<Home>.Instance.featuredProfiles[SelfInstancingMonoSingleton<Home>.Instance.featuredIndex], browserFeaturedSlotSelection);
				}
			});
			if (SelfInstancingMonoSingleton<Collection>.Instance.IsSubscribed(SelfInstancingMonoSingleton<Home>.Instance.featuredProfiles[SelfInstancingMonoSingleton<Home>.Instance.featuredIndex].id) && !Collection.IsDependencyForOtherMods(SelfInstancingMonoSingleton<Home>.Instance.featuredProfiles[SelfInstancingMonoSingleton<Home>.Instance.featuredIndex].id))
			{
				list.Add(new ContextMenuOption
				{
					nameTranslationReference = "Unsubscribe",
					action = delegate
					{
						SelfInstancingMonoSingleton<ModioContextMenu>.Instance.Close();
						SelfInstancingMonoSingleton<Home>.Instance.SubscribeToFeaturedMod();
					}
				});
			}
			SelfInstancingMonoSingleton<ModioContextMenu>.Instance.Open(SelfInstancingMonoSingleton<Home>.Instance.featuredSelectedMoreOptionsButtonPosition, list, SelfInstancingMonoSingleton<Home>.Instance.browserFeaturedSlotSelection);
		}

		public void SubscribeToFeaturedMod()
		{
			if (featuredProfiles == null || featuredProfiles.Length <= featuredIndex)
			{
				return;
			}
			if (SelfInstancingMonoSingleton<Collection>.Instance.IsSubscribed(featuredProfiles[featuredIndex].id))
			{
				if (Collection.IsDependencyForOtherMods(featuredProfiles[featuredIndex].id))
				{
					SelfInstancingMonoSingleton<Notifications>.Instance.AddNotificationToQueue(new Notifications.QueuedNotice
					{
						title = "",
						description = SelfInstancingMonoSingleton<TranslationManager>.Instance.Get("UnsubscribeDepText"),
						positiveAccent = false
					});
					return;
				}
				Translation.Get(featuredSubscribeTranslation, "Subscribe", featuredSelectedSubscribeButtonText);
				Mods.UnsubscribeFromEvent(featuredProfiles[featuredIndex], delegate
				{
					UpdateFeaturedSubscribeButtonText(featuredProfiles[featuredIndex].id);
				});
			}
			else
			{
				Translation.Get(featuredSubscribeTranslation, "Unsubscribe", featuredSelectedSubscribeButtonText);
				Mods.SubscribeToEvent(featuredProfiles[featuredIndex], delegate
				{
					UpdateFeaturedSubscribeButtonText(featuredProfiles[featuredIndex].id);
				});
			}
			RefreshSelectedFeaturedModDetails();
		}

		public void PageFeaturedRow(bool right)
		{
			if (featuredProfiles == null || featuredProfiles.Length == 0)
			{
				return;
			}
			if (right)
			{
				featuredIndex = GetNextIndex(featuredIndex, featuredProfiles.Length);
			}
			else
			{
				featuredIndex = GetPreviousIndex(featuredIndex, featuredProfiles.Length);
			}
			FeaturedModListItem.transitionCount = 0;
			FeaturedModListItem[] array = featuredSlotListItems;
			foreach (FeaturedModListItem featuredModListItem in array)
			{
				int num = ((!right) ? GetNextIndex(featuredModListItem.rowIndex, featuredSlotPositions.Length) : GetPreviousIndex(featuredModListItem.rowIndex, featuredSlotPositions.Length));
				if ((!right) ? ((byte)num != 0) : (num != featuredSlotPositions.Length - 1))
				{
					featuredModListItem.Transition(featuredSlotPositions[featuredModListItem.rowIndex], featuredSlotPositions[num]);
				}
				else
				{
					featuredModListItem.transform.position = featuredSlotPositions[num].position;
					featuredModListItem.profileIndex = GetIndex(change: (!right) ? (featuredSlotPositions.Length * -1) : featuredSlotPositions.Length, current: featuredModListItem.profileIndex, length: featuredProfiles.Length);
					featuredModListItem.Setup(featuredProfiles[featuredModListItem.profileIndex]);
				}
				featuredModListItem.rowIndex = num;
			}
			RefreshSelectedFeaturedModDetails();
		}

		internal void HideFeaturedHighlight()
		{
			browserFeaturedSlotSelectionHighlightBorder.SetActive(value: false);
			StartCoroutine(ImageTransitions.AlphaFast(browserFeaturedSlotBackplate, 0.7f));
			browserFeaturedSlotInfo.SetActive(value: false);
		}

		internal void ShowFeaturedHighlight()
		{
			browserFeaturedSlotSelectionHighlightBorder.SetActive(value: true);
			StartCoroutine(ImageTransitions.AlphaFast(browserFeaturedSlotBackplate, 1f));
			browserFeaturedSlotBackplate.gameObject.SetActive(value: true);
			browserFeaturedSlotInfo.SetActive(value: true);
			RefreshSelectedFeaturedModDetails();
			SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(browserFeaturedSlotSelection, selectEvenWhenUsingMouse: true);
		}

		private void RefreshSelectedFeaturedModDetails()
		{
			if (featuredProfiles != null && featuredProfiles.Length != 0)
			{
				featuredSelectedName.text = featuredProfiles[featuredIndex].name;
				UpdateFeaturedSubscribeButtonText(featuredProfiles[featuredIndex].id);
				RefreshFeaturedCarouselProgressTabs();
			}
		}

		private void RefreshFeaturedCarouselProgressTabs()
		{
			FeaturedModListItem[] array = featuredSlotListItems;
			foreach (FeaturedModListItem featuredModListItem in array)
			{
				featuredModListItem.progressTab.Setup(featuredProfiles[featuredModListItem.profileIndex]);
			}
		}

		private void UpdateFeaturedSubscribeButtonText(ModId id)
		{
			if (SelfInstancingMonoSingleton<Collection>.Instance.IsSubscribed(id))
			{
				if (Collection.IsDependencyForOtherMods(id))
				{
					Translation.Get(featuredSubscribeTranslation, "Dependency", featuredSelectedSubscribeButtonText);
					Button componentInParent = featuredSelectedSubscribeButtonText.GetComponentInParent<Button>();
					if (componentInParent != null)
					{
						componentInParent.GetComponent<Image>().color = SharedUi.colorScheme.GetSchemeColor(ColorSetterType.NegativeAccent);
					}
				}
				else
				{
					Translation.Get(featuredSubscribeTranslation, "Unsubscribe", featuredSelectedSubscribeButtonText);
					Button componentInParent2 = featuredSelectedSubscribeButtonText.GetComponentInParent<Button>();
					if (componentInParent2 != null)
					{
						componentInParent2.GetComponent<Image>().color = SharedUi.colorScheme.GetSchemeColor(ColorSetterType.Inactive1);
					}
				}
			}
			else
			{
				Translation.Get(featuredSubscribeTranslation, "Subscribe", featuredSelectedSubscribeButtonText);
				Button componentInParent3 = featuredSelectedSubscribeButtonText.GetComponentInParent<Button>();
				if (componentInParent3 != null)
				{
					componentInParent3.GetComponent<Image>().color = SharedUi.colorScheme.GetSchemeColor(ColorSetterType.Inactive1);
				}
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(featuredSelectedSubscribeButtonText.transform.parent as RectTransform);
			LayoutRebuilder.ForceRebuildLayoutImmediate(featuredSelectedSubscribeButtonText.transform.parent as RectTransform);
		}

		internal void RefreshHomePanel()
		{
			ClearRowListItems();
			ClearModListItemRowDictionary();
			ModIOUnity.GetMods(MonoSingleton<Browser>.Instance.FeaturedSearchFilter, AddModProfilesToFeaturedCarousel);
			SearchFilter[] browserRowSearchFilters = MonoSingleton<Browser>.Instance.BrowserRowSearchFilters;
			int num = 0;
			ModListRow[] browserPanelModListRows = BrowserPanelModListRows;
			foreach (ModListRow obj in browserPanelModListRows)
			{
				if (num >= browserRowSearchFilters.Length)
				{
					num = browserRowSearchFilters.Length - 1;
				}
				obj.AttemptToPopulateRowWithMods(browserRowSearchFilters[num++]);
			}
		}

		private void ClearRowListItems()
		{
			ListItem.HideListItems<HomeModListItem>();
		}

		internal void AddPlaceholdersToList<T>(Transform list, GameObject prefab, int placeholders)
		{
			for (int i = 0; i < placeholders; i++)
			{
				ListItem listItem = ListItem.GetListItem<T>(prefab, list, SharedUi.colorScheme, getPlaceholders: true);
				listItem.PlaceholderSetup();
				listItem.SetViewportRestraint(SelfInstancingMonoSingleton<SearchResults>.Instance.SearchResultsListItemParent as RectTransform, null);
			}
		}

		internal void AddModListItemToRowDictionaryCache(ListItem item, GameObject row)
		{
			if (!cachedModListItemsByRow.ContainsKey(row))
			{
				cachedModListItemsByRow.Add(row, new HashSet<ListItem>());
			}
			if (!cachedModListItemsByRow[row].Contains(item))
			{
				cachedModListItemsByRow[row].Add(item);
			}
		}

		private void ClearModListItemRowDictionary()
		{
			cachedModListItemsByRow.Clear();
		}

		private void AddModProfilesToFeaturedCarousel(ResultAnd<ModPage> response)
		{
			if (!Browser.IsOpen || !response.result.Succeeded())
			{
				return;
			}
			featuredProfiles = response.value.modProfiles;
			if (response.value.modProfiles.Length < 10 && response.value.modProfiles.Length != 0)
			{
				featuredProfiles = new ModProfile[10];
				int num = 0;
				for (int i = 0; i < 10; i++)
				{
					if (num >= response.value.modProfiles.Length)
					{
						num = 0;
					}
					featuredProfiles[i] = response.value.modProfiles[num];
					num++;
				}
			}
			FeaturedModListItem[] array;
			if (featuredProfiles.Length < 5)
			{
				array = featuredSlotListItems;
				for (int j = 0; j < array.Length; j++)
				{
					array[j].PlaceholderSetup();
				}
				return;
			}
			array = featuredSlotListItems;
			foreach (FeaturedModListItem featuredModListItem in array)
			{
				int num2 = featuredModListItem.rowIndex;
				if (num2 >= featuredProfiles.Length)
				{
					num2 -= featuredProfiles.Length;
				}
				featuredModListItem.Setup(featuredProfiles[featuredModListItem.profileIndex]);
				if (num2 == 2)
				{
					featuredIndex = featuredModListItem.profileIndex;
				}
			}
			RefreshSelectedFeaturedModDetails();
		}

		public void OnScrollValueChange()
		{
			float num = 1f;
			if (num != -1f)
			{
				_ = browserHeaderLastAlphaTarget;
			}
		}

		public void FeaturedItemSelect(bool state)
		{
			isFeaturedItemSelected = state;
		}

		internal static void ModManagementEvent(ModManagementEventType type, ModId id, Result eventResult)
		{
			if (SelfInstancingMonoSingleton<Home>.Instance.featuredProfiles == null)
			{
				return;
			}
			FeaturedModListItem[] array = SelfInstancingMonoSingleton<Home>.Instance.featuredSlotListItems;
			foreach (FeaturedModListItem featuredModListItem in array)
			{
				if ((long)SelfInstancingMonoSingleton<Home>.Instance.featuredProfiles[featuredModListItem.profileIndex].id == (long)id)
				{
					featuredModListItem.progressTab.UpdateStatus(type, id);
				}
			}
		}

		internal static void UpdateProgressState(ProgressHandle handle)
		{
			if (handle == null || !IsOn())
			{
				return;
			}
			if (HomeModListItem.listItems.ContainsKey(handle.modId))
			{
				HomeModListItem.listItems[handle.modId].UpdateProgressBar(handle);
			}
			if (SelfInstancingMonoSingleton<Home>.Instance.featuredProfiles != null)
			{
				FeaturedModListItem[] array = SelfInstancingMonoSingleton<Home>.Instance.featuredSlotListItems;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].progressTab.UpdateProgress(handle);
				}
			}
		}

		public void RefreshModListItems()
		{
			Result result;
			List<SubscribedMod> subbedMods = ModIOUnity.GetSubscribedMods(out result).ToList();
			if (!result.Succeeded())
			{
				return;
			}
			HomeModListItem.listItems.Where((KeyValuePair<ModId, HomeModListItem> x) => x.Value.isActiveAndEnabled).ToList().ForEach(delegate(KeyValuePair<ModId, HomeModListItem> x)
			{
				if (subbedMods.Any((SubscribedMod mod) => mod.modProfile.Equals(x.Value.profile)))
				{
					x.Value.Setup(x.Value.profile);
				}
			});
		}

		public void ResetScrollRect()
		{
			scrollRect.verticalNormalizedPosition = 1f;
		}

		public int GetIndex(int current, int length, int change)
		{
			if (length == 0)
			{
				return 0;
			}
			for (current += change; current >= length; current -= length)
			{
			}
			while (current < 0)
			{
				current += length;
			}
			return current;
		}

		public static int GetPreviousIndex(int current, int length)
		{
			if (length == 0)
			{
				return 0;
			}
			current--;
			if (current < 0)
			{
				current = length - 1;
			}
			return current;
		}

		public static int GetNextIndex(int current, int length)
		{
			if (length == 0)
			{
				return 0;
			}
			current++;
			if (current >= length)
			{
				current = 0;
			}
			return current;
		}
	}
}
