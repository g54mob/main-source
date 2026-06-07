using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Achievements
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 8)]
	internal struct CopyAchievementDefinitionByIndexOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private uint m_AchievementIndex;

		public uint AchievementIndex
		{
			set
			{
			}
		}

		public void Set(CopyAchievementDefinitionByIndexOptions other)
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
