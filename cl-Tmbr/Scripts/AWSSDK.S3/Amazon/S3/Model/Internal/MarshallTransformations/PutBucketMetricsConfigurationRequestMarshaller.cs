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
	public class PutBucketMetricsConfigurationRequestMarshaller : IMarshaller<IRequest, PutBucketMetricsConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutBucketMetricsConfigurationRequestMarshaller _instance;

		public static PutBucketMetricsConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutBucketMetricsConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutBucketMetricsConfigurationRequest)input);
		}

		public IRequest Marshall(PutBucketMetricsConfigurationRequest PutBucketMetricsConfigurationRequest)
		{
			IRequest request = new DefaultRequest(PutBucketMetricsConfigurationRequest, "AmazonS3");
			request.HttpMethod = "PUT";
			if (PutBucketMetricsConfigurationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(PutBucketMetricsConfigurationRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(PutBucketMetricsConfigurationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "PutBucketMetricsConfigurationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("metrics");
			request.AddSubResource("id", PutBucketMetricsConfigurationRequest.MetricsId);
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				MetricsConfiguration metricsConfiguration = PutBucketMetricsConfigurationRequest.MetricsConfiguration;
				if (metricsConfiguration != null)
				{
					xmlWriter.WriteStartElement("MetricsConfiguration", "http://s3.amazonaws.com/doc/2006-03-01/");
					if (metricsConfiguration != null)
					{
						if (metricsConfiguration.IsSetMetricsId())
						{
							xmlWriter.WriteElementString("Id", "http://s3.amazonaws.com/doc/2006-03-01/", S3Transforms.ToXmlStringValue(metricsConfiguration.MetricsId));
						}
						if (metricsConfiguration.IsSetMetricsFilter())
						{
							xmlWriter.WriteStartElement("Filter", "http://s3.amazonaws.com/doc/2006-03-01/");
							metricsConfiguration.MetricsFilter.MetricsFilterPredicate.Accept(new MetricsPredicateVisitor(xmlWriter));
							xmlWriter.WriteEndElement();
						}
					}
					xmlWriter.WriteEndElement();
				}
			}
			try
			{
				string s = xMLEncodedStringWriter.ToString();
				request.Content = Encoding.UTF8.GetBytes(s);
				request.Headers["Content-Type"] = "application/xml";
				ChecksumUtils.SetChecksumData(request);
				return request;
			}
			catch (EncoderFallbackException innerException)
			{
				throw new AmazonServiceException("Unable to marshall request to XML", innerException);
			}
		}
	}
}
