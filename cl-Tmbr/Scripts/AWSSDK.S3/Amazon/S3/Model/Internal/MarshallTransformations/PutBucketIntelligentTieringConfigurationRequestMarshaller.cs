using System;
using System.Globalization;
using System.Text;
using System.Xml;
using Amazon.Runtime;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;

namespace Amazon.S3.Model.Internal.MarshallTransformations
{
	public class PutBucketIntelligentTieringConfigurationRequestMarshaller : IMarshaller<IRequest, PutBucketIntelligentTieringConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutBucketIntelligentTieringConfigurationRequestMarshaller _instance;

		public static PutBucketIntelligentTieringConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutBucketIntelligentTieringConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutBucketIntelligentTieringConfigurationRequest)input);
		}

		public IRequest Marshall(PutBucketIntelligentTieringConfigurationRequest PutBucketIntelligentTieringConfigurationRequest)
		{
			IRequest request = new DefaultRequest(PutBucketIntelligentTieringConfigurationRequest, "AmazonS3");
			IntelligentTieringConfiguration intelligentTieringConfiguration = PutBucketIntelligentTieringConfigurationRequest.IntelligentTieringConfiguration;
			request.HttpMethod = "PUT";
			if (string.IsNullOrEmpty(PutBucketIntelligentTieringConfigurationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "PutBucketIntelligentTieringConfigurationRequest.BucketName");
			}
			if (intelligentTieringConfiguration == null)
			{
				throw new ArgumentException("IntelligentTieringConfiguration is a required property and must be set before making this call.", "PutBucketIntelligentTieringConfigurationRequest.IntelligentTieringConfiguration");
			}
			if (string.IsNullOrEmpty(intelligentTieringConfiguration.IntelligentTieringId))
			{
				throw new ArgumentException("IntelligentTieringId is a required property and must be set before making this call.", "IntelligentTieringConfiguration.IntelligentTieringId");
			}
			if (string.IsNullOrEmpty(PutBucketIntelligentTieringConfigurationRequest.IntelligentTieringId))
			{
				throw new ArgumentException("IntelligentTieringId is a required property and must be set before making this call.", "PutBucketIntelligentTieringConfigurationRequest.IntelligentTieringId");
			}
			if (!intelligentTieringConfiguration.IsSetStatus())
			{
				throw new ArgumentException("Status is a required property and must be set before making this call.", "IntelligentTieringConfiguration.Status");
			}
			if (!intelligentTieringConfiguration.IsSetTieringList())
			{
				throw new ArgumentException("TieringList is a required property and must be set before making this call.", "IntelligentTieringConfiguration.TieringList");
			}
			request.ResourcePath = "/";
			request.AddSubResource("intelligent-tiering");
			request.AddSubResource("id", PutBucketIntelligentTieringConfigurationRequest.IntelligentTieringId);
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				if (intelligentTieringConfiguration != null)
				{
					xmlWriter.WriteStartElement("IntelligentTieringConfiguration", "http://s3.amazonaws.com/doc/2006-03-01/");
					if (intelligentTieringConfiguration != null)
					{
						if (intelligentTieringConfiguration.IsSetIntelligentTieringId())
						{
							xmlWriter.WriteElementString("Id", S3Transforms.ToXmlStringValue(intelligentTieringConfiguration.IntelligentTieringId));
						}
						if (intelligentTieringConfiguration.IsSetIntelligentTieringFilter())
						{
							xmlWriter.WriteStartElement("Filter");
							intelligentTieringConfiguration.IntelligentTieringFilter.IntelligentTieringFilterPredicate.Accept(new IntelligentTieringPredicateVisitor(xmlWriter));
							xmlWriter.WriteEndElement();
						}
						if (intelligentTieringConfiguration.IsSetStatus())
						{
							xmlWriter.WriteElementString("Status", S3Transforms.ToXmlStringValue(intelligentTieringConfiguration.Status));
						}
						if (intelligentTieringConfiguration.IsSetTieringList())
						{
							foreach (Tiering tiering in intelligentTieringConfiguration.Tierings)
							{
								if (tiering != null)
								{
									xmlWriter.WriteStartElement("Tiering");
									xmlWriter.WriteElementString("Days", S3Transforms.ToXmlStringValue(tiering.Days.Value));
									xmlWriter.WriteElementString("AccessTier", S3Transforms.ToXmlStringValue(tiering.AccessTier));
									xmlWriter.WriteEndElement();
								}
							}
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
