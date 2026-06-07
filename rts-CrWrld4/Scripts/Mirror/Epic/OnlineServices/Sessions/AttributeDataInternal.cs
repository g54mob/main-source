using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 32)]
	internal struct AttributeDataInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_Key;

		private AttributeDataValueInternal m_Value;

		public string Key
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public AttributeDataValue Value
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(AttributeData other)
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
