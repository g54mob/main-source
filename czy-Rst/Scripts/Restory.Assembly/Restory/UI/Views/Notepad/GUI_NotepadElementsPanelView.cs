using System.Collections.Generic;
using Restory.UI.Presenters.Notepad;
using TMPro;
using UnityEngine;

namespace Restory.UI.Views.Notepad
{
	public sealed class GUI_NotepadElementsPanelView : MonoBehaviour
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private RectTransform installedElementsContainer;

		[SerializeField]
		private RectTransform onSurfaceElementsContainer;

		[SerializeField]
		private TMP_Text installedElementsCount;

		[SerializeField]
		private TMP_Text onSurfaceElementsCount;

		private List<GUI_NotepadElementItemView> items = new List<GUI_NotepadElementItemView>();

		public void SetVisibility(bool shouldBeVisible)
		{
			canvasGroup.alpha = (shouldBeVisible ? 1 : 0);
			canvasGroup.blocksRaycasts = shouldBeVisible;
			canvasGroup.interactable = shouldBeVisible;
		}

		public void SetElements(List<ElementItemAndPosition> elementsViews)
		{
			ClearElements();
			AddElements(elementsViews);
		}

		public void ClearElements()
		{
			items.Clear();
			if ((bool)installedElementsContainer)
			{
				installedElementsContainer.DetachChildren();
			}
			if ((bool)onSurfaceElementsContainer)
			{
				onSurfaceElementsContainer.DetachChildren();
			}
		}

		public void Clear()
		{
			ClearElements();
		}

		private void AddElements(List<ElementItemAndPosition> elementItems)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			foreach (ElementItemAndPosition elementItem in elementItems)
			{
				items.Add(elementItem.Item.View);
				SetElementParent(elementItem);
				switch (elementItem.Status)
				{
				case ElementItemStatus.EmptySocket:
					HandleEmptySocket(elementItem, elementItems);
					num++;
					break;
				case ElementItemStatus.InstalledElement:
					num2++;
					num++;
					break;
				case ElementItemStatus.ElementOnSurface:
					num3++;
					break;
				default:
					Debug.LogError($"Unexpected item status: {elementItem.Status}");
					break;
				}
			}
			installedElementsCount.text = $"{num2}/{num}";
			onSurfaceElementsCount.text = $"{num3}";
		}

		private void SetElementParent(ElementItemAndPosition elementItem)
		{
			ElementItemStatus status = elementItem.Status;
			if (status == ElementItemStatus.EmptySocket || status == ElementItemStatus.InstalledElement)
			{
				elementItem.Item.View.transform.SetParent(installedElementsContainer, worldPositionStays: false);
			}
			else
			{
				elementItem.Item.View.transform.SetParent(onSurfaceElementsContainer, worldPositionStays: false);
			}
		}

		private void HandleEmptySocket(ElementItemAndPosition emptyItem, List<ElementItemAndPosition> allItems)
		{
			foreach (ElementItemAndPosition allItem in allItems)
			{
				if (allItem.Status == ElementItemStatus.ElementOnSurface && !(allItem.Item.Info != emptyItem.Item.Info))
				{
					return;
				}
			}
			emptyItem.Item.View.MarkAsEmptySocketWithoutReplacementOnSurface();
		}
	}
}
