using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.PlayerDataStorage
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct DuplicateFileOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private IntPtr m_SourceFilename;

		private IntPtr m_DestinationFilename;

		public ProductUserId LocalUserId
		{
			set
			{
			}
		}

		public string SourceFilename
		{
			set
			{
			}
		}

		public string DestinationFilename
		{
			set
			{
			}
		}

		public void Set(DuplicateFileOptions other)
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
