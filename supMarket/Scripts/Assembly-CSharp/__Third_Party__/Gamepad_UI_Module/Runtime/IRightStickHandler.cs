using UnityEngine.EventSystems;

namespace __Third_Party__.Gamepad_UI_Module.Runtime
{
	public interface IRightStickHandler : IEventSystemHandler
	{
		void OnRightStick(ButtonAxisEventData eventData);

		void OnRightStickHold(ButtonAxisEventData eventData);
	}
}
