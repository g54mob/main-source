using System;
using System.Collections.Generic;
using System.Linq;
using ModIO;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	internal class ListItem : MonoBehaviour
	{
		private static Dictionary<Type, List<ListItem>> ListItems = new Dictionary<Type, List<ListItem>>();

		private static ListItem LastCreatedListItem;

		public ViewportRestraint viewportRestraint;

		public Selectable selectable;

		public bool isPlaceholder;

		public List<ColorSetter> colorSetters = new List<ColorSetter>();

		public List<MultiTargetButton> buttons = new List<MultiTargetButton>();

		public List<MultiTargetDropdown> dropdowns = new List<MultiTargetDropdown>();

		public List<MultiTargetToggle> toggles = new List<MultiTargetToggle>();

		public ColorScheme scheme;

		protected virtual void Awake()
		{
			LastCreatedListItem = this;
		}

		private void Reset()
		{
			GetColorSchemeComponents();
		}

		[ContextMenu("Get Color Setters")]
		public void GetColorSchemeComponents()
		{
			colorSetters = new List<ColorSetter>(GetComponentsInChildren<ColorSetter>());
			buttons = new List<MultiTargetButton>(GetComponentsInChildren<MultiTargetButton>());
			dropdowns = new List<MultiTargetDropdown>(GetComponentsInChildren<MultiTargetDropdown>());
			toggles = new List<MultiTargetToggle>(GetComponentsInChildren<MultiTargetToggle>());
		}

		public void SetColorScheme(ColorScheme scheme)
		{
			this.scheme = scheme;
			foreach (ColorSetter colorSetter in colorSetters)
			{
				colorSetter.Refresh(scheme);
			}
			foreach (MultiTargetButton button in buttons)
			{
				button.scheme = scheme;
			}
			foreach (MultiTargetDropdown dropdown in dropdowns)
			{
				dropdown.scheme = scheme;
			}
			foreach (MultiTargetToggle toggle in toggles)
			{
				toggle.scheme = scheme;
			}
		}

		public virtual void SetViewportRestraint(RectTransform content, RectTransform viewport)
		{
			if (viewportRestraint == null)
			{
				viewportRestraint = base.gameObject.AddComponent<ViewportRestraint>();
			}
			viewportRestraint.DefaultViewportContainer = content;
			viewportRestraint.Viewport = viewport;
		}

		public virtual void Select()
		{
		}

		public virtual void DeSelect()
		{
		}

		public virtual void PlaceholderSetup()
		{
			isPlaceholder = true;
		}

		public virtual void Setup()
		{
			isPlaceholder = false;
		}

		public virtual void Setup(string title)
		{
			isPlaceholder = false;
		}

		public virtual void Setup(string tagName, string tagCategory)
		{
			isPlaceholder = false;
		}

		public virtual void Setup(ModProfile profile)
		{
			isPlaceholder = false;
		}

		public virtual void Setup(SubscribedMod mod)
		{
			isPlaceholder = false;
		}

		public virtual void Setup(InstalledMod profile)
		{
			isPlaceholder = false;
		}

		public virtual void Setup(CollectionProfile profile)
		{
			isPlaceholder = false;
		}

		public virtual void Setup(ModProfile profile, bool subscriptionStatus, string progressStatus)
		{
			isPlaceholder = false;
		}

		public virtual void Setup(Action onClick)
		{
			isPlaceholder = false;
		}

		public virtual void Setup(string title, Action onClick)
		{
			isPlaceholder = false;
		}

		public void RedrawRectTransform()
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(base.transform as RectTransform);
		}

		public static ListItem GetListItem<T>(GameObject prefab, Transform parent, ColorScheme scheme, bool getPlaceholders = false)
		{
			Type typeFromHandle = typeof(T);
			if (!ListItems.ContainsKey(typeFromHandle))
			{
				ListItems.Add(typeFromHandle, new List<ListItem>());
			}
			foreach (ListItem item in ListItems[typeFromHandle])
			{
				if (!(item == null) && (!item.gameObject.activeSelf || (item.isPlaceholder && !getPlaceholders)))
				{
					item.SetColorScheme(scheme);
					item.transform.SetParent(parent);
					return item;
				}
			}
			UnityEngine.Object.Instantiate(prefab).transform.SetParent(parent);
			LastCreatedListItem.transform.localScale = Vector3.one;
			ListItems[typeFromHandle].Add(LastCreatedListItem);
			LastCreatedListItem.SetColorScheme(scheme);
			return LastCreatedListItem;
		}

		public static void HideListItems<T>(bool placeholdersOnly = false)
		{
			Type typeFromHandle = typeof(T);
			bool flag = false;
			if (ListItems.ContainsKey(typeFromHandle))
			{
				foreach (ListItem item in ListItems[typeFromHandle])
				{
					if (item == null)
					{
						flag = true;
					}
					else if (!placeholdersOnly || item.isPlaceholder)
					{
						item.gameObject.SetActive(value: false);
					}
				}
			}
			if (flag)
			{
				CleanupMissingReferencesInListItemGroup<T>();
			}
		}

		public static void CleanupMissingReferencesInListItemGroup<T>()
		{
			List<ListItem> list = new List<ListItem>();
			Type typeFromHandle = typeof(T);
			if (!ListItems.ContainsKey(typeFromHandle))
			{
				return;
			}
			foreach (ListItem item in ListItems[typeFromHandle])
			{
				if (item != null)
				{
					list.Add(item);
				}
			}
			ListItems[typeFromHandle] = list;
		}

		public static IEnumerable<T> Where<T>(Func<T, bool> predicate) where T : ListItem
		{
			Type typeFromHandle = typeof(T);
			if (!ListItems.ContainsKey(typeFromHandle))
			{
				ListItems.Add(typeFromHandle, new List<ListItem>());
			}
			return ListItems[typeFromHandle].Where((ListItem x) => predicate(x as T)).OfType<T>();
		}
	}
}
