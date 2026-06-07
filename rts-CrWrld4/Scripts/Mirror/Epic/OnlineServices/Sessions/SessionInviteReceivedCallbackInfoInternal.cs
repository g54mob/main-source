using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct SessionInviteReceivedCallbackInfoInternal : ICallbackInfoInternal
	{
		private IntPtr m_ClientData;

		private IntPtr m_LocalUserId;

		private IntPtr m_TargetUserId;

		private IntPtr m_InviteId;

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public ProductUserId LocalUserId => null;

		public ProductUserId TargetUserId => null;

		public string InviteId => null;
	}
}
