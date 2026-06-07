using UnityEngine;

namespace Simulator.GameWorld
{
	public interface IUIInputReceiver
	{
		private static IUIInputReceiver _current;

		void OnUIInput_Navigate(Vector2 direction);

		void OnUIInput_Point(Vector2 mousePosition);

		void OnUIInput_Submit();

		void OnUIInput_Space();

		void OnUIInput_Memo();

		void OnUIInput_GamepadNorthButton();

		void OnUIInput_GamepadWestButton();

		void OnUIInput_ExitWorkshop();

		static void SetCurrent(IUIInputReceiver receiver)
		{
			_current = receiver;
		}

		static bool HasCurrent(out IUIInputReceiver receiver)
		{
			receiver = _current;
			return receiver != null;
		}
	}
}
