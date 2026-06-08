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
	public class PutBucketAnalyticsConfigurationRequestMarshaller : IMarshaller<IRequest, PutBucketAnalyticsConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutBucketAnalyticsConfigurationRequestMarshaller _instance;

		public static PutBucketAnalyticsConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutBucketAnalyticsConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutBucketAnalyticsConfigurationRequest)input);
		}

		public IRequest Marshall(PutBucketAnalyticsConfigurationRequest putBucketAnalyticsConfigurationRequest)
		{
			IRequest request = new DefaultRequest(putBucketAnalyticsConfigurationRequest, "AmazonS3");
			request.HttpMethod = "PUT";
			if (putBucketAnalyticsConfigurationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(putBucketAnalyticsConfigurationRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(putBucketAnalyticsConfigurationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "PutBucketAnalyticsConfigurationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("analytics");
			if (putBucketAnalyticsConfigurationRequest.IsSetAnalyticsId())
			{
				request.AddSubResource("id", S3Transforms.ToStringValue(putBucketAnalyticsConfigurationRequest.AnalyticsId));
			}
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				if (putBucketAnalyticsConfigurationRequest.IsSetAnalyticsConfiguration())
				{
					AnalyticsConfiguration analyticsConfiguration = putBucketAnalyticsConfigurationRequest.AnalyticsConfiguration;
					xmlWriter.WriteStartElement("AnalyticsConfiguration", "http://s3.amazonaws.com/doc/2006-03-01/");
					if (analyticsConfiguration.IsSetAnalyticsId())
					{
						xmlWriter.WriteElementString("Id", analyticsConfiguration.AnalyticsId);
					}
					if (analyticsConfiguration.IsSetAnalyticsFilter())
					{
						xmlWriter.WriteStartElement("Filter");
						analyticsConfiguration.AnalyticsFilter.AnalyticsFilterPredicate.Accept(new AnalyticsPredicateVisitor(xmlWriter));
						xmlWriter.WriteEndElement();
					}
					if (analyticsConfiguration.IsSetStorageClassAnalysis() && analyticsConfiguration.IsSetStorageClassAnalysis())
					{
						StorageClassAnalysis storageClassAnalysis = analyticsConfiguration.StorageClassAnalysis;
						xmlWriter.WriteStartElement("StorageClassAnalysis");
						if (storageClassAnalysis.IsSetDataExport())
						{
							xmlWriter.WriteStartElement("DataExport");
							StorageClassAnalysisDataExport dataExport = storageClassAnalysis.DataExport;
							if (dataExport.IsSetOutputSchemaVersion())
							{
								StorageClassAnalysisSchemaVersion outputSchemaVersion = dataExport.OutputSchemaVersion;
								if (outputSchemaVersion != null)
								{
									xmlWriter.WriteElementString("OutputSchemaVersion", outputSchemaVersion);
								}
							}
							if (dataExport.IsSetDestination())
							{
								xmlWriter.WriteStartElement("Destination");
								AnalyticsExportDestination destination = dataExport.Destination;
								if (destination.IsSetS3BucketDestination())
								{
									xmlWriter.WriteStartElement("S3BucketDestination");
									AnalyticsS3BucketDestination s3BucketDestination = destination.S3BucketDestination;
									if (s3BucketDestination.IsSetFormat())
									{
										xmlWriter.WriteElementString("Format", s3BucketDestination.Format);
									}
									if (s3BucketDestination.IsSetBucketAccountId())
									{
										xmlWriter.WriteElementString("BucketAccountId", s3BucketDestination.BucketAccountId);
									}
									if (s3BucketDestination.IsSetBucketName())
									{
										xmlWriter.WriteElementString("Bucket", s3BucketDestination.BucketName);
									}
									if (s3BucketDestination.IsSetPrefix())
									{
										xmlWriter.WriteElementString("Prefix", s3BucketDestination.Prefix);
									}
									xmlWriter.WriteEndElement();
								}
								xmlWriter.WriteEndElement();
							}
							xmlWriter.WriteEndElement();
						}
						xmlWriter.WriteEndElement();
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
