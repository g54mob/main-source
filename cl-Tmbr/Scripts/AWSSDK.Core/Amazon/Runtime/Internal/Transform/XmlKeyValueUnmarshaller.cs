using System.Collections.Generic;

namespace Amazon.Runtime.Internal.Transform
{
	public class XmlKeyValueUnmarshaller<K, V, KUnmarshaller, VUnmarshaller> : IXmlUnmarshaller<KeyValuePair<K, V>, XmlUnmarshallerContext> where KUnmarshaller : IXmlUnmarshaller<K, XmlUnmarshallerContext> where VUnmarshaller : IXmlUnmarshaller<V, XmlUnmarshallerContext>
	{
		private KUnmarshaller keyUnmarshaller;

		private VUnmarshaller valueUnmarshaller;

		private string keyName;

		private string valueName;

		public XmlKeyValueUnmarshaller(KUnmarshaller keyUnmarshaller, VUnmarshaller valueUnmarshaller, string keyName, string valueName)
		{
			this.keyUnmarshaller = keyUnmarshaller;
			this.valueUnmarshaller = valueUnmarshaller;
			this.keyName = keyName;
			this.valueName = valueName;
		}

		public KeyValuePair<K, V> Unmarshall(XmlUnmarshallerContext context)
		{
			K key = default(K);
			V value = default(V);
			while (context.IsAttribute)
			{
				context.Read();
			}
			int currentDepth = context.CurrentDepth;
			int startingStackDepth = currentDepth + 1;
			while (context.Read())
			{
				if (context.TestExpression(keyName, startingStackDepth))
				{
					key = keyUnmarshaller.Unmarshall(context);
				}
				else if (context.TestExpression(valueName, startingStackDepth))
				{
					value = valueUnmarshaller.Unmarshall(context);
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					break;
				}
			}
			return new KeyValuePair<K, V>(key, value);
		}
	}
}
