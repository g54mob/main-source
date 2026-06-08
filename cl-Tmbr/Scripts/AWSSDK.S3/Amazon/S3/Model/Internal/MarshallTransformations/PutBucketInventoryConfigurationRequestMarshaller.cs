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
	public class PutBucketInventoryConfigurationRequestMarshaller : IMarshaller<IRequest, PutBucketInventoryConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutBucketInventoryConfigurationRequestMarshaller _instance;

		public static PutBucketInventoryConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutBucketInventoryConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutBucketInventoryConfigurationRequest)input);
		}

		public IRequest Marshall(PutBucketInventoryConfigurationRequest putBucketInventoryConfigurationRequest)
		{
			IRequest request = new DefaultRequest(putBucketInventoryConfigurationRequest, "AmazonS3");
			request.HttpMethod = "PUT";
			if (putBucketInventoryConfigurationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(putBucketInventoryConfigurationRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(putBucketInventoryConfigurationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "PutBucketInventoryConfigurationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("inventory");
			if (putBucketInventoryConfigurationRequest.IsSetInventoryId())
			{
				request.AddSubResource("id", S3Transforms.ToStringValue(putBucketInventoryConfigurationRequest.InventoryId));
			}
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				if (putBucketInventoryConfigurationRequest.IsSetInventoryConfiguration())
				{
					InventoryConfiguration inventoryConfiguration = putBucketInventoryConfigurationRequest.InventoryConfiguration;
					xmlWriter.WriteStartElement("InventoryConfiguration", "http://s3.amazonaws.com/doc/2006-03-01/");
					if (inventoryConfiguration != null)
					{
						if (inventoryConfiguration.IsSetDestination())
						{
							InventoryDestination destination = inventoryConfiguration.Destination;
							xmlWriter.WriteStartElement("Destination");
							if (destination.isSetS3BucketDestination())
							{
								InventoryS3BucketDestination s3BucketDestination = destination.S3BucketDestination;
								xmlWriter.WriteStartElement("S3BucketDestination");
								if (s3BucketDestination.IsSetAccountId())
								{
									xmlWriter.WriteElementString("AccountId", S3Transforms.ToXmlStringValue(s3BucketDestination.AccountId));
								}
								if (s3BucketDestination.IsSetBucketName())
								{
									xmlWriter.WriteElementString("Bucket", S3Transforms.ToXmlStringValue(s3BucketDestination.BucketName));
								}
								if (s3BucketDestination.IsSetInventoryFormat())
								{
									xmlWriter.WriteElementString("Format", S3Transforms.ToXmlStringValue(s3BucketDestination.InventoryFormat));
								}
								if (s3BucketDestination.IsSetPrefix())
								{
									xmlWriter.WriteElementString("Prefix", S3Transforms.ToXmlStringValue(s3BucketDestination.Prefix));
								}
								if (s3BucketDestination.IsSetInventoryEncryption())
								{
									xmlWriter.WriteStartElement("Encryption");
									InventoryEncryption inventoryEncryption = s3BucketDestination.InventoryEncryption;
									if (inventoryEncryption.IsSetSSEKMS())
									{
										xmlWriter.WriteStartElement("SSE-KMS");
										if (inventoryEncryption.SSEKMS.IsSetKeyId())
										{
											xmlWriter.WriteElementString("KeyId", S3Transforms.ToXmlStringValue(inventoryEncryption.SSEKMS.KeyId));
										}
										xmlWriter.WriteEndElement();
									}
									if (inventoryEncryption.IsSetSSES3())
									{
										xmlWriter.WriteStartElement("SSE-S3");
										xmlWriter.WriteEndElement();
									}
									xmlWriter.WriteEndElement();
								}
								xmlWriter.WriteEndElement();
							}
							xmlWriter.WriteEndElement();
						}
						xmlWriter.WriteElementString("IsEnabled", S3Transforms.ToXmlStringValue(inventoryConfiguration.IsEnabled == true));
						if (inventoryConfiguration.IsSetInventoryFilter())
						{
							xmlWriter.WriteStartElement("Filter");
							inventoryConfiguration.InventoryFilter.InventoryFilterPredicate.Accept(new InventoryPredicateVisitor(xmlWriter));
							xmlWriter.WriteEndElement();
						}
						if (inventoryConfiguration.IsSetInventoryId())
						{
							xmlWriter.WriteElementString("Id", S3Transforms.ToXmlStringValue(inventoryConfiguration.InventoryId));
						}
						if (inventoryConfiguration.IsSetIncludedObjectVersions())
						{
							xmlWriter.WriteElementString("IncludedObjectVersions", S3Transforms.ToXmlStringValue(inventoryConfiguration.IncludedObjectVersions));
						}
						if (inventoryConfiguration.IsSetInventoryOptionalFields())
						{
							xmlWriter.WriteStartElement("OptionalFields");
							foreach (InventoryOptionalField inventoryOptionalField in inventoryConfiguration.InventoryOptionalFields)
							{
								xmlWriter.WriteElementString("Field", S3Transforms.ToXmlStringValue(inventoryOptionalField));
							}
							xmlWriter.WriteEndElement();
						}
						if (inventoryConfiguration.IsSetSchedule())
						{
							xmlWriter.WriteStartElement("Schedule");
							InventorySchedule schedule = inventoryConfiguration.Schedule;
							if (schedule.IsFrequency())
							{
								xmlWriter.WriteElementString("Frequency", S3Transforms.ToXmlStringValue(schedule.Frequency));
							}
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
