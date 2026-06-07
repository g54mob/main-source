using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Stats
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 56)]
	internal struct QueryStatsOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private long m_StartTime;

		private long m_EndTime;

		private IntPtr m_StatNames;

		private uint m_StatNamesCount;

		private IntPtr m_TargetUserId;

		public ProductUserId LocalUserId
		{
			set
			{
			}
		}

		public DateTimeOffset? StartTime
		{
			set
			{
			}
		}

		public DateTimeOffset? EndTime
		{
			set
			{
			}
		}

		public string[] StatNames
		{
			set
			{
			}
		}

		public ProductUserId TargetUserId
		{
			set
			{
			}
		}

		public void Set(QueryStatsOptions other)
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
