using System.Net;

namespace Coherence.Flux
{
	public delegate void PortReceivedDataCallback(byte[] data, IPEndPoint receivedFrom, object state);
}
