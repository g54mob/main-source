using System.Threading;

namespace Telepathy
{
	internal class ClientConnectionState : ConnectionState
	{
		public Thread receiveThread;

		public bool Connecting;

		public readonly MagnificentReceivePipe receivePipe;

		public bool Connected => false;

		public ClientConnectionState(int MaxMessageSize)
			: base(null, 0)
		{
		}

		public void Dispose()
		{
		}
	}
}
