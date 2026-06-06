using UnityEngine;
using UnityEngine.EventSystems;

namespace PajamaLlama.Extensions
{
	public static class EventDataExtensions
	{
		public static bool IsPointerOver(this PointerEventData eventData, GameObject gameObject, bool checkIsParent = false)
		{
			GameObject gameObject2 = eventData.pointerCurrentRaycast.gameObject;
			if (!(gameObject2 == gameObject))
			{
				if (checkIsParent && gameObject2 != null)
				{
					return gameObject2.transform.IsChildOf(gameObject.transform);
				}
				return false;
			}
			return true;
		}
	}
}
