using System;
using System.Collections.Generic;
using ModIO;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	internal class ListItem : MonoBehaviour
	{
		private static Dictionary<Type, List<ListItem>> ListItems;

		private static ListItem LastCreatedListItem;

		public ViewportRestraint viewportRestraint;

		public Selectable selectable;

		public bool isPlaceholder;

		public List<ColorSetter> colorSetters;

		public List<MultiTargetButton> buttons;

		public List<MultiTargetDropdown> dropdowns;

		public List<MultiTargetToggle> toggles;

		public ColorScheme scheme;

		protected virtual void Awake()
		{
		}

		private void Reset()
		{
		}

		[ContextMenu("Get Color Setters")]
		public void GetColorSchemeComponents()
		{
		}

		public void SetColorScheme(ColorScheme scheme)
		{
		}

		public virtual void SetViewportRestraint(RectTransform content, RectTransform viewport)
		{
		}

		public virtual void Select()
		{
		}

		public virtual void DeSelect()
		{
		}

		public virtual void PlaceholderSetup()
		{
		}

		public virtual void Setup()
		{
		}

		public virtual void Setup(string title)
		{
		}

		public virtual void Setup(string tagName, string tagCategory)
		{
		}

		public virtual void Setup(ModProfile profile)
		{
		}

		public virtual void Setup(SubscribedMod mod)
		{
		}

		public virtual void Setup(InstalledMod profile)
		{
		}

		public virtual void Setup(CollectionProfile profile)
		{
		}

		public virtual void Setup(ModProfile profile, bool subscriptionStatus, string progressStatus)
		{
		}

		public virtual void Setup(Action onClick)
		{
		}

		public virtual void Setup(string title, Action onClick)
		{
		}

		public void RedrawRectTransform()
		{
		}

		public static ListItem GetListItem<T>(GameObject prefab, Transform parent, ColorScheme scheme, bool getPlaceholders = false)
		{
			return null;
		}

		public static void HideListItems<T>(bool placeholdersOnly = false)
		{
		}

		public static void CleanupMissingReferencesInListItemGroup<T>()
		{
		}

		public static IEnumerable<T> Where<T>(Func<T, bool> predicate) where T : ListItem
		{
			return null;
		}
	}
}
