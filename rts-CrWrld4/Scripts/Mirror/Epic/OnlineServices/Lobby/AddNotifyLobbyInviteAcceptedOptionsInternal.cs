using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 4)]
	internal struct AddNotifyLobbyInviteAcceptedOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		public void Set(AddNotifyLobbyInviteAcceptedOptions other)
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
