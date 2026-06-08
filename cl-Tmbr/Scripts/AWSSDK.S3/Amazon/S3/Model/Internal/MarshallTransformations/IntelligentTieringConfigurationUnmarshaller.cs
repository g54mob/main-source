using System.Collections.Generic;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class IntelligentTieringConfigurationUnmarshaller : IXmlUnmarshaller<IntelligentTieringConfiguration, XmlUnmarshallerContext>
	{
		private static IntelligentTieringConfigurationUnmarshaller _instance;

		public static IntelligentTieringConfigurationUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new IntelligentTieringConfigurationUnmarshaller();
				}
				return _instance;
			}
		}

		public IntelligentTieringConfiguration Unmarshall(XmlUnmarshallerContext context)
		{
			IntelligentTieringConfiguration intelligentTieringConfiguration = new IntelligentTieringConfiguration();
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
					if (context.TestExpression("Filter", num))
					{
						intelligentTieringConfiguration.IntelligentTieringFilter = new IntelligentTieringFilter
						{
							IntelligentTieringFilterPredicate = IntelligentTieringPredicateListFilterUnmarshaller.Instance.Unmarshall(context)[0]
						};
					}
					else if (context.TestExpression("Id", num))
					{
						intelligentTieringConfiguration.IntelligentTieringId = StringUnmarshaller.Instance.Unmarshall(context);
					}
					else if (context.TestExpression("Status", num))
					{
						intelligentTieringConfiguration.Status = StringUnmarshaller.Instance.Unmarshall(context);
					}
					else if (context.TestExpression("Tiering", num))
					{
						if (intelligentTieringConfiguration.Tierings == null)
						{
							intelligentTieringConfiguration.Tierings = new List<Tiering>();
						}
						intelligentTieringConfiguration.Tierings.Add(TieringUnmarshaller.Instance.Unmarshall(context));
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return intelligentTieringConfiguration;
				}
			}
			return intelligentTieringConfiguration;
		}
	}
}
