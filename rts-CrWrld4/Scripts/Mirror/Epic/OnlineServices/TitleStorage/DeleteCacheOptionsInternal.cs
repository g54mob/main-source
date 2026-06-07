using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.TitleStorage
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct DeleteCacheOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		public ProductUserId LocalUserId
		{
			set
			{
			}
		}

		public void Set(DeleteCacheOptions other)
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
