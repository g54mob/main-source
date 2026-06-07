using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 4)]
	internal struct LobbyDetailsGetAttributeCountOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		public void Set(LobbyDetailsGetAttributeCountOptions other)
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
