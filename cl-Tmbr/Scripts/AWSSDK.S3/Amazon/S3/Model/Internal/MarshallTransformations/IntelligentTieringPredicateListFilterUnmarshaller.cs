using System.Collections.Generic;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class IntelligentTieringPredicateListFilterUnmarshaller : IXmlUnmarshaller<List<IntelligentTieringFilterPredicate>, XmlUnmarshallerContext>
	{
		private static IntelligentTieringPredicateListFilterUnmarshaller _instance;

		public static IntelligentTieringPredicateListFilterUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new IntelligentTieringPredicateListFilterUnmarshaller();
				}
				return _instance;
			}
		}

		public List<IntelligentTieringFilterPredicate> Unmarshall(XmlUnmarshallerContext context)
		{
			List<IntelligentTieringFilterPredicate> list = new List<IntelligentTieringFilterPredicate>();
			int currentDepth = context.CurrentDepth;
			int num = currentDepth + 1;
			if (context.IsStartOfDocument)
			{
				num += 2;
			}
			while (context.Read())
			{
				if (context.IsStartElement || context.IsAttribute)
				{
					if (context.TestExpression("Prefix", num))
					{
						list.Add(new IntelligentTieringPrefixPredicate(StringUnmarshaller.Instance.Unmarshall(context)));
					}
					else if (context.TestExpression("Tag", num))
					{
						list.Add(new IntelligentTieringTagPredicate(TagUnmarshaller.Instance.Unmarshall(context)));
					}
					else if (context.TestExpression("And", num))
					{
						list.Add(new IntelligentTieringAndOperator(Unmarshall(context)));
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return list;
				}
			}
			return list;
		}
	}
}
