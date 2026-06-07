using UnityEngine;
using UnityEngine.EventSystems;

namespace CurvedUI
{
	public class CUI_DragBetweenCanvases : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IEndDragHandler, IDragHandler
	{
		private Vector2 dragPoint;

		public void OnBeginDrag(PointerEventData data)
		{
			Debug.Log("OnBeginDrag");
			Vector2 newPos = Vector2.zero;
			RaycastPosition(out newPos);
			dragPoint = new Vector2((base.transform as RectTransform).localPosition.x, (base.transform as RectTransform).localPosition.y) - newPos;
		}

		public void OnDrag(PointerEventData data)
		{
			CurvedUISettings componentInParent = GetComponentInParent<CurvedUISettings>();
			Ray ray = Camera.main.ScreenPointToRay(new Vector2((float)Screen.width / 2f, (float)Screen.height / 2f));
			if (CurvedUIInputModule.ControlMethod == CurvedUIInputModule.CUIControlMethod.MOUSE)
			{
				ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			}
			else if (CurvedUIInputModule.ControlMethod == CurvedUIInputModule.CUIControlMethod.GAZE)
			{
				ray = Camera.main.ScreenPointToRay(new Vector2((float)Screen.width / 2f, (float)Screen.height / 2f));
			}
			if (!Physics.Raycast(ray, out var hitInfo))
			{
				return;
			}
			CurvedUISettings componentInParent2 = hitInfo.collider.GetComponentInParent<CurvedUISettings>();
			Vector2 o_positionOnCanvas = Vector2.zero;
			if (!(componentInParent2 != null))
			{
				return;
			}
			if (componentInParent2 != componentInParent)
			{
				base.transform.SetParent(componentInParent2.transform);
				base.transform.ResetTransform();
				CurvedUIVertexEffect[] componentsInChildren = GetComponentsInChildren<CurvedUIVertexEffect>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					componentsInChildren[i].FindParentSettings(forceNew: true);
				}
			}
			componentInParent2.RaycastToCanvasSpace(ray, out o_positionOnCanvas);
			(base.transform as RectTransform).localPosition = o_positionOnCanvas + dragPoint;
		}

		public void OnEndDrag(PointerEventData data)
		{
			Debug.Log("OnEndDrag");
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
