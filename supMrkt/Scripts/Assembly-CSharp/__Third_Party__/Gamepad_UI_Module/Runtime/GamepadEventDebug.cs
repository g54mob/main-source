using UnityEngine;
using UnityEngine.EventSystems;

namespace __Third_Party__.Gamepad_UI_Module.Runtime
{
	public class GamepadEventDebug : MonoBehaviour, IConfirmHandler, IEventSystemHandler, IBackHandler, ITriggerHandler, IBumperHandler, IMenuHandler, IOptionHandler
	{
		public void OnConfirm(ButtonEventData eventData)
		{
		}

		public void OnConfirmHold(ButtonEventData eventData)
		{
		}

		public void OnBack(ButtonEventData eventData)
		{
		}

		public void OnBackHold(ButtonEventData eventData)
		{
		}

		public void OnTriggerLeftPress(ButtonEventData eventData)
		{
		}

		public void OnTriggerRightPress(ButtonEventData eventData)
		{
		}

		public void OnTriggerLeftHold(ButtonEventData eventData)
		{
		}

		public void OnTriggerRightHold(ButtonEventData eventData)
		{
		}

		public void OnBumperLeftPress(ButtonEventData eventData)
		{
		}

		public void OnBumperRightPress(ButtonEventData eventData)
		{
		}

		public void OnBumperLeftHold(ButtonEventData eventData)
		{
		}

		public void OnBumperRightHold(ButtonEventData eventData)
		{
		}

		public void OnMenu(ButtonEventData eventData)
		{
		}

		public void OnOption(ButtonEventData eventData)
		{
		}
	}
}
