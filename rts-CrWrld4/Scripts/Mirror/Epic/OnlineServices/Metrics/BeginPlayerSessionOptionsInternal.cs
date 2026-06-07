using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Metrics
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 48)]
	internal struct BeginPlayerSessionOptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private BeginPlayerSessionOptionsAccountIdInternal m_AccountId;

		private IntPtr m_DisplayName;

		private UserControllerType m_ControllerType;

		private IntPtr m_ServerIp;

		private IntPtr m_GameSessionId;

		public BeginPlayerSessionOptionsAccountId AccountId
		{
			set
			{
			}
		}

		public string DisplayName
		{
			set
			{
			}
		}

		public UserControllerType ControllerType
		{
			set
			{
			}
		}

		public string ServerIp
		{
			set
			{
			}
		}

		public string GameSessionId
		{
			set
			{
			}
		}

		public void Set(BeginPlayerSessionOptions other)
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
