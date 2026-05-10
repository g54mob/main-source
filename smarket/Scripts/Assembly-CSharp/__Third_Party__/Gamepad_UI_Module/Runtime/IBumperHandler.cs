using UnityEngine.EventSystems;

namespace __Third_Party__.Gamepad_UI_Module.Runtime
{
	public interface IBumperHandler : IEventSystemHandler
	{
		void OnBumperLeftPress(ButtonEventData eventData);

		void OnBumperRightPress(ButtonEventData eventData);

		void OnBumperLeftHold(ButtonEventData eventData);

		void OnBumperRightHold(ButtonEventData eventData);
	}
}
