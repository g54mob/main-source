using UnityEngine;
using UnityEngine.EventSystems;

namespace UIScripts
{
	public class OnHoverKeep : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		public OnHoverShow hoverShow;

		private void Awake()
		{
			if (hoverShow == null)
			{
				Object.Destroy(this);
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (base.gameObject.activeSelf)
			{
				hoverShow.OnPointerEnter(eventData);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (base.gameObject.activeSelf)
			{
				hoverShow.OnPointerExit(eventData);
			}
		}
	}
}
