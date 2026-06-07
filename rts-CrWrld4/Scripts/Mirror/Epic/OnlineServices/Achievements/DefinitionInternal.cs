using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Achievements
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 96)]
	internal struct DefinitionInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_AchievementId;

		private IntPtr m_DisplayName;

		private IntPtr m_Description;

		private IntPtr m_LockedDisplayName;

		private IntPtr m_LockedDescription;

		private IntPtr m_HiddenDescription;

		private IntPtr m_CompletionDescription;

		private IntPtr m_UnlockedIconId;

		private IntPtr m_LockedIconId;

		private int m_IsHidden;

		private int m_StatThresholdsCount;

		private IntPtr m_StatThresholds;

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

		public string LockedDisplayName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string LockedDescription
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string HiddenDescription
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string CompletionDescription
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string UnlockedIconId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string LockedIconId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool IsHidden
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public StatThresholds[] StatThresholds
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(Definition other)
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
