using System.Collections.Generic;
using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketIntelligentTieringConfigurationResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static GetBucketIntelligentTieringConfigurationResponseUnmarshaller _instance;

		public static GetBucketIntelligentTieringConfigurationResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketIntelligentTieringConfigurationResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			GetBucketIntelligentTieringConfigurationResponse getBucketIntelligentTieringConfigurationResponse = new GetBucketIntelligentTieringConfigurationResponse();
			while (context.Read())
			{
				if (context.IsStartElement)
				{
					UnmarshallResult(context, getBucketIntelligentTieringConfigurationResponse);
				}
			}
			return getBucketIntelligentTieringConfigurationResponse;
		}

		private static void UnmarshallResult(XmlUnmarshallerContext context, GetBucketIntelligentTieringConfigurationResponse response)
		{
			int currentDepth = context.CurrentDepth;
			int num = currentDepth + 1;
			if (context.IsStartOfDocument)
			{
				num += 2;
			}
			response.IntelligentTieringConfiguration = new IntelligentTieringConfiguration();
			while (context.Read())
			{
				if (context.IsStartElement || context.IsAttribute)
				{
					if (context.TestExpression("Filter", num))
					{
						response.IntelligentTieringConfiguration.IntelligentTieringFilter = new IntelligentTieringFilter
						{
							IntelligentTieringFilterPredicate = IntelligentTieringPredicateListFilterUnmarshaller.Instance.Unmarshall(context)[0]
						};
					}
					else if (context.TestExpression("Id", num))
					{
						response.IntelligentTieringConfiguration.IntelligentTieringId = StringUnmarshaller.Instance.Unmarshall(context);
					}
					else if (context.TestExpression("Status", num))
					{
						response.IntelligentTieringConfiguration.Status = StringUnmarshaller.Instance.Unmarshall(context);
					}
					else if (context.TestExpression("Tiering", num))
					{
						if (response.IntelligentTieringConfiguration.Tierings == null)
						{
							response.IntelligentTieringConfiguration.Tierings = new List<Tiering>();
						}
						response.IntelligentTieringConfiguration.Tierings.Add(TieringUnmarshaller.Instance.Unmarshall(context));
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					break;
				}
			}
		}
	}
}
