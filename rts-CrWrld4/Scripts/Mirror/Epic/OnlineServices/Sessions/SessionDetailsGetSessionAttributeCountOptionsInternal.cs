using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 4)]
	internal struct SessionDetailsGetSessionAttributeCountOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		public void Set(SessionDetailsGetSessionAttributeCountOptions other)
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
