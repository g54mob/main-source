using UnityEngine.EventSystems;

namespace __Third_Party__.Gamepad_UI_Module.Runtime
{
	public interface IRightStickButtonHandler : IEventSystemHandler
	{
		void OnRightStickButton(ButtonEventData eventData);
	}
}
