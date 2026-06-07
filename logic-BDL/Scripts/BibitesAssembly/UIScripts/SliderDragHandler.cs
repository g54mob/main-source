using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UIScripts
{
	public class SliderDragHandler : MonoBehaviour, IBeginDragHandler, IEventSystemHandler, IEndDragHandler
	{
		[SerializeField]
		private Slider slider;

		public UnityEvent<float> onEndDrag = new UnityEvent<float>();

		public UnityEvent<float> onBeginDrag = new UnityEvent<float>();

		public void OnBeginDrag(PointerEventData eventData)
		{
			onBeginDrag.Invoke(slider.value);
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			onEndDrag.Invoke(slider.value);
		}
	}
}
