using System.Collections.Generic;
using Amazon.Runtime.Internal.Transform;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class LoggingEnabledUnmarshaller : IXmlUnmarshaller<S3BucketLoggingConfig, XmlUnmarshallerContext>
	{
		private static LoggingEnabledUnmarshaller _instance;

		public static LoggingEnabledUnmarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new LoggingEnabledUnmarshaller();
				}
				return _instance;
			}
		}

		public S3BucketLoggingConfig Unmarshall(XmlUnmarshallerContext context)
		{
			S3BucketLoggingConfig s3BucketLoggingConfig = new S3BucketLoggingConfig();
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
					if (context.TestExpression("TargetBucket", num))
					{
						s3BucketLoggingConfig.TargetBucketName = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
					else if (context.TestExpression("Grant", num + 1))
					{
						if (s3BucketLoggingConfig.Grants == null)
						{
							s3BucketLoggingConfig.Grants = new List<S3Grant>();
						}
						s3BucketLoggingConfig.Grants.Add(GrantUnmarshaller.Instance.Unmarshall(context));
					}
					else if (context.TestExpression("TargetObjectKeyFormat", num))
					{
						s3BucketLoggingConfig.TargetObjectKeyFormat = TargetObjectKeyFormatUnmarshaller.Instance.Unmarshall(context);
					}
					else if (context.TestExpression("TargetPrefix", num))
					{
						s3BucketLoggingConfig.TargetPrefix = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					return s3BucketLoggingConfig;
				}
			}
			return s3BucketLoggingConfig;
		}
	}
}
