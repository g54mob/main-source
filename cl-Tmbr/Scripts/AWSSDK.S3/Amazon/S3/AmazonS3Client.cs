using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Runtime;
using Amazon.Runtime.Credentials.Internal;
using Amazon.Runtime.Endpoints;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Auth;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.SharedInterfaces;
using Amazon.S3.Internal;
using Amazon.S3.Internal.S3Express;
using Amazon.S3.Model;
using Amazon.S3.Model.Internal.MarshallTransformations;
using Amazon.S3.Transfer;
using Amazon.S3.Util;
using Amazon.Util;
using Amazon.Util.Internal;

namespace Amazon.S3
{
	public class AmazonS3Client : AmazonServiceClient, IAmazonS3, IDisposable, ICoreAmazonS3, IAmazonService
	{
		private class SigningResult
		{
			public string Authorization { get; set; }

			public string Result { get; set; }
		}

		private static readonly HashSet<string> _sigV2SupportedRegions = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "ap-northeast-1", "ap-southeast-1", "ap-southeast-2", "eu-west-1", "sa-east-1", "us-east-1", "us-west-1", "us-west-2" };

		private static IServiceMetadata serviceMetadata = new AmazonS3Metadata();

		private IS3PaginatorFactory _paginators;

		public IS3PaginatorFactory Paginators
		{
			get
			{
				if (_paginators == null)
				{
					_paginators = new S3PaginatorFactory(this);
				}
				return _paginators;
			}
		}

		protected override IServiceMetadata ServiceMetadata => serviceMetadata;

		IClientConfig IAmazonService.Config => base.Config;

		protected override void Initialize()
		{
			if (base.Config is AmazonS3Config amazonS3Config)
			{
				amazonS3Config.ResignRetries = true;
				if (amazonS3Config.S3ExpressCredentialProvider == null)
				{
					amazonS3Config.S3ExpressCredentialProvider = new DefaultS3ExpressCredentialProvider(this);
				}
			}
			base.Initialize();
		}

		internal string GetPreSignedURLInternal(GetPreSignedUrlRequest request)
		{
			AWSCredentials obj = base.Config.DefaultAWSCredentials ?? DefaultIdentityResolverConfiguration.ResolveDefaultIdentity<AWSCredentials>();
			if (obj == null)
			{
				throw new AmazonS3Exception("Credentials must be specified, cannot call method anonymously");
			}
			if (request == null)
			{
				throw new ArgumentNullException("request", "The PreSignedUrlRequest specified is null!");
			}
			if (!request.IsSetExpires())
			{
				throw new InvalidOperationException("The Expires specified is null!");
			}
			Arn arn = null;
			SignatureVersion signatureVersion = DetermineSignatureVersionToUse(request, ref arn);
			ImmutableCredentials immutableCredentials = obj.GetCredentials();
			IRequest request2 = Marshall(base.Config, request, immutableCredentials.AccessKey, immutableCredentials.Token, signatureVersion);
			Amazon.Runtime.Internal.ExecutionContext executionContext = new Amazon.Runtime.Internal.ExecutionContext(new RequestContext(enableMetrics: true, new NullSigner())
			{
				Request = request2,
				ClientConfig = base.Config,
				OriginalRequest = request
			}, null);
			new AmazonS3EndpointResolver().ProcessRequestHandlers(executionContext);
			AmazonS3Config amazonS3Config = base.Config as AmazonS3Config;
			if (executionContext.RequestContext.Request.IsDirectoryBucket() && !amazonS3Config.DisableS3ExpressSessionAuth)
			{
				ConvertToS3Express(immutableCredentials, executionContext, ref signatureVersion, amazonS3Config);
				SessionCredentials sessionCredentials = amazonS3Config.S3ExpressCredentialProvider.ResolveSessionCredentials(request.BucketName);
				if (sessionCredentials != null)
				{
					request2.Parameters.Add("X-Amz-S3session-Token", sessionCredentials.SessionToken);
					immutableCredentials = new ImmutableCredentials(sessionCredentials.AccessKeyId, sessionCredentials.SecretAccessKey, null);
				}
			}
			RequestMetrics metrics = new RequestMetrics();
			return ReturnSigningResult(signatureVersion, request2, base.Config, metrics, immutableCredentials, arn).Result;
		}

		internal async Task<string> GetPreSignedURLInternalAsync(GetPreSignedUrlRequest request)
		{
			AWSCredentials obj = base.Config.DefaultAWSCredentials ?? DefaultIdentityResolverConfiguration.ResolveDefaultIdentity<AWSCredentials>();
			if (obj == null)
			{
				throw new AmazonS3Exception("Credentials must be specified, cannot call method anonymously");
			}
			if (request == null)
			{
				throw new ArgumentNullException("request", "The PreSignedUrlRequest specified is null!");
			}
			if (!request.IsSetExpires())
			{
				throw new InvalidOperationException("The Expires specified is null!");
			}
			Arn arn = null;
			SignatureVersion signatureVersionToUse = DetermineSignatureVersionToUse(request, ref arn);
			ImmutableCredentials immutableCredentials = await obj.GetCredentialsAsync().ConfigureAwait(continueOnCapturedContext: false);
			IRequest irequest = Marshall(base.Config, request, immutableCredentials.AccessKey, immutableCredentials.Token, signatureVersionToUse);
			Amazon.Runtime.Internal.ExecutionContext executionContext = new Amazon.Runtime.Internal.ExecutionContext(new RequestContext(enableMetrics: true, new NullSigner())
			{
				Request = irequest,
				ClientConfig = base.Config,
				OriginalRequest = request
			}, null);
			new AmazonS3EndpointResolver().ProcessRequestHandlers(executionContext);
			AmazonS3Config amazonS3Config = base.Config as AmazonS3Config;
			if (executionContext.RequestContext.Request.IsDirectoryBucket() && !amazonS3Config.DisableS3ExpressSessionAuth)
			{
				ConvertToS3Express(immutableCredentials, executionContext, ref signatureVersionToUse, amazonS3Config);
				SessionCredentials sessionCredentials = await amazonS3Config.S3ExpressCredentialProvider.ResolveSessionCredentialsAsync(request.BucketName).ConfigureAwait(continueOnCapturedContext: false);
				irequest.Parameters.Add("X-Amz-S3session-Token", sessionCredentials.SessionToken);
				immutableCredentials = new ImmutableCredentials(sessionCredentials.AccessKeyId, sessionCredentials.SecretAccessKey, null);
			}
			RequestMetrics metrics = new RequestMetrics();
			return ReturnSigningResult(signatureVersionToUse, irequest, base.Config, metrics, immutableCredentials, arn).Result;
		}

		private static IRequest Marshall(IClientConfig config, GetPreSignedUrlRequest getPreSignedUrlRequest, string accessKey, string token, SignatureVersion signatureVersion)
		{
			IRequest request = new DefaultRequest(getPreSignedUrlRequest, "AmazonS3");
			request.HttpMethod = getPreSignedUrlRequest.Verb.ToString();
			HeadersCollection headers = getPreSignedUrlRequest.Headers;
			foreach (string key in headers.Keys)
			{
				request.Headers[key] = headers[key];
			}
			AmazonS3Util.SetMetadataHeaders(request, getPreSignedUrlRequest.Metadata);
			if (getPreSignedUrlRequest.ServerSideEncryptionMethod != null && getPreSignedUrlRequest.ServerSideEncryptionMethod != ServerSideEncryptionMethod.None)
			{
				request.Headers.Add("x-amz-server-side-encryption", S3Transforms.ToStringValue(getPreSignedUrlRequest.ServerSideEncryptionMethod));
			}
			if (getPreSignedUrlRequest.IsSetServerSideEncryptionCustomerMethod())
			{
				request.Headers.Add("x-amz-server-side-encryption-customer-algorithm", getPreSignedUrlRequest.ServerSideEncryptionCustomerMethod);
			}
			if (getPreSignedUrlRequest.IsSetServerSideEncryptionKeyManagementServiceKeyId())
			{
				request.Headers.Add("x-amz-server-side-encryption-aws-kms-key-id", getPreSignedUrlRequest.ServerSideEncryptionKeyManagementServiceKeyId);
			}
			if (getPreSignedUrlRequest.IsSetRequestPayer() && getPreSignedUrlRequest.RequestPayer == RequestPayer.Requester)
			{
				request.Parameters.Add("x-amz-request-payer", RequestPayer.Requester.Value);
			}
			IDictionary<string, string> parameters = request.Parameters;
			StringBuilder stringBuilder = new StringBuilder("");
			if (!string.IsNullOrEmpty(getPreSignedUrlRequest.Key))
			{
				stringBuilder.Append("/{Key+}");
				request.AddPathResource("{Key+}", S3Transforms.ToStringValue(getPreSignedUrlRequest.Key));
			}
			long secondsUntilExpiration = GetSecondsUntilExpiration(config, getPreSignedUrlRequest, signatureVersion);
			if ((signatureVersion == SignatureVersion.SigV4 || signatureVersion == SignatureVersion.SigV4a) && secondsUntilExpiration > 604800)
			{
				throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "The maximum expiry period for a presigned url using AWS4 signing is {0} seconds", 604800L));
			}
			if (signatureVersion == SignatureVersion.SigV2)
			{
				parameters.Add("Expires", secondsUntilExpiration.ToString(CultureInfo.InvariantCulture));
				parameters.Add("AWSAccessKeyId", accessKey);
				if (!string.IsNullOrEmpty(token))
				{
					parameters.Add("x-amz-security-token", token);
				}
			}
			else
			{
				parameters.Add("X-Amz-Expires", secondsUntilExpiration.ToString(CultureInfo.InvariantCulture));
				if (!string.IsNullOrEmpty(token))
				{
					parameters.Add("X-Amz-Security-Token", token);
				}
			}
			if (getPreSignedUrlRequest.IsSetVersionId())
			{
				request.AddSubResource("versionId", S3Transforms.ToStringValue(getPreSignedUrlRequest.VersionId));
			}
			if (getPreSignedUrlRequest.IsSetUploadId())
			{
				request.AddSubResource("uploadId", S3Transforms.ToStringValue(getPreSignedUrlRequest.UploadId));
			}
			if (getPreSignedUrlRequest.IsSetPartNumber())
			{
				request.AddSubResource("partNumber", S3Transforms.ToStringValue(getPreSignedUrlRequest.PartNumber.Value));
			}
			ResponseHeaderOverrides responseHeaderOverrides = getPreSignedUrlRequest.ResponseHeaderOverrides;
			if (!string.IsNullOrEmpty(responseHeaderOverrides.CacheControl))
			{
				parameters.Add("response-cache-control", responseHeaderOverrides.CacheControl);
			}
			if (!string.IsNullOrEmpty(responseHeaderOverrides.ContentType))
			{
				parameters.Add("response-content-type", responseHeaderOverrides.ContentType);
			}
			if (!string.IsNullOrEmpty(responseHeaderOverrides.ContentLanguage))
			{
				parameters.Add("response-content-language", responseHeaderOverrides.ContentLanguage);
			}
			if (!string.IsNullOrEmpty(responseHeaderOverrides.Expires))
			{
				parameters.Add("response-expires", responseHeaderOverrides.Expires);
			}
			if (!string.IsNullOrEmpty(responseHeaderOverrides.ContentDisposition))
			{
				parameters.Add("response-content-disposition", responseHeaderOverrides.ContentDisposition);
			}
			if (!string.IsNullOrEmpty(responseHeaderOverrides.ContentEncoding))
			{
				parameters.Add("response-content-encoding", responseHeaderOverrides.ContentEncoding);
			}
			foreach (string key2 in getPreSignedUrlRequest.Parameters.Keys)
			{
				parameters.Add(key2, getPreSignedUrlRequest.Parameters[key2]);
			}
			request.ResourcePath = stringBuilder.ToString();
			request.UseQueryString = true;
			return request;
		}

		private SignatureVersion DetermineSignatureVersionToUse(GetPreSignedUrlRequest request, ref Arn arn)
		{
			SignatureVersion signatureVersion = SignatureVersion.SigV4;
			if (Arn.TryParse(request.BucketName, out arn) && (arn.TryParseAccessPoint(out var _) || arn.IsOutpostArn()))
			{
				signatureVersion = SignatureVersion.SigV4;
				if (arn.IsMRAPArn())
				{
					signatureVersion = SignatureVersion.SigV4a;
				}
			}
			else
			{
				string text = AWS4Signer.DetermineSigningRegion(base.Config, "s3", null, null);
				if (signatureVersion == SignatureVersion.SigV4 && string.IsNullOrEmpty(text))
				{
					throw new InvalidOperationException("To use AWS4 signing, a region must be specified in the client configuration using the AuthenticationRegion or Region properties, or be determinable from the service URL.");
				}
				if (signatureVersion == SignatureVersion.SigV4)
				{
					RegionEndpoint bySystemName = RegionEndpoint.GetBySystemName(text);
					if (GetSecondsUntilExpiration(base.Config, request, signatureVersion) > 604800 && _sigV2SupportedRegions.Contains(bySystemName?.SystemName))
					{
						signatureVersion = SignatureVersion.SigV2;
					}
				}
			}
			return signatureVersion;
		}

		private static void ConvertToS3Express(ImmutableCredentials immutableCredentials, Amazon.Runtime.Internal.ExecutionContext context, ref SignatureVersion signatureVersion, AmazonS3Config config)
		{
			IRequest request = context.RequestContext.Request;
			GetPreSignedUrlRequest request2 = request.OriginalRequest as GetPreSignedUrlRequest;
			if (GetSecondsUntilExpiration(config, request2, SignatureVersion.SigV4) > 604800)
			{
				throw new AmazonS3Exception("S3 Express only works with SigV4 which does not allow expiration greater than 7 days. Please create a presignedUrl thatis shorter than 7 days.");
			}
			if (!string.IsNullOrEmpty(immutableCredentials.Token) && signatureVersion == SignatureVersion.SigV4)
			{
				request.Parameters.Remove("X-Amz-Security-Token");
			}
			signatureVersion = SignatureVersion.SigV4;
		}

		private static SigningResult ReturnSigningResult(SignatureVersion signatureVersionToUse, IRequest iRequest, IClientConfig config, RequestMetrics metrics, ImmutableCredentials immutableCredentials, Arn arn)
		{
			SigningResult signingResult = new SigningResult();
			switch (signatureVersionToUse)
			{
			case SignatureVersion.SigV4a:
			{
				AWS4aSigningResult aWS4aSigningResult = new AWS4aSignerCRTWrapper().Presign4a(iRequest, config, metrics, immutableCredentials, "s3", arn.IsMRAPArn() ? "*" : "");
				signingResult.Result = aWS4aSigningResult.PresignedUri;
				break;
			}
			case SignatureVersion.SigV4:
			{
				AWS4SigningResult aWS4SigningResult = new AWS4PreSignedUrlSigner().SignRequest(iRequest, config, metrics, immutableCredentials.AccessKey, immutableCredentials.SecretKey);
				signingResult.Authorization = "&" + aWS4SigningResult.ForQueryParameters;
				signingResult.Result = AmazonServiceClient.ComposeUrl(iRequest).AbsoluteUri + signingResult.Authorization;
				break;
			}
			default:
				Amazon.S3.Internal.S3Signer.SignRequest(iRequest, metrics, immutableCredentials.AccessKey, immutableCredentials.SecretKey);
				signingResult.Authorization = iRequest.Headers["Authorization"];
				signingResult.Authorization = signingResult.Authorization.Substring(signingResult.Authorization.IndexOf(":", StringComparison.Ordinal) + 1);
				signingResult.Authorization = "&Signature=" + AWSSDKUtils.UrlEncode(signingResult.Authorization, path: false);
				signingResult.Result = AmazonServiceClient.ComposeUrl(iRequest).AbsoluteUri + signingResult.Authorization;
				break;
			}
			ServiceOperationEndpointParameters parameters = new ServiceOperationEndpointParameters(iRequest.OriginalRequest);
			Protocol protocol = ((!config.DetermineServiceOperationEndpoint(parameters).URL.StartsWith("https", StringComparison.OrdinalIgnoreCase)) ? Protocol.HTTP : Protocol.HTTPS);
			if ((iRequest.OriginalRequest as GetPreSignedUrlRequest).Protocol != protocol)
			{
				switch (protocol)
				{
				case Protocol.HTTP:
					signingResult.Result = signingResult.Result.Replace("http://", "https://");
					break;
				case Protocol.HTTPS:
					signingResult.Result = signingResult.Result.Replace("https://", "http://");
					break;
				}
			}
			return signingResult;
		}

		private static long GetSecondsUntilExpiration(IClientConfig config, GetPreSignedUrlRequest request, SignatureVersion signatureVersion)
		{
			DateTime dateTime;
			if (signatureVersion == SignatureVersion.SigV2)
			{
				dateTime = AWSSDKUtils.EPOCH_START;
			}
			else
			{
				ServiceOperationEndpointParameters parameters = new ServiceOperationEndpointParameters(request);
				dateTime = CorrectClockSkew.GetCorrectedUtcNowForEndpoint(config.DetermineServiceOperationEndpoint(parameters).URL);
			}
			return Convert.ToInt64((request.Expires.GetValueOrDefault().ToUniversalTime() - dateTime).TotalSeconds);
		}

		internal static void CleanupRequest(AmazonWebServiceRequest request)
		{
			if (request is PutObjectRequest putObjectRequest)
			{
				if (putObjectRequest.InputStream != null && (!string.IsNullOrEmpty(putObjectRequest.FilePath) || putObjectRequest.AutoCloseStream))
				{
					putObjectRequest.InputStream.Dispose();
				}
				if (!string.IsNullOrEmpty(putObjectRequest.FilePath) || !string.IsNullOrEmpty(putObjectRequest.ContentBody))
				{
					putObjectRequest.InputStream = null;
				}
			}
			if (request is UploadPartRequest uploadPartRequest)
			{
				if (uploadPartRequest.IsSetFilePath() && uploadPartRequest.InputStream != null)
				{
					uploadPartRequest.InputStream.Dispose();
				}
				if (uploadPartRequest.IsSetFilePath())
				{
					uploadPartRequest.InputStream = null;
				}
			}
		}

		internal void ConfigureProxy(HttpWebRequest httpRequest)
		{
			httpRequest.Proxy = base.Config.GetWebProxy();
			if (httpRequest.Proxy != null && base.Config.ProxyCredentials != null)
			{
				httpRequest.Proxy.Credentials = base.Config.ProxyCredentials;
			}
			if (httpRequest.Proxy == null && !NoProxyFilter.Instance.Match(httpRequest.RequestUri))
			{
				if (httpRequest.RequestUri.Scheme == Uri.UriSchemeHttp)
				{
					httpRequest.Proxy = base.Config.GetHttpProxy();
				}
				else if (httpRequest.RequestUri.Scheme == Uri.UriSchemeHttps)
				{
					httpRequest.Proxy = base.Config.GetHttpsProxy();
				}
			}
		}

		public string GetPreSignedURL(GetPreSignedUrlRequest request)
		{
			return GetPreSignedURLInternal(request);
		}

		public async Task<string> GetPreSignedURLAsync(GetPreSignedUrlRequest request)
		{
			return await GetPreSignedURLInternalAsync(request).ConfigureAwait(continueOnCapturedContext: false);
		}

		string ICoreAmazonS3.GeneratePreSignedURL(string bucketName, string objectKey, DateTime expiration, IDictionary<string, object> additionalProperties)
		{
			GetPreSignedUrlRequest getPreSignedUrlRequest = new GetPreSignedUrlRequest
			{
				BucketName = bucketName,
				Key = objectKey,
				Expires = expiration
			};
			InternalSDKUtils.ApplyValuesV2(getPreSignedUrlRequest, additionalProperties);
			return GetPreSignedURL(getPreSignedUrlRequest);
		}

		[Obsolete("GetACL combines both GetBucketAcl and GetObjectAcl and is deprecated. Please use the separated GetObjectAcl and GetBucketAcl operations.")]
		public virtual GetACLResponse GetACL(string bucketName)
		{
			GetACLRequest getACLRequest = new GetACLRequest();
			getACLRequest.BucketName = bucketName;
			return GetACL(getACLRequest);
		}

		[Obsolete("GetACL combines both GetBucketAcl and GetObjectAcl and is deprecated. Please use the separated GetObjectAcl and GetBucketAcl operations.")]
		public virtual GetACLResponse GetACL(GetACLRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetACLRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetACLResponseUnmarshaller.Instance;
			return Invoke<GetACLResponse>(request, invokeOptions);
		}

		[Obsolete("GetACL combines both GetBucketAcl and GetObjectAcl and is deprecated. Please use the separated GetObjectAcl and GetBucketAcl operations.")]
		public virtual Task<GetACLResponse> GetACLAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			GetACLRequest getACLRequest = new GetACLRequest();
			getACLRequest.BucketName = bucketName;
			return GetACLAsync(getACLRequest, cancellationToken);
		}

		[Obsolete("GetACL combines both GetBucketAcl and GetObjectAcl and is deprecated. Please use the separated GetObjectAcl and GetBucketAcl operations.")]
		public virtual Task<GetACLResponse> GetACLAsync(GetACLRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetACLRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetACLResponseUnmarshaller.Instance;
			return InvokeAsync<GetACLResponse>(request, invokeOptions, cancellationToken);
		}

		[Obsolete("PutACL combines both PutBucketAcl and PutObjectAcl and is deprecated. Please use the separated PutObjectAcl and PutBucketAcl operations.")]
		public virtual PutACLResponse PutACL(PutACLRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutACLRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutACLResponseUnmarshaller.Instance;
			return Invoke<PutACLResponse>(request, invokeOptions);
		}

		[Obsolete("PutACL combines both PutBucketAcl and PutObjectAcl and is deprecated. Please use the separated PutObjectAcl and PutBucketAcl operations.")]
		public virtual Task<PutACLResponse> PutACLAsync(PutACLRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutACLRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutACLResponseUnmarshaller.Instance;
			return InvokeAsync<PutACLResponse>(request, invokeOptions, cancellationToken);
		}

		async Task<IList<string>> ICoreAmazonS3.GetAllObjectKeysAsync(string bucketName, string prefix, IDictionary<string, object> additionalProperties)
		{
			List<string> keys = new List<string>();
			string text = null;
			do
			{
				ListObjectsRequest listObjectsRequest = new ListObjectsRequest
				{
					BucketName = bucketName,
					Prefix = prefix,
					Marker = text
				};
				InternalSDKUtils.ApplyValuesV2(listObjectsRequest, additionalProperties);
				ListObjectsResponse listObjectsResponse = await ListObjectsAsync(listObjectsRequest).ConfigureAwait(continueOnCapturedContext: false);
				if (listObjectsResponse.S3Objects != null)
				{
					keys.AddRange(listObjectsResponse.S3Objects.Select((S3Object o) => o.Key));
				}
				text = listObjectsResponse.NextMarker;
			}
			while (!string.IsNullOrEmpty(text));
			return keys;
		}

		Task ICoreAmazonS3.DeleteAsync(string bucketName, string objectKey, IDictionary<string, object> additionalProperties, CancellationToken cancellationToken)
		{
			DeleteObjectRequest deleteObjectRequest = new DeleteObjectRequest
			{
				BucketName = bucketName,
				Key = objectKey
			};
			InternalSDKUtils.ApplyValuesV2(deleteObjectRequest, additionalProperties);
			return DeleteObjectAsync(deleteObjectRequest, cancellationToken);
		}

		Task ICoreAmazonS3.DeletesAsync(string bucketName, IEnumerable<string> objectKeys, IDictionary<string, object> additionalProperties, CancellationToken cancellationToken)
		{
			DeleteObjectsRequest deleteObjectsRequest = new DeleteObjectsRequest
			{
				BucketName = bucketName
			};
			foreach (string objectKey in objectKeys)
			{
				deleteObjectsRequest.AddKey(objectKey);
			}
			InternalSDKUtils.ApplyValuesV2(deleteObjectsRequest, additionalProperties);
			return DeleteObjectsAsync(deleteObjectsRequest, cancellationToken);
		}

		Task ICoreAmazonS3.UploadObjectFromStreamAsync(string bucketName, string objectKey, Stream stream, IDictionary<string, object> additionalProperties, CancellationToken cancellationToken)
		{
			TransferUtility transferUtility = new TransferUtility(this);
			TransferUtilityUploadRequest transferUtilityUploadRequest = new TransferUtilityUploadRequest
			{
				BucketName = bucketName,
				Key = objectKey,
				InputStream = stream
			};
			InternalSDKUtils.ApplyValuesV2(transferUtilityUploadRequest, additionalProperties);
			return transferUtility.UploadAsync(transferUtilityUploadRequest, cancellationToken);
		}

		async Task<Stream> ICoreAmazonS3.GetObjectStreamAsync(string bucketName, string objectKey, IDictionary<string, object> additionalProperties, CancellationToken cancellationToken)
		{
			GetObjectRequest getObjectRequest = new GetObjectRequest
			{
				BucketName = bucketName,
				Key = objectKey
			};
			InternalSDKUtils.ApplyValuesV2(getObjectRequest, additionalProperties);
			return (await GetObjectAsync(getObjectRequest, cancellationToken).ConfigureAwait(continueOnCapturedContext: false)).ResponseStream;
		}

		Task ICoreAmazonS3.UploadObjectFromFilePathAsync(string bucketName, string objectKey, string filepath, IDictionary<string, object> additionalProperties, CancellationToken cancellationToken)
		{
			TransferUtility transferUtility = new TransferUtility(this);
			TransferUtilityUploadRequest transferUtilityUploadRequest = new TransferUtilityUploadRequest
			{
				BucketName = bucketName,
				Key = objectKey,
				FilePath = filepath
			};
			InternalSDKUtils.ApplyValuesV2(transferUtilityUploadRequest, additionalProperties);
			return transferUtility.UploadAsync(transferUtilityUploadRequest, cancellationToken);
		}

		Task ICoreAmazonS3.DownloadToFilePathAsync(string bucketName, string objectKey, string filepath, IDictionary<string, object> additionalProperties, CancellationToken cancellationToken)
		{
			TransferUtility transferUtility = new TransferUtility(this);
			TransferUtilityDownloadRequest transferUtilityDownloadRequest = new TransferUtilityDownloadRequest
			{
				BucketName = bucketName,
				Key = objectKey,
				FilePath = filepath
			};
			InternalSDKUtils.ApplyValuesV2(transferUtilityDownloadRequest, additionalProperties);
			return transferUtility.DownloadAsync(transferUtilityDownloadRequest, cancellationToken);
		}

		Task ICoreAmazonS3.MakeObjectPublicAsync(string bucket, string objectKey, bool enable)
		{
			PutObjectAclRequest request = new PutObjectAclRequest
			{
				BucketName = bucket,
				Key = objectKey,
				ACL = (enable ? S3CannedACL.PublicRead : S3CannedACL.Private)
			};
			return PutObjectAclAsync(request);
		}

		async Task ICoreAmazonS3.EnsureBucketExistsAsync(string bucketName)
		{
			try
			{
				await PutBucketAsync(bucketName).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (BucketAlreadyOwnedByYouException)
			{
			}
		}

		public AmazonS3Client()
			: base(new AmazonS3Config())
		{
		}

		public AmazonS3Client(RegionEndpoint region)
			: base(new AmazonS3Config
			{
				RegionEndpoint = region
			})
		{
		}

		public AmazonS3Client(AmazonS3Config config)
			: base(config)
		{
		}

		public AmazonS3Client(AWSCredentials credentials)
			: this(credentials, new AmazonS3Config())
		{
		}

		public AmazonS3Client(AWSCredentials credentials, RegionEndpoint region)
			: this(credentials, new AmazonS3Config
			{
				RegionEndpoint = region
			})
		{
		}

		public AmazonS3Client(AWSCredentials credentials, AmazonS3Config clientConfig)
			: base(credentials, clientConfig)
		{
		}

		public AmazonS3Client(string awsAccessKeyId, string awsSecretAccessKey)
			: this(awsAccessKeyId, awsSecretAccessKey, new AmazonS3Config())
		{
		}

		public AmazonS3Client(string awsAccessKeyId, string awsSecretAccessKey, RegionEndpoint region)
			: this(awsAccessKeyId, awsSecretAccessKey, new AmazonS3Config
			{
				RegionEndpoint = region
			})
		{
		}

		public AmazonS3Client(string awsAccessKeyId, string awsSecretAccessKey, AmazonS3Config clientConfig)
			: base(awsAccessKeyId, awsSecretAccessKey, clientConfig)
		{
		}

		public AmazonS3Client(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken)
			: this(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, new AmazonS3Config())
		{
		}

		public AmazonS3Client(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, RegionEndpoint region)
			: this(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, new AmazonS3Config
			{
				RegionEndpoint = region
			})
		{
		}

		public AmazonS3Client(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, AmazonS3Config clientConfig)
			: base(awsAccessKeyId, awsSecretAccessKey, awsSessionToken, clientConfig)
		{
		}

		protected override void CustomizeRuntimePipeline(RuntimePipeline pipeline)
		{
			pipeline.AddHandlerBefore<Marshaller>(new AmazonS3PreMarshallHandler());
			pipeline.AddHandlerAfter<EndpointResolver>(new AmazonS3KmsHandler());
			pipeline.AddHandlerBefore<Unmarshaller>(new AmazonS3ResponseHandler());
			pipeline.AddHandlerAfter<ErrorCallbackHandler>(new AmazonS3ExceptionHandler());
			pipeline.AddHandlerAfter<Unmarshaller>(new AmazonS3RedirectHandler());
			pipeline.AddHandlerBefore<Signer>(new S3ExpressPreSigner());
			pipeline.AddHandlerAfter<EndpointResolver>(new AmazonS3PostMarshallHandler());
			if (base.Config.RetryMode == RequestRetryMode.Standard)
			{
				pipeline.ReplaceHandler<RetryHandler>(new RetryHandler(new AmazonS3StandardRetryPolicy(base.Config)));
			}
			if (base.Config.RetryMode == RequestRetryMode.Adaptive)
			{
				pipeline.ReplaceHandler<RetryHandler>(new RetryHandler(new AmazonS3AdaptiveRetryPolicy(base.Config)));
			}
			pipeline.RemoveHandler<EndpointResolver>();
			pipeline.AddHandlerAfter<Marshaller>(new AmazonS3EndpointResolver());
			pipeline.AddHandlerAfter<Marshaller>(new AmazonS3AuthSchemeHandler());
		}

		protected override void Dispose(bool disposing)
		{
			if (base.Config is AmazonS3Config { S3ExpressCredentialProvider: not null } amazonS3Config)
			{
				amazonS3Config.S3ExpressCredentialProvider.Dispose();
			}
			base.Dispose(disposing);
		}

		internal virtual AbortMultipartUploadResponse AbortMultipartUpload(AbortMultipartUploadRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = AbortMultipartUploadRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = AbortMultipartUploadResponseUnmarshaller.Instance;
			return Invoke<AbortMultipartUploadResponse>(request, invokeOptions);
		}

		public virtual Task<AbortMultipartUploadResponse> AbortMultipartUploadAsync(string bucketName, string key, string uploadId, CancellationToken cancellationToken = default(CancellationToken))
		{
			AbortMultipartUploadRequest abortMultipartUploadRequest = new AbortMultipartUploadRequest();
			abortMultipartUploadRequest.BucketName = bucketName;
			abortMultipartUploadRequest.Key = key;
			abortMultipartUploadRequest.UploadId = uploadId;
			return AbortMultipartUploadAsync(abortMultipartUploadRequest, cancellationToken);
		}

		public virtual Task<AbortMultipartUploadResponse> AbortMultipartUploadAsync(AbortMultipartUploadRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = AbortMultipartUploadRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = AbortMultipartUploadResponseUnmarshaller.Instance;
			return InvokeAsync<AbortMultipartUploadResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual CompleteMultipartUploadResponse CompleteMultipartUpload(CompleteMultipartUploadRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = CompleteMultipartUploadRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = CompleteMultipartUploadResponseUnmarshaller.Instance;
			return Invoke<CompleteMultipartUploadResponse>(request, invokeOptions);
		}

		public virtual Task<CompleteMultipartUploadResponse> CompleteMultipartUploadAsync(CompleteMultipartUploadRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = CompleteMultipartUploadRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = CompleteMultipartUploadResponseUnmarshaller.Instance;
			return InvokeAsync<CompleteMultipartUploadResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual CopyObjectResponse CopyObject(CopyObjectRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = CopyObjectRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = CopyObjectResponseUnmarshaller.Instance;
			return Invoke<CopyObjectResponse>(request, invokeOptions);
		}

		public virtual Task<CopyObjectResponse> CopyObjectAsync(string sourceBucket, string sourceKey, string destinationBucket, string destinationKey, CancellationToken cancellationToken = default(CancellationToken))
		{
			CopyObjectRequest copyObjectRequest = new CopyObjectRequest();
			copyObjectRequest.SourceBucket = sourceBucket;
			copyObjectRequest.SourceKey = sourceKey;
			copyObjectRequest.DestinationBucket = destinationBucket;
			copyObjectRequest.DestinationKey = destinationKey;
			return CopyObjectAsync(copyObjectRequest, cancellationToken);
		}

		public virtual Task<CopyObjectResponse> CopyObjectAsync(string sourceBucket, string sourceKey, string sourceVersionId, string destinationBucket, string destinationKey, CancellationToken cancellationToken = default(CancellationToken))
		{
			CopyObjectRequest copyObjectRequest = new CopyObjectRequest();
			copyObjectRequest.SourceBucket = sourceBucket;
			copyObjectRequest.SourceKey = sourceKey;
			copyObjectRequest.SourceVersionId = sourceVersionId;
			copyObjectRequest.DestinationBucket = destinationBucket;
			copyObjectRequest.DestinationKey = destinationKey;
			return CopyObjectAsync(copyObjectRequest, cancellationToken);
		}

		public virtual Task<CopyObjectResponse> CopyObjectAsync(CopyObjectRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = CopyObjectRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = CopyObjectResponseUnmarshaller.Instance;
			return InvokeAsync<CopyObjectResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual CopyPartResponse CopyPart(CopyPartRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = CopyPartRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = CopyPartResponseUnmarshaller.Instance;
			return Invoke<CopyPartResponse>(request, invokeOptions);
		}

		public virtual Task<CopyPartResponse> CopyPartAsync(string sourceBucket, string sourceKey, string destinationBucket, string destinationKey, string uploadId, int? partNumber, CancellationToken cancellationToken = default(CancellationToken))
		{
			CopyPartRequest copyPartRequest = new CopyPartRequest();
			copyPartRequest.SourceBucket = sourceBucket;
			copyPartRequest.SourceKey = sourceKey;
			copyPartRequest.DestinationBucket = destinationBucket;
			copyPartRequest.DestinationKey = destinationKey;
			copyPartRequest.UploadId = uploadId;
			copyPartRequest.PartNumber = partNumber;
			return CopyPartAsync(copyPartRequest, cancellationToken);
		}

		public virtual Task<CopyPartResponse> CopyPartAsync(string sourceBucket, string sourceKey, string sourceVersionId, string destinationBucket, string destinationKey, string uploadId, int? partNumber, CancellationToken cancellationToken = default(CancellationToken))
		{
			CopyPartRequest copyPartRequest = new CopyPartRequest();
			copyPartRequest.SourceBucket = sourceBucket;
			copyPartRequest.SourceKey = sourceKey;
			copyPartRequest.SourceVersionId = sourceVersionId;
			copyPartRequest.DestinationBucket = destinationBucket;
			copyPartRequest.DestinationKey = destinationKey;
			copyPartRequest.UploadId = uploadId;
			copyPartRequest.PartNumber = partNumber;
			return CopyPartAsync(copyPartRequest, cancellationToken);
		}

		public virtual Task<CopyPartResponse> CopyPartAsync(CopyPartRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = CopyPartRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = CopyPartResponseUnmarshaller.Instance;
			return InvokeAsync<CopyPartResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual CreateBucketMetadataTableConfigurationResponse CreateBucketMetadataTableConfiguration(CreateBucketMetadataTableConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = CreateBucketMetadataTableConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = CreateBucketMetadataTableConfigurationResponseUnmarshaller.Instance;
			return Invoke<CreateBucketMetadataTableConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<CreateBucketMetadataTableConfigurationResponse> CreateBucketMetadataTableConfigurationAsync(CreateBucketMetadataTableConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = CreateBucketMetadataTableConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = CreateBucketMetadataTableConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<CreateBucketMetadataTableConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual CreateSessionResponse CreateSession(CreateSessionRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = CreateSessionRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = CreateSessionResponseUnmarshaller.Instance;
			return Invoke<CreateSessionResponse>(request, invokeOptions);
		}

		public virtual Task<CreateSessionResponse> CreateSessionAsync(CreateSessionRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = CreateSessionRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = CreateSessionResponseUnmarshaller.Instance;
			return InvokeAsync<CreateSessionResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual DeleteBucketResponse DeleteBucket(DeleteBucketRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketResponseUnmarshaller.Instance;
			return Invoke<DeleteBucketResponse>(request, invokeOptions);
		}

		public virtual Task<DeleteBucketResponse> DeleteBucketAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			DeleteBucketRequest deleteBucketRequest = new DeleteBucketRequest();
			deleteBucketRequest.BucketName = bucketName;
			return DeleteBucketAsync(deleteBucketRequest, cancellationToken);
		}

		public virtual Task<DeleteBucketResponse> DeleteBucketAsync(DeleteBucketRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketResponseUnmarshaller.Instance;
			return InvokeAsync<DeleteBucketResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual DeleteBucketAnalyticsConfigurationResponse DeleteBucketAnalyticsConfiguration(DeleteBucketAnalyticsConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketAnalyticsConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketAnalyticsConfigurationResponseUnmarshaller.Instance;
			return Invoke<DeleteBucketAnalyticsConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<DeleteBucketAnalyticsConfigurationResponse> DeleteBucketAnalyticsConfigurationAsync(DeleteBucketAnalyticsConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketAnalyticsConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketAnalyticsConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<DeleteBucketAnalyticsConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual DeleteBucketEncryptionResponse DeleteBucketEncryption(DeleteBucketEncryptionRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketEncryptionRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketEncryptionResponseUnmarshaller.Instance;
			return Invoke<DeleteBucketEncryptionResponse>(request, invokeOptions);
		}

		public virtual Task<DeleteBucketEncryptionResponse> DeleteBucketEncryptionAsync(DeleteBucketEncryptionRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketEncryptionRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketEncryptionResponseUnmarshaller.Instance;
			return InvokeAsync<DeleteBucketEncryptionResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual DeleteBucketIntelligentTieringConfigurationResponse DeleteBucketIntelligentTieringConfiguration(DeleteBucketIntelligentTieringConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketIntelligentTieringConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketIntelligentTieringConfigurationResponseUnmarshaller.Instance;
			return Invoke<DeleteBucketIntelligentTieringConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<DeleteBucketIntelligentTieringConfigurationResponse> DeleteBucketIntelligentTieringConfigurationAsync(DeleteBucketIntelligentTieringConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketIntelligentTieringConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketIntelligentTieringConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<DeleteBucketIntelligentTieringConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual DeleteBucketInventoryConfigurationResponse DeleteBucketInventoryConfiguration(DeleteBucketInventoryConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketInventoryConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketInventoryConfigurationResponseUnmarshaller.Instance;
			return Invoke<DeleteBucketInventoryConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<DeleteBucketInventoryConfigurationResponse> DeleteBucketInventoryConfigurationAsync(DeleteBucketInventoryConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketInventoryConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketInventoryConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<DeleteBucketInventoryConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual DeleteBucketMetadataTableConfigurationResponse DeleteBucketMetadataTableConfiguration(DeleteBucketMetadataTableConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketMetadataTableConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketMetadataTableConfigurationResponseUnmarshaller.Instance;
			return Invoke<DeleteBucketMetadataTableConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<DeleteBucketMetadataTableConfigurationResponse> DeleteBucketMetadataTableConfigurationAsync(DeleteBucketMetadataTableConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketMetadataTableConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketMetadataTableConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<DeleteBucketMetadataTableConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual DeleteBucketMetricsConfigurationResponse DeleteBucketMetricsConfiguration(DeleteBucketMetricsConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketMetricsConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketMetricsConfigurationResponseUnmarshaller.Instance;
			return Invoke<DeleteBucketMetricsConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<DeleteBucketMetricsConfigurationResponse> DeleteBucketMetricsConfigurationAsync(DeleteBucketMetricsConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketMetricsConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketMetricsConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<DeleteBucketMetricsConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual DeleteBucketOwnershipControlsResponse DeleteBucketOwnershipControls(DeleteBucketOwnershipControlsRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketOwnershipControlsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketOwnershipControlsResponseUnmarshaller.Instance;
			return Invoke<DeleteBucketOwnershipControlsResponse>(request, invokeOptions);
		}

		public virtual Task<DeleteBucketOwnershipControlsResponse> DeleteBucketOwnershipControlsAsync(DeleteBucketOwnershipControlsRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketOwnershipControlsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketOwnershipControlsResponseUnmarshaller.Instance;
			return InvokeAsync<DeleteBucketOwnershipControlsResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual DeleteBucketPolicyResponse DeleteBucketPolicy(DeleteBucketPolicyRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketPolicyRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketPolicyResponseUnmarshaller.Instance;
			return Invoke<DeleteBucketPolicyResponse>(request, invokeOptions);
		}

		public virtual Task<DeleteBucketPolicyResponse> DeleteBucketPolicyAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			DeleteBucketPolicyRequest deleteBucketPolicyRequest = new DeleteBucketPolicyRequest();
			deleteBucketPolicyRequest.BucketName = bucketName;
			return DeleteBucketPolicyAsync(deleteBucketPolicyRequest, cancellationToken);
		}

		public virtual Task<DeleteBucketPolicyResponse> DeleteBucketPolicyAsync(DeleteBucketPolicyRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketPolicyRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketPolicyResponseUnmarshaller.Instance;
			return InvokeAsync<DeleteBucketPolicyResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual DeleteBucketReplicationResponse DeleteBucketReplication(DeleteBucketReplicationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketReplicationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketReplicationResponseUnmarshaller.Instance;
			return Invoke<DeleteBucketReplicationResponse>(request, invokeOptions);
		}

		public virtual Task<DeleteBucketReplicationResponse> DeleteBucketReplicationAsync(DeleteBucketReplicationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketReplicationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketReplicationResponseUnmarshaller.Instance;
			return InvokeAsync<DeleteBucketReplicationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual DeleteBucketTaggingResponse DeleteBucketTagging(DeleteBucketTaggingRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketTaggingRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketTaggingResponseUnmarshaller.Instance;
			return Invoke<DeleteBucketTaggingResponse>(request, invokeOptions);
		}

		public virtual Task<DeleteBucketTaggingResponse> DeleteBucketTaggingAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			DeleteBucketTaggingRequest deleteBucketTaggingRequest = new DeleteBucketTaggingRequest();
			deleteBucketTaggingRequest.BucketName = bucketName;
			return DeleteBucketTaggingAsync(deleteBucketTaggingRequest, cancellationToken);
		}

		public virtual Task<DeleteBucketTaggingResponse> DeleteBucketTaggingAsync(DeleteBucketTaggingRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketTaggingRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketTaggingResponseUnmarshaller.Instance;
			return InvokeAsync<DeleteBucketTaggingResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual DeleteBucketWebsiteResponse DeleteBucketWebsite(DeleteBucketWebsiteRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketWebsiteRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketWebsiteResponseUnmarshaller.Instance;
			return Invoke<DeleteBucketWebsiteResponse>(request, invokeOptions);
		}

		public virtual Task<DeleteBucketWebsiteResponse> DeleteBucketWebsiteAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			DeleteBucketWebsiteRequest deleteBucketWebsiteRequest = new DeleteBucketWebsiteRequest();
			deleteBucketWebsiteRequest.BucketName = bucketName;
			return DeleteBucketWebsiteAsync(deleteBucketWebsiteRequest, cancellationToken);
		}

		public virtual Task<DeleteBucketWebsiteResponse> DeleteBucketWebsiteAsync(DeleteBucketWebsiteRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteBucketWebsiteRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteBucketWebsiteResponseUnmarshaller.Instance;
			return InvokeAsync<DeleteBucketWebsiteResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual DeleteCORSConfigurationResponse DeleteCORSConfiguration(DeleteCORSConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteCORSConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteCORSConfigurationResponseUnmarshaller.Instance;
			return Invoke<DeleteCORSConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<DeleteCORSConfigurationResponse> DeleteCORSConfigurationAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			DeleteCORSConfigurationRequest deleteCORSConfigurationRequest = new DeleteCORSConfigurationRequest();
			deleteCORSConfigurationRequest.BucketName = bucketName;
			return DeleteCORSConfigurationAsync(deleteCORSConfigurationRequest, cancellationToken);
		}

		public virtual Task<DeleteCORSConfigurationResponse> DeleteCORSConfigurationAsync(DeleteCORSConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteCORSConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteCORSConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<DeleteCORSConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual DeleteLifecycleConfigurationResponse DeleteLifecycleConfiguration(DeleteLifecycleConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteLifecycleConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteLifecycleConfigurationResponseUnmarshaller.Instance;
			return Invoke<DeleteLifecycleConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<DeleteLifecycleConfigurationResponse> DeleteLifecycleConfigurationAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			DeleteLifecycleConfigurationRequest deleteLifecycleConfigurationRequest = new DeleteLifecycleConfigurationRequest();
			deleteLifecycleConfigurationRequest.BucketName = bucketName;
			return DeleteLifecycleConfigurationAsync(deleteLifecycleConfigurationRequest, cancellationToken);
		}

		public virtual Task<DeleteLifecycleConfigurationResponse> DeleteLifecycleConfigurationAsync(DeleteLifecycleConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteLifecycleConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteLifecycleConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<DeleteLifecycleConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual DeleteObjectResponse DeleteObject(DeleteObjectRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteObjectRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteObjectResponseUnmarshaller.Instance;
			return Invoke<DeleteObjectResponse>(request, invokeOptions);
		}

		public virtual Task<DeleteObjectResponse> DeleteObjectAsync(string bucketName, string key, CancellationToken cancellationToken = default(CancellationToken))
		{
			DeleteObjectRequest deleteObjectRequest = new DeleteObjectRequest();
			deleteObjectRequest.BucketName = bucketName;
			deleteObjectRequest.Key = key;
			return DeleteObjectAsync(deleteObjectRequest, cancellationToken);
		}

		public virtual Task<DeleteObjectResponse> DeleteObjectAsync(string bucketName, string key, string versionId, CancellationToken cancellationToken = default(CancellationToken))
		{
			DeleteObjectRequest deleteObjectRequest = new DeleteObjectRequest();
			deleteObjectRequest.BucketName = bucketName;
			deleteObjectRequest.Key = key;
			deleteObjectRequest.VersionId = versionId;
			return DeleteObjectAsync(deleteObjectRequest, cancellationToken);
		}

		public virtual Task<DeleteObjectResponse> DeleteObjectAsync(DeleteObjectRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteObjectRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteObjectResponseUnmarshaller.Instance;
			return InvokeAsync<DeleteObjectResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual DeleteObjectsResponse DeleteObjects(DeleteObjectsRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteObjectsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteObjectsResponseUnmarshaller.Instance;
			return Invoke<DeleteObjectsResponse>(request, invokeOptions);
		}

		public virtual Task<DeleteObjectsResponse> DeleteObjectsAsync(DeleteObjectsRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteObjectsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteObjectsResponseUnmarshaller.Instance;
			return InvokeAsync<DeleteObjectsResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual DeleteObjectTaggingResponse DeleteObjectTagging(DeleteObjectTaggingRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteObjectTaggingRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteObjectTaggingResponseUnmarshaller.Instance;
			return Invoke<DeleteObjectTaggingResponse>(request, invokeOptions);
		}

		public virtual Task<DeleteObjectTaggingResponse> DeleteObjectTaggingAsync(DeleteObjectTaggingRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeleteObjectTaggingRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeleteObjectTaggingResponseUnmarshaller.Instance;
			return InvokeAsync<DeleteObjectTaggingResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual DeletePublicAccessBlockResponse DeletePublicAccessBlock(DeletePublicAccessBlockRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeletePublicAccessBlockRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeletePublicAccessBlockResponseUnmarshaller.Instance;
			return Invoke<DeletePublicAccessBlockResponse>(request, invokeOptions);
		}

		public virtual Task<DeletePublicAccessBlockResponse> DeletePublicAccessBlockAsync(DeletePublicAccessBlockRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = DeletePublicAccessBlockRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = DeletePublicAccessBlockResponseUnmarshaller.Instance;
			return InvokeAsync<DeletePublicAccessBlockResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetBucketAccelerateConfigurationResponse GetBucketAccelerateConfiguration(GetBucketAccelerateConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketAccelerateConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketAccelerateConfigurationResponseUnmarshaller.Instance;
			return Invoke<GetBucketAccelerateConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<GetBucketAccelerateConfigurationResponse> GetBucketAccelerateConfigurationAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			GetBucketAccelerateConfigurationRequest getBucketAccelerateConfigurationRequest = new GetBucketAccelerateConfigurationRequest();
			getBucketAccelerateConfigurationRequest.BucketName = bucketName;
			return GetBucketAccelerateConfigurationAsync(getBucketAccelerateConfigurationRequest, cancellationToken);
		}

		public virtual Task<GetBucketAccelerateConfigurationResponse> GetBucketAccelerateConfigurationAsync(GetBucketAccelerateConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketAccelerateConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketAccelerateConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<GetBucketAccelerateConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetBucketAclResponse GetBucketAcl(GetBucketAclRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketAclRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketAclResponseUnmarshaller.Instance;
			return Invoke<GetBucketAclResponse>(request, invokeOptions);
		}

		public virtual Task<GetBucketAclResponse> GetBucketAclAsync(GetBucketAclRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketAclRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketAclResponseUnmarshaller.Instance;
			return InvokeAsync<GetBucketAclResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetBucketAnalyticsConfigurationResponse GetBucketAnalyticsConfiguration(GetBucketAnalyticsConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketAnalyticsConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketAnalyticsConfigurationResponseUnmarshaller.Instance;
			return Invoke<GetBucketAnalyticsConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<GetBucketAnalyticsConfigurationResponse> GetBucketAnalyticsConfigurationAsync(GetBucketAnalyticsConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketAnalyticsConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketAnalyticsConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<GetBucketAnalyticsConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetBucketEncryptionResponse GetBucketEncryption(GetBucketEncryptionRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketEncryptionRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketEncryptionResponseUnmarshaller.Instance;
			return Invoke<GetBucketEncryptionResponse>(request, invokeOptions);
		}

		public virtual Task<GetBucketEncryptionResponse> GetBucketEncryptionAsync(GetBucketEncryptionRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketEncryptionRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketEncryptionResponseUnmarshaller.Instance;
			return InvokeAsync<GetBucketEncryptionResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetBucketIntelligentTieringConfigurationResponse GetBucketIntelligentTieringConfiguration(GetBucketIntelligentTieringConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketIntelligentTieringConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketIntelligentTieringConfigurationResponseUnmarshaller.Instance;
			return Invoke<GetBucketIntelligentTieringConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<GetBucketIntelligentTieringConfigurationResponse> GetBucketIntelligentTieringConfigurationAsync(GetBucketIntelligentTieringConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketIntelligentTieringConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketIntelligentTieringConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<GetBucketIntelligentTieringConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetBucketInventoryConfigurationResponse GetBucketInventoryConfiguration(GetBucketInventoryConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketInventoryConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketInventoryConfigurationResponseUnmarshaller.Instance;
			return Invoke<GetBucketInventoryConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<GetBucketInventoryConfigurationResponse> GetBucketInventoryConfigurationAsync(GetBucketInventoryConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketInventoryConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketInventoryConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<GetBucketInventoryConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetBucketLocationResponse GetBucketLocation(GetBucketLocationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketLocationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketLocationResponseUnmarshaller.Instance;
			return Invoke<GetBucketLocationResponse>(request, invokeOptions);
		}

		public virtual Task<GetBucketLocationResponse> GetBucketLocationAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			GetBucketLocationRequest getBucketLocationRequest = new GetBucketLocationRequest();
			getBucketLocationRequest.BucketName = bucketName;
			return GetBucketLocationAsync(getBucketLocationRequest, cancellationToken);
		}

		public virtual Task<GetBucketLocationResponse> GetBucketLocationAsync(GetBucketLocationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketLocationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketLocationResponseUnmarshaller.Instance;
			return InvokeAsync<GetBucketLocationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetBucketLoggingResponse GetBucketLogging(GetBucketLoggingRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketLoggingRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketLoggingResponseUnmarshaller.Instance;
			return Invoke<GetBucketLoggingResponse>(request, invokeOptions);
		}

		public virtual Task<GetBucketLoggingResponse> GetBucketLoggingAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			GetBucketLoggingRequest getBucketLoggingRequest = new GetBucketLoggingRequest();
			getBucketLoggingRequest.BucketName = bucketName;
			return GetBucketLoggingAsync(getBucketLoggingRequest, cancellationToken);
		}

		public virtual Task<GetBucketLoggingResponse> GetBucketLoggingAsync(GetBucketLoggingRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketLoggingRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketLoggingResponseUnmarshaller.Instance;
			return InvokeAsync<GetBucketLoggingResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetBucketMetadataTableConfigurationResponse GetBucketMetadataTableConfiguration(GetBucketMetadataTableConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketMetadataTableConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketMetadataTableConfigurationResponseUnmarshaller.Instance;
			return Invoke<GetBucketMetadataTableConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<GetBucketMetadataTableConfigurationResponse> GetBucketMetadataTableConfigurationAsync(GetBucketMetadataTableConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketMetadataTableConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketMetadataTableConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<GetBucketMetadataTableConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetBucketMetricsConfigurationResponse GetBucketMetricsConfiguration(GetBucketMetricsConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketMetricsConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketMetricsConfigurationResponseUnmarshaller.Instance;
			return Invoke<GetBucketMetricsConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<GetBucketMetricsConfigurationResponse> GetBucketMetricsConfigurationAsync(GetBucketMetricsConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketMetricsConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketMetricsConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<GetBucketMetricsConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetBucketNotificationResponse GetBucketNotification(GetBucketNotificationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketNotificationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketNotificationResponseUnmarshaller.Instance;
			return Invoke<GetBucketNotificationResponse>(request, invokeOptions);
		}

		public virtual Task<GetBucketNotificationResponse> GetBucketNotificationAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			GetBucketNotificationRequest getBucketNotificationRequest = new GetBucketNotificationRequest();
			getBucketNotificationRequest.BucketName = bucketName;
			return GetBucketNotificationAsync(getBucketNotificationRequest, cancellationToken);
		}

		public virtual Task<GetBucketNotificationResponse> GetBucketNotificationAsync(GetBucketNotificationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketNotificationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketNotificationResponseUnmarshaller.Instance;
			return InvokeAsync<GetBucketNotificationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetBucketOwnershipControlsResponse GetBucketOwnershipControls(GetBucketOwnershipControlsRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketOwnershipControlsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketOwnershipControlsResponseUnmarshaller.Instance;
			return Invoke<GetBucketOwnershipControlsResponse>(request, invokeOptions);
		}

		public virtual Task<GetBucketOwnershipControlsResponse> GetBucketOwnershipControlsAsync(GetBucketOwnershipControlsRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketOwnershipControlsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketOwnershipControlsResponseUnmarshaller.Instance;
			return InvokeAsync<GetBucketOwnershipControlsResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetBucketPolicyResponse GetBucketPolicy(GetBucketPolicyRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketPolicyRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketPolicyResponseUnmarshaller.Instance;
			return Invoke<GetBucketPolicyResponse>(request, invokeOptions);
		}

		public virtual Task<GetBucketPolicyResponse> GetBucketPolicyAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			GetBucketPolicyRequest getBucketPolicyRequest = new GetBucketPolicyRequest();
			getBucketPolicyRequest.BucketName = bucketName;
			return GetBucketPolicyAsync(getBucketPolicyRequest, cancellationToken);
		}

		public virtual Task<GetBucketPolicyResponse> GetBucketPolicyAsync(GetBucketPolicyRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketPolicyRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketPolicyResponseUnmarshaller.Instance;
			return InvokeAsync<GetBucketPolicyResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetBucketPolicyStatusResponse GetBucketPolicyStatus(GetBucketPolicyStatusRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketPolicyStatusRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketPolicyStatusResponseUnmarshaller.Instance;
			return Invoke<GetBucketPolicyStatusResponse>(request, invokeOptions);
		}

		public virtual Task<GetBucketPolicyStatusResponse> GetBucketPolicyStatusAsync(GetBucketPolicyStatusRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketPolicyStatusRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketPolicyStatusResponseUnmarshaller.Instance;
			return InvokeAsync<GetBucketPolicyStatusResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetBucketReplicationResponse GetBucketReplication(GetBucketReplicationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketReplicationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketReplicationResponseUnmarshaller.Instance;
			return Invoke<GetBucketReplicationResponse>(request, invokeOptions);
		}

		public virtual Task<GetBucketReplicationResponse> GetBucketReplicationAsync(GetBucketReplicationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketReplicationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketReplicationResponseUnmarshaller.Instance;
			return InvokeAsync<GetBucketReplicationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetBucketRequestPaymentResponse GetBucketRequestPayment(GetBucketRequestPaymentRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketRequestPaymentRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketRequestPaymentResponseUnmarshaller.Instance;
			return Invoke<GetBucketRequestPaymentResponse>(request, invokeOptions);
		}

		public virtual Task<GetBucketRequestPaymentResponse> GetBucketRequestPaymentAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			GetBucketRequestPaymentRequest getBucketRequestPaymentRequest = new GetBucketRequestPaymentRequest();
			getBucketRequestPaymentRequest.BucketName = bucketName;
			return GetBucketRequestPaymentAsync(getBucketRequestPaymentRequest, cancellationToken);
		}

		public virtual Task<GetBucketRequestPaymentResponse> GetBucketRequestPaymentAsync(GetBucketRequestPaymentRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketRequestPaymentRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketRequestPaymentResponseUnmarshaller.Instance;
			return InvokeAsync<GetBucketRequestPaymentResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetBucketTaggingResponse GetBucketTagging(GetBucketTaggingRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketTaggingRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketTaggingResponseUnmarshaller.Instance;
			return Invoke<GetBucketTaggingResponse>(request, invokeOptions);
		}

		public virtual Task<GetBucketTaggingResponse> GetBucketTaggingAsync(GetBucketTaggingRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketTaggingRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketTaggingResponseUnmarshaller.Instance;
			return InvokeAsync<GetBucketTaggingResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetBucketVersioningResponse GetBucketVersioning(GetBucketVersioningRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketVersioningRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketVersioningResponseUnmarshaller.Instance;
			return Invoke<GetBucketVersioningResponse>(request, invokeOptions);
		}

		public virtual Task<GetBucketVersioningResponse> GetBucketVersioningAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			GetBucketVersioningRequest getBucketVersioningRequest = new GetBucketVersioningRequest();
			getBucketVersioningRequest.BucketName = bucketName;
			return GetBucketVersioningAsync(getBucketVersioningRequest, cancellationToken);
		}

		public virtual Task<GetBucketVersioningResponse> GetBucketVersioningAsync(GetBucketVersioningRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketVersioningRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketVersioningResponseUnmarshaller.Instance;
			return InvokeAsync<GetBucketVersioningResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetBucketWebsiteResponse GetBucketWebsite(GetBucketWebsiteRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketWebsiteRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketWebsiteResponseUnmarshaller.Instance;
			return Invoke<GetBucketWebsiteResponse>(request, invokeOptions);
		}

		public virtual Task<GetBucketWebsiteResponse> GetBucketWebsiteAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			GetBucketWebsiteRequest getBucketWebsiteRequest = new GetBucketWebsiteRequest();
			getBucketWebsiteRequest.BucketName = bucketName;
			return GetBucketWebsiteAsync(getBucketWebsiteRequest, cancellationToken);
		}

		public virtual Task<GetBucketWebsiteResponse> GetBucketWebsiteAsync(GetBucketWebsiteRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetBucketWebsiteRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetBucketWebsiteResponseUnmarshaller.Instance;
			return InvokeAsync<GetBucketWebsiteResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetCORSConfigurationResponse GetCORSConfiguration(GetCORSConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetCORSConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetCORSConfigurationResponseUnmarshaller.Instance;
			return Invoke<GetCORSConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<GetCORSConfigurationResponse> GetCORSConfigurationAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			GetCORSConfigurationRequest getCORSConfigurationRequest = new GetCORSConfigurationRequest();
			getCORSConfigurationRequest.BucketName = bucketName;
			return GetCORSConfigurationAsync(getCORSConfigurationRequest, cancellationToken);
		}

		public virtual Task<GetCORSConfigurationResponse> GetCORSConfigurationAsync(GetCORSConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetCORSConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetCORSConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<GetCORSConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetLifecycleConfigurationResponse GetLifecycleConfiguration(GetLifecycleConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetLifecycleConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetLifecycleConfigurationResponseUnmarshaller.Instance;
			return Invoke<GetLifecycleConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<GetLifecycleConfigurationResponse> GetLifecycleConfigurationAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			GetLifecycleConfigurationRequest getLifecycleConfigurationRequest = new GetLifecycleConfigurationRequest();
			getLifecycleConfigurationRequest.BucketName = bucketName;
			return GetLifecycleConfigurationAsync(getLifecycleConfigurationRequest, cancellationToken);
		}

		public virtual Task<GetLifecycleConfigurationResponse> GetLifecycleConfigurationAsync(GetLifecycleConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetLifecycleConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetLifecycleConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<GetLifecycleConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetObjectResponse GetObject(GetObjectRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetObjectRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetObjectResponseUnmarshaller.Instance;
			return Invoke<GetObjectResponse>(request, invokeOptions);
		}

		public virtual Task<GetObjectResponse> GetObjectAsync(string bucketName, string key, CancellationToken cancellationToken = default(CancellationToken))
		{
			GetObjectRequest getObjectRequest = new GetObjectRequest();
			getObjectRequest.BucketName = bucketName;
			getObjectRequest.Key = key;
			return GetObjectAsync(getObjectRequest, cancellationToken);
		}

		public virtual Task<GetObjectResponse> GetObjectAsync(string bucketName, string key, string versionId, CancellationToken cancellationToken = default(CancellationToken))
		{
			GetObjectRequest getObjectRequest = new GetObjectRequest();
			getObjectRequest.BucketName = bucketName;
			getObjectRequest.Key = key;
			getObjectRequest.VersionId = versionId;
			return GetObjectAsync(getObjectRequest, cancellationToken);
		}

		public virtual Task<GetObjectResponse> GetObjectAsync(GetObjectRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetObjectRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetObjectResponseUnmarshaller.Instance;
			return InvokeAsync<GetObjectResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetObjectAclResponse GetObjectAcl(GetObjectAclRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetObjectAclRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetObjectAclResponseUnmarshaller.Instance;
			return Invoke<GetObjectAclResponse>(request, invokeOptions);
		}

		public virtual Task<GetObjectAclResponse> GetObjectAclAsync(GetObjectAclRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetObjectAclRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetObjectAclResponseUnmarshaller.Instance;
			return InvokeAsync<GetObjectAclResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetObjectAttributesResponse GetObjectAttributes(GetObjectAttributesRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetObjectAttributesRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetObjectAttributesResponseUnmarshaller.Instance;
			return Invoke<GetObjectAttributesResponse>(request, invokeOptions);
		}

		public virtual Task<GetObjectAttributesResponse> GetObjectAttributesAsync(GetObjectAttributesRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetObjectAttributesRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetObjectAttributesResponseUnmarshaller.Instance;
			return InvokeAsync<GetObjectAttributesResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetObjectLegalHoldResponse GetObjectLegalHold(GetObjectLegalHoldRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetObjectLegalHoldRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetObjectLegalHoldResponseUnmarshaller.Instance;
			return Invoke<GetObjectLegalHoldResponse>(request, invokeOptions);
		}

		public virtual Task<GetObjectLegalHoldResponse> GetObjectLegalHoldAsync(GetObjectLegalHoldRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetObjectLegalHoldRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetObjectLegalHoldResponseUnmarshaller.Instance;
			return InvokeAsync<GetObjectLegalHoldResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetObjectLockConfigurationResponse GetObjectLockConfiguration(GetObjectLockConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetObjectLockConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetObjectLockConfigurationResponseUnmarshaller.Instance;
			return Invoke<GetObjectLockConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<GetObjectLockConfigurationResponse> GetObjectLockConfigurationAsync(GetObjectLockConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetObjectLockConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetObjectLockConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<GetObjectLockConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetObjectMetadataResponse GetObjectMetadata(GetObjectMetadataRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetObjectMetadataRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetObjectMetadataResponseUnmarshaller.Instance;
			return Invoke<GetObjectMetadataResponse>(request, invokeOptions);
		}

		public virtual Task<GetObjectMetadataResponse> GetObjectMetadataAsync(string bucketName, string key, CancellationToken cancellationToken = default(CancellationToken))
		{
			GetObjectMetadataRequest getObjectMetadataRequest = new GetObjectMetadataRequest();
			getObjectMetadataRequest.BucketName = bucketName;
			getObjectMetadataRequest.Key = key;
			return GetObjectMetadataAsync(getObjectMetadataRequest, cancellationToken);
		}

		public virtual Task<GetObjectMetadataResponse> GetObjectMetadataAsync(string bucketName, string key, string versionId, CancellationToken cancellationToken = default(CancellationToken))
		{
			GetObjectMetadataRequest getObjectMetadataRequest = new GetObjectMetadataRequest();
			getObjectMetadataRequest.BucketName = bucketName;
			getObjectMetadataRequest.Key = key;
			getObjectMetadataRequest.VersionId = versionId;
			return GetObjectMetadataAsync(getObjectMetadataRequest, cancellationToken);
		}

		public virtual Task<GetObjectMetadataResponse> GetObjectMetadataAsync(GetObjectMetadataRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetObjectMetadataRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetObjectMetadataResponseUnmarshaller.Instance;
			return InvokeAsync<GetObjectMetadataResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetObjectRetentionResponse GetObjectRetention(GetObjectRetentionRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetObjectRetentionRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetObjectRetentionResponseUnmarshaller.Instance;
			return Invoke<GetObjectRetentionResponse>(request, invokeOptions);
		}

		public virtual Task<GetObjectRetentionResponse> GetObjectRetentionAsync(GetObjectRetentionRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetObjectRetentionRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetObjectRetentionResponseUnmarshaller.Instance;
			return InvokeAsync<GetObjectRetentionResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetObjectTaggingResponse GetObjectTagging(GetObjectTaggingRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetObjectTaggingRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetObjectTaggingResponseUnmarshaller.Instance;
			return Invoke<GetObjectTaggingResponse>(request, invokeOptions);
		}

		public virtual Task<GetObjectTaggingResponse> GetObjectTaggingAsync(GetObjectTaggingRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetObjectTaggingRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetObjectTaggingResponseUnmarshaller.Instance;
			return InvokeAsync<GetObjectTaggingResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetObjectTorrentResponse GetObjectTorrent(GetObjectTorrentRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetObjectTorrentRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetObjectTorrentResponseUnmarshaller.Instance;
			return Invoke<GetObjectTorrentResponse>(request, invokeOptions);
		}

		public virtual Task<GetObjectTorrentResponse> GetObjectTorrentAsync(string bucketName, string key, CancellationToken cancellationToken = default(CancellationToken))
		{
			GetObjectTorrentRequest getObjectTorrentRequest = new GetObjectTorrentRequest();
			getObjectTorrentRequest.BucketName = bucketName;
			getObjectTorrentRequest.Key = key;
			return GetObjectTorrentAsync(getObjectTorrentRequest, cancellationToken);
		}

		public virtual Task<GetObjectTorrentResponse> GetObjectTorrentAsync(GetObjectTorrentRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetObjectTorrentRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetObjectTorrentResponseUnmarshaller.Instance;
			return InvokeAsync<GetObjectTorrentResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual GetPublicAccessBlockResponse GetPublicAccessBlock(GetPublicAccessBlockRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetPublicAccessBlockRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetPublicAccessBlockResponseUnmarshaller.Instance;
			return Invoke<GetPublicAccessBlockResponse>(request, invokeOptions);
		}

		public virtual Task<GetPublicAccessBlockResponse> GetPublicAccessBlockAsync(GetPublicAccessBlockRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = GetPublicAccessBlockRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = GetPublicAccessBlockResponseUnmarshaller.Instance;
			return InvokeAsync<GetPublicAccessBlockResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual HeadBucketResponse HeadBucket(HeadBucketRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = HeadBucketRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = HeadBucketResponseUnmarshaller.Instance;
			return Invoke<HeadBucketResponse>(request, invokeOptions);
		}

		public virtual Task<HeadBucketResponse> HeadBucketAsync(HeadBucketRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = HeadBucketRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = HeadBucketResponseUnmarshaller.Instance;
			return InvokeAsync<HeadBucketResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual InitiateMultipartUploadResponse InitiateMultipartUpload(InitiateMultipartUploadRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = InitiateMultipartUploadRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = InitiateMultipartUploadResponseUnmarshaller.Instance;
			return Invoke<InitiateMultipartUploadResponse>(request, invokeOptions);
		}

		public virtual Task<InitiateMultipartUploadResponse> InitiateMultipartUploadAsync(string bucketName, string key, CancellationToken cancellationToken = default(CancellationToken))
		{
			InitiateMultipartUploadRequest initiateMultipartUploadRequest = new InitiateMultipartUploadRequest();
			initiateMultipartUploadRequest.BucketName = bucketName;
			initiateMultipartUploadRequest.Key = key;
			return InitiateMultipartUploadAsync(initiateMultipartUploadRequest, cancellationToken);
		}

		public virtual Task<InitiateMultipartUploadResponse> InitiateMultipartUploadAsync(InitiateMultipartUploadRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = InitiateMultipartUploadRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = InitiateMultipartUploadResponseUnmarshaller.Instance;
			return InvokeAsync<InitiateMultipartUploadResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual ListBucketAnalyticsConfigurationsResponse ListBucketAnalyticsConfigurations(ListBucketAnalyticsConfigurationsRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = ListBucketAnalyticsConfigurationsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = ListBucketAnalyticsConfigurationsResponseUnmarshaller.Instance;
			return Invoke<ListBucketAnalyticsConfigurationsResponse>(request, invokeOptions);
		}

		public virtual Task<ListBucketAnalyticsConfigurationsResponse> ListBucketAnalyticsConfigurationsAsync(ListBucketAnalyticsConfigurationsRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = ListBucketAnalyticsConfigurationsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = ListBucketAnalyticsConfigurationsResponseUnmarshaller.Instance;
			return InvokeAsync<ListBucketAnalyticsConfigurationsResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual ListBucketIntelligentTieringConfigurationsResponse ListBucketIntelligentTieringConfigurations(ListBucketIntelligentTieringConfigurationsRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = ListBucketIntelligentTieringConfigurationsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = ListBucketIntelligentTieringConfigurationsResponseUnmarshaller.Instance;
			return Invoke<ListBucketIntelligentTieringConfigurationsResponse>(request, invokeOptions);
		}

		public virtual Task<ListBucketIntelligentTieringConfigurationsResponse> ListBucketIntelligentTieringConfigurationsAsync(ListBucketIntelligentTieringConfigurationsRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = ListBucketIntelligentTieringConfigurationsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = ListBucketIntelligentTieringConfigurationsResponseUnmarshaller.Instance;
			return InvokeAsync<ListBucketIntelligentTieringConfigurationsResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual ListBucketInventoryConfigurationsResponse ListBucketInventoryConfigurations(ListBucketInventoryConfigurationsRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = ListBucketInventoryConfigurationsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = ListBucketInventoryConfigurationsResponseUnmarshaller.Instance;
			return Invoke<ListBucketInventoryConfigurationsResponse>(request, invokeOptions);
		}

		public virtual Task<ListBucketInventoryConfigurationsResponse> ListBucketInventoryConfigurationsAsync(ListBucketInventoryConfigurationsRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = ListBucketInventoryConfigurationsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = ListBucketInventoryConfigurationsResponseUnmarshaller.Instance;
			return InvokeAsync<ListBucketInventoryConfigurationsResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual ListBucketMetricsConfigurationsResponse ListBucketMetricsConfigurations(ListBucketMetricsConfigurationsRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = ListBucketMetricsConfigurationsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = ListBucketMetricsConfigurationsResponseUnmarshaller.Instance;
			return Invoke<ListBucketMetricsConfigurationsResponse>(request, invokeOptions);
		}

		public virtual Task<ListBucketMetricsConfigurationsResponse> ListBucketMetricsConfigurationsAsync(ListBucketMetricsConfigurationsRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = ListBucketMetricsConfigurationsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = ListBucketMetricsConfigurationsResponseUnmarshaller.Instance;
			return InvokeAsync<ListBucketMetricsConfigurationsResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual ListBucketsResponse ListBuckets()
		{
			return ListBuckets(new ListBucketsRequest());
		}

		internal virtual ListBucketsResponse ListBuckets(ListBucketsRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = ListBucketsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = ListBucketsResponseUnmarshaller.Instance;
			return Invoke<ListBucketsResponse>(request, invokeOptions);
		}

		public virtual Task<ListBucketsResponse> ListBucketsAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			return ListBucketsAsync(new ListBucketsRequest(), cancellationToken);
		}

		public virtual Task<ListBucketsResponse> ListBucketsAsync(ListBucketsRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = ListBucketsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = ListBucketsResponseUnmarshaller.Instance;
			return InvokeAsync<ListBucketsResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual ListDirectoryBucketsResponse ListDirectoryBuckets(ListDirectoryBucketsRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = ListDirectoryBucketsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = ListDirectoryBucketsResponseUnmarshaller.Instance;
			return Invoke<ListDirectoryBucketsResponse>(request, invokeOptions);
		}

		public virtual Task<ListDirectoryBucketsResponse> ListDirectoryBucketsAsync(ListDirectoryBucketsRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = ListDirectoryBucketsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = ListDirectoryBucketsResponseUnmarshaller.Instance;
			return InvokeAsync<ListDirectoryBucketsResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual ListMultipartUploadsResponse ListMultipartUploads(ListMultipartUploadsRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = ListMultipartUploadsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = ListMultipartUploadsResponseUnmarshaller.Instance;
			return Invoke<ListMultipartUploadsResponse>(request, invokeOptions);
		}

		public virtual Task<ListMultipartUploadsResponse> ListMultipartUploadsAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			ListMultipartUploadsRequest listMultipartUploadsRequest = new ListMultipartUploadsRequest();
			listMultipartUploadsRequest.BucketName = bucketName;
			return ListMultipartUploadsAsync(listMultipartUploadsRequest, cancellationToken);
		}

		public virtual Task<ListMultipartUploadsResponse> ListMultipartUploadsAsync(string bucketName, string prefix, CancellationToken cancellationToken = default(CancellationToken))
		{
			ListMultipartUploadsRequest listMultipartUploadsRequest = new ListMultipartUploadsRequest();
			listMultipartUploadsRequest.BucketName = bucketName;
			listMultipartUploadsRequest.Prefix = prefix;
			return ListMultipartUploadsAsync(listMultipartUploadsRequest, cancellationToken);
		}

		public virtual Task<ListMultipartUploadsResponse> ListMultipartUploadsAsync(ListMultipartUploadsRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = ListMultipartUploadsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = ListMultipartUploadsResponseUnmarshaller.Instance;
			return InvokeAsync<ListMultipartUploadsResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual ListObjectsResponse ListObjects(ListObjectsRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = ListObjectsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = ListObjectsResponseUnmarshaller.Instance;
			return Invoke<ListObjectsResponse>(request, invokeOptions);
		}

		public virtual Task<ListObjectsResponse> ListObjectsAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			ListObjectsRequest listObjectsRequest = new ListObjectsRequest();
			listObjectsRequest.BucketName = bucketName;
			return ListObjectsAsync(listObjectsRequest, cancellationToken);
		}

		public virtual Task<ListObjectsResponse> ListObjectsAsync(string bucketName, string prefix, CancellationToken cancellationToken = default(CancellationToken))
		{
			ListObjectsRequest listObjectsRequest = new ListObjectsRequest();
			listObjectsRequest.BucketName = bucketName;
			listObjectsRequest.Prefix = prefix;
			return ListObjectsAsync(listObjectsRequest, cancellationToken);
		}

		public virtual Task<ListObjectsResponse> ListObjectsAsync(ListObjectsRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = ListObjectsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = ListObjectsResponseUnmarshaller.Instance;
			return InvokeAsync<ListObjectsResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual ListObjectsV2Response ListObjectsV2(ListObjectsV2Request request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = ListObjectsV2RequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = ListObjectsV2ResponseUnmarshaller.Instance;
			return Invoke<ListObjectsV2Response>(request, invokeOptions);
		}

		public virtual Task<ListObjectsV2Response> ListObjectsV2Async(ListObjectsV2Request request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = ListObjectsV2RequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = ListObjectsV2ResponseUnmarshaller.Instance;
			return InvokeAsync<ListObjectsV2Response>(request, invokeOptions, cancellationToken);
		}

		internal virtual ListPartsResponse ListParts(ListPartsRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = ListPartsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = ListPartsResponseUnmarshaller.Instance;
			return Invoke<ListPartsResponse>(request, invokeOptions);
		}

		public virtual Task<ListPartsResponse> ListPartsAsync(string bucketName, string key, string uploadId, CancellationToken cancellationToken = default(CancellationToken))
		{
			ListPartsRequest listPartsRequest = new ListPartsRequest();
			listPartsRequest.BucketName = bucketName;
			listPartsRequest.Key = key;
			listPartsRequest.UploadId = uploadId;
			return ListPartsAsync(listPartsRequest, cancellationToken);
		}

		public virtual Task<ListPartsResponse> ListPartsAsync(ListPartsRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = ListPartsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = ListPartsResponseUnmarshaller.Instance;
			return InvokeAsync<ListPartsResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual ListVersionsResponse ListVersions(ListVersionsRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = ListVersionsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = ListVersionsResponseUnmarshaller.Instance;
			return Invoke<ListVersionsResponse>(request, invokeOptions);
		}

		public virtual Task<ListVersionsResponse> ListVersionsAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			ListVersionsRequest listVersionsRequest = new ListVersionsRequest();
			listVersionsRequest.BucketName = bucketName;
			return ListVersionsAsync(listVersionsRequest, cancellationToken);
		}

		public virtual Task<ListVersionsResponse> ListVersionsAsync(string bucketName, string prefix, CancellationToken cancellationToken = default(CancellationToken))
		{
			ListVersionsRequest listVersionsRequest = new ListVersionsRequest();
			listVersionsRequest.BucketName = bucketName;
			listVersionsRequest.Prefix = prefix;
			return ListVersionsAsync(listVersionsRequest, cancellationToken);
		}

		public virtual Task<ListVersionsResponse> ListVersionsAsync(ListVersionsRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = ListVersionsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = ListVersionsResponseUnmarshaller.Instance;
			return InvokeAsync<ListVersionsResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutBucketResponse PutBucket(PutBucketRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketResponseUnmarshaller.Instance;
			return Invoke<PutBucketResponse>(request, invokeOptions);
		}

		public virtual Task<PutBucketResponse> PutBucketAsync(string bucketName, CancellationToken cancellationToken = default(CancellationToken))
		{
			PutBucketRequest putBucketRequest = new PutBucketRequest();
			putBucketRequest.BucketName = bucketName;
			return PutBucketAsync(putBucketRequest, cancellationToken);
		}

		public virtual Task<PutBucketResponse> PutBucketAsync(PutBucketRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketResponseUnmarshaller.Instance;
			return InvokeAsync<PutBucketResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutBucketAccelerateConfigurationResponse PutBucketAccelerateConfiguration(PutBucketAccelerateConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketAccelerateConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketAccelerateConfigurationResponseUnmarshaller.Instance;
			return Invoke<PutBucketAccelerateConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<PutBucketAccelerateConfigurationResponse> PutBucketAccelerateConfigurationAsync(PutBucketAccelerateConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketAccelerateConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketAccelerateConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<PutBucketAccelerateConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutBucketAclResponse PutBucketAcl(PutBucketAclRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketAclRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketAclResponseUnmarshaller.Instance;
			return Invoke<PutBucketAclResponse>(request, invokeOptions);
		}

		public virtual Task<PutBucketAclResponse> PutBucketAclAsync(PutBucketAclRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketAclRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketAclResponseUnmarshaller.Instance;
			return InvokeAsync<PutBucketAclResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutBucketAnalyticsConfigurationResponse PutBucketAnalyticsConfiguration(PutBucketAnalyticsConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketAnalyticsConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketAnalyticsConfigurationResponseUnmarshaller.Instance;
			return Invoke<PutBucketAnalyticsConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<PutBucketAnalyticsConfigurationResponse> PutBucketAnalyticsConfigurationAsync(PutBucketAnalyticsConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketAnalyticsConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketAnalyticsConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<PutBucketAnalyticsConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutBucketEncryptionResponse PutBucketEncryption(PutBucketEncryptionRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketEncryptionRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketEncryptionResponseUnmarshaller.Instance;
			return Invoke<PutBucketEncryptionResponse>(request, invokeOptions);
		}

		public virtual Task<PutBucketEncryptionResponse> PutBucketEncryptionAsync(PutBucketEncryptionRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketEncryptionRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketEncryptionResponseUnmarshaller.Instance;
			return InvokeAsync<PutBucketEncryptionResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutBucketIntelligentTieringConfigurationResponse PutBucketIntelligentTieringConfiguration(PutBucketIntelligentTieringConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketIntelligentTieringConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketIntelligentTieringConfigurationResponseUnmarshaller.Instance;
			return Invoke<PutBucketIntelligentTieringConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<PutBucketIntelligentTieringConfigurationResponse> PutBucketIntelligentTieringConfigurationAsync(PutBucketIntelligentTieringConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketIntelligentTieringConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketIntelligentTieringConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<PutBucketIntelligentTieringConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutBucketInventoryConfigurationResponse PutBucketInventoryConfiguration(PutBucketInventoryConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketInventoryConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketInventoryConfigurationResponseUnmarshaller.Instance;
			return Invoke<PutBucketInventoryConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<PutBucketInventoryConfigurationResponse> PutBucketInventoryConfigurationAsync(PutBucketInventoryConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketInventoryConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketInventoryConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<PutBucketInventoryConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutBucketLoggingResponse PutBucketLogging(PutBucketLoggingRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketLoggingRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketLoggingResponseUnmarshaller.Instance;
			return Invoke<PutBucketLoggingResponse>(request, invokeOptions);
		}

		public virtual Task<PutBucketLoggingResponse> PutBucketLoggingAsync(PutBucketLoggingRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketLoggingRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketLoggingResponseUnmarshaller.Instance;
			return InvokeAsync<PutBucketLoggingResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutBucketMetricsConfigurationResponse PutBucketMetricsConfiguration(PutBucketMetricsConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketMetricsConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketMetricsConfigurationResponseUnmarshaller.Instance;
			return Invoke<PutBucketMetricsConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<PutBucketMetricsConfigurationResponse> PutBucketMetricsConfigurationAsync(PutBucketMetricsConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketMetricsConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketMetricsConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<PutBucketMetricsConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutBucketNotificationResponse PutBucketNotification(PutBucketNotificationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketNotificationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketNotificationResponseUnmarshaller.Instance;
			return Invoke<PutBucketNotificationResponse>(request, invokeOptions);
		}

		public virtual Task<PutBucketNotificationResponse> PutBucketNotificationAsync(PutBucketNotificationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketNotificationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketNotificationResponseUnmarshaller.Instance;
			return InvokeAsync<PutBucketNotificationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutBucketOwnershipControlsResponse PutBucketOwnershipControls(PutBucketOwnershipControlsRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketOwnershipControlsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketOwnershipControlsResponseUnmarshaller.Instance;
			return Invoke<PutBucketOwnershipControlsResponse>(request, invokeOptions);
		}

		public virtual Task<PutBucketOwnershipControlsResponse> PutBucketOwnershipControlsAsync(PutBucketOwnershipControlsRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketOwnershipControlsRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketOwnershipControlsResponseUnmarshaller.Instance;
			return InvokeAsync<PutBucketOwnershipControlsResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutBucketPolicyResponse PutBucketPolicy(PutBucketPolicyRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketPolicyRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketPolicyResponseUnmarshaller.Instance;
			return Invoke<PutBucketPolicyResponse>(request, invokeOptions);
		}

		public virtual Task<PutBucketPolicyResponse> PutBucketPolicyAsync(string bucketName, string policy, CancellationToken cancellationToken = default(CancellationToken))
		{
			PutBucketPolicyRequest putBucketPolicyRequest = new PutBucketPolicyRequest();
			putBucketPolicyRequest.BucketName = bucketName;
			putBucketPolicyRequest.Policy = policy;
			return PutBucketPolicyAsync(putBucketPolicyRequest, cancellationToken);
		}

		public virtual Task<PutBucketPolicyResponse> PutBucketPolicyAsync(string bucketName, string policy, string contentMD5, CancellationToken cancellationToken = default(CancellationToken))
		{
			PutBucketPolicyRequest putBucketPolicyRequest = new PutBucketPolicyRequest();
			putBucketPolicyRequest.BucketName = bucketName;
			putBucketPolicyRequest.Policy = policy;
			putBucketPolicyRequest.ContentMD5 = contentMD5;
			return PutBucketPolicyAsync(putBucketPolicyRequest, cancellationToken);
		}

		public virtual Task<PutBucketPolicyResponse> PutBucketPolicyAsync(PutBucketPolicyRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketPolicyRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketPolicyResponseUnmarshaller.Instance;
			return InvokeAsync<PutBucketPolicyResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutBucketReplicationResponse PutBucketReplication(PutBucketReplicationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketReplicationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketReplicationResponseUnmarshaller.Instance;
			return Invoke<PutBucketReplicationResponse>(request, invokeOptions);
		}

		public virtual Task<PutBucketReplicationResponse> PutBucketReplicationAsync(PutBucketReplicationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketReplicationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketReplicationResponseUnmarshaller.Instance;
			return InvokeAsync<PutBucketReplicationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutBucketRequestPaymentResponse PutBucketRequestPayment(PutBucketRequestPaymentRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketRequestPaymentRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketRequestPaymentResponseUnmarshaller.Instance;
			return Invoke<PutBucketRequestPaymentResponse>(request, invokeOptions);
		}

		public virtual Task<PutBucketRequestPaymentResponse> PutBucketRequestPaymentAsync(string bucketName, RequestPaymentConfiguration requestPaymentConfiguration, CancellationToken cancellationToken = default(CancellationToken))
		{
			PutBucketRequestPaymentRequest putBucketRequestPaymentRequest = new PutBucketRequestPaymentRequest();
			putBucketRequestPaymentRequest.BucketName = bucketName;
			putBucketRequestPaymentRequest.RequestPaymentConfiguration = requestPaymentConfiguration;
			return PutBucketRequestPaymentAsync(putBucketRequestPaymentRequest, cancellationToken);
		}

		public virtual Task<PutBucketRequestPaymentResponse> PutBucketRequestPaymentAsync(PutBucketRequestPaymentRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketRequestPaymentRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketRequestPaymentResponseUnmarshaller.Instance;
			return InvokeAsync<PutBucketRequestPaymentResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutBucketTaggingResponse PutBucketTagging(PutBucketTaggingRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketTaggingRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketTaggingResponseUnmarshaller.Instance;
			return Invoke<PutBucketTaggingResponse>(request, invokeOptions);
		}

		public virtual Task<PutBucketTaggingResponse> PutBucketTaggingAsync(string bucketName, List<Tag> tagSet, CancellationToken cancellationToken = default(CancellationToken))
		{
			PutBucketTaggingRequest putBucketTaggingRequest = new PutBucketTaggingRequest();
			putBucketTaggingRequest.BucketName = bucketName;
			putBucketTaggingRequest.TagSet = tagSet;
			return PutBucketTaggingAsync(putBucketTaggingRequest, cancellationToken);
		}

		public virtual Task<PutBucketTaggingResponse> PutBucketTaggingAsync(PutBucketTaggingRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketTaggingRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketTaggingResponseUnmarshaller.Instance;
			return InvokeAsync<PutBucketTaggingResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutBucketVersioningResponse PutBucketVersioning(PutBucketVersioningRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketVersioningRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketVersioningResponseUnmarshaller.Instance;
			return Invoke<PutBucketVersioningResponse>(request, invokeOptions);
		}

		public virtual Task<PutBucketVersioningResponse> PutBucketVersioningAsync(PutBucketVersioningRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketVersioningRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketVersioningResponseUnmarshaller.Instance;
			return InvokeAsync<PutBucketVersioningResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutBucketWebsiteResponse PutBucketWebsite(PutBucketWebsiteRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketWebsiteRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketWebsiteResponseUnmarshaller.Instance;
			return Invoke<PutBucketWebsiteResponse>(request, invokeOptions);
		}

		public virtual Task<PutBucketWebsiteResponse> PutBucketWebsiteAsync(string bucketName, WebsiteConfiguration websiteConfiguration, CancellationToken cancellationToken = default(CancellationToken))
		{
			PutBucketWebsiteRequest putBucketWebsiteRequest = new PutBucketWebsiteRequest();
			putBucketWebsiteRequest.BucketName = bucketName;
			putBucketWebsiteRequest.WebsiteConfiguration = websiteConfiguration;
			return PutBucketWebsiteAsync(putBucketWebsiteRequest, cancellationToken);
		}

		public virtual Task<PutBucketWebsiteResponse> PutBucketWebsiteAsync(PutBucketWebsiteRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutBucketWebsiteRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutBucketWebsiteResponseUnmarshaller.Instance;
			return InvokeAsync<PutBucketWebsiteResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutCORSConfigurationResponse PutCORSConfiguration(PutCORSConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutCORSConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutCORSConfigurationResponseUnmarshaller.Instance;
			return Invoke<PutCORSConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<PutCORSConfigurationResponse> PutCORSConfigurationAsync(string bucketName, CORSConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken))
		{
			PutCORSConfigurationRequest putCORSConfigurationRequest = new PutCORSConfigurationRequest();
			putCORSConfigurationRequest.BucketName = bucketName;
			putCORSConfigurationRequest.Configuration = configuration;
			return PutCORSConfigurationAsync(putCORSConfigurationRequest, cancellationToken);
		}

		public virtual Task<PutCORSConfigurationResponse> PutCORSConfigurationAsync(PutCORSConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutCORSConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutCORSConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<PutCORSConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutLifecycleConfigurationResponse PutLifecycleConfiguration(PutLifecycleConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutLifecycleConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutLifecycleConfigurationResponseUnmarshaller.Instance;
			return Invoke<PutLifecycleConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<PutLifecycleConfigurationResponse> PutLifecycleConfigurationAsync(string bucketName, LifecycleConfiguration configuration, CancellationToken cancellationToken = default(CancellationToken))
		{
			PutLifecycleConfigurationRequest putLifecycleConfigurationRequest = new PutLifecycleConfigurationRequest();
			putLifecycleConfigurationRequest.BucketName = bucketName;
			putLifecycleConfigurationRequest.Configuration = configuration;
			return PutLifecycleConfigurationAsync(putLifecycleConfigurationRequest, cancellationToken);
		}

		public virtual Task<PutLifecycleConfigurationResponse> PutLifecycleConfigurationAsync(PutLifecycleConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutLifecycleConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutLifecycleConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<PutLifecycleConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutObjectResponse PutObject(PutObjectRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutObjectRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutObjectResponseUnmarshaller.Instance;
			return Invoke<PutObjectResponse>(request, invokeOptions);
		}

		public virtual Task<PutObjectResponse> PutObjectAsync(PutObjectRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutObjectRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutObjectResponseUnmarshaller.Instance;
			return InvokeAsync<PutObjectResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutObjectAclResponse PutObjectAcl(PutObjectAclRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutObjectAclRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutObjectAclResponseUnmarshaller.Instance;
			return Invoke<PutObjectAclResponse>(request, invokeOptions);
		}

		public virtual Task<PutObjectAclResponse> PutObjectAclAsync(PutObjectAclRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutObjectAclRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutObjectAclResponseUnmarshaller.Instance;
			return InvokeAsync<PutObjectAclResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutObjectLegalHoldResponse PutObjectLegalHold(PutObjectLegalHoldRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutObjectLegalHoldRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutObjectLegalHoldResponseUnmarshaller.Instance;
			return Invoke<PutObjectLegalHoldResponse>(request, invokeOptions);
		}

		public virtual Task<PutObjectLegalHoldResponse> PutObjectLegalHoldAsync(PutObjectLegalHoldRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutObjectLegalHoldRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutObjectLegalHoldResponseUnmarshaller.Instance;
			return InvokeAsync<PutObjectLegalHoldResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutObjectLockConfigurationResponse PutObjectLockConfiguration(PutObjectLockConfigurationRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutObjectLockConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutObjectLockConfigurationResponseUnmarshaller.Instance;
			return Invoke<PutObjectLockConfigurationResponse>(request, invokeOptions);
		}

		public virtual Task<PutObjectLockConfigurationResponse> PutObjectLockConfigurationAsync(PutObjectLockConfigurationRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutObjectLockConfigurationRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutObjectLockConfigurationResponseUnmarshaller.Instance;
			return InvokeAsync<PutObjectLockConfigurationResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutObjectRetentionResponse PutObjectRetention(PutObjectRetentionRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutObjectRetentionRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutObjectRetentionResponseUnmarshaller.Instance;
			return Invoke<PutObjectRetentionResponse>(request, invokeOptions);
		}

		public virtual Task<PutObjectRetentionResponse> PutObjectRetentionAsync(PutObjectRetentionRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutObjectRetentionRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutObjectRetentionResponseUnmarshaller.Instance;
			return InvokeAsync<PutObjectRetentionResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutObjectTaggingResponse PutObjectTagging(PutObjectTaggingRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutObjectTaggingRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutObjectTaggingResponseUnmarshaller.Instance;
			return Invoke<PutObjectTaggingResponse>(request, invokeOptions);
		}

		public virtual Task<PutObjectTaggingResponse> PutObjectTaggingAsync(PutObjectTaggingRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutObjectTaggingRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutObjectTaggingResponseUnmarshaller.Instance;
			return InvokeAsync<PutObjectTaggingResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual PutPublicAccessBlockResponse PutPublicAccessBlock(PutPublicAccessBlockRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutPublicAccessBlockRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutPublicAccessBlockResponseUnmarshaller.Instance;
			return Invoke<PutPublicAccessBlockResponse>(request, invokeOptions);
		}

		public virtual Task<PutPublicAccessBlockResponse> PutPublicAccessBlockAsync(PutPublicAccessBlockRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = PutPublicAccessBlockRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = PutPublicAccessBlockResponseUnmarshaller.Instance;
			return InvokeAsync<PutPublicAccessBlockResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual RestoreObjectResponse RestoreObject(RestoreObjectRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = RestoreObjectRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = RestoreObjectResponseUnmarshaller.Instance;
			return Invoke<RestoreObjectResponse>(request, invokeOptions);
		}

		public virtual Task<RestoreObjectResponse> RestoreObjectAsync(string bucketName, string key, CancellationToken cancellationToken = default(CancellationToken))
		{
			RestoreObjectRequest restoreObjectRequest = new RestoreObjectRequest();
			restoreObjectRequest.BucketName = bucketName;
			restoreObjectRequest.Key = key;
			return RestoreObjectAsync(restoreObjectRequest, cancellationToken);
		}

		public virtual Task<RestoreObjectResponse> RestoreObjectAsync(string bucketName, string key, int? days, CancellationToken cancellationToken = default(CancellationToken))
		{
			RestoreObjectRequest restoreObjectRequest = new RestoreObjectRequest();
			restoreObjectRequest.BucketName = bucketName;
			restoreObjectRequest.Key = key;
			restoreObjectRequest.Days = days;
			return RestoreObjectAsync(restoreObjectRequest, cancellationToken);
		}

		public virtual Task<RestoreObjectResponse> RestoreObjectAsync(string bucketName, string key, string versionId, CancellationToken cancellationToken = default(CancellationToken))
		{
			RestoreObjectRequest restoreObjectRequest = new RestoreObjectRequest();
			restoreObjectRequest.BucketName = bucketName;
			restoreObjectRequest.Key = key;
			restoreObjectRequest.VersionId = versionId;
			return RestoreObjectAsync(restoreObjectRequest, cancellationToken);
		}

		public virtual Task<RestoreObjectResponse> RestoreObjectAsync(string bucketName, string key, string versionId, int? days, CancellationToken cancellationToken = default(CancellationToken))
		{
			RestoreObjectRequest restoreObjectRequest = new RestoreObjectRequest();
			restoreObjectRequest.BucketName = bucketName;
			restoreObjectRequest.Key = key;
			restoreObjectRequest.VersionId = versionId;
			restoreObjectRequest.Days = days;
			return RestoreObjectAsync(restoreObjectRequest, cancellationToken);
		}

		public virtual Task<RestoreObjectResponse> RestoreObjectAsync(RestoreObjectRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = RestoreObjectRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = RestoreObjectResponseUnmarshaller.Instance;
			return InvokeAsync<RestoreObjectResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual SelectObjectContentResponse SelectObjectContent(SelectObjectContentRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = SelectObjectContentRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = SelectObjectContentResponseUnmarshaller.Instance;
			return Invoke<SelectObjectContentResponse>(request, invokeOptions);
		}

		public virtual Task<SelectObjectContentResponse> SelectObjectContentAsync(SelectObjectContentRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = SelectObjectContentRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = SelectObjectContentResponseUnmarshaller.Instance;
			return InvokeAsync<SelectObjectContentResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual UploadPartResponse UploadPart(UploadPartRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = UploadPartRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = UploadPartResponseUnmarshaller.Instance;
			return Invoke<UploadPartResponse>(request, invokeOptions);
		}

		public virtual Task<UploadPartResponse> UploadPartAsync(UploadPartRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = UploadPartRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = UploadPartResponseUnmarshaller.Instance;
			return InvokeAsync<UploadPartResponse>(request, invokeOptions, cancellationToken);
		}

		internal virtual WriteGetObjectResponseResponse WriteGetObjectResponse(WriteGetObjectResponseRequest request)
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = WriteGetObjectResponseRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = WriteGetObjectResponseResponseUnmarshaller.Instance;
			return Invoke<WriteGetObjectResponseResponse>(request, invokeOptions);
		}

		public virtual Task<WriteGetObjectResponseResponse> WriteGetObjectResponseAsync(WriteGetObjectResponseRequest request, CancellationToken cancellationToken = default(CancellationToken))
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = WriteGetObjectResponseRequestMarshaller.Instance;
			invokeOptions.ResponseUnmarshaller = WriteGetObjectResponseResponseUnmarshaller.Instance;
			return InvokeAsync<WriteGetObjectResponseResponse>(request, invokeOptions, cancellationToken);
		}

		public Endpoint DetermineServiceOperationEndpoint(AmazonWebServiceRequest request)
		{
			ServiceOperationEndpointParameters parameters = new ServiceOperationEndpointParameters(request);
			return base.Config.DetermineServiceOperationEndpoint(parameters);
		}
	}
}
