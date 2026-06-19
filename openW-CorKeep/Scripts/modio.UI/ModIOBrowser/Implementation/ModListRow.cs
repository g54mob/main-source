using System.Collections;
using System.Collections.Generic;
using ModIO;
using ModIO.Util;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	public class ModListRow : MonoBehaviour, ISelectHandler, IEventSystemHandler
	{
		[Header("UI Elements")]
		[SerializeField]
		private GameObject ErrorPanel;

		[SerializeField]
		private GameObject LoadingPanel;

		[SerializeField]
		private GameObject RowPanel;

		[SerializeField]
		private GameObject MainSelectableHighlights;

		[SerializeField]
		private GameObject ModListItemPrefab;

		[SerializeField]
		private Transform ModListItemContainer;

		[Header("Selectables")]
		[SerializeField]
		private Selectable AboveSelection;

		[SerializeField]
		private Selectable BelowSelection;

		internal static Vector2 currentSelectedPosition = Vector2.zero;

		private List<ListItem> items = new List<ListItem>();

		private SearchFilter lastUsedFilter;

		public void OnSelect(BaseEventData eventData)
		{
			StartCoroutine(OnSelectFrameDelay());
		}

		private IEnumerator OnSelectFrameDelay()
		{
			yield return null;
			SelectFromPosition(currentSelectedPosition);
		}

		public void SelectFromPosition(Vector2 position)
		{
			if (ErrorPanel.activeSelf || items.Count == 0)
			{
				return;
			}
			ListItem listItem = null;
			float num = -1f;
			foreach (ListItem item in items)
			{
				float num2 = Mathf.Abs(position.x - item.transform.position.x);
				if (num < 0f || num > num2)
				{
					listItem = item;
					num = num2;
				}
			}
			if (listItem == null)
			{
				Debug.LogError("[mod.io Browser] Attempted to select a null item in ModListRow");
			}
			else
			{
				SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(listItem.selectable);
			}
		}

		public void SwipeRow(bool right)
		{
			ListItem listItem = null;
			float num = 0f;
			float width = RowPanel.GetComponent<RectTransform>().rect.width;
			foreach (ListItem item in items)
			{
				if (!(item.transform is RectTransform rectTransform))
				{
					continue;
				}
				float num2 = rectTransform.sizeDelta.x / 2f;
				float x = ModListItemContainer.GetComponent<RectTransform>().anchoredPosition.x;
				float num3 = (right ? (rectTransform.anchoredPosition.x + num2 + x) : (rectTransform.anchoredPosition.x - num2 + x));
				if (!right && num3 < 0f)
				{
					if (num3 > num || num == 0f)
					{
						num = num3;
						listItem = item;
					}
				}
				else if (right && num3 > width && (num3 < num || num == 0f))
				{
					num = num3;
					listItem = item;
				}
			}
			listItem?.viewportRestraint?.CheckSelectionHorizontalVisibility();
			SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(listItem?.selectable);
		}

		public void AttemptToPopulateRowWithMods(SearchFilter filter)
		{
			lastUsedFilter = filter;
			ErrorPanel.SetActive(value: false);
			RowPanel.SetActive(value: false);
			LoadingPanel.SetActive(value: true);
			MainSelectableHighlights.SetActive(value: true);
			ModIOUnity.GetMods(filter, GetModsResponse);
		}

		public void RetryGetMods()
		{
			AttemptToPopulateRowWithMods(lastUsedFilter);
		}

		private void GetModsResponse(ResultAnd<ModPage> response)
		{
			if (Browser.IsOpen)
			{
				LoadingPanel.SetActive(value: false);
				if (response.result.Succeeded())
				{
					PopulateRowFromModPage(response.value);
				}
				else
				{
					ErrorPanel.SetActive(value: true);
				}
			}
		}

		private void PopulateRowFromModPage(ModPage page)
		{
			List<ModProfile> list = new List<ModProfile>();
			ModProfile[] modProfiles = page.modProfiles;
			for (int i = 0; i < modProfiles.Length; i++)
			{
				ModProfile item = modProfiles[i];
				if (item.stats.ratingsPercentagePositive >= 75 && item.stats.downloadsToday >= 10 && item.stats.ratingsPositive >= 10)
				{
					list.Add(item);
				}
			}
			ModProfile[] array = list.ToArray();
			LoadingPanel.SetActive(value: false);
			ErrorPanel.SetActive(value: false);
			RowPanel.SetActive(value: true);
			MainSelectableHighlights.SetActive(value: false);
			items.Clear();
			ListItem listItem = null;
			modProfiles = array;
			foreach (ModProfile profile in modProfiles)
			{
				ListItem listItem2 = ListItem.GetListItem<HomeModListItem>(ModListItemPrefab, ModListItemContainer, SharedUi.colorScheme);
				listItem2.Setup(profile);
				listItem2.SetViewportRestraint(ModListItemContainer as RectTransform, null);
				SelfInstancingMonoSingleton<Home>.Instance.AddModListItemToRowDictionaryCache(listItem2, ModListItemContainer.gameObject);
				Selectable selectOnLeft = null;
				if (listItem != null)
				{
					Navigation navigation = listItem.selectable.navigation;
					navigation.selectOnRight = listItem2.selectable;
					listItem.selectable.navigation = navigation;
					selectOnLeft = listItem.selectable;
				}
				Navigation navigation2 = new Navigation
				{
					mode = Navigation.Mode.Explicit,
					selectOnUp = AboveSelection,
					selectOnDown = BelowSelection,
					selectOnLeft = selectOnLeft
				};
				listItem2.selectable.navigation = navigation2;
				listItem = listItem2;
				items.Add(listItem2);
			}
		}
	}
}
