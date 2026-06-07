using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sanctions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct PlayerSanctionInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private long m_TimePlaced;

		private IntPtr m_Action;

		public long TimePlaced
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public string Action
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void Set(PlayerSanction other)
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
