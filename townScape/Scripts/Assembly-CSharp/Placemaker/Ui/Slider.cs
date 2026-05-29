using Os.Utils;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class Slider : UIBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, UiMaster.IUiSetup
	{
		[SerializeField]
		public UnityEvent_Float onValueChange;

		public bool pointerInside;

		public bool buttonDown;

		public bool dragging;

		public RectTransform sliderContainer;

		public RectTransform sliderHandle;

		public RectTransform sliderBackground0;

		public RectTransform sliderBackground1;

		private float oldValue;

		private float newValue;

		private UpdateState pressedState;

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
		}

		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
		}

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
		{
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
		}

		void IDragHandler.OnDrag(PointerEventData eventData)
		{
		}

		void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
		{
		}

		void IEndDragHandler.OnEndDrag(PointerEventData eventData)
		{
		}

		public float GetValue()
		{
			return 0f;
		}

		public void SetValue(float value)
		{
		}

		protected override void OnRectTransformDimensionsChange()
		{
		}

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}
	}
}
