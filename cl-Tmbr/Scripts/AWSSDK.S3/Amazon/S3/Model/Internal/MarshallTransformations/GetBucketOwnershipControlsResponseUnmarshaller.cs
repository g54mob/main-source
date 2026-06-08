using System.Collections.Generic;
using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketOwnershipControlsResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static GetBucketOwnershipControlsResponseUnmarshaller _instance;

		public static GetBucketOwnershipControlsResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketOwnershipControlsResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			GetBucketOwnershipControlsResponse getBucketOwnershipControlsResponse = new GetBucketOwnershipControlsResponse();
			UnmarshallResult(context, getBucketOwnershipControlsResponse);
			return getBucketOwnershipControlsResponse;
		}

		private static void UnmarshallResult(XmlUnmarshallerContext context, GetBucketOwnershipControlsResponse response)
		{
			int currentDepth = context.CurrentDepth;
			int num = currentDepth;
			if (context.IsStartOfDocument)
			{
				num += 2;
			}
			while (context.Read())
			{
				if (context.IsStartElement || context.IsAttribute)
				{
					if (context.TestExpression("Rule", num))
					{
						if (response.OwnershipControls.Rules == null)
						{
							response.OwnershipControls.Rules = new List<OwnershipControlsRule>();
						}
						response.OwnershipControls.Rules.Add(OwnershipControlsRuleUnmarshaller.Instance.Unmarshall(context));
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
