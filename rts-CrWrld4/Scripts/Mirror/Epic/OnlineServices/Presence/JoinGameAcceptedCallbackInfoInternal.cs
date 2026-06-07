using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Presence
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 40)]
	internal struct JoinGameAcceptedCallbackInfoInternal : ICallbackInfoInternal
	{
		private IntPtr m_ClientData;

		private IntPtr m_JoinInfo;

		private IntPtr m_LocalUserId;

		private IntPtr m_TargetUserId;

		private ulong m_UiEventId;

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public string JoinInfo => null;

		public EpicAccountId LocalUserId => null;

		public EpicAccountId TargetUserId => null;

		public ulong UiEventId => 0uL;
	}
}
