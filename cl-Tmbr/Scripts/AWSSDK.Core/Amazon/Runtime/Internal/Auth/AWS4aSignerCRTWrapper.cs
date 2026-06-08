using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Amazon.Runtime.Identity;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.SharedInterfaces;
using Amazon.RuntimeDependencies;
using Amazon.Util.Internal;
using ThirdParty.RuntimeBackports;

namespace Amazon.Runtime.Internal.Auth
{
	public class AWS4aSignerCRTWrapper : AbstractAWSSigner
	{
		internal const string CRT_WRAPPER_ASSEMBLY_NAME = "AWSSDK.Extensions.CrtIntegration";

		internal const string CRT_WRAPPER_NUGET_PACKGE_NAME = "AWSSDK.Extensions.CrtIntegration";

		internal const string CRT_WRAPPER_CLASS_NAME = "Amazon.Extensions.CrtIntegration.CrtAWS4aSigner";

		private static IAWSSigV4aProvider _awsSigV4AProvider;

		private static object _lock = new object();

		public override ClientProtocol Protocol => _awsSigV4AProvider.Protocol;

		public AWS4aSignerCRTWrapper()
			: this(signPayload: true)
		{
		}

		[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026", Justification = "Reflection code is only used as a fallback in case the SDK was not trimmed. Trimmed scenarios should register dependencies with Amazon.RuntimeDependencyRegistry.GlobalRuntimeDependencyRegistry")]
		[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2075", Justification = "Reflection code is only used as a fallback in case the SDK was not trimmed. Trimmed scenarios should register dependencies with Amazon.RuntimeDependencyRegistry.GlobalRuntimeDependencyRegistry")]
		public AWS4aSignerCRTWrapper(bool signPayload)
		{
			if (_awsSigV4AProvider != null)
			{
				return;
			}
			lock (_lock)
			{
				if (_awsSigV4AProvider != null)
				{
					return;
				}
				_awsSigV4AProvider = GlobalRuntimeDependencyRegistry.Instance.GetInstance<IAWSSigV4aProvider>("AWSSDK.Extensions.CrtIntegration", "Amazon.Extensions.CrtIntegration.CrtAWS4aSigner", new CreateInstanceContext(new SigV4aCrtSignerContext(signPayload)));
				if (_awsSigV4AProvider != null)
				{
					return;
				}
				try
				{
					_awsSigV4AProvider = ServiceClientHelpers.LoadTypeFromAssembly("AWSSDK.Extensions.CrtIntegration", "Amazon.Extensions.CrtIntegration.CrtAWS4aSigner").GetConstructor(new Type[1] { typeof(bool) }).Invoke(new object[1] { signPayload }) as IAWSSigV4aProvider;
				}
				catch (Exception)
				{
					if (InternalSDKUtils.IsRunningNativeAot())
					{
						throw new MissingRuntimeDependencyException("AWSSDK.Extensions.CrtIntegration", "Amazon.Extensions.CrtIntegration.CrtAWS4aSigner", "RegisterSigV4aProvider");
					}
					throw new AWSCommonRuntimeException(string.Format(CultureInfo.InvariantCulture, "Attempting to make a request that requires an implementation of AWS Signature V4a. Add a reference to the AWSSDK.Extensions.CrtIntegration NuGet package to your project to include the AWS Signature V4a signer."));
				}
			}
		}

		public override void Sign(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, BaseIdentity identity)
		{
			ImmutableCredentials credentials = (identity as AWSCredentials).GetCredentials();
			if (credentials != null)
			{
				_awsSigV4AProvider.Sign(request, clientConfig, metrics, credentials);
			}
		}

		public AWS4aSigningResult SignRequest(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, ImmutableCredentials credentials)
		{
			return _awsSigV4AProvider.SignRequest(request, clientConfig, metrics, credentials);
		}

		public AWS4aSigningResult Presign4a(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, ImmutableCredentials credentials, string service, string overrideSigningRegion)
		{
			return _awsSigV4AProvider.Presign4a(request, clientConfig, metrics, credentials, service, overrideSigningRegion);
		}

		public string SignChunk(Stream chunkBody, string previousSignature, AWS4aSigningResult headerSigningResult)
		{
			return _awsSigV4AProvider.SignChunk(chunkBody, previousSignature, headerSigningResult);
		}

		public string SignTrailingHeaderChunk(IDictionary<string, string> trailingHeaders, string previousSignature, AWS4aSigningResult headerSigningResult)
		{
			return _awsSigV4AProvider.SignTrailingHeaderChunk(trailingHeaders, previousSignature, headerSigningResult);
		}
	}
}
