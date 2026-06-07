using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.PlayerDataStorage
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct ReadFileCallbackInfoInternal : ICallbackInfoInternal
	{
		private Result m_ResultCode;

		private IntPtr m_ClientData;

		private IntPtr m_LocalUserId;

		private IntPtr m_Filename;

		public Result ResultCode => default(Result);

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public ProductUserId LocalUserId => null;

		public string Filename => null;
	}
}
