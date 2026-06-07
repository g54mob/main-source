using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Achievements
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct CopyAchievementDefinitionV2ByAchievementIdOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_AchievementId;

		public string AchievementId
		{
			set
			{
			}
		}

		public void Set(CopyAchievementDefinitionV2ByAchievementIdOptions other)
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
