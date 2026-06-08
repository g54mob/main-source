using System.Collections.Generic;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class GetBucketNotificationResponse : AmazonWebServiceResponse
	{
		private List<TopicConfiguration> _topicConfigurations = (AWSConfigs.InitializeCollections ? new List<TopicConfiguration>() : null);

		private List<QueueConfiguration> _queueConfigurations = (AWSConfigs.InitializeCollections ? new List<QueueConfiguration>() : null);

		private List<LambdaFunctionConfiguration> _lambdaFunctionConfigurations = (AWSConfigs.InitializeCollections ? new List<LambdaFunctionConfiguration>() : null);

		private EventBridgeConfiguration _eventBridgeConfiguration;

		public List<TopicConfiguration> TopicConfigurations
		{
			get
			{
				return _topicConfigurations;
			}
			set
			{
				_topicConfigurations = value;
			}
		}

		public List<QueueConfiguration> QueueConfigurations
		{
			get
			{
				return _queueConfigurations;
			}
			set
			{
				_queueConfigurations = value;
			}
		}

		public List<LambdaFunctionConfiguration> LambdaFunctionConfigurations
		{
			get
			{
				return _lambdaFunctionConfigurations;
			}
			set
			{
				_lambdaFunctionConfigurations = value;
			}
		}

		public EventBridgeConfiguration EventBridgeConfiguration
		{
			get
			{
				return _eventBridgeConfiguration;
			}
			set
			{
				_eventBridgeConfiguration = value;
			}
		}

		internal bool IsSetEventBridgeConfiguration()
		{
			return _eventBridgeConfiguration != null;
		}
	}
}
