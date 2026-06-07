using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Achievements
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct StatThresholdsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_Name;

		private int m_Threshold;

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

		public int Threshold
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public void Set(StatThresholds other)
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
