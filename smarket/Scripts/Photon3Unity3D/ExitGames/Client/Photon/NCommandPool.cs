using System.Collections.Generic;

namespace ExitGames.Client.Photon
{
	internal class NCommandPool
	{
		private readonly Stack<NCommand> pool;

		public NCommand Acquire(EnetPeer peer, byte[] inBuff, ref int readingOffset)
		{
			return null;
		}

		public NCommand Acquire(EnetPeer peer, byte commandType, StreamBuffer payload, byte channel)
		{
			return null;
		}

		public void Release(NCommand nCommand)
		{
		}
	}
}
