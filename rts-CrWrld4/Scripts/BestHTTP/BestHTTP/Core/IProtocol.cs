using System;

namespace BestHTTP.Core
{
	public interface IProtocol : IDisposable
	{
		HostConnectionKey ConnectionKey { get; }

		bool IsClosed { get; }

		void HandleEvents();

		void CancellationRequested();
	}
}
