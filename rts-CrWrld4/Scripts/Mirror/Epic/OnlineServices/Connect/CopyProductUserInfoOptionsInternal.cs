using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Connect
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct CopyProductUserInfoOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_TargetUserId;

		public ProductUserId TargetUserId
		{
			set
			{
			}
		}

		public void Set(CopyProductUserInfoOptions other)
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
