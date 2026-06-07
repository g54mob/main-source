using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Achievements
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct CopyPlayerAchievementByIndexOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_TargetUserId;

		private uint m_AchievementIndex;

		private IntPtr m_LocalUserId;

		public ProductUserId TargetUserId
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

		public ProductUserId LocalUserId
		{
			set
			{
			}
		}

		public void Set(CopyPlayerAchievementByIndexOptions other)
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
