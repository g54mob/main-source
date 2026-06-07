using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Achievements
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct GetPlayerAchievementCountOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_UserId;

		public ProductUserId UserId
		{
			set
			{
			}
		}

		public void Set(GetPlayerAchievementCountOptions other)
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
