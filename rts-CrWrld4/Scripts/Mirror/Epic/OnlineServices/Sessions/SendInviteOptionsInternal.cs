using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct SendInviteOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_SessionName;

		private IntPtr m_LocalUserId;

		private IntPtr m_TargetUserId;

		public string SessionName
		{
			set
			{
			}
		}

		public ProductUserId LocalUserId
		{
			set
			{
			}
		}

		public ProductUserId TargetUserId
		{
			set
			{
			}
		}

		public void Set(SendInviteOptions other)
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
