using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Ecom
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct CopyTransactionByIdOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private IntPtr m_TransactionId;

		public EpicAccountId LocalUserId
		{
			set
			{
			}
		}

		public string TransactionId
		{
			set
			{
			}
		}

		public void Set(CopyTransactionByIdOptions other)
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
