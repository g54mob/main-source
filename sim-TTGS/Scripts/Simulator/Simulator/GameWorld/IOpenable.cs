namespace Simulator.GameWorld
{
	public interface IOpenable
	{
		bool IsOpen { get; }

		bool CanBeToggled();

		bool ToggleOpenState();
	}
}
