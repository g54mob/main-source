using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Reports
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct SendPlayerBehaviorReportCompleteCallbackInfoInternal : ICallbackInfoInternal
	{
		private Result m_ResultCode;

		private IntPtr m_ClientData;

		public Result ResultCode => default(Result);

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;
	}
}
