using UnityEngine.EventSystems;

namespace __Third_Party__.Gamepad_UI_Module.Runtime
{
	public interface IBackHandler : IEventSystemHandler
	{
		void OnBack(ButtonEventData eventData);

		void OnBackHold(ButtonEventData eventData);
	}
}
