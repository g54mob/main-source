using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 8)]
	internal struct SessionDetailsCopySessionAttributeByIndexOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private uint m_AttrIndex;

		public uint AttrIndex
		{
			set
			{
			}
		}

		public void Set(SessionDetailsCopySessionAttributeByIndexOptions other)
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
