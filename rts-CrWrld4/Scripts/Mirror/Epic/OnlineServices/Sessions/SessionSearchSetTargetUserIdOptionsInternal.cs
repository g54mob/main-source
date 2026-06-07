using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct SessionSearchSetTargetUserIdOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_TargetUserId;

		public ProductUserId TargetUserId
		{
			set
			{
			}
		}

		public void Set(SessionSearchSetTargetUserIdOptions other)
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
