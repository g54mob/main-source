using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Ecom
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct CheckoutEntryInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_OfferId;

		public string OfferId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(CheckoutEntry other)
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
