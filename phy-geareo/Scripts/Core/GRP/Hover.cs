using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GRP
{
	public class Hover : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerMoveHandler, IPointerExitHandler
	{
		private static List<RaycastResult> raycasts;

		public bool isHover { get; set; }

		public static bool IsHover(GameObject go)
		{
			return false;
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public virtual void OnPointerEnter(PointerEventData eventData)
		{
		}

		public virtual void OnPointerExit(PointerEventData eventData)
		{
		}

		public virtual void OnPointerMove(PointerEventData eventData)
		{
		}
	}
}
