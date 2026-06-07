using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Achievements
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 88)]
	internal struct DefinitionV2Internal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_AchievementId;

		private IntPtr m_UnlockedDisplayName;

		private IntPtr m_UnlockedDescription;

		private IntPtr m_LockedDisplayName;

		private IntPtr m_LockedDescription;

		private IntPtr m_FlavorText;

		private IntPtr m_UnlockedIconURL;

		private IntPtr m_LockedIconURL;

		private int m_IsHidden;

		private uint m_StatThresholdsCount;

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

		public string UnlockedDisplayName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string UnlockedDescription
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

		public string UnlockedIconURL
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string LockedIconURL
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

		public void Set(DefinitionV2 other)
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
