using System;

namespace NSMedieval.State
{
	public interface IGameDisposable : IDisposable
	{
		bool HasDisposed { get; }

		event Action<IGameDisposable> OnDisposedEvent;
	}
}
