namespace Restory.Gameplay.Equipment.Ultrasonic.States
{
	public interface IUltrasonicStateSwitcher
	{
		void EnterDisabledState();

		void EnterIdleState();

		void EnterLaunchedState();
	}
}
