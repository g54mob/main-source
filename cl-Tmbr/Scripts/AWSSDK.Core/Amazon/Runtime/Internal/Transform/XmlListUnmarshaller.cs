using System.Collections.Generic;

namespace Amazon.Runtime.Internal.Transform
{
	public class XmlListUnmarshaller<T, TUnmarshaller> : IXmlUnmarshaller<List<T>, XmlUnmarshallerContext> where TUnmarshaller : IXmlUnmarshaller<T, XmlUnmarshallerContext>
	{
		private TUnmarshaller iUnmarshaller;

		public XmlListUnmarshaller(TUnmarshaller iUnmarshaller)
		{
			this.iUnmarshaller = iUnmarshaller;
		}

		public List<T> Unmarshall(XmlUnmarshallerContext context)
		{
			int currentDepth = context.CurrentDepth;
			int startingStackDepth = currentDepth + 1;
			List<T> list = new List<T>();
			while (context.Read() && context.CurrentDepth >= currentDepth)
			{
				if (context.IsStartElement && context.TestExpression("member", startingStackDepth))
				{
					T item = iUnmarshaller.Unmarshall(context);
					list.Add(item);
				}
			}
			return list;
		}
	}
}
