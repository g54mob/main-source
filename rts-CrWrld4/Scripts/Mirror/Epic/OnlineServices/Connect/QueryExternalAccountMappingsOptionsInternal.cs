using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Connect
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 40)]
	internal struct QueryExternalAccountMappingsOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private ExternalAccountType m_AccountIdType;

		private IntPtr m_ExternalAccountIds;

		private uint m_ExternalAccountIdCount;

		public ProductUserId LocalUserId
		{
			set
			{
			}
		}

		public ExternalAccountType AccountIdType
		{
			set
			{
			}
		}

		public string[] ExternalAccountIds
		{
			set
			{
			}
		}

		public void Set(QueryExternalAccountMappingsOptions other)
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
