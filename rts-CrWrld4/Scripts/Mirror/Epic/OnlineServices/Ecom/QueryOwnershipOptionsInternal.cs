using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Ecom
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 40)]
	internal struct QueryOwnershipOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private IntPtr m_CatalogItemIds;

		private uint m_CatalogItemIdCount;

		private IntPtr m_CatalogNamespace;

		public EpicAccountId LocalUserId
		{
			set
			{
			}
		}

		public string[] CatalogItemIds
		{
			set
			{
			}
		}

		public string CatalogNamespace
		{
			set
			{
			}
		}

		public void Set(QueryOwnershipOptions other)
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
