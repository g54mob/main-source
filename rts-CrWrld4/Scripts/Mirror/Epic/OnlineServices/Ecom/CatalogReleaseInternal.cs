using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Ecom
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 40)]
	internal struct CatalogReleaseInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private uint m_CompatibleAppIdCount;

		private IntPtr m_CompatibleAppIds;

		private uint m_CompatiblePlatformCount;

		private IntPtr m_CompatiblePlatforms;

		private IntPtr m_ReleaseNote;

		public string[] CompatibleAppIds
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string[] CompatiblePlatforms
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string ReleaseNote
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(CatalogRelease other)
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
