using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Rhizomatic
{
	public class CurveHoverColor : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
	{
		public Graphic graphic;

		public Color hoverColor;

		private Color defaultColor;

		private bool isDown;

		private bool isHover;

		private void Awake()
		{
		}

		private void OnDisable()
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		public void OnPointerUp(PointerEventData eventData)
		{
		}
	}
}
