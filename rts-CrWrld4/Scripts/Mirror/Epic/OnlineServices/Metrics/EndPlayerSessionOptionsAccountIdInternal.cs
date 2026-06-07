using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Metrics
{
	[StructLayout((LayoutKind)2, Pack = 1, Size = 12)]
	internal struct EndPlayerSessionOptionsAccountIdInternal : ISettable, IDisposable
	{
		[FieldOffset(0)]
		private MetricsAccountIdType m_AccountIdType;

		[FieldOffset(4)]
		private IntPtr m_Epic;

		[FieldOffset(4)]
		private IntPtr m_External;

		public EpicAccountId Epic
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string External
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(EndPlayerSessionOptionsAccountId other)
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
