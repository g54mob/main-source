using Assets.Nimbatus.Scripts.Common.Cursor;
using Assets.Nimbatus.Scripts.Controls.Keybinds;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Selection;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging
{
	public class NimbatusItemDropSurface : MonoBehaviour
	{
		public float DragSpeed = 10f;

		private Vector3 _targetPosition;

		private Vector3 _origin;

		private Vector3 _difference;

		private static bool _hasStarted;

		public void OnClick()
		{
			if (DragAndDropHelper.DraggedItem == null)
			{
				ItemSelector.Reset();
			}
			OnDrop(null);
		}

		public void OnDragStart()
		{
			if (!BaseSingleton<KeybindManager>.Instance.GetKey(EKeybinding.MultiSelect))
			{
				_hasStarted = true;
				_origin = MousePos();
			}
		}

		public void OnDragEnd()
		{
			_hasStarted = false;
		}

		public void OnDrag()
		{
			if (_hasStarted && !BaseSingleton<KeybindManager>.Instance.GetKey(EKeybinding.MultiSelect))
			{
				_difference = MousePos() - Camera.main.transform.position;
				_targetPosition = _origin - _difference;
				Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, _targetPosition, Time.smoothDeltaTime * DragSpeed);
			}
		}

		private Vector3 MousePos()
		{
			return Camera.main.ScreenToWorldPoint(Input.mousePosition);
		}

		public void Update()
		{
			if ((!Input.GetKey(KeyCode.Escape) && !Input.GetMouseButtonDown(1)) || !(DragAndDropHelper.DraggedItem != null))
			{
				return;
			}
			DragAndDropHelper.DraggedItem.IsDraggable = false;
			if (DragAndDropHelper.DraggedItem is DronePart)
			{
				DronePart dronePart = DragAndDropHelper.DraggedItem as DronePart;
				if (dronePart != null)
				{
					dronePart.Delete();
					BaseSingleton<UndoManager>.Instance.Store(UndoManager.EStoreReason.Delete);
				}
			}
			else
			{
				Object.Destroy(DragAndDropHelper.DraggedItem.gameObject);
			}
			NimbatusCursor.Clear();
			DragAndDropHelper.DraggedItem = null;
		}

		public void OnDrop(GameObject o)
		{
			if (DragAndDropHelper.DraggedItem != null && DragAndDropHelper.DraggedItem.ShouldBePlaced())
			{
				PlaceItem(DragAndDropHelper.DraggedItem);
				NimbatusCursor.Clear();
				DragAndDropHelper.DraggedItem = null;
			}
		}

		public void PlaceItem(NimbatusItem item)
		{
			NimbatusCursor.Clear();
			item.transform.position = new Vector3(item.transform.position.x, item.transform.position.y, base.transform.position.z - 1f);
			item.EnableColliders(true);
			DronePart dronePart;
			if ((object)(dronePart = item as DronePart) != null)
			{
				dronePart.Place();
				ItemSelector.Select(dronePart);
			}
			if (BaseSingleton<UndoManager>.Instance != null)
			{
				BaseSingleton<UndoManager>.Instance.Store();
			}
		}
	}
}
