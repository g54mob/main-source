using UnityEngine.EventSystems;

namespace __Third_Party__.Gamepad_UI_Module.Runtime
{
	public interface ILeftStickHandler : IEventSystemHandler
	{
		void OnLeftStick(ButtonAxisEventData eventData);

		void OnLeftStickHold(ButtonAxisEventData eventData);
	}
}
