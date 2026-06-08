using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public interface IJsonErrorResponseUnmarshaller<T, TJsonUnmarshallerContext>
	{
		T Unmarshall(TJsonUnmarshallerContext context, ErrorResponse errorResponse, ref StreamingUtf8JsonReader reader);
	}
}
