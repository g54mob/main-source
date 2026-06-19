using System.Collections.Generic;
using ModIO.Util;
using UnityEngine;
using UnityEngine.UI;

namespace ModIOBrowser.Implementation
{
	internal class ModioContextMenu : SelfInstancingMonoSingleton<ModioContextMenu>
	{
		public GameObject ContextMenu;

		[SerializeField]
		public Transform ContextMenuList;

		[SerializeField]
		public GameObject ContextMenuListItemPrefab;

		[SerializeField]
		public Selectable ContextMenuPreviousSelection;

		internal void Open(Transform t, List<ContextMenuOption> options, Selectable previousSelection)
		{
			if (options.Count < 1)
			{
				return;
			}
			Vector2 vector = t.position;
			vector.y -= 24f;
			if (t is RectTransform rectTransform)
			{
				float x = rectTransform.sizeDelta.x;
				RectTransform obj = base.transform as RectTransform;
				Vector2 sizeDelta = obj.sizeDelta;
				sizeDelta.x = x;
				obj.sizeDelta = sizeDelta;
			}
			ListItem.HideListItems<ContextMenuListItem>();
			ContextMenuPreviousSelection = previousSelection;
			base.gameObject.SetActive(value: true);
			base.transform.position = vector;
			bool flag = false;
			Selectable selectable = null;
			Selectable selectable2 = null;
			foreach (ContextMenuOption option in options)
			{
				ListItem listItem = ListItem.GetListItem<ContextMenuListItem>(ContextMenuListItemPrefab, ContextMenuList, SharedUi.colorScheme);
				listItem.Setup(SelfInstancingMonoSingleton<TranslationManager>.Instance.Get(option.nameTranslationReference), option.action);
				listItem.SetColorScheme(SharedUi.colorScheme);
				Navigation navigation = listItem.selectable.navigation;
				navigation.mode = Navigation.Mode.Explicit;
				navigation.selectOnLeft = null;
				navigation.selectOnRight = null;
				navigation.selectOnUp = selectable;
				navigation.selectOnDown = null;
				listItem.selectable.navigation = navigation;
				if (selectable != null)
				{
					Navigation navigation2 = selectable.navigation;
					navigation2.selectOnDown = listItem.selectable;
					selectable.navigation = navigation2;
				}
				selectable = listItem.selectable;
				if (!flag)
				{
					selectable2 = listItem.selectable;
					flag = true;
				}
			}
			if (!SelfInstancingMonoSingleton<InputNavigation>.Instance.mouseNavigation)
			{
				SelfInstancingMonoSingleton<SelectionManager>.Instance.SetNewViewDefaultSelection(UiViews.ContextMenu, selectable2);
				SelfInstancingMonoSingleton<SelectionManager>.Instance.SelectView(UiViews.ContextMenu);
			}
			LayoutRebuilder.ForceRebuildLayoutImmediate(ContextMenuList as RectTransform);
		}

		public void Close()
		{
			base.gameObject.SetActive(value: false);
			if (ContextMenuPreviousSelection != null)
			{
				SelfInstancingMonoSingleton<InputNavigation>.Instance.Select(SelfInstancingMonoSingleton<ModioContextMenu>.Instance.ContextMenuPreviousSelection);
			}
		}

		private void Update()
		{
			if (base.gameObject.activeSelf && IsMouseInUse())
			{
				RectTransform obj = base.transform as RectTransform;
				Vector3 point = obj.InverseTransformPoint(Input.mousePosition);
				if (!obj.rect.Contains(point))
				{
					base.gameObject.SetActive(value: false);
				}
			}
		}

		private bool IsMouseInUse()
		{
			return SelfInstancingMonoSingleton<InputNavigation>.Instance.mouseNavigation;
		}
	}
}
