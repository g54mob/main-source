using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sanctions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct GetPlayerSanctionCountOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_TargetUserId;

		public ProductUserId TargetUserId
		{
			set
			{
			}
		}

		public void Set(GetPlayerSanctionCountOptions other)
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
