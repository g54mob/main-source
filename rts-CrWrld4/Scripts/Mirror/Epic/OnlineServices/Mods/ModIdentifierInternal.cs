using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Mods
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 48)]
	internal struct ModIdentifierInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_NamespaceId;

		private IntPtr m_ItemId;

		private IntPtr m_ArtifactId;

		private IntPtr m_Title;

		private IntPtr m_Version;

		public string NamespaceId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string ItemId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string ArtifactId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Title
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Version
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(ModIdentifier other)
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
