using System.Collections.Generic;
using Amazon.Runtime;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class GetObjectAclResponseUnmarshaller : S3ReponseUnmarshaller
	{
		private static GetObjectAclResponseUnmarshaller _instance = new GetObjectAclResponseUnmarshaller();

		public static GetObjectAclResponseUnmarshaller Instance => _instance;

		public override AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext context)
		{
			GetObjectAclResponse getObjectAclResponse = new GetObjectAclResponse();
			while (context.Read())
			{
				if (context.IsStartElement)
				{
					UnmarshallResult(context, getObjectAclResponse);
				}
			}
			if (context.ResponseData.IsHeaderPresent("x-amz-request-charged"))
			{
				getObjectAclResponse.RequestCharged = context.ResponseData.GetHeaderValue("x-amz-request-charged");
			}
			return getObjectAclResponse;
		}

		private static void UnmarshallResult(XmlUnmarshallerContext context, GetObjectAclResponse response)
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

		internal static GetObjectAclResponseUnmarshaller GetInstance()
		{
			return _instance;
		}
	}
}
