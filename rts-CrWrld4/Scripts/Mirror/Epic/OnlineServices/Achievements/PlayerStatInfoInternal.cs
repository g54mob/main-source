using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Achievements
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct PlayerStatInfoInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_Name;

		private int m_CurrentValue;

		private int m_ThresholdValue;

		public string Name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int CurrentValue
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public int ThresholdValue
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public void Set(PlayerStatInfo other)
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
