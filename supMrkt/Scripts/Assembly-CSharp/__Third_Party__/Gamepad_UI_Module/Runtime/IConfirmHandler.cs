using UnityEngine.EventSystems;

namespace __Third_Party__.Gamepad_UI_Module.Runtime
{
	public interface IConfirmHandler : IEventSystemHandler
	{
		void OnConfirm(ButtonEventData eventData);

		void OnConfirmHold(ButtonEventData eventData);
	}
}
