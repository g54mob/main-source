using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct UpdateSessionCallbackInfoInternal : ICallbackInfoInternal
	{
		private Result m_ResultCode;

		private IntPtr m_ClientData;

		private IntPtr m_SessionName;

		private IntPtr m_SessionId;

		public Result ResultCode => default(Result);

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public string SessionName => null;

		public string SessionId => null;
	}
}
