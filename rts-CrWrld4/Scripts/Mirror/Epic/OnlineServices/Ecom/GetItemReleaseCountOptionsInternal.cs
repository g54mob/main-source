using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Ecom
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct GetItemReleaseCountOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private IntPtr m_ItemId;

		public EpicAccountId LocalUserId
		{
			set
			{
			}
		}

		public string ItemId
		{
			set
			{
			}
		}

		public void Set(GetItemReleaseCountOptions other)
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
