using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct LobbyMemberUpdateReceivedCallbackInfoInternal : ICallbackInfoInternal
	{
		private IntPtr m_ClientData;

		private IntPtr m_LobbyId;

		private IntPtr m_TargetUserId;

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public string LobbyId => null;

		public ProductUserId TargetUserId => null;
	}
}
