using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Achievements
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 80)]
	internal struct PlayerAchievementInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_AchievementId;

		private double m_Progress;

		private long m_UnlockTime;

		private int m_StatInfoCount;

		private IntPtr m_StatInfo;

		private IntPtr m_DisplayName;

		private IntPtr m_Description;

		private IntPtr m_IconURL;

		private IntPtr m_FlavorText;

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

		public double Progress
		{
			get
			{
				return 0.0;
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

		public PlayerStatInfo[] StatInfo
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string DisplayName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Description
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string IconURL
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string FlavorText
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(PlayerAchievement other)
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
