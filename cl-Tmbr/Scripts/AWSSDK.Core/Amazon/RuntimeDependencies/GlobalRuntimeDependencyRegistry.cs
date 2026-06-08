namespace Amazon.RuntimeDependencies
{
	public class GlobalRuntimeDependencyRegistry : BaseRuntimeDependencyRegistry
	{
		private static readonly GlobalRuntimeDependencyRegistry _instance = new GlobalRuntimeDependencyRegistry();

		public static GlobalRuntimeDependencyRegistry Instance => _instance;

		internal GlobalRuntimeDependencyRegistry()
		{
		}

		public void RegisterChecksumProvider(object instance)
		{
			RegisterInstance("AWSSDK.Extensions.CrtIntegration", "AWSSDK.Extensions.CrtIntegration.CrtChecksums", instance);
		}

		public void RegisterSigV4aProvider(RuntimeDependencyFactory factory)
		{
			RegisterInstance("AWSSDK.Extensions.CrtIntegration", "Amazon.Extensions.CrtIntegration.CrtAWS4aSigner", factory);
		}

		public void RegisterSecurityTokenServiceClient(object instance)
		{
			RegisterInstance("AWSSDK.SecurityToken", "Amazon.SecurityToken.AmazonSecurityTokenServiceClient", instance);
		}

		public void RegisterSecurityTokenServiceClient(RuntimeDependencyFactory factory)
		{
			RegisterInstance("AWSSDK.SecurityToken", "Amazon.SecurityToken.AmazonSecurityTokenServiceClient", factory);
		}

		public void RegisterSSOClient(object instance)
		{
			RegisterInstance("AWSSDK.SSO", "Amazon.SSO.AmazonSSOClient", instance);
		}

		public void RegisterSSOClient(RuntimeDependencyFactory factory)
		{
			RegisterInstance("AWSSDK.SSO", "Amazon.SSO.AmazonSSOClient", factory);
		}

		public void RegisterSSOOIDCClient(object instance)
		{
			RegisterInstance("AWSSDK.SSOOIDC", "Amazon.SSOOIDC.AmazonSSOOIDCClient", instance);
		}

		public void RegisterSSOOIDCClient(RuntimeDependencyFactory factory)
		{
			RegisterInstance("AWSSDK.SSOOIDC", "Amazon.SSOOIDC.AmazonSSOOIDCClient", factory);
		}

		public void RegisterS3Client(object instance)
		{
			RegisterInstance("AWSSDK.S3", "Amazon.S3.AmazonS3Client", instance);
		}

		public void RegisterS3Client(RuntimeDependencyFactory factory)
		{
			RegisterInstance("AWSSDK.S3", "Amazon.S3.AmazonS3Client", factory);
		}
	}
}
