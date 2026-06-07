using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Presence
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 16)]
	internal struct PresenceModificationDeleteDataOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private int m_RecordsCount;

		private IntPtr m_Records;

		public PresenceModificationDataRecordId[] Records
		{
			set
			{
			}
		}

		public void Set(PresenceModificationDeleteDataOptions other)
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
