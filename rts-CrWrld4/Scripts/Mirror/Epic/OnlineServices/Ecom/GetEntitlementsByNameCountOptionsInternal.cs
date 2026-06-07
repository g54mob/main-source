using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Ecom
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct GetEntitlementsByNameCountOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private IntPtr m_EntitlementName;

		public EpicAccountId LocalUserId
		{
			set
			{
			}
		}

		public string EntitlementName
		{
			set
			{
			}
		}

		public void Set(GetEntitlementsByNameCountOptions other)
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
