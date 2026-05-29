using System;

namespace CTS
{
	public interface IProcessMachine : IDestructibleFurniture, IInteractiveFurniture, IVisibleBBTObject, IBBTObject, IObject, IVisible, IMachine, IManageableFurniture
	{
		event Action ProcessStarted;

		event Action ProcessEnded;
	}
}
