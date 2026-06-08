using System;
using System.Globalization;
using System.Net;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.SharedInterfaces;
using Amazon.RuntimeDependencies;
using Amazon.Util.Internal;
using ThirdParty.RuntimeBackports;

namespace Amazon.Runtime.Internal
{
	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "Reflection code is only used as a fallback in case the SDK was not trimmed. Trimmed scenarios should register dependencies with Amazon.RuntimeDependencyRegistry.GlobalRuntimeDependencyRegistry")]
	public static class SSOServiceClientHelpers
	{
		public static ICoreAmazonSSOOIDC BuildSSOIDCClient(RegionEndpoint region, IWebProxy proxySettings = null)
		{
			ICoreAmazonSSOOIDC coreAmazonSSOOIDC = GlobalRuntimeDependencyRegistry.Instance.GetInstance<ICoreAmazonSSOOIDC>("AWSSDK.SSOOIDC", "Amazon.SSOOIDC.AmazonSSOOIDCClient", new CreateInstanceContext(new SSOOIDCClientContext
			{
				Region = region,
				ProxySettings = proxySettings
			}));
			if (coreAmazonSSOOIDC == null)
			{
				coreAmazonSSOOIDC = CreateClient<ICoreAmazonSSOOIDC>(region, "Amazon.SSOOIDC.AmazonSSOOIDCClient", "Amazon.SSOOIDC.AmazonSSOOIDCConfig", "AWSSDK.SSOOIDC", "RegisterSSOOIDCClient", proxySettings);
			}
			return coreAmazonSSOOIDC;
		}

		[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "Reflection code is only used as a fallback in case the SDK was not trimmed. Trimmed scenarios should register dependencies with Amazon.RuntimeDependencyRegistry.GlobalRuntimeDependencyRegistry")]
		public static ICoreAmazonSSO BuildSSOClient(RegionEndpoint region, IWebProxy proxySettings = null)
		{
			ICoreAmazonSSO coreAmazonSSO = GlobalRuntimeDependencyRegistry.Instance.GetInstance<ICoreAmazonSSO>("AWSSDK.SSO", "Amazon.SSO.AmazonSSOClient", new CreateInstanceContext(new SSOClientContext
			{
				Region = region,
				ProxySettings = proxySettings
			}));
			if (coreAmazonSSO == null)
			{
				coreAmazonSSO = CreateClient<ICoreAmazonSSO>(region, "Amazon.SSO.AmazonSSOClient", "Amazon.SSO.AmazonSSOConfig", "AWSSDK.SSO", "RegisterSSOClient", proxySettings);
			}
			return coreAmazonSSO;
		}

		[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "Reflection code is only used as a fallback in case the SDK was not trimmed. Trimmed scenarios should register dependencies with Amazon.RuntimeDependencyRegistry.GlobalRuntimeDependencyRegistry")]
		public static ICoreAmazonSSO_Logout BuildSSOLogoutClient(RegionEndpoint region, IWebProxy proxySettings = null)
		{
			ICoreAmazonSSO_Logout coreAmazonSSO_Logout = GlobalRuntimeDependencyRegistry.Instance.GetInstance<ICoreAmazonSSO_Logout>("AWSSDK.SSO", "Amazon.SSO.AmazonSSOClient", new CreateInstanceContext(new SSOClientContext
			{
				Region = region,
				ProxySettings = proxySettings
			}));
			if (coreAmazonSSO_Logout == null)
			{
				coreAmazonSSO_Logout = CreateClient<ICoreAmazonSSO_Logout>(region, "Amazon.SSO.AmazonSSOClient", "Amazon.SSO.AmazonSSOConfig", "AWSSDK.SSO", "RegisterSSOClient", proxySettings);
			}
			return coreAmazonSSO_Logout;
		}

		[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "Reflection code is only used as a fallback in case the SDK was not trimmed. Trimmed scenarios should register dependencies with Amazon.RuntimeDependencyRegistry.GlobalRuntimeDependencyRegistry")]
		public static ICoreAmazonSSOOIDC_V2 BuildSSOIDC_V2Client(RegionEndpoint region, IWebProxy proxySettings = null)
		{
			ICoreAmazonSSOOIDC_V2 coreAmazonSSOOIDC_V = GlobalRuntimeDependencyRegistry.Instance.GetInstance<ICoreAmazonSSOOIDC_V2>("AWSSDK.SSOOIDC", "Amazon.SSOOIDC.AmazonSSOOIDCClient", new CreateInstanceContext(new SSOOIDCClientContext
			{
				Region = region,
				ProxySettings = proxySettings
			}));
			if (coreAmazonSSOOIDC_V == null)
			{
				coreAmazonSSOOIDC_V = CreateClient<ICoreAmazonSSOOIDC_V2>(region, "Amazon.SSOOIDC.AmazonSSOOIDCClient", "Amazon.SSOOIDC.AmazonSSOOIDCConfig", "AWSSDK.SSOOIDC", "RegisterSSOOIDCClient", proxySettings);
			}
			return coreAmazonSSOOIDC_V;
		}

		[RequiresUnreferencedCode("Using CreateClient to dynamically load dependency is not supported for Native AOT. SDK calling code must use Amazon.RuntimeDependencyRegistry to explicitly provide runtime dependencies.")]
		private static T CreateClient<T>(RegionEndpoint region, string serviceClassName, string serviceConfigName, string parentAssemblyName, string runtimeDependencyRegistryMethod, IWebProxy proxySettings = null) where T : class
		{
			try
			{
				ClientConfig clientConfig = ServiceClientHelpers.CreateServiceConfig(parentAssemblyName, serviceConfigName);
				clientConfig.RegionEndpoint = region;
				if (proxySettings != null)
				{
					clientConfig.SetWebProxy(proxySettings);
				}
				return ServiceClientHelpers.CreateServiceFromAssembly<T>(parentAssemblyName, serviceClassName, new AnonymousAWSCredentials(), clientConfig);
			}
			catch (Exception innerException)
			{
				if (InternalSDKUtils.IsRunningNativeAot())
				{
					throw new MissingRuntimeDependencyException(parentAssemblyName, serviceClassName, runtimeDependencyRegistryMethod);
				}
				InvalidOperationException ex = new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Assembly {0} could not be found or loaded. This assembly must be available at runtime to use {1}.", parentAssemblyName, typeof(SSOServiceClientHelpers).AssemblyQualifiedName), innerException);
				Logger.GetLogger(typeof(SSOServiceClientHelpers)).Error(ex, ex.Message);
				throw ex;
			}
		}
	}
}
