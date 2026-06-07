using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Stats
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct CopyStatByNameOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_TargetUserId;

		private IntPtr m_Name;

		public ProductUserId TargetUserId
		{
			set
			{
			}
		}

		public string Name
		{
			set
			{
			}
		}

		public void Set(CopyStatByNameOptions other)
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
