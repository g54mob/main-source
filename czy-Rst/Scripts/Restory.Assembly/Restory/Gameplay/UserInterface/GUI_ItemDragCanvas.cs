using Restory.StorageSystem.StorageElements;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.UserInterface
{
	public class GUI_ItemDragCanvas : MonoBehaviour, IInitializable
	{
		[SerializeField]
		private GUI_StorageSlotElementDrag slotElementItem;

		private Transform draggedItemTransform;

		public void Initialize()
		{
			slotElementItem.Hide();
			draggedItemTransform = slotElementItem.transform;
		}

		public void StartDragItem(StorageItemElement itemElement)
		{
			HideItem();
			slotElementItem.SetItem(itemElement);
			Show();
		}

		public void StopDrag()
		{
			HideItem();
			Hide();
		}

		public void ShowItem(Vector2 pointerPosition)
		{
			DragItem(pointerPosition);
			slotElementItem.Show();
		}

		public void HideItem()
		{
			slotElementItem.Hide();
		}

		public void DragItem(Vector2 pointerPosition)
		{
			draggedItemTransform.position = pointerPosition;
		}

		private void Show()
		{
			base.gameObject.SetActive(value: true);
		}

		private void Hide()
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
