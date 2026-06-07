using System;
using Coherence.Brook;
using Coherence.Connection;

namespace Coherence.RSL.Brisk.Connection
{
	public interface IConnectionReceiver
	{
		Action<IInOctetStream> RecvChannel { get; set; }

		void Close(ConnectionCloseReason reason);
	}
}
