using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Presence
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct DataRecordInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_Key;

		private IntPtr m_Value;

		public string Key
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(DataRecord other)
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
