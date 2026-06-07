using System;

namespace Simulator.GameWorld
{
	public interface IStandUser
	{
		event Action<IStandUser> ArrivedAtStand;

		event Action<IStandUser, bool> QuittedStand;

		void OnAccessStand(Stand stand, NavigationPoint destination, int placeIndex);

		void OnWaitInStandLine(Stand stand, NavigationPoint destination, int queueIndex);

		void OnAskedToQuitStand(Stand stand, bool completed);
	}
}
