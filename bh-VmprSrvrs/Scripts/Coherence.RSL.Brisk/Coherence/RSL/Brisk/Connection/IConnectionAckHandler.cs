using System;
using Coherence.Brook;

namespace Coherence.RSL.Brisk.Connection
{
	public interface IConnectionAckHandler
	{
		Action<DeliveryInfo> AckChannel { get; set; }
	}
}
