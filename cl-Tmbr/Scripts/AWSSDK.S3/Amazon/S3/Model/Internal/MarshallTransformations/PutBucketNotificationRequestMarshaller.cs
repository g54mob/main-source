using System;
using System.Globalization;
using System.Text;
using System.Xml;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
using Amazon.S3.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class PutBucketNotificationRequestMarshaller : IMarshaller<IRequest, PutBucketNotificationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutBucketNotificationRequestMarshaller _instance;

		public static PutBucketNotificationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutBucketNotificationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutBucketNotificationRequest)input);
		}

		public IRequest Marshall(PutBucketNotificationRequest putBucketNotificationRequest)
		{
			IRequest request = new DefaultRequest(putBucketNotificationRequest, "AmazonS3");
			request.HttpMethod = "PUT";
			if (putBucketNotificationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(putBucketNotificationRequest.ExpectedBucketOwner));
			}
			if (putBucketNotificationRequest.IsSetSkipDestinationValidation())
			{
				request.Headers[S3Constants.AmzHeaderSkipDestinationValidation] = StringUtils.FromBool(putBucketNotificationRequest.SkipDestinationValidation);
			}
			if (putBucketNotificationRequest.IsSetChecksumAlgorithm())
			{
				request.Headers[S3Constants.AmzHeaderSdkChecksumAlgorithm] = S3Transforms.ToStringValue(putBucketNotificationRequest.ChecksumAlgorithm);
			}
			if (string.IsNullOrEmpty(putBucketNotificationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "PutBucketNotificationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("notification");
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				xmlWriter.WriteStartElement("NotificationConfiguration", "http://s3.amazonaws.com/doc/2006-03-01/");
				if (putBucketNotificationRequest.IsSetTopicConfigurations())
				{
					foreach (TopicConfiguration topicConfiguration in putBucketNotificationRequest.TopicConfigurations)
					{
						if (topicConfiguration != null)
						{
							xmlWriter.WriteStartElement("TopicConfiguration");
							if (topicConfiguration.IsSetId())
							{
								xmlWriter.WriteElementString("Id", S3Transforms.ToXmlStringValue(topicConfiguration.Id));
							}
							if (topicConfiguration.IsSetTopic())
							{
								xmlWriter.WriteElementString("Topic", S3Transforms.ToXmlStringValue(topicConfiguration.Topic));
							}
							WriteConfigurationCommon(xmlWriter, topicConfiguration);
							xmlWriter.WriteEndElement();
						}
					}
				}
				if (putBucketNotificationRequest.IsSetQueueConfigurations())
				{
					foreach (QueueConfiguration queueConfiguration in putBucketNotificationRequest.QueueConfigurations)
					{
						if (queueConfiguration != null)
						{
							xmlWriter.WriteStartElement("QueueConfiguration");
							if (queueConfiguration.IsSetId())
							{
								xmlWriter.WriteElementString("Id", S3Transforms.ToXmlStringValue(queueConfiguration.Id));
							}
							if (queueConfiguration.IsSetQueue())
							{
								xmlWriter.WriteElementString("Queue", S3Transforms.ToXmlStringValue(queueConfiguration.Queue));
							}
							WriteConfigurationCommon(xmlWriter, queueConfiguration);
							xmlWriter.WriteEndElement();
						}
					}
				}
				if (putBucketNotificationRequest.IsSetLambdaFunctionConfigurations())
				{
					foreach (LambdaFunctionConfiguration lambdaFunctionConfiguration in putBucketNotificationRequest.LambdaFunctionConfigurations)
					{
						if (lambdaFunctionConfiguration != null)
						{
							xmlWriter.WriteStartElement("CloudFunctionConfiguration");
							if (lambdaFunctionConfiguration.IsSetId())
							{
								xmlWriter.WriteElementString("Id", S3Transforms.ToXmlStringValue(lambdaFunctionConfiguration.Id));
							}
							if (lambdaFunctionConfiguration.IsSetFunctionArn())
							{
								xmlWriter.WriteElementString("CloudFunction", S3Transforms.ToXmlStringValue(lambdaFunctionConfiguration.FunctionArn));
							}
							WriteConfigurationCommon(xmlWriter, lambdaFunctionConfiguration);
							xmlWriter.WriteEndElement();
						}
					}
				}
				if (putBucketNotificationRequest.IsSetEventBridgeConfiguration())
				{
					xmlWriter.WriteStartElement("EventBridgeConfiguration");
					xmlWriter.WriteEndElement();
				}
				xmlWriter.WriteEndElement();
			}
			try
			{
				string s = xMLEncodedStringWriter.ToString();
				request.Content = Encoding.UTF8.GetBytes(s);
				request.Headers["Content-Type"] = "application/xml";
				ChecksumUtils.SetChecksumData(request, putBucketNotificationRequest.ChecksumAlgorithm, fallbackToMD5: false, isRequestChecksumRequired: true, S3Constants.AmzHeaderSdkChecksumAlgorithm);
				return request;
			}
			catch (EncoderFallbackException innerException)
			{
				throw new AmazonServiceException("Unable to marshall request to XML", innerException);
			}
		}

		private static void WriteConfigurationCommon(XmlWriter xmlWriter, NotificationConfiguration notificationConfiguration)
		{
			if (notificationConfiguration.IsSetEvents())
			{
				foreach (EventType @event in notificationConfiguration.Events)
				{
					xmlWriter.WriteElementString("Event", S3Transforms.ToXmlStringValue(@event));
				}
			}
			if (!notificationConfiguration.IsSetFilter())
			{
				return;
			}
			xmlWriter.WriteStartElement("Filter");
			Filter filter = notificationConfiguration.Filter;
			if (filter.IsSetS3KeyFilter())
			{
				xmlWriter.WriteStartElement("S3Key");
				S3KeyFilter s3KeyFilter = filter.S3KeyFilter;
				if (s3KeyFilter.IsSetFilterRules())
				{
					foreach (FilterRule filterRule in s3KeyFilter.FilterRules)
					{
						if (filterRule != null)
						{
							xmlWriter.WriteStartElement("FilterRule");
							xmlWriter.WriteElementString("Name", filterRule.Name);
							xmlWriter.WriteElementString("Value", filterRule.Value);
							xmlWriter.WriteEndElement();
						}
					}
				}
				xmlWriter.WriteEndElement();
			}
			xmlWriter.WriteEndElement();
		}
	}
}
