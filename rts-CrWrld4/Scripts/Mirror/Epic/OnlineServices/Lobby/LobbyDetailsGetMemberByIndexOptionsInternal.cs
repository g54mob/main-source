using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 8)]
	internal struct LobbyDetailsGetMemberByIndexOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private uint m_MemberIndex;

		public uint MemberIndex
		{
			set
			{
			}
		}

		public void Set(LobbyDetailsGetMemberByIndexOptions other)
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
