using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Auth
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct LoginStatusChangedCallbackInfoInternal : ICallbackInfoInternal
	{
		private IntPtr m_ClientData;

		private IntPtr m_LocalUserId;

		private LoginStatus m_PrevStatus;

		private LoginStatus m_CurrentStatus;

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public EpicAccountId LocalUserId => null;

		public LoginStatus PrevStatus => default(LoginStatus);

		public LoginStatus CurrentStatus => default(LoginStatus);
	}
}
