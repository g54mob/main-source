using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Mods
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 24)]
	internal struct ModInfoInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private int m_ModsCount;

		private IntPtr m_Mods;

		private ModEnumerationType m_Type;

		public ModIdentifier[] Mods
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public ModEnumerationType Type
		{
			get
			{
				return default(ModEnumerationType);
			}
			set
			{
			}
		}

		public void Set(ModInfo other)
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
