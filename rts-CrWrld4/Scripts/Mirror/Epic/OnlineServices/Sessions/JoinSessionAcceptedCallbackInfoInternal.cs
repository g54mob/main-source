using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct JoinSessionAcceptedCallbackInfoInternal : ICallbackInfoInternal
	{
		private IntPtr m_ClientData;

		private IntPtr m_LocalUserId;

		private ulong m_UiEventId;

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public ProductUserId LocalUserId => null;

		public ulong UiEventId => 0uL;
	}
}
