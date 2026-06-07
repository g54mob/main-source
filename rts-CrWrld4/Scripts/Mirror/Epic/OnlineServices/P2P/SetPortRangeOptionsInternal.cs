using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.P2P
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 8)]
	internal struct SetPortRangeOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private ushort m_Port;

		private ushort m_MaxAdditionalPortsToTry;

		public ushort Port
		{
			set
			{
			}
		}

		public ushort MaxAdditionalPortsToTry
		{
			set
			{
			}
		}

		public void Set(SetPortRangeOptions other)
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
