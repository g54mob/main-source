using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Connect
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct QueryExternalAccountMappingsCallbackInfoInternal : ICallbackInfoInternal
	{
		private Result m_ResultCode;

		private IntPtr m_ClientData;

		private IntPtr m_LocalUserId;

		public Result ResultCode => default(Result);

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public ProductUserId LocalUserId => null;
	}
}
