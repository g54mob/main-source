using System.IO;

namespace Amazon.Runtime.Internal.Transform
{
	public abstract class EC2ResponseUnmarshaller : XmlResponseUnmarshaller
	{
		public override AmazonWebServiceResponse Unmarshall(UnmarshallerContext input)
		{
			AmazonWebServiceResponse amazonWebServiceResponse = base.Unmarshall(input);
			if (amazonWebServiceResponse.ResponseMetadata == null)
			{
				amazonWebServiceResponse.ResponseMetadata = new ResponseMetadata();
			}
			if (input is EC2UnmarshallerContext eC2UnmarshallerContext && !string.IsNullOrEmpty(eC2UnmarshallerContext.RequestId))
			{
				amazonWebServiceResponse.ResponseMetadata.RequestId = eC2UnmarshallerContext.RequestId;
			}
			return amazonWebServiceResponse;
		}

		protected override UnmarshallerContext ConstructUnmarshallerContext(Stream responseStream, bool maintainResponseBody, IWebResponseData response, bool isException)
		{
			return new EC2UnmarshallerContext(responseStream, maintainResponseBody, response, isException, null);
		}

		protected override UnmarshallerContext ConstructUnmarshallerContext(Stream responseStream, bool maintainResponseBody, IWebResponseData response, bool isException, IRequestContext requestContext)
		{
			return new EC2UnmarshallerContext(responseStream, maintainResponseBody, response, isException, requestContext);
		}
	}
}
