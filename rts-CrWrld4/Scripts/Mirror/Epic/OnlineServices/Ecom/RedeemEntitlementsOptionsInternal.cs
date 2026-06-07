using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Ecom
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct RedeemEntitlementsOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private uint m_EntitlementIdCount;

		private IntPtr m_EntitlementIds;

		public EpicAccountId LocalUserId
		{
			set
			{
			}
		}

		public string[] EntitlementIds
		{
			set
			{
			}
		}

		public void Set(RedeemEntitlementsOptions other)
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
