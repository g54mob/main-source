using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Borodar.FarlandSkies.Core.Demo
{
	public class ColorPicker : MonoBehaviour, IDragHandler, IEventSystemHandler, IEndDragHandler, IPointerClickHandler
	{
		private RectTransform _rectTransform;

		private Image _image;

		public BaseColorButton ColorButton { get; set; }

		public void Awake()
		{
		}

		public void OnDrag(PointerEventData eventData)
		{
		}

		public void OnEndDrag(PointerEventData eventData)
		{
		}

		public void OnPointerClick(PointerEventData eventData)
		{
		}

		private void OnPickColor(PointerEventData eventData)
		{
		}
	}
}
