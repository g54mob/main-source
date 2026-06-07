using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct SessionDetailsAttributeInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_Data;

		private SessionAttributeAdvertisementType m_AdvertisementType;

		public AttributeData Data
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SessionAttributeAdvertisementType AdvertisementType
		{
			get
			{
				return default(SessionAttributeAdvertisementType);
			}
			set
			{
			}
		}

		public void Set(SessionDetailsAttribute other)
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
