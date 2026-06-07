using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.P2P
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 40)]
	internal struct SocketIdInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private byte[] m_SocketName;

		public string SocketName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(SocketId other)
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
