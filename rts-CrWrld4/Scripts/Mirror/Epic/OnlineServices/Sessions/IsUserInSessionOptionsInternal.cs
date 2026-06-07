using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct IsUserInSessionOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_SessionName;

		private IntPtr m_TargetUserId;

		public string SessionName
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

		public void Set(IsUserInSessionOptions other)
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
