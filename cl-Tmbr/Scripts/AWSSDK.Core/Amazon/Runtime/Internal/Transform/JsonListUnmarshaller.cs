using System.Collections.Generic;
using System.Text.Json;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class JsonListUnmarshaller<T, TUnmarshaller> : IJsonUnmarshaller<List<T>, JsonUnmarshallerContext> where TUnmarshaller : IJsonUnmarshaller<T, JsonUnmarshallerContext>
	{
		private TUnmarshaller iUnmarshaller;

		public JsonListUnmarshaller(TUnmarshaller iUnmarshaller)
		{
			this.iUnmarshaller = iUnmarshaller;
		}

		public List<T> Unmarshall(JsonUnmarshallerContext context, ref StreamingUtf8JsonReader reader)
		{
			context.Read(ref reader);
			if (context.CurrentTokenType == JsonTokenType.Null)
			{
				if (AWSConfigs.InitializeCollections)
				{
					return new List<T>();
				}
				return null;
			}
			List<T> list = new AlwaysSendList<T>();
			while (!context.Peek(JsonTokenType.EndArray, ref reader))
			{
				list.Add(iUnmarshaller.Unmarshall(context, ref reader));
			}
			context.Read(ref reader);
			return list;
		}
	}
}
