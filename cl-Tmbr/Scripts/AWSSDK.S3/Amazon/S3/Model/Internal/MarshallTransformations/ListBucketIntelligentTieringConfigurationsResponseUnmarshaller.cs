using System.Collections.Generic;
using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class ListBucketIntelligentTieringConfigurationsResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static ListBucketIntelligentTieringConfigurationsResponseUnmarshaller _instance = new ListBucketIntelligentTieringConfigurationsResponseUnmarshaller();

		public static ListBucketIntelligentTieringConfigurationsResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new ListBucketIntelligentTieringConfigurationsResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			ListBucketIntelligentTieringConfigurationsResponse listBucketIntelligentTieringConfigurationsResponse = new ListBucketIntelligentTieringConfigurationsResponse();
			while (context.Read())
			{
				if (context.IsStartElement)
				{
					UnmarshallResult(context, listBucketIntelligentTieringConfigurationsResponse);
				}
			}
			return listBucketIntelligentTieringConfigurationsResponse;
		}

		private static void UnmarshallResult(XmlUnmarshallerContext context, ListBucketIntelligentTieringConfigurationsResponse response)
		{
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
					if (context.TestExpression("ContinuationToken", num))
					{
						response.ContinuationToken = StringUnmarshaller.Instance.Unmarshall(context);
					}
					else if (context.TestExpression("IntelligentTieringConfiguration", num))
					{
						if (response.IntelligentTieringConfigurationList == null)
						{
							response.IntelligentTieringConfigurationList = new List<IntelligentTieringConfiguration>();
						}
						response.IntelligentTieringConfigurationList.Add(IntelligentTieringConfigurationUnmarshaller.Instance.Unmarshall(context));
					}
					else if (context.TestExpression("IsTruncated", num))
					{
						response.IsTruncated = BoolUnmarshaller.Instance.Unmarshall(context);
					}
					else if (context.TestExpression("NextContinuationToken", num))
					{
						response.NextContinuationToken = StringUnmarshaller.Instance.Unmarshall(context);
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
