using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ListBucketInventoryConfigurationsRequestMarshaller : IMarshaller<IRequest, ListBucketInventoryConfigurationsRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static ListBucketInventoryConfigurationsRequestMarshaller _instance;

		public static ListBucketInventoryConfigurationsRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ListBucketInventoryConfigurationsRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((ListBucketInventoryConfigurationsRequest)input);
		}

		public IRequest Marshall(ListBucketInventoryConfigurationsRequest listBucketInventoryConfigurationsRequest)
		{
			IRequest request = new DefaultRequest(listBucketInventoryConfigurationsRequest, "AmazonS3");
			request.HttpMethod = "GET";
			if (listBucketInventoryConfigurationsRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(listBucketInventoryConfigurationsRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(listBucketInventoryConfigurationsRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "ListBucketInventoryConfigurationsRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("inventory");
			if (listBucketInventoryConfigurationsRequest.IsSetContinuationToken())
			{
				request.AddSubResource("continuation-token", listBucketInventoryConfigurationsRequest.ContinuationToken.ToString());
			}
			request.UseQueryString = true;
			return request;
		}
	}
}
