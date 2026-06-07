using System;
using System.Runtime.InteropServices;

namespace Epic.OnlineServices.Platform
{
	[StructLayout((LayoutKind)0, Pack = 8, Size = 112)]
	internal struct OptionsInternal : ISettable, IDisposable
	{
		private int m_ApiVersion;

		private IntPtr m_Reserved;

		private IntPtr m_ProductId;

		private IntPtr m_SandboxId;

		private ClientCredentialsInternal m_ClientCredentials;

		private int m_IsServer;

		private IntPtr m_EncryptionKey;

		private IntPtr m_OverrideCountryCode;

		private IntPtr m_OverrideLocaleCode;

		private IntPtr m_DeploymentId;

		private PlatformFlags m_Flags;

		private IntPtr m_CacheDirectory;

		private uint m_TickBudgetInMilliseconds;

		public IntPtr Reserved
		{
			set
			{
			}
		}

		public string ProductId
		{
			set
			{
			}
		}

		public string SandboxId
		{
			set
			{
			}
		}

		public ClientCredentials ClientCredentials
		{
			set
			{
			}
		}

		public bool IsServer
		{
			set
			{
			}
		}

		public string EncryptionKey
		{
			set
			{
			}
		}

		public string OverrideCountryCode
		{
			set
			{
			}
		}

		public string OverrideLocaleCode
		{
			set
			{
			}
		}

		public string DeploymentId
		{
			set
			{
			}
		}

		public PlatformFlags Flags
		{
			set
			{
			}
		}

		public string CacheDirectory
		{
			set
			{
			}
		}

		public uint TickBudgetInMilliseconds
		{
			set
			{
			}
		}

		public void Set(Options other)
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
