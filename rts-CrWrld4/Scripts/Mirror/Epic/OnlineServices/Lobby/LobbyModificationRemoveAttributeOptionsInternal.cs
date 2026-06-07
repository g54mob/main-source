using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct LobbyModificationRemoveAttributeOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_Key;

		public string Key
		{
			set
			{
			}
		}

		public void Set(LobbyModificationRemoveAttributeOptions other)
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
