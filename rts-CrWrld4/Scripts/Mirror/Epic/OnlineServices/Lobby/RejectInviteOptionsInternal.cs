using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct RejectInviteOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_InviteId;

		private IntPtr m_LocalUserId;

		public string InviteId
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

		public void Set(RejectInviteOptions other)
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
