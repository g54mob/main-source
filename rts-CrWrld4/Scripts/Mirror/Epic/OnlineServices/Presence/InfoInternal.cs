using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Presence
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 72)]
	internal struct InfoInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private Status m_Status;

		private IntPtr m_UserId;

		private IntPtr m_ProductId;

		private IntPtr m_ProductVersion;

		private IntPtr m_Platform;

		private IntPtr m_RichText;

		private int m_RecordsCount;

		private IntPtr m_Records;

		private IntPtr m_ProductName;

		public Status Status
		{
			get
			{
				return default(Status);
			}
			set
			{
			}
		}

		public EpicAccountId UserId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string ProductId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string ProductVersion
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Platform
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string RichText
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public DataRecord[] Records
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string ProductName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(Info other)
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
