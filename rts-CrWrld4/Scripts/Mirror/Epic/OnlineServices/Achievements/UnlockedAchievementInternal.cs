using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Achievements
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct UnlockedAchievementInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_AchievementId;

		private long m_UnlockTime;

		public string AchievementId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DateTimeOffset? UnlockTime
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(UnlockedAchievement other)
		{
		}

		public void Set(object other)
		{
		}

		public void Dispose()
		{
		}
	}
}
