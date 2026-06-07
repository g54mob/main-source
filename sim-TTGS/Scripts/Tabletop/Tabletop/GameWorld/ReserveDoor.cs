using Simulator.GameWorld;

namespace Tabletop.GameWorld
{
	public class ReserveDoor : Door
	{
		protected override bool CanOpen(bool open)
		{
			if (base.CanOpen(open))
			{
				return ShopExtensionSystem.ReserveExtensionLevel > 0;
			}
			return false;
		}
	}
}
