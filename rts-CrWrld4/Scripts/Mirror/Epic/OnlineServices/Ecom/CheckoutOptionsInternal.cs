using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Ecom
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 40)]
	internal struct CheckoutOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private IntPtr m_OverrideCatalogNamespace;

		private uint m_EntryCount;

		private IntPtr m_Entries;

		public EpicAccountId LocalUserId
		{
			set
			{
			}
		}

		public string OverrideCatalogNamespace
		{
			set
			{
			}
		}

		public CheckoutEntry[] Entries
		{
			set
			{
			}
		}

		public void Set(CheckoutOptions other)
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
