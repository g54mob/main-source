using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Presence
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct PresenceModificationDataRecordIdInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_Key;

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

		public void Set(PresenceModificationDataRecordId other)
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
