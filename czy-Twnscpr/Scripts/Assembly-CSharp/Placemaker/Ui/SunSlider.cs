using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class SunSlider : UIBehaviour, UiMaster.IUiSetup, IPointerUpHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler, IDragHandler, IBeginDragHandler, IEndDragHandler, IPointerDownHandler
	{
		[SerializeField]
		private SunButton sunButton;

		[SerializeField]
		[Space]
		private AudioClip buttonDownClip;

		[SerializeField]
		private AudioClip buttonUpClip;

		[Space]
		[SerializeField]
		private Transform[] handlesToScale;

		public UpdateState scaleZ;

		public UpdateState scaleXY;

		private bool hover;

		private bool pressed;

		void UiMaster.IUiSetup.OnStart(UiMaster master)
		{
		}

		void UiMaster.IUiSetup.OnSetup(UiMaster master)
		{
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
		}

		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
		}

		private void UpdateAnim()
		{
		}

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
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

		public void SetHover(bool isActive)
		{
		}
	}
}
