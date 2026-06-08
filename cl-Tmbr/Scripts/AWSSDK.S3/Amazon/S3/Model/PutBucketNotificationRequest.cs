using System.Collections.Generic;
using Amazon.Runtime;

namespace Amazon.S3.Model
{
	public class PutBucketNotificationRequest : AmazonWebServiceRequest
	{
		private ChecksumAlgorithm _checksumAlgorithm;

		private string expectedBucketOwner;

		private bool? _skipDestinationValidation;

		private EventBridgeConfiguration _eventBridgeConfiguration;

		public string BucketName { get; set; }

		public ChecksumAlgorithm ChecksumAlgorithm
		{
			get
			{
				return _checksumAlgorithm;
			}
			set
			{
				_checksumAlgorithm = value;
			}
		}

		public List<TopicConfiguration> TopicConfigurations { get; set; }

		public List<QueueConfiguration> QueueConfigurations { get; set; }

		public List<LambdaFunctionConfiguration> LambdaFunctionConfigurations { get; set; }

		public string ExpectedBucketOwner
		{
			get
			{
				return expectedBucketOwner;
			}
			set
			{
				expectedBucketOwner = value;
			}
		}

		public bool? SkipDestinationValidation
		{
			get
			{
				return _skipDestinationValidation;
			}
			set
			{
				_skipDestinationValidation = value;
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

		internal bool IsSetBucketName()
		{
			return BucketName != null;
		}

		internal bool IsSetChecksumAlgorithm()
		{
			return _checksumAlgorithm != null;
		}

		internal bool IsSetTopicConfigurations()
		{
			if (TopicConfigurations != null)
			{
				return TopicConfigurations.Count > 0;
			}
			return false;
		}

		internal bool IsSetQueueConfigurations()
		{
			if (QueueConfigurations != null)
			{
				return QueueConfigurations.Count > 0;
			}
			return false;
		}

		internal bool IsSetLambdaFunctionConfigurations()
		{
			if (LambdaFunctionConfigurations != null)
			{
				return LambdaFunctionConfigurations.Count > 0;
			}
			return false;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}

		internal bool IsSetSkipDestinationValidation()
		{
			return _skipDestinationValidation.HasValue;
		}

		internal bool IsSetEventBridgeConfiguration()
		{
			return _eventBridgeConfiguration != null;
		}
	}
}
