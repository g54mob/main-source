using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Ecom
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct ItemOwnershipInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_Id;

		private OwnershipStatus m_OwnershipStatus;

		public string Id
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public OwnershipStatus OwnershipStatus
		{
			get
			{
				return default(OwnershipStatus);
			}
			set
			{
			}
		}

		public void Set(ItemOwnership other)
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
