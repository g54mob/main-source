using Amazon.Runtime.Identity;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Auth
{
	public class AWSEndpointAuthSchemeSigner : AbstractAWSSigner
	{
		public override ClientProtocol Protocol => ClientProtocol.RestProtocol;

		public override void Sign(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, BaseIdentity identity)
		{
			bool useSigV4Setting = request.SignatureVersion == SignatureVersion.SigV4;
			AbstractAWSSigner abstractAWSSigner = SelectSigner(this, useSigV4Setting, request, clientConfig);
			AWS4aSignerCRTWrapper aWS4aSignerCRTWrapper = abstractAWSSigner as AWS4aSignerCRTWrapper;
			AWS4Signer aWS4Signer = abstractAWSSigner as AWS4Signer;
			bool flag = aWS4aSignerCRTWrapper != null;
			bool flag2 = aWS4Signer != null;
			ImmutableCredentials credentials = ((identity as AWSCredentials) ?? throw new AmazonClientException("The identity parameter must be of type AWSCredentials for the signer AWSEndpointAuthSchemeSigner.")).GetCredentials();
			if (credentials == null)
			{
				return;
			}
			AWSSigningResultBase aWSSigningResultBase;
			if (flag)
			{
				aWSSigningResultBase = aWS4aSignerCRTWrapper.SignRequest(request, clientConfig, metrics, credentials);
			}
			else
			{
				if (!flag2)
				{
					throw new AmazonClientException(request.ServiceName + " supports only SigV4 and SigV4a signature versions.");
				}
				aWSSigningResultBase = aWS4Signer.SignRequest(request, clientConfig, metrics, credentials.AccessKey, credentials.SecretKey);
			}
			request.Headers["Authorization"] = aWSSigningResultBase.ForAuthorizationHeader;
		}
	}
}
