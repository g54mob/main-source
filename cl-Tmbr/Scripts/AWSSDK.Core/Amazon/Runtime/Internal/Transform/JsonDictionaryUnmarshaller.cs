using System.Collections.Generic;
using System.Text.Json;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class JsonDictionaryUnmarshaller<TKey, TValue, TKeyUnmarshaller, TValueUnmarshaller> : IJsonUnmarshaller<Dictionary<TKey, TValue>, JsonUnmarshallerContext> where TKeyUnmarshaller : IJsonUnmarshaller<TKey, JsonUnmarshallerContext> where TValueUnmarshaller : IJsonUnmarshaller<TValue, JsonUnmarshallerContext>
	{
		private JsonKeyValueUnmarshaller<TKey, TValue, TKeyUnmarshaller, TValueUnmarshaller> KVUnmarshaller;

		public JsonDictionaryUnmarshaller(TKeyUnmarshaller kUnmarshaller, TValueUnmarshaller vUnmarshaller)
		{
			KVUnmarshaller = new JsonKeyValueUnmarshaller<TKey, TValue, TKeyUnmarshaller, TValueUnmarshaller>(kUnmarshaller, vUnmarshaller);
		}

		public Dictionary<TKey, TValue> Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			context.Read(ref reader);
			if (context.CurrentTokenType == JsonTokenType.Null)
			{
				if (AWSConfigs.InitializeCollections)
				{
					return new Dictionary<TKey, TValue>();
				}
				return null;
			}
			Dictionary<TKey, TValue> dictionary = new AlwaysSendDictionary<TKey, TValue>();
			while (!context.Peek(JsonTokenType.EndObject, ref reader))
			{
				KeyValuePair<TKey, TValue> keyValuePair = KVUnmarshaller.Unmarshall(context, ref reader);
				dictionary.Add(keyValuePair.Key, keyValuePair.Value);
			}
			context.Read(ref reader);
			return dictionary;
		}
	}
}
