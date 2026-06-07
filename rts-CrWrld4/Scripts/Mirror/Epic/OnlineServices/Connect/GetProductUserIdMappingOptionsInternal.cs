using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Connect
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct GetProductUserIdMappingOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private ExternalAccountType m_AccountIdType;

		private IntPtr m_TargetProductUserId;

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

		public ProductUserId TargetProductUserId
		{
			set
			{
			}
		}

		public void Set(GetProductUserIdMappingOptions other)
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
