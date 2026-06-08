using System;
using System.Net;

namespace Amazon.Runtime
{
	public class FederatedAWSCredentialsOptions
	{
		private readonly object syncLock = new object();

		private Func<CredentialRequestCallbackArgs, NetworkCredential> credentialRequestCallback;

		private object customCallbackState;

		private string userIdentity;

		private string profileName;

		private RegionEndpoint stsRegion;

		private WebProxy proxySettings;

		public string UserIdentity
		{
			get
			{
				lock (syncLock)
				{
					return userIdentity;
				}
			}
			set
			{
				lock (syncLock)
				{
					userIdentity = value;
				}
			}
		}

		public Func<CredentialRequestCallbackArgs, NetworkCredential> CredentialRequestCallback
		{
			get
			{
				lock (syncLock)
				{
					return credentialRequestCallback;
				}
			}
			set
			{
				lock (syncLock)
				{
					credentialRequestCallback = value;
				}
			}
		}

		public object CustomCallbackState
		{
			get
			{
				lock (syncLock)
				{
					return customCallbackState;
				}
			}
			set
			{
				lock (syncLock)
				{
					customCallbackState = value;
				}
			}
		}

		public WebProxy ProxySettings
		{
			get
			{
				lock (syncLock)
				{
					return proxySettings;
				}
			}
			set
			{
				lock (syncLock)
				{
					proxySettings = value;
				}
			}
		}

		public RegionEndpoint STSRegion
		{
			get
			{
				lock (syncLock)
				{
					return stsRegion;
				}
			}
			set
			{
				lock (syncLock)
				{
					stsRegion = value;
				}
			}
		}

		public string ProfileName
		{
			get
			{
				lock (syncLock)
				{
					return profileName;
				}
			}
			set
			{
				lock (syncLock)
				{
					profileName = value;
				}
			}
		}
	}
}
