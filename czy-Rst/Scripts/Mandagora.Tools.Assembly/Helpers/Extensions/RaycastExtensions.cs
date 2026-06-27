using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Helpers.Extensions
{
	public static class RaycastExtensions
	{
		public static void MouseRaycast(this EventSystem eventSystem, Vector2 screenPosition, List<RaycastResult> pointerRaycastResults)
		{
			PointerEventData eventData = new PointerEventData(eventSystem)
			{
				position = screenPosition
			};
			eventSystem.RaycastAll(eventData, pointerRaycastResults);
		}

		public static bool TryGetComponent<T>(this ICollection<RaycastResult> raycastResults, out T component)
		{
			component = default(T);
			foreach (RaycastResult raycastResult in raycastResults)
			{
				if (raycastResult.gameObject != null && raycastResult.gameObject.TryGetComponent<T>(out component))
				{
					return true;
				}
			}
			return false;
		}

		public static bool TryGetComponentInParent<T>(this ICollection<RaycastResult> raycastResults, out T component)
		{
			component = default(T);
			foreach (RaycastResult raycastResult in raycastResults)
			{
				if (!(raycastResult.gameObject == null))
				{
					if (raycastResult.gameObject.TryGetComponent<T>(out component))
					{
						return true;
					}
					component = raycastResult.gameObject.GetComponentInParent<T>();
					if (component != null)
					{
						return true;
					}
				}
			}
			return false;
		}

		public static bool TryGetComponentInFirstParent<T>(this IEnumerable<RaycastResult> raycastResults, out T component)
		{
			component = default(T);
			foreach (RaycastResult raycastResult in raycastResults)
			{
				if (!(raycastResult.gameObject == null))
				{
					component = raycastResult.gameObject.GetComponentInParent<T>();
					return component != null;
				}
			}
			return false;
		}

		public static bool TryGetComponent<T>(this RaycastHit[] raycastResults, out T component)
		{
			component = default(T);
			for (int i = 0; i < raycastResults.Length; i++)
			{
				RaycastHit raycastHit = raycastResults[i];
				if (raycastHit.transform != null && raycastHit.transform.TryGetComponent<T>(out component))
				{
					return true;
				}
			}
			return false;
		}

		public static Vector3 HighestHitPosition(this RaycastHit[] raycastHits, int raycastFunctionHitsCount)
		{
			Vector3 point = raycastHits[0].point;
			for (int i = 0; i < raycastFunctionHitsCount; i++)
			{
				if (raycastHits[i].point.y > point.y)
				{
					point = raycastHits[i].point;
				}
			}
			return point;
		}
	}
}
