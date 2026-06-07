using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.UI
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 4)]
	internal struct GetToggleFriendsKeyOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		public void Set(GetToggleFriendsKeyOptions other)
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
