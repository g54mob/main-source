using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Platform
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 72)]
	internal struct InitializeOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_AllocateMemoryFunction;

		private IntPtr m_ReallocateMemoryFunction;

		private IntPtr m_ReleaseMemoryFunction;

		private IntPtr m_ProductName;

		private IntPtr m_ProductVersion;

		private IntPtr m_Reserved;

		private IntPtr m_SystemInitializeOptions;

		private IntPtr m_OverrideThreadAffinity;

		public IntPtr AllocateMemoryFunction
		{
			set
			{
			}
		}

		public IntPtr ReallocateMemoryFunction
		{
			set
			{
			}
		}

		public IntPtr ReleaseMemoryFunction
		{
			set
			{
			}
		}

		public string ProductName
		{
			set
			{
			}
		}

		public string ProductVersion
		{
			set
			{
			}
		}

		public IntPtr SystemInitializeOptions
		{
			set
			{
			}
		}

		public InitializeThreadAffinity OverrideThreadAffinity
		{
			set
			{
			}
		}

		public void Set(InitializeOptions other)
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
