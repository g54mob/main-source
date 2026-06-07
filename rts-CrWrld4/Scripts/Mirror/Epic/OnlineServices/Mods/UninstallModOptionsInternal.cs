using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Mods
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct UninstallModOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_LocalUserId;

		private IntPtr m_Mod;

		public EpicAccountId LocalUserId
		{
			set
			{
			}
		}

		public ModIdentifier Mod
		{
			set
			{
			}
		}

		public void Set(UninstallModOptions other)
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
