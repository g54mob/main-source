using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace __Third_Party__.Gamepad_UI_Module.Runtime
{
	public class ButtonEventData : BaseEventData
	{
		public InputActionPhase Phase;

		public ButtonEventData(EventSystem eventSystem)
			: base(null)
		{
		}
	}
}
