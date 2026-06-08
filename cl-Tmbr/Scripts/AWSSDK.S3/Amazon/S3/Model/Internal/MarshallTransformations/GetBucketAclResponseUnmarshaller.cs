using System.Collections.Generic;
using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetBucketAclResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static GetBucketAclResponseUnmarshaller _instance = new GetBucketAclResponseUnmarshaller();

		public static GetBucketAclResponseUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new GetBucketAclResponseUnmarshaller();
				}
				return _instance;
			}
		}

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			GetBucketAclResponse getBucketAclResponse = new GetBucketAclResponse();
			while (context.Read())
			{
				if (context.IsStartElement)
				{
					UnmarshallResult(context, getBucketAclResponse);
				}
			}
			return getBucketAclResponse;
		}

		private static void UnmarshallResult(XmlUnmarshallerContext context, GetBucketAclResponse response)
		{
			int currentDepth = context.CurrentDepth;
			int num = currentDepth + 1;
			if (context.IsStartOfDocument)
			{
				num++;
			}
			if (context.IsEmptyResponse)
			{
				return;
			}
			while (context.Read())
			{
				if (context.IsStartElement || context.IsAttribute)
				{
					if (context.TestExpression("AccessControlList/Grant", num))
					{
						if (response.Grants == null)
						{
							response.Grants = new List<S3Grant>();
						}
						GrantUnmarshaller instance = GrantUnmarshaller.Instance;
						response.Grants.Add(instance.Unmarshall(context));
					}
					else if (context.TestExpression("Owner", num))
					{
						OwnerUnmarshaller instance2 = OwnerUnmarshaller.Instance;
						response.Owner = instance2.Unmarshall(context);
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
