using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetObjectTorrentRequestMarshaller : IMarshaller<IRequest, GetObjectTorrentRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetObjectTorrentRequestMarshaller _instance;

		public static GetObjectTorrentRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetObjectTorrentRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetObjectTorrentRequest)input);
		}

		public IRequest Marshall(GetObjectTorrentRequest getObjectTorrentRequest)
		{
			IRequest request = new DefaultRequest(getObjectTorrentRequest, "AmazonS3");
			request.HttpMethod = "GET";
			if (getObjectTorrentRequest.IsSetRequestPayer())
			{
				request.Headers.Add(S3Constants.AmzHeaderRequestPayer, S3Transforms.ToStringValue(getObjectTorrentRequest.RequestPayer.ToString()));
			}
			if (getObjectTorrentRequest.IsSetRequestPayer())
			{
				request.Headers.Add(S3Constants.AmzHeaderRequestPayer, S3Transforms.ToStringValue(getObjectTorrentRequest.RequestPayer.ToString()));
			}
			if (getObjectTorrentRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(getObjectTorrentRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(getObjectTorrentRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "GetObjectTorrentRequest.BucketName");
			}
			if (string.IsNullOrEmpty(getObjectTorrentRequest.Key))
			{
				throw new ArgumentException("Key is a required property and must be set before making this call.", "GetObjectTorrentRequest.Key");
			}
			request.AddPathResource("{Key+}", S3Transforms.ToStringValue(getObjectTorrentRequest.Key));
			request.ResourcePath = "/{Key+}";
			request.AddSubResource("torrent");
			request.UseQueryString = true;
			return request;
		}
	}
}
