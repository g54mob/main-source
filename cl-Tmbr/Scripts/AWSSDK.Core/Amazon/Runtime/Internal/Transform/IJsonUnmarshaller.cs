using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public interface IJsonUnmarshaller<T, TJsonUnmarshallerContext>
	{
		T Unmarshall(TJsonUnmarshallerContext input, ref StreamingUtf8JsonReader reader);
	}
}
