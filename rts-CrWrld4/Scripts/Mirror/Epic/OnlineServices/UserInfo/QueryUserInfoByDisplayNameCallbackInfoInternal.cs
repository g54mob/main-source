using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.UserInfo
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 40)]
	internal struct QueryUserInfoByDisplayNameCallbackInfoInternal : ICallbackInfoInternal
	{
		private Result m_ResultCode;

		private IntPtr m_ClientData;

		private IntPtr m_LocalUserId;

		private IntPtr m_TargetUserId;

		private IntPtr m_DisplayName;

		public Result ResultCode => default(Result);

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public EpicAccountId LocalUserId => null;

		public EpicAccountId TargetUserId => null;

		public string DisplayName => null;
	}
}
