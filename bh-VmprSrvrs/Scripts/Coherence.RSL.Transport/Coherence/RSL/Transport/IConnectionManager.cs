using System;

namespace Coherence.RSL.Transport
{
	public interface IConnectionManager
	{
		Action<ITransportConnection> OnConnectionAttempt { get; set; }

		void OnConnectionClosed(ITransportConnection connection);
	}
}
