using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Presence
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct PresenceModificationSetJoinInfoOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_JoinInfo;

		public string JoinInfo
		{
			set
			{
			}
		}

		public void Set(PresenceModificationSetJoinInfoOptions other)
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
