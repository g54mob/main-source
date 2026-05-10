using UnityEngine.EventSystems;

namespace __Third_Party__.Gamepad_UI_Module.Runtime
{
	public interface ILeftStickButtonHandler : IEventSystemHandler
	{
		void OnLeftStickButton(ButtonEventData eventData);
	}
}
