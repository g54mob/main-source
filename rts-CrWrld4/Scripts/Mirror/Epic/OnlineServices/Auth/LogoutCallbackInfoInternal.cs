using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Auth
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct LogoutCallbackInfoInternal : ICallbackInfoInternal
	{
		private Result m_ResultCode;

		private IntPtr m_ClientData;

		private IntPtr m_LocalUserId;

		public Result ResultCode => default(Result);

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public EpicAccountId LocalUserId => null;
	}
}
