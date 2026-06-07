using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.TitleStorage
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct CopyFileMetadataByFilenameOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private IntPtr m_Filename;

		public ProductUserId LocalUserId
		{
			set
			{
			}
		}

		public string Filename
		{
			set
			{
			}
		}

		public void Set(CopyFileMetadataByFilenameOptions other)
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
