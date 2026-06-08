using System.Collections.Generic;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class CORSRuleUnmarshaller : IXmlUnmarshaller<CORSRule, XmlUnmarshallerContext>
	{
		private static CORSRuleUnmarshaller _instance;

		public static CORSRuleUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new CORSRuleUnmarshaller();
				}
				return _instance;
			}
		}

		public CORSRule Unmarshall(XmlUnmarshallerContext context)
		{
			CORSRule cORSRule = new CORSRule();
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
					if (context.TestExpression("AllowedMethod", num))
					{
						if (cORSRule.AllowedMethods == null)
						{
							cORSRule.AllowedMethods = new List<string>();
						}
						cORSRule.AllowedMethods.Add(StringUnmarshaller.GetInstance().Unmarshall(context));
					}
					else if (context.TestExpression("AllowedOrigin", num))
					{
						if (cORSRule.AllowedOrigins == null)
						{
							cORSRule.AllowedOrigins = new List<string>();
						}
						cORSRule.AllowedOrigins.Add(StringUnmarshaller.GetInstance().Unmarshall(context));
					}
					else if (context.TestExpression("ExposeHeader", num))
					{
						if (cORSRule.ExposeHeaders == null)
						{
							cORSRule.ExposeHeaders = new List<string>();
						}
						cORSRule.ExposeHeaders.Add(StringUnmarshaller.GetInstance().Unmarshall(context));
					}
					else if (context.TestExpression("AllowedHeader", num))
					{
						if (cORSRule.AllowedHeaders == null)
						{
							cORSRule.AllowedHeaders = new List<string>();
						}
						cORSRule.AllowedHeaders.Add(StringUnmarshaller.GetInstance().Unmarshall(context));
					}
					else if (context.TestExpression("MaxAgeSeconds", num))
					{
						cORSRule.MaxAgeSeconds = IntUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("ID", num))
					{
						cORSRule.Id = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return cORSRule;
				}
			}
			return cORSRule;
		}
	}
}
