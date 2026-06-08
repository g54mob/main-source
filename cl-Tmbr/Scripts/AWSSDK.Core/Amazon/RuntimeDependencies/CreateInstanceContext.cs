namespace Amazon.RuntimeDependencies
{
	public class CreateInstanceContext
	{
		public enum ContextType
		{
			SecurityTokenServiceClient = 0,
			KeyManagementServiceClient = 1,
			SigV4aCrtSigner = 2,
			CheckSumProvider = 3,
			SSOClient = 4,
			SSOOIDCClient = 5,
			S3ClientContext = 6
		}

		public ContextType Type { get; }

		public SecurityTokenServiceClientContext SecurityTokenServiceClientContextData { get; }

		public KeyManagementServiceClientContext KeyManagementServiceClientContextData { get; }

		public SigV4aCrtSignerContext SigV4aCrtSignerContextData { get; }

		public CheckSumProviderContext CheckSumProviderContextData { get; }

		public SSOClientContext SSOClientContextData { get; }

		public SSOOIDCClientContext SSOOIDCClientContextData { get; }

		public S3ClientContext S3ClientContextData { get; }

		public CreateInstanceContext(SecurityTokenServiceClientContext context)
		{
			SecurityTokenServiceClientContextData = context;
			Type = ContextType.SecurityTokenServiceClient;
		}

		public CreateInstanceContext(KeyManagementServiceClientContext context)
		{
			KeyManagementServiceClientContextData = context;
			Type = ContextType.KeyManagementServiceClient;
		}

		public CreateInstanceContext(SigV4aCrtSignerContext context)
		{
			SigV4aCrtSignerContextData = context;
			Type = ContextType.SigV4aCrtSigner;
		}

		public CreateInstanceContext(CheckSumProviderContext context)
		{
			CheckSumProviderContextData = context;
			Type = ContextType.CheckSumProvider;
		}

		public CreateInstanceContext(SSOClientContext context)
		{
			SSOClientContextData = context;
			Type = ContextType.SSOClient;
		}

		public CreateInstanceContext(SSOOIDCClientContext context)
		{
			SSOOIDCClientContextData = context;
			Type = ContextType.SSOOIDCClient;
		}

		public CreateInstanceContext(S3ClientContext context)
		{
			S3ClientContextData = context;
			Type = ContextType.S3ClientContext;
		}
	}
}
