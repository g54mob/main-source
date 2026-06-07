using System;
using Coherence.Connection;

namespace Coherence.Toolkit.Relay
{
	public interface IRelay
	{
		CoherenceRelayManager RelayManager { get; set; }

		event Action<ConnectionException> OnError;

		void Open();

		void Close();

		void Update();

		void Flush()
		{
		}
	}
}
