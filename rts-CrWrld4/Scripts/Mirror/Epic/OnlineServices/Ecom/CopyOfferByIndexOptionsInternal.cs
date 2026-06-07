using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Ecom
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct CopyOfferByIndexOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private uint m_OfferIndex;

		public EpicAccountId LocalUserId
		{
			set
			{
			}
		}

		public uint OfferIndex
		{
			set
			{
			}
		}

		public void Set(CopyOfferByIndexOptions other)
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
