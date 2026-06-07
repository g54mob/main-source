using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Platform
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 48)]
	internal struct InitializeThreadAffinityInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private ulong m_NetworkWork;

		private ulong m_StorageIo;

		private ulong m_WebSocketIo;

		private ulong m_P2PIo;

		private ulong m_HttpRequestIo;

		public ulong NetworkWork
		{
			get
			{
				return 0uL;
			}
			set
			{
			}
		}

		public ulong StorageIo
		{
			get
			{
				return 0uL;
			}
			set
			{
			}
		}

		public ulong WebSocketIo
		{
			get
			{
				return 0uL;
			}
			set
			{
			}
		}

		public ulong P2PIo
		{
			get
			{
				return 0uL;
			}
			set
			{
			}
		}

		public ulong HttpRequestIo
		{
			get
			{
				return 0uL;
			}
			set
			{
			}
		}

		public void Set(InitializeThreadAffinity other)
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
