using Assets.Nimbatus.Scripts.Common.Cursor;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging
{
	public static class DragAndDropHelper
	{
		private static NimbatusItem _draggedItem;

		public static NimbatusItem DraggedItem
		{
			get
			{
				return _draggedItem;
			}
			set
			{
				if (value != null)
				{
					value.IsDragged(true);
				}
				if (_draggedItem != null)
				{
					_draggedItem.IsDragged(false);
				}
				_draggedItem = value;
			}
		}

		public static void DeleteDraggedItem()
		{
			DraggedItem.IsDraggable = false;
			if (DraggedItem is DronePart)
			{
				DronePart dronePart = DraggedItem as DronePart;
				if (dronePart != null)
				{
					dronePart.Delete();
					BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.Delete);
				}
			}
			else
			{
				Object.Destroy(DraggedItem.gameObject);
			}
			NimbatusCursor.Clear();
			DraggedItem = null;
		}
	}
}
