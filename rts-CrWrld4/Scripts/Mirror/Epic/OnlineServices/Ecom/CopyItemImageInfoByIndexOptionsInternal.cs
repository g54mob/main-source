using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Ecom
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct CopyItemImageInfoByIndexOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private IntPtr m_ItemId;

		private uint m_ImageInfoIndex;

		public EpicAccountId LocalUserId
		{
			set
			{
			}
		}

		public string ItemId
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

		public void Set(CopyItemImageInfoByIndexOptions other)
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
