namespace Simulator.GameWorld
{
	public interface IUIShouldersInputReceiver
	{
		private static IUIShouldersInputReceiver _current;

		void OnUIInput_GamepadShoulders(float value);

		static void SetCurrent(IUIShouldersInputReceiver receiver)
		{
			_current = receiver;
		}

		static bool HasCurrent(out IUIShouldersInputReceiver receiver)
		{
			receiver = _current;
			return receiver != null;
		}
	}
}
