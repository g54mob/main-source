using System;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetACLRequestMarshaller : IMarshaller<IRequest, GetACLRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static GetACLRequestMarshaller _instance;

		public static GetACLRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetACLRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((GetACLRequest)input);
		}

		public IRequest Marshall(GetACLRequest getObjectAclRequest)
		{
			IRequest request = new DefaultRequest(getObjectAclRequest, "AmazonS3");
			request.HttpMethod = "GET";
			if (getObjectAclRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(getObjectAclRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(getObjectAclRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "GetACLRequest.BucketName");
			}
			request.AddPathResource("{Key+}", S3Transforms.ToStringValue(getObjectAclRequest.Key));
			request.ResourcePath = "/{Key+}";
			request.AddSubResource("acl");
			if (getObjectAclRequest.IsSetVersionId())
			{
				request.AddSubResource("versionId", S3Transforms.ToStringValue(getObjectAclRequest.VersionId));
			}
			request.UseQueryString = true;
			return request;
		}
	}
}
