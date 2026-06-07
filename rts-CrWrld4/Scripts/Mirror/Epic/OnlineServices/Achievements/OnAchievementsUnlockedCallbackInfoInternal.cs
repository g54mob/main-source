using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Achievements
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct OnAchievementsUnlockedCallbackInfoInternal : ICallbackInfoInternal
	{
		private IntPtr m_ClientData;

		private IntPtr m_UserId;

		private uint m_AchievementsCount;

		private IntPtr m_AchievementIds;

		public object ClientData => null;

		public IntPtr ClientDataAddress => (IntPtr)0;

		public ProductUserId UserId => null;

		public string[] AchievementIds => null;
	}
}
