using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct LobbyInviteReceivedCallbackInfoInternal : ICallbackInfoInternal
	{
		private IntPtr m_ClientData;

		private IntPtr m_InviteId;

		private IntPtr m_LocalUserId;

		private IntPtr m_TargetUserId;

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public string InviteId => null;

		public ProductUserId LocalUserId => null;

		public ProductUserId TargetUserId => null;
	}
}
