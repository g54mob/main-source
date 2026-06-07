using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct LobbyMemberStatusReceivedCallbackInfoInternal : ICallbackInfoInternal
	{
		private IntPtr m_ClientData;

		private IntPtr m_LobbyId;

		private IntPtr m_TargetUserId;

		private LobbyMemberStatus m_CurrentStatus;

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public string LobbyId => null;

		public ProductUserId TargetUserId => null;

		public LobbyMemberStatus CurrentStatus => default(LobbyMemberStatus);
	}
}
