using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModIO;
using ModIO.Util;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	internal class SearchPanel : SelfInstancingMonoSingleton<SearchPanel>
	{
		[Header("Search Panel")]
		[SerializeField]
		public GameObject SearchPanelGameObject;

		[SerializeField]
		public TMP_InputField SearchPanelField;

		[SerializeField]
		private GameObject SearchPanelTagCategoryPrefab;

		[SerializeField]
		private RectTransform SearchPanelTagViewport;

		[SerializeField]
		private Transform SearchPanelTagParent;

		[SerializeField]
		private GameObject SearchPanelTagPrefab;

		[SerializeField]
		public Image SearchPanelLeftBumperIcon;

		[SerializeField]
		public Image SearchPanelRightBumperIcon;

		public static HashSet<Tag> searchFilterTags = new HashSet<Tag>();

		internal TagCategory[] tags;

		private bool gettingTags;

		public void Open()
		{
			SearchPanelGameObject.SetActive(value: true);
			SelfInstancingMonoSingleton<SelectionManager>.Instance.SelectView(UiViews.SearchFilters);
			SearchPanelField.text = "";
			FieldNavigationLock();
			SetupTags();
		}

		private void FieldNavigationLock()
		{
			Navigation navigation = SearchPanelField.navigation;
			navigation.mode = Navigation.Mode.None;
			SearchPanelField.navigation = navigation;
		}

		private void FieldNavigationUnlock(List<Selectable> listItems)
		{
			Navigation navigation = SearchPanelField.navigation;
			navigation.mode = Navigation.Mode.Explicit;
			if (listItems.Count > 0)
			{
				navigation.selectOnDown = listItems[0];
			}
			navigation.selectOnUp = null;
			navigation.selectOnRight = null;
			navigation.selectOnLeft = null;
			SearchPanelField.navigation = navigation;
		}

		public void Close()
		{
			InputReceiver.currentSelectedInputField = null;
			SearchPanelGameObject.SetActive(value: false);
			SelfInstancingMonoSingleton<SelectionManager>.Instance.SelectPreviousView();
		}

		public void ClearFilter()
		{
			searchFilterTags = new HashSet<Tag>();
			SearchPanelField.SetTextWithoutNotify("");
			SetupTags();
		}

		public void SetupTags()
		{
			if (tags != null)
			{
				CreateTagCategoryListItems(tags);
			}
			else
			{
				UpdateTags();
			}
		}

		internal async Task WaitForTagsToUpdate()
		{
			if (!gettingTags && tags == null)
			{
				UpdateTags();
			}
			while (gettingTags)
			{
				await Task.Yield();
			}
		}

		private void UpdateTags()
		{
			gettingTags = true;
			ModIOUnity.GetTagCategories(ReceiveTags);
		}

		private void ReceiveTags(ResultAnd<TagCategory[]> resultAndTags)
		{
			if (resultAndTags.result.Succeeded())
			{
				tags = resultAndTags.value;
				CreateTagCategoryListItems(resultAndTags.value);
			}
			gettingTags = false;
		}

		internal List<string> GetHiddenTags()
		{
			List<string> list = new List<string>();
			TagCategory[] array = tags;
			for (int i = 0; i < array.Length; i++)
			{
				TagCategory tagCategory = array[i];
				if (tagCategory.hidden)
				{
					ModIO.Tag[] array2 = tagCategory.tags;
					for (int j = 0; j < array2.Length; j++)
					{
						ModIO.Tag tag = array2[j];
						list.Add(SelfInstancingMonoSingleton<TranslationManager>.Instance.Get(tag.name));
					}
				}
			}
			return list;
		}

		private void CreateTagCategoryListItems(TagCategory[] tags)
		{
			if (tags == null || tags.Length < 1)
			{
				return;
			}
			ListItem.HideListItems<TagListItem>();
			ListItem.HideListItems<TagCategoryListItem>();
			TagJumpToSelection.ClearCache();
			List<Selectable> list = new List<Selectable>();
			for (int i = 0; i < tags.Length; i++)
			{
				TagCategory category = tags[i];
				if (!category.hidden)
				{
					ListItem.GetListItem<TagCategoryListItem>(SearchPanelTagCategoryPrefab, SearchPanelTagParent, SharedUi.colorScheme).Setup(SelfInstancingMonoSingleton<TranslationManager>.Instance.Get(category.name));
					IEnumerable<ListItem> source = CreateTagListItems(category);
					list.AddRange(source.Select((ListItem x) => x.selectable));
				}
			}
			UpdateBumperIcons();
			List<Selectable> list2 = list.OrderBy((Selectable x) => x.transform.GetSiblingIndex()).ToList();
			ReorderAndSetNavigation(list2);
			LayoutRebuilder.ForceRebuildLayoutImmediate(SearchPanelTagParent as RectTransform);
			FieldNavigationUnlock(list2);
		}

		private void ReorderAndSetNavigation(List<Selectable> items)
		{
			items.ForEach(delegate(Selectable x)
			{
				Navigation navigation4 = x.navigation;
				navigation4.mode = Navigation.Mode.Explicit;
				navigation4.selectOnUp = null;
				navigation4.selectOnDown = null;
				navigation4.selectOnRight = null;
				navigation4.selectOnLeft = null;
				x.navigation = navigation4;
			});
			for (int num = 0; num < items.Count(); num++)
			{
				Navigation navigation = items[num].navigation;
				if (GetWithinBoundsOfList(items, num - 1, out var item))
				{
					navigation.selectOnUp = item;
					Navigation navigation2 = item.navigation;
					navigation2.selectOnDown = items[num];
					item.navigation = navigation2;
				}
				else
				{
					navigation.selectOnUp = SearchPanelField;
				}
				if (GetWithinBoundsOfList(items, num + 1, out var item2))
				{
					navigation.selectOnDown = item2;
					Navigation navigation3 = item2.navigation;
					navigation3.selectOnDown = items[num];
					item2.navigation = navigation3;
				}
				else
				{
					navigation.selectOnDown = null;
				}
				items[num].navigation = navigation;
			}
		}

		private bool GetWithinBoundsOfList<T>(List<T> list, int index, out T item)
		{
			item = default(T);
			if (index >= 0 && index < list.Count())
			{
				item = list[index];
				return true;
			}
			return false;
		}

		private IEnumerable<ListItem> CreateTagListItems(TagCategory category)
		{
			bool setJumpTo = false;
			ModIO.Tag[] array = category.tags;
			for (int i = 0; i < array.Length; i++)
			{
				ModIO.Tag tag = array[i];
				ListItem listItem = ListItem.GetListItem<TagListItem>(SearchPanelTagPrefab, SearchPanelTagParent, SharedUi.colorScheme);
				listItem.Setup(tag.name, category.name);
				listItem.SetViewportRestraint(SearchPanelTagParent as RectTransform, SearchPanelTagViewport);
				if (!setJumpTo)
				{
					listItem.Setup();
					setJumpTo = true;
				}
				yield return listItem;
			}
		}

		public void ApplyFilter()
		{
			SelfInstancingMonoSingleton<SearchResults>.Instance.Open(SearchPanelField.text);
		}

		internal void UpdateBumperIcons()
		{
			Color color = SearchPanelLeftBumperIcon.color;
			color.a = (TagJumpToSelection.CanTabLeft() ? 1f : 0.2f);
			SearchPanelLeftBumperIcon.color = color;
			Color color2 = SearchPanelRightBumperIcon.color;
			color2.a = (TagJumpToSelection.CanTabRight() ? 1f : 0.2f);
			SearchPanelRightBumperIcon.color = color2;
		}

		internal void ToggleState()
		{
			if (SearchPanelGameObject.activeSelf)
			{
				SelfInstancingMonoSingleton<SearchPanel>.Instance.Close();
			}
			else
			{
				SelfInstancingMonoSingleton<SearchPanel>.Instance.Open();
			}
		}
	}
}
