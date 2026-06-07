using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct SessionModificationAddAttributeOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_SessionAttribute;

		private SessionAttributeAdvertisementType m_AdvertisementType;

		public AttributeData SessionAttribute
		{
			set
			{
			}
		}

		public SessionAttributeAdvertisementType AdvertisementType
		{
			set
			{
			}
		}

		public void Set(SessionModificationAddAttributeOptions other)
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
