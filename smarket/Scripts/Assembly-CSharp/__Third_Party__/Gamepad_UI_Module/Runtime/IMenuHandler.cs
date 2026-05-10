using UnityEngine.EventSystems;

namespace __Third_Party__.Gamepad_UI_Module.Runtime
{
	public interface IMenuHandler : IEventSystemHandler
	{
		void OnMenu(ButtonEventData eventData);
	}
}
