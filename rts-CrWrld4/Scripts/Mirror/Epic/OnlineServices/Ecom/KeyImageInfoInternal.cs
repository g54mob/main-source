using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Ecom
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct KeyImageInfoInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_Type;

		private IntPtr m_Url;

		private uint m_Width;

		private uint m_Height;

		public string Type
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Url
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public uint Width
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public uint Height
		{
			get
			{
				return 0u;
			}
			set
			{
			}
		}

		public void Set(KeyImageInfo other)
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
