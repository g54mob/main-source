using System.Collections.Generic;

namespace FishNet.Transporting.Yak
{
	public abstract class CommonSocket
	{
		private LocalConnectionState _connectionState;

		protected Transport Transport;

		internal LocalConnectionState GetLocalConnectionState()
		{
			return default(LocalConnectionState);
		}

		protected virtual void SetLocalConnectionState(LocalConnectionState connectionState, bool server)
		{
		}

		internal virtual void Initialize(Transport t, CommonSocket socket)
		{
		}

		internal void ClearQueue(ref Queue<LocalPacket> queue)
		{
		}
	}
}
