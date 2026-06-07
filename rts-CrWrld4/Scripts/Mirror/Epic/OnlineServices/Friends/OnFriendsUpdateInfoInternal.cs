using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Friends
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct OnFriendsUpdateInfoInternal : ICallbackInfoInternal
	{
		private IntPtr m_ClientData;

		private IntPtr m_LocalUserId;

		private IntPtr m_TargetUserId;

		private FriendsStatus m_PreviousStatus;

		private FriendsStatus m_CurrentStatus;

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public EpicAccountId LocalUserId => null;

		public EpicAccountId TargetUserId => null;

		public FriendsStatus PreviousStatus => default(FriendsStatus);

		public FriendsStatus CurrentStatus => default(FriendsStatus);
	}
}
