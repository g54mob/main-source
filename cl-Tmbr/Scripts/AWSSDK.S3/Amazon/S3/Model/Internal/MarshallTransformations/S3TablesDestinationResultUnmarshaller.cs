using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class S3TablesDestinationResultUnmarshaller : IXmlUnmarshaller<S3TablesDestinationResult, XmlUnmarshallerContext>
	{
		private static S3TablesDestinationResultUnmarshaller _instance;

		public static S3TablesDestinationResultUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new S3TablesDestinationResultUnmarshaller();
				}
				return _instance;
			}
		}

		public S3TablesDestinationResult Unmarshall(XmlUnmarshallerContext context)
		{
			S3TablesDestinationResult s3TablesDestinationResult = new S3TablesDestinationResult();
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
					if (context.TestExpression("TableBucketArn", num))
					{
						s3TablesDestinationResult.TableBucketArn = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("TableArn", num))
					{
						s3TablesDestinationResult.TableArn = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("TableName", num))
					{
						s3TablesDestinationResult.TableName = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("TableNamespace", num))
					{
						s3TablesDestinationResult.TableNamespace = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return s3TablesDestinationResult;
				}
			}
			return s3TablesDestinationResult;
		}
	}
}
