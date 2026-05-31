using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace __Third_Party__.Gamepad_UI_Module.Runtime
{
	public class ButtonAxisEventData : AxisEventData
	{
		public InputActionPhase Phase;

		public ButtonAxisEventData(EventSystem eventSystem)
			: base(null)
		{
		}
	}
}
