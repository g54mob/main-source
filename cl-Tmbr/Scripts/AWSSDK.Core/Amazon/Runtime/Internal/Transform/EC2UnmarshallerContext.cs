using System.IO;

namespace Amazon.Runtime.Internal.Transform
{
	public class EC2UnmarshallerContext : XmlUnmarshallerContext
	{
		public string RequestId { get; private set; }

		public EC2UnmarshallerContext(Stream responseStream, bool maintainResponseBody, IWebResponseData responseData, bool isException = false)
			: base(responseStream, maintainResponseBody, responseData, isException)
		{
		}

		public EC2UnmarshallerContext(Stream responseStream, bool maintainResponseBody, IWebResponseData responseData, bool isException, IRequestContext requestContext)
			: base(responseStream, maintainResponseBody, responseData, isException, requestContext)
		{
		}

		public override bool Read()
		{
			bool result = base.Read();
			if (RequestId == null && IsStartElement && TestExpression("RequestId", 2))
			{
				RequestId = StringUnmarshaller.GetInstance().Unmarshall(this);
			}
			return result;
		}
	}
}
