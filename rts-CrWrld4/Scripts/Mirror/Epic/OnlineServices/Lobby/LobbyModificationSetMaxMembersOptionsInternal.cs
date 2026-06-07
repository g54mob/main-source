using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 8)]
	internal struct LobbyModificationSetMaxMembersOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private uint m_MaxMembers;

		public uint MaxMembers
		{
			set
			{
			}
		}

		public void Set(LobbyModificationSetMaxMembersOptions other)
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
