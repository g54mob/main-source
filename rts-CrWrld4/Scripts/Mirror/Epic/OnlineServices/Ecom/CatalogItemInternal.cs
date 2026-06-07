using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Ecom
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 88)]
	internal struct CatalogItemInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_CatalogNamespace;

		private IntPtr m_Id;

		private IntPtr m_EntitlementName;

		private IntPtr m_TitleText;

		private IntPtr m_DescriptionText;

		private IntPtr m_LongDescriptionText;

		private IntPtr m_TechnicalDetailsText;

		private IntPtr m_DeveloperText;

		private EcomItemType m_ItemType;

		private long m_EntitlementEndTimestamp;

		public string CatalogNamespace
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string Id
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string EntitlementName
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string TitleText
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string DescriptionText
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string LongDescriptionText
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string TechnicalDetailsText
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string DeveloperText
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public EcomItemType ItemType
		{
			get
			{
				return default(EcomItemType);
			}
			set
			{
			}
		}

		public long EntitlementEndTimestamp
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public void Set(CatalogItem other)
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
