using UnityEngine.EventSystems;

namespace __Third_Party__.Gamepad_UI_Module.Runtime
{
	public interface ITriggerHandler : IEventSystemHandler
	{
		void OnTriggerLeftPress(ButtonEventData eventData);

		void OnTriggerRightPress(ButtonEventData eventData);

		void OnTriggerLeftHold(ButtonEventData eventData);

		void OnTriggerRightHold(ButtonEventData eventData);
	}
}
