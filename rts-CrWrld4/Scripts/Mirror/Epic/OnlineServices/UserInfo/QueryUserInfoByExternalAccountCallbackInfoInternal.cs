using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.UserInfo
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 48)]
	internal struct QueryUserInfoByExternalAccountCallbackInfoInternal : ICallbackInfoInternal
	{
		private Result m_ResultCode;

		private IntPtr m_ClientData;

		private IntPtr m_LocalUserId;

		private IntPtr m_ExternalAccountId;

		private ExternalAccountType m_AccountType;

		private IntPtr m_TargetUserId;

		public Result ResultCode => default(Result);

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public EpicAccountId LocalUserId => null;

		public string ExternalAccountId => null;

		public ExternalAccountType AccountType => default(ExternalAccountType);

		public EpicAccountId TargetUserId => null;
	}
}
