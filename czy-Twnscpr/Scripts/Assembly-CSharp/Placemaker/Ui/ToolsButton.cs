using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Placemaker.Ui
{
	public class ToolsButton : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDropHandler
	{
		[SerializeField]
		public bool hovered;

		[SerializeField]
		public bool down;

		[SerializeField]
		public bool selected;

		[SerializeField]
		public bool disabled;

		[SerializeField]
		private float hoverLerp;

		[SerializeField]
		private float downLerp;

		[SerializeField]
		private float selectedLerp;

		[SerializeField]
		private float disabledLerp;

		[SerializeField]
		private DistanceFieldSettings backround;

		[SerializeField]
		private DistanceFieldSettings foreground;

		public Action onClicked;

		void IDropHandler.OnDrop(PointerEventData eventData)
		{
		}

		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
		{
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
		}

		void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
		{
		}

		private void Start()
		{
		}

		private void Setup()
		{
		}

		private void Update()
		{
		}
	}
}
