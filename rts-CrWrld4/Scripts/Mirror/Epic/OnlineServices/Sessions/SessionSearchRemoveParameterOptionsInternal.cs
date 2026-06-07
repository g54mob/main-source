using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct SessionSearchRemoveParameterOptionsInternal : ISettable, IDisposable
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

		public void Set(SessionSearchRemoveParameterOptions other)
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
