namespace Simulator.GameWorld
{
	public interface ISensable
	{
		bool CanBeSensed();

		void OnSensed();

		void OnUnsensed();
	}
}
