using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct CopyLobbyDetailsHandleByUiEventIdOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private ulong m_UiEventId;

		public ulong UiEventId
		{
			set
			{
			}
		}

		public void Set(CopyLobbyDetailsHandleByUiEventIdOptions other)
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
