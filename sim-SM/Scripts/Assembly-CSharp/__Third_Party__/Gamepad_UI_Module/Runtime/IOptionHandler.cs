using UnityEngine.EventSystems;

namespace __Third_Party__.Gamepad_UI_Module.Runtime
{
	public interface IOptionHandler : IEventSystemHandler
	{
		void OnOption(ButtonEventData eventData);
	}
}
