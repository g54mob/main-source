using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Ecom
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct QueryEntitlementsOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private IntPtr m_EntitlementNames;

		private uint m_EntitlementNameCount;

		private int m_IncludeRedeemed;

		public EpicAccountId LocalUserId
		{
			set
			{
			}
		}

		public string[] EntitlementNames
		{
			set
			{
			}
		}

		public bool IncludeRedeemed
		{
			set
			{
			}
		}

		public void Set(QueryEntitlementsOptions other)
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
