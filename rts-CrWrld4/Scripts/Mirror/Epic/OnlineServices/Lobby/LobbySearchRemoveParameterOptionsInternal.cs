using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Lobby
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct LobbySearchRemoveParameterOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_Key;

		private ComparisonOp m_ComparisonOp;

		public string Key
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

		public void Set(LobbySearchRemoveParameterOptions other)
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
