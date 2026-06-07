using Simulator.GameWorld;

namespace Tabletop.GameWorld
{
	public class TabletopPlayerCharacter : PlayerCharacter, ITabletopPlayerInputReceiver, IPlayerInputReceiver
	{
		public virtual void OnPlayerInput_Collection()
		{
			Collection.Open(ECollectionMode.BROWSE);
		}
	}
}
