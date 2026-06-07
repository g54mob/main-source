using UnityEngine.EventSystems;

namespace __Third_Party__.Gamepad_UI_Module.Runtime
{
	public interface INorthButtonHandler : IEventSystemHandler
	{
		void OnNorthButton(ButtonEventData eventData);
	}
}
