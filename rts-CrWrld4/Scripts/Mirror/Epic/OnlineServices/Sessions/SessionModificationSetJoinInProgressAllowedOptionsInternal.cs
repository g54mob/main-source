using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Sessions
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 8)]
	internal struct SessionModificationSetJoinInProgressAllowedOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private int m_AllowJoinInProgress;

		public bool AllowJoinInProgress
		{
			set
			{
			}
		}

		public void Set(SessionModificationSetJoinInProgressAllowedOptions other)
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
