using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace Dorfromantik
{
	public class CameraUtility : MonoBehaviour
	{
		public static Vector3 ScreenPosToWorldPosOnGroundPlane(Camera targetCamera, Vector2 screenPoint)
		{
			Ray ray = targetCamera.ScreenPointToRay(new Vector3(screenPoint.x, screenPoint.y));
			new Plane(Vector3.up, Vector3.zero).Raycast(ray, out var enter);
			return ray.GetPoint(enter);
		}

		public static Vector3 ViewportPosToWorldPosOnGroundPlane(Vector2 viewPortPoint, Camera targetCamera)
		{
			Ray ray = targetCamera.ViewportPointToRay(new Vector3(viewPortPoint.x, viewPortPoint.y));
			new Plane(Vector3.up, Vector3.zero).Raycast(ray, out var enter);
			return ray.GetPoint(enter);
		}

		public static GameObject PointerGameObject(params int[] uiLayers)
		{
			PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
			pointerEventData.position = Pointer.current.position.ReadValue();
			List<RaycastResult> list = new List<RaycastResult>();
			EventSystem.current.RaycastAll(pointerEventData, list);
			foreach (RaycastResult item in list)
			{
				if (Enumerable.Contains(uiLayers, item.gameObject.layer))
				{
					return item.gameObject;
				}
			}
			return null;
		}

		public static bool IsVisibleByCamera(Vector3 checkWorldPoint, Camera targetCamera, Vector2 offscreenMargin)
		{
			Vector3 vector = targetCamera.WorldToViewportPoint(checkWorldPoint);
			if (vector.x >= 0f - offscreenMargin.x && vector.x <= 1f + offscreenMargin.x && vector.y >= 0f - offscreenMargin.y && vector.y <= 1f + offscreenMargin.y)
			{
				return true;
			}
			return false;
		}
	}
}
