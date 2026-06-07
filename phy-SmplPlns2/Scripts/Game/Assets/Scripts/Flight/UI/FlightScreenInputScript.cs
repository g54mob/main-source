using Assets.Scripts.UI;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Flight.UI
{
	public class FlightScreenInputScript : ScreenInputScript, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		private bool _isPressingButtonOrTouching;

		private bool _pointerHovering;

		private bool _pointerHoveringLastFrame;

		public bool IsPointerInside => _pointerHovering;

		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			_isPressingButtonOrTouching = true;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			_pointerHovering = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			_pointerHovering = false;
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
			_isPressingButtonOrTouching = base.TrackedInputs.Count > 0;
		}

		protected virtual void LateUpdate()
		{
			if (!_isPressingButtonOrTouching)
			{
				_ = _pointerHovering;
			}
			if (!_pointerHovering)
			{
				_ = _pointerHoveringLastFrame;
			}
			_pointerHoveringLastFrame = _pointerHovering;
		}
	}
}
