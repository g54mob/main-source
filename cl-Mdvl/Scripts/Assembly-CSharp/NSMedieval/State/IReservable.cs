using System;
using NSMedieval.Goap;

namespace NSMedieval.State
{
	public interface IReservable : IGameDisposable, IDisposable
	{
		event Action<IReservable, IGoapAgentOwner> OnReservedEvent;

		event Action<IReservable, IGoapAgentOwner> OnReleasedEvent;

		int GetMaxReservers();

		void OnReservationChanged(bool isReserved, IGoapAgentOwner agent);
	}
}
