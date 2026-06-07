using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sanctions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct CopyPlayerSanctionByIndexOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_TargetUserId;

		private uint m_SanctionIndex;

		public ProductUserId TargetUserId
		{
			set
			{
			}
		}

		public uint SanctionIndex
		{
			set
			{
			}
		}

		public void Set(CopyPlayerSanctionByIndexOptions other)
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
