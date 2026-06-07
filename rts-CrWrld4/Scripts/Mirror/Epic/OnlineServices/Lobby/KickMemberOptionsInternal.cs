using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct KickMemberOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LobbyId;

		private IntPtr m_LocalUserId;

		private IntPtr m_TargetUserId;

		public string LobbyId
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

		public void Set(KickMemberOptions other)
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
