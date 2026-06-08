using System;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime.Identity;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;

namespace Amazon.Runtime.Internal.Auth
{
	public abstract class AbstractAWSSigner : ISigner
	{
		private readonly object _lock = new object();

		private AWS4Signer _aws4Signer;

		private AWS4aSignerCRTWrapper _aws4aSignerCRTWrapper;

		private AWS4Signer AWS4SignerInstance
		{
			get
			{
				if (_aws4Signer == null)
				{
					lock (_lock)
					{
						if (_aws4Signer == null)
						{
							_aws4Signer = new AWS4Signer();
						}
					}
				}
				return _aws4Signer;
			}
		}

		private AWS4aSignerCRTWrapper AWS4aSignerCRTWrapperInstance
		{
			get
			{
				if (_aws4aSignerCRTWrapper == null)
				{
					lock (_lock)
					{
						if (_aws4aSignerCRTWrapper == null)
						{
							_aws4aSignerCRTWrapper = new AWS4aSignerCRTWrapper();
						}
					}
				}
				return _aws4aSignerCRTWrapper;
			}
		}

		public virtual bool RequiresCredentials { get; } = true;

		public abstract ClientProtocol Protocol { get; }

		protected static string ComputeHash(string data, string secretkey, SigningAlgorithm algorithm)
		{
			try
			{
				return CryptoUtilFactory.CryptoInstance.HMACSign(data, secretkey, algorithm);
			}
			catch (Exception ex)
			{
				throw new Amazon.Runtime.SignatureException("Failed to generate signature: " + ex.Message, ex);
			}
		}

		protected static string ComputeHash(byte[] data, string secretkey, SigningAlgorithm algorithm)
		{
			try
			{
				return CryptoUtilFactory.CryptoInstance.HMACSign(data, secretkey, algorithm);
			}
			catch (Exception ex)
			{
				throw new Amazon.Runtime.SignatureException("Failed to generate signature: " + ex.Message, ex);
			}
		}

		public abstract void Sign(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, BaseIdentity identity);

		public virtual Task SignAsync(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, BaseIdentity identity, CancellationToken token = default(CancellationToken))
		{
			Sign(request, clientConfig, metrics, identity);
			return Task.CompletedTask;
		}

		protected static bool UseV4Signing(bool useSigV4Setting, IRequest request, IClientConfig config)
		{
			if (request.SignatureVersion == SignatureVersion.SigV4 || useSigV4Setting)
			{
				return true;
			}
			RegionEndpoint regionEndpoint = null;
			if (!string.IsNullOrEmpty(request.AuthenticationRegion))
			{
				regionEndpoint = RegionEndpoint.GetBySystemName(request.AuthenticationRegion);
			}
			if (regionEndpoint == null && !string.IsNullOrEmpty(config.ServiceURL))
			{
				string text = AWSSDKUtils.DetermineRegion(config.ServiceURL);
				if (!string.IsNullOrEmpty(text))
				{
					regionEndpoint = RegionEndpoint.GetBySystemName(text);
				}
			}
			if (regionEndpoint == null && config.RegionEndpoint != null)
			{
				regionEndpoint = config.RegionEndpoint;
			}
			if (regionEndpoint != null)
			{
				return true;
			}
			return false;
		}

		protected AbstractAWSSigner SelectSigner(IRequest request, IClientConfig config)
		{
			return SelectSigner(this, useSigV4Setting: false, request, config);
		}

		protected AbstractAWSSigner SelectSigner(AbstractAWSSigner defaultSigner, bool useSigV4Setting, IRequest request, IClientConfig config)
		{
			if (request.SignatureVersion == SignatureVersion.SigV4a)
			{
				return AWS4aSignerCRTWrapperInstance;
			}
			if (UseV4Signing(useSigV4Setting, request, config))
			{
				return AWS4SignerInstance;
			}
			return defaultSigner;
		}

		public virtual IEventSigner CreateEventSigner(BaseIdentity identity, string region, string service, string requestSignature)
		{
			throw new NotImplementedException();
		}
	}
}
