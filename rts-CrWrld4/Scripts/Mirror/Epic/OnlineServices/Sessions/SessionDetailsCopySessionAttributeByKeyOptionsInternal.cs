using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct SessionDetailsCopySessionAttributeByKeyOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_AttrKey;

		public string AttrKey
		{
			set
			{
			}
		}

		public void Set(SessionDetailsCopySessionAttributeByKeyOptions other)
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
