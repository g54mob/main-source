using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct LobbySearchSetParameterOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_Parameter;

		private ComparisonOp m_ComparisonOp;

		public AttributeData Parameter
		{
			set
			{
			}
		}

		public ComparisonOp ComparisonOp
		{
			set
			{
			}
		}

		public void Set(LobbySearchSetParameterOptions other)
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
