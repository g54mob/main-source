using System;
using System.Text;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class PutObjectTaggingRequestMarshaller : IMarshaller<IRequest, PutObjectTaggingRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutObjectTaggingRequestMarshaller _instance;

		public static PutObjectTaggingRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutObjectTaggingRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutObjectTaggingRequest)input);
		}

		public IRequest Marshall(PutObjectTaggingRequest putObjectTaggingRequest)
		{
			IRequest request = new DefaultRequest(putObjectTaggingRequest, "AmazonS3");
			request.HttpMethod = "PUT";
			if (putObjectTaggingRequest.IsSetChecksumAlgorithm())
			{
				request.Headers.Add(S3Constants.AmzHeaderSdkChecksumAlgorithm, S3Transforms.ToStringValue(putObjectTaggingRequest.ChecksumAlgorithm));
			}
			if (putObjectTaggingRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(putObjectTaggingRequest.ExpectedBucketOwner));
			}
			if (putObjectTaggingRequest.IsSetRequestPayer())
			{
				request.Headers.Add(S3Constants.AmzHeaderRequestPayer, S3Transforms.ToStringValue(putObjectTaggingRequest.RequestPayer));
			}
			if (string.IsNullOrEmpty(putObjectTaggingRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "PutObjectTaggingRequest.BucketName");
			}
			if (string.IsNullOrEmpty(putObjectTaggingRequest.Key))
			{
				throw new ArgumentException("Key is a required property and must be set before making this call.", "PutObjectTaggingRequest.Key");
			}
			request.AddPathResource("{Key+}", putObjectTaggingRequest.Key);
			request.ResourcePath = "/{Key+}";
			request.AddSubResource("tagging");
			if (putObjectTaggingRequest.IsSetVersionId())
			{
				request.AddSubResource("versionId", putObjectTaggingRequest.VersionId);
			}
			try
			{
				string s = AmazonS3Util.SerializeTaggingToXml(putObjectTaggingRequest.Tagging);
				request.Content = Encoding.UTF8.GetBytes(s);
				request.Headers["Content-Type"] = "application/xml";
				ChecksumUtils.SetChecksumData(request, putObjectTaggingRequest.ChecksumAlgorithm, fallbackToMD5: false, isRequestChecksumRequired: true, S3Constants.AmzHeaderSdkChecksumAlgorithm);
				return request;
			}
			catch (EncoderFallbackException innerException)
			{
				throw new AmazonServiceException("Unable to marhsall request to XML", innerException);
			}
		}
	}
}
