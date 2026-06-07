using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Achievements
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct CopyUnlockedAchievementByIndexOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_UserId;

		private uint m_AchievementIndex;

		public ProductUserId UserId
		{
			set
			{
			}
		}

		public uint AchievementIndex
		{
			set
			{
			}
		}

		public void Set(CopyUnlockedAchievementByIndexOptions other)
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
