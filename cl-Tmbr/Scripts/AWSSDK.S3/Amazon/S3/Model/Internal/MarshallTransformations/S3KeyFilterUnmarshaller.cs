using System.Collections.Generic;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class S3KeyFilterUnmarshaller : IXmlUnmarshaller<S3KeyFilter, XmlUnmarshallerContext>
	{
		private static S3KeyFilterUnmarshaller _instance;

		public static S3KeyFilterUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new S3KeyFilterUnmarshaller();
				}
				return _instance;
			}
		}

		public S3KeyFilter Unmarshall(XmlUnmarshallerContext context)
		{
			S3KeyFilter s3KeyFilter = new S3KeyFilter();
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
					if (context.TestExpression("FilterRule", num))
					{
						if (s3KeyFilter.FilterRules == null)
						{
							s3KeyFilter.FilterRules = new List<FilterRule>();
						}
						s3KeyFilter.FilterRules.Add(FilterRuleUnmarshaller.Instance.Unmarshall(context));
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return s3KeyFilter;
				}
			}
			return s3KeyFilter;
		}
	}
}
