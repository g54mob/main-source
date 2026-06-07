using UnityEngine;
using UnityEngine.EventSystems;

namespace CurvedUI
{
	public class CUI_draggable : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler
	{
		private Vector2 savedVector;

		private bool isDragged;

		public void OnBeginDrag(PointerEventData data)
		{
			Debug.Log("OnBeginDrag");
			Vector2 newPos = Vector2.zero;
			RaycastPosition(out newPos);
			savedVector = new Vector2((base.transform as RectTransform).localPosition.x, (base.transform as RectTransform).localPosition.y) - newPos;
			isDragged = true;
		}

		public void OnDrag(PointerEventData data)
		{
		}

		public void OnEndDrag(PointerEventData data)
		{
			Debug.Log("OnEndDrag");
			isDragged = false;
		}

		private void LateUpdate()
		{
			if (isDragged)
			{
				Debug.Log("OnDrag");
				Vector2 newPos = Vector2.zero;
				RaycastPosition(out newPos);
				(base.transform as RectTransform).localPosition = newPos + savedVector;
			}
		}

		private void RaycastPosition(out Vector2 newPos)
		{
			if (CurvedUIInputModule.ControlMethod == CurvedUIInputModule.CUIControlMethod.MOUSE)
			{
				GetComponentInParent<CurvedUISettings>().RaycastToCanvasSpace(Camera.main.ScreenPointToRay(Input.mousePosition), out newPos);
			}
			else if (CurvedUIInputModule.ControlMethod == CurvedUIInputModule.CUIControlMethod.GAZE)
			{
				GetComponentInParent<CurvedUISettings>().RaycastToCanvasSpace(Camera.main.ScreenPointToRay(new Vector2((float)Screen.width / 2f, (float)Screen.height / 2f)), out newPos);
			}
			else
			{
				newPos = Vector2.zero;
			}
		}
	}
}
