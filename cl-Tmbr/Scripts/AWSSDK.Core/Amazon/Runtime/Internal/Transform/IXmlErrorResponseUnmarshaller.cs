namespace Amazon.Runtime.Internal.Transform
{
	public interface IXmlErrorResponseUnmarshaller<TUnmarshaller, TXmlUnmarshallerContext> : IXmlUnmarshaller<TUnmarshaller, TXmlUnmarshallerContext>
	{
		TUnmarshaller Unmarshall(XmlUnmarshallerContext input, ErrorResponse errorResponse);
	}
}
