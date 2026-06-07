using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct SessionModificationSetBucketIdOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_BucketId;

		public string BucketId
		{
			set
			{
			}
		}

		public void Set(SessionModificationSetBucketIdOptions other)
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
