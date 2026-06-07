using System;
using UnityEngine;

namespace FuryStudios.FurySDK.Settings
{
	[Serializable]
	public class EpicPlatformSettings
	{
		[SerializeField]
		private string clientId;

		[SerializeField]
		private string clientSecret;

		[SerializeField]
		private string productName;

		[SerializeField]
		private string productVersion;

		[SerializeField]
		private string productId;

		[SerializeField]
		private string sandboxId;

		[SerializeField]
		private string deploymentId;

		[SerializeField]
		private int devCredentialsPort;

		[SerializeField]
		private string devCredentialsToken;

		public string ClientID => null;

		public string ClientSecret => null;

		public string ProductName => null;

		public string ProductVersion => null;

		public string ProductId => null;

		public string SandboxId => null;

		public string DeploymentId => null;

		public int DevCredentialsPort => 0;

		public string DevCredentialsToken => null;
	}
}
