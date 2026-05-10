using UnityEngine.EventSystems;

namespace __Third_Party__.Gamepad_UI_Module.Runtime
{
	public interface IWestButtonHandler : IEventSystemHandler
	{
		void OnWestButton(ButtonEventData eventData);
	}
}
