using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Ecom
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct CopyOfferImageInfoByIndexOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private IntPtr m_OfferId;

		private uint m_ImageInfoIndex;

		public EpicAccountId LocalUserId
		{
			set
			{
			}
		}

		public string OfferId
		{
			set
			{
			}
		}

		public uint ImageInfoIndex
		{
			set
			{
			}
		}

		public void Set(CopyOfferImageInfoByIndexOptions other)
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
