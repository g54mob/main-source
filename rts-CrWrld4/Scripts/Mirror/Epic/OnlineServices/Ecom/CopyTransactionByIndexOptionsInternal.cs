using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Ecom
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct CopyTransactionByIndexOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private uint m_TransactionIndex;

		public EpicAccountId LocalUserId
		{
			set
			{
			}
		}

		public uint TransactionIndex
		{
			set
			{
			}
		}

		public void Set(CopyTransactionByIndexOptions other)
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
