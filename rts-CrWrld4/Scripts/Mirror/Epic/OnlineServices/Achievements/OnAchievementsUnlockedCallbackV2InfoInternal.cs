using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Achievements
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct OnAchievementsUnlockedCallbackV2InfoInternal : ICallbackInfoInternal
	{
		private IntPtr m_ClientData;

		private IntPtr m_UserId;

		private IntPtr m_AchievementId;

		private long m_UnlockTime;

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public ProductUserId UserId => null;

		public string AchievementId => null;

		public DateTimeOffset? UnlockTime => null;
	}
}
