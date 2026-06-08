using System;
using System.IO;
using System.Text.Json;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class MemoryStreamUnmarshaller : IXmlUnmarshaller<MemoryStream, XmlUnmarshallerContext>, IJsonUnmarshaller<MemoryStream, JsonUnmarshallerContext>
	{
		private static MemoryStreamUnmarshaller _instance = new MemoryStreamUnmarshaller();

		public static MemoryStreamUnmarshaller Instance => _instance;

		private MemoryStreamUnmarshaller()
		{
		}

		public static MemoryStreamUnmarshaller GetInstance()
		{
			return Instance;
		}

		public MemoryStream Unmarshall(XmlUnmarshallerContext context)
		{
			byte[] array = Convert.FromBase64String(context.ReadText());
			return new MemoryStream(array, 0, array.Length, writable: true, publiclyVisible: true);
		}

		public MemoryStream Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			context.Read(ref reader);
			if (context.CurrentTokenType == JsonTokenType.Null)
			{
				return null;
			}
			byte[] array = Convert.FromBase64String(context.ReadText(ref reader));
			return new MemoryStream(array, 0, array.Length, writable: true, publiclyVisible: true);
		}
	}
}
