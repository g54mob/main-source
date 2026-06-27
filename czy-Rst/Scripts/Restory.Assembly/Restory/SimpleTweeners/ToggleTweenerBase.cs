namespace Restory.SimpleTweeners
{
	public abstract class ToggleTweenerBase : SimpleTweenerBase
	{
		public abstract bool IsOn { get; }

		public abstract void TurnOn();

		public abstract void TurnOff();
	}
}
