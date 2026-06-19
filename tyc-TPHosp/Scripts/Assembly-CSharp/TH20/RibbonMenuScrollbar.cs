using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TH20
{
	public class RibbonMenuScrollbar : Scrollbar
	{
		private RibbonMenu _owningRibbonMenu;

		private InputManager _inputManager;

		public void Setup(RibbonMenu owningRibbonMenu, InputManager inputManager)
		{
			_owningRibbonMenu = owningRibbonMenu;
			_inputManager = inputManager;
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			base.OnPointerDown(eventData);
			_inputManager.NotifyScrollbarDrag(bState: true);
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
			base.OnPointerUp(eventData);
			_inputManager.NotifyScrollbarDrag(bState: false);
		}
	}
}
