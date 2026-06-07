using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Ecom
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct QueryOffersOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private IntPtr m_OverrideCatalogNamespace;

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

		public void Set(QueryOffersOptions other)
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
