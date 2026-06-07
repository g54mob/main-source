using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Ecom
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 48)]
	internal struct EntitlementInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_EntitlementName;

		private IntPtr m_EntitlementId;

		private IntPtr m_CatalogItemId;

		private int m_ServerIndex;

		private int m_Redeemed;

		private long m_EndTimestamp;

		public string EntitlementName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string EntitlementId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string CatalogItemId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int ServerIndex
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public bool Redeemed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public long EndTimestamp
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public void Set(Entitlement other)
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
