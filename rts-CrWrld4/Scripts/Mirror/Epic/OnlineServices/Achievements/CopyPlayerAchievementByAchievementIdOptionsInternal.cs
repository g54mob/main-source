using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Achievements
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct CopyPlayerAchievementByAchievementIdOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_TargetUserId;

		private IntPtr m_AchievementId;

		private IntPtr m_LocalUserId;

		public ProductUserId TargetUserId
		{
			set
			{
			}
		}

		public string AchievementId
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

		public void Set(CopyPlayerAchievementByAchievementIdOptions other)
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
