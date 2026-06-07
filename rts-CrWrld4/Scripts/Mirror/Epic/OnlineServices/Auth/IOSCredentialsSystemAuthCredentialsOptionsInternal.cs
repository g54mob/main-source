using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Auth
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct IOSCredentialsSystemAuthCredentialsOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_PresentationContextProviding;

		public IntPtr PresentationContextProviding
		{
			get
			{
				return (IntPtr)0;
			}
			set
			{
			}
		}

		public void Set(IOSCredentialsSystemAuthCredentialsOptions other)
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
