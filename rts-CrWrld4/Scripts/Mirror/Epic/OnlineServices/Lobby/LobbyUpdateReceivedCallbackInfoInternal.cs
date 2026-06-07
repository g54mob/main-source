using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct LobbyUpdateReceivedCallbackInfoInternal : ICallbackInfoInternal
	{
		private IntPtr m_ClientData;

		private IntPtr m_LobbyId;

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public string LobbyId => null;
	}
}
