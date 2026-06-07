using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.P2P
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 8)]
	internal struct SetRelayControlOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private RelayControl m_RelayControl;

		public RelayControl RelayControl
		{
			set
			{
			}
		}

		public void Set(SetRelayControlOptions other)
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
