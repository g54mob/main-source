using System.Collections.Generic;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class JsonKeyValueUnmarshaller<K, V, KUnmarshaller, VUnmarshaller> : IJsonUnmarshaller<KeyValuePair<K, V>, JsonUnmarshallerContext> where KUnmarshaller : IJsonUnmarshaller<K, JsonUnmarshallerContext> where VUnmarshaller : IJsonUnmarshaller<V, JsonUnmarshallerContext>
	{
		private KUnmarshaller keyUnmarshaller;

		private VUnmarshaller valueUnmarshaller;

		public JsonKeyValueUnmarshaller(KUnmarshaller keyUnmarshaller, VUnmarshaller valueUnmarshaller)
		{
			this.keyUnmarshaller = keyUnmarshaller;
			this.valueUnmarshaller = valueUnmarshaller;
		}

		public KeyValuePair<K, V> Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			K key = keyUnmarshaller.Unmarshall(context, ref reader);
			V value = valueUnmarshaller.Unmarshall(context, ref reader);
			return new KeyValuePair<K, V>(key, value);
		}
	}
}
