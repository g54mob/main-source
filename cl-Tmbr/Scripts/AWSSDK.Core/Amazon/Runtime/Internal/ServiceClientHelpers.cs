using System;
using System.Linq;
using System.Reflection;
using ThirdParty.RuntimeBackports;

namespace Amazon.Runtime.Internal
{
	public static class ServiceClientHelpers
	{
		public const string S3_ASSEMBLY_NAME = "AWSSDK.S3";

		public const string S3_SERVICE_CLASS_NAME = "Amazon.S3.AmazonS3Client";

		public const string SSO_ASSEMBLY_NAME = "AWSSDK.SSO";

		public const string SSO_SERVICE_CLASS_NAME = "Amazon.SSO.AmazonSSOClient";

		public const string SSO_SERVICE_CONFIG_NAME = "Amazon.SSO.AmazonSSOConfig";

		public const string SSO_OIDC_ASSEMBLY_NAME = "AWSSDK.SSOOIDC";

		public const string SSO_OIDC_SERVICE_CLASS_NAME = "Amazon.SSOOIDC.AmazonSSOOIDCClient";

		public const string SSO_OIDC_SERVICE_CONFIG_NAME = "Amazon.SSOOIDC.AmazonSSOOIDCConfig";

		public const string STS_ASSEMBLY_NAME = "AWSSDK.SecurityToken";

		public const string STS_SERVICE_CLASS_NAME = "Amazon.SecurityToken.AmazonSecurityTokenServiceClient";

		public const string STS_SERVICE_CONFIG_NAME = "Amazon.SecurityToken.AmazonSecurityTokenServiceConfig";

		public static TClient CreateServiceFromAnother<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TClient, [DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] TConfig>(AmazonServiceClient originalServiceClient) where TClient : AmazonServiceClient where TConfig : ClientConfig, new()
		{
			AWSCredentials defaultAWSCredentials = originalServiceClient.Config.DefaultAWSCredentials;
			TConfig val = originalServiceClient.CloneConfig<TConfig>();
			return typeof(TClient).GetConstructor(new Type[2]
			{
				typeof(AWSCredentials),
				val.GetType()
			}).Invoke(new object[2] { defaultAWSCredentials, val }) as TClient;
		}

		[RequiresUnreferencedCode("Using ServiceClientHelper to dynamically load dependency is not supported for Native AOT. SDK calling code should use Amazon.RuntimeDependencyRegistry to use explicitly provided runtime dependencies.")]
		public static TClient CreateServiceFromAssembly<TClient>(string assemblyName, string serviceClientClassName, RegionEndpoint region) where TClient : class
		{
			return LoadServiceClientType(assemblyName, serviceClientClassName).GetConstructor(new Type[1] { typeof(RegionEndpoint) }).Invoke(new object[1] { region }) as TClient;
		}

		[RequiresUnreferencedCode("Using ServiceClientHelper to dynamically load dependency is not supported for Native AOT. SDK calling code should use Amazon.RuntimeDependencyRegistry to use explicitly provided runtime dependencies.")]
		public static TClient CreateServiceFromAssembly<TClient>(string assemblyName, string serviceClientClassName, AWSCredentials credentials, RegionEndpoint region) where TClient : class
		{
			return LoadServiceClientType(assemblyName, serviceClientClassName).GetConstructor(new Type[2]
			{
				typeof(AWSCredentials),
				typeof(RegionEndpoint)
			}).Invoke(new object[2] { credentials, region }) as TClient;
		}

		[RequiresUnreferencedCode("Using ServiceClientHelper to dynamically load dependency is not supported for Native AOT. SDK calling code should use Amazon.RuntimeDependencyRegistry to use explicitly provided runtime dependencies.")]
		public static TClient CreateServiceFromAssembly<TClient>(string assemblyName, string serviceClientClassName, AWSCredentials credentials, ClientConfig config) where TClient : class
		{
			return LoadServiceClientType(assemblyName, serviceClientClassName).GetConstructor(new Type[2]
			{
				typeof(AWSCredentials),
				config.GetType()
			}).Invoke(new object[2] { credentials, config }) as TClient;
		}

		[RequiresUnreferencedCode("Using ServiceClientHelper to dynamically load dependency is not supported for Native AOT. SDK calling code should use Amazon.RuntimeDependencyRegistry to use explicitly provided runtime dependencies.")]
		public static TClient CreateServiceFromAssembly<TClient>(string assemblyName, string serviceClientClassName, AmazonServiceClient originalServiceClient) where TClient : class
		{
			Type type = LoadServiceClientType(assemblyName, serviceClientClassName);
			ClientConfig clientConfig = CreateServiceConfig(assemblyName, serviceClientClassName.Replace("Client", "Config"));
			originalServiceClient.CloneConfig(clientConfig);
			return type.GetConstructor(new Type[2]
			{
				typeof(AWSCredentials),
				clientConfig.GetType()
			}).Invoke(new object[2]
			{
				originalServiceClient.Config.DefaultAWSCredentials,
				clientConfig
			}) as TClient;
		}

		[RequiresUnreferencedCode("Using ServiceClientHelper to dynamically load dependency is not supported for Native AOT. SDK calling code must use Amazon.RuntimeDependencyRegistry to explicitly provide runtime dependencies.")]
		public static ClientConfig CreateServiceConfig(string assemblyName, string serviceConfigClassName)
		{
			return LoadServiceConfigType(assemblyName, serviceConfigClassName).GetConstructor(new Type[0]).Invoke(new object[0]) as ClientConfig;
		}

		[RequiresUnreferencedCode("Using ServiceClientHelper to dynamically load dependency is not supported for Native AOT. SDK calling code must use Amazon.RuntimeDependencyRegistry to explicitly provide runtime dependencies.")]
		private static Type LoadServiceClientType(string assemblyName, string serviceClientClassName)
		{
			return LoadTypeFromAssembly(assemblyName, serviceClientClassName);
		}

		[RequiresUnreferencedCode("Using ServiceClientHelper to dynamically load dependency is not supported for Native AOT. SDK calling code must use Amazon.RuntimeDependencyRegistry to explicitly provide runtime dependencies.")]
		private static Type LoadServiceConfigType(string assemblyName, string serviceConfigClassName)
		{
			return LoadTypeFromAssembly(assemblyName, serviceConfigClassName);
		}

		[RequiresUnreferencedCode("Using ServiceClientHelper to dynamically load dependency is not supported for Native AOT. SDK calling code must use Amazon.RuntimeDependencyRegistry to explicitly provide runtime dependencies.")]
		internal static Type LoadTypeFromAssembly(string assemblyName, string className)
		{
			return GetSDKAssembly(assemblyName).GetType(className);
		}

		[RequiresUnreferencedCode("Using ServiceClientHelper to dynamically load dependency is not supported for Native AOT. SDK calling code must use Amazon.RuntimeDependencyRegistry to explicitly provide runtime dependencies.")]
		private static Assembly GetSDKAssembly(string assemblyName)
		{
			return AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault((Assembly x) => string.Equals(x.GetName().Name, assemblyName, StringComparison.Ordinal)) ?? Assembly.Load(new AssemblyName(assemblyName)) ?? throw new AmazonClientException("Failed to load assembly. Be sure to include a reference to " + assemblyName + ".");
		}
	}
}
