using System.Collections.Generic;
using Amazon.Runtime.Internal.Util;

namespace Amazon.Runtime.Internal.Transform
{
	public class XmlDictionaryUnmarshaller<TKey, TValue, TKeyUnmarshaller, TValueUnmarshaller> : IXmlUnmarshaller<Dictionary<TKey, TValue>, XmlUnmarshallerContext> where TKeyUnmarshaller : IXmlUnmarshaller<TKey, XmlUnmarshallerContext> where TValueUnmarshaller : IXmlUnmarshaller<TValue, XmlUnmarshallerContext>
	{
		private XmlKeyValueUnmarshaller<TKey, TValue, TKeyUnmarshaller, TValueUnmarshaller> KVUnmarshaller;

		public XmlDictionaryUnmarshaller(TKeyUnmarshaller kUnmarshaller, TValueUnmarshaller vUnmarshaller, string keyName, string valueName)
		{
			KVUnmarshaller = new XmlKeyValueUnmarshaller<TKey, TValue, TKeyUnmarshaller, TValueUnmarshaller>(kUnmarshaller, vUnmarshaller, keyName, valueName);
		}

		public Dictionary<TKey, TValue> Unmarshall(XmlUnmarshallerContext context)
		{
			int currentDepth = context.CurrentDepth;
			AlwaysSendDictionary<TKey, TValue> alwaysSendDictionary = new AlwaysSendDictionary<TKey, TValue>();
			while (context.Read() && (!context.IsEndElement || context.CurrentDepth >= currentDepth))
			{
				KeyValuePair<TKey, TValue> keyValuePair = KVUnmarshaller.Unmarshall(context);
				alwaysSendDictionary.Add(keyValuePair.Key, keyValuePair.Value);
			}
			return alwaysSendDictionary;
		}
	}
}
