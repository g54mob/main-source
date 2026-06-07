using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Stats
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct IngestDataInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_StatName;

		private int m_IngestAmount;

		public string StatName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int IngestAmount
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public void Set(IngestData other)
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
