using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Connect
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct GetExternalAccountMappingsOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private ExternalAccountType m_AccountIdType;

		private IntPtr m_TargetExternalUserId;

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

		public string TargetExternalUserId
		{
			set
			{
			}
		}

		public void Set(GetExternalAccountMappingsOptions other)
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
