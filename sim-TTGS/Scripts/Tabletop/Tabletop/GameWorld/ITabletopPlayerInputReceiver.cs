using Simulator.GameWorld;

namespace Tabletop.GameWorld
{
	public interface ITabletopPlayerInputReceiver : IPlayerInputReceiver
	{
		void OnPlayerInput_Collection();
	}
}
