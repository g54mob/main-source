using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Platform
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct AndroidInitializeOptionsSystemInitializeOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_Reserved;

		private IntPtr m_OptionalInternalDirectory;

		private IntPtr m_OptionalExternalDirectory;

		public IntPtr Reserved
		{
			get
			{
				return (IntPtr)0;
			}
			set
			{
			}
		}

		public string OptionalInternalDirectory
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string OptionalExternalDirectory
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(AndroidInitializeOptionsSystemInitializeOptions other)
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
