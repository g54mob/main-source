using System;

namespace Coherence.Transport
{
	[Obsolete("Replaced by TransportType.")]
	[Deprecated("04/2024", 1, 3, 0, Reason = "Replaced by TransportType.")]
	public enum DefaultTransportMode
	{
		UDPWithTCPFallback = 0,
		UDPOnly = 1,
		TCPOnly = 2,
		UDPExperimental = 3
	}
}
