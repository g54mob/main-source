using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.P2P
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 40)]
	internal struct OnRemoteConnectionClosedInfoInternal : ICallbackInfoInternal
	{
		private IntPtr m_ClientData;

		private IntPtr m_LocalUserId;

		private IntPtr m_RemoteUserId;

		private IntPtr m_SocketId;

		private ConnectionClosedReason m_Reason;

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public ProductUserId LocalUserId => null;

		public ProductUserId RemoteUserId => null;

		public SocketId SocketId => null;

		public ConnectionClosedReason Reason => default(ConnectionClosedReason);
	}
}
