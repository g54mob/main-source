using System;
using System.Collections.Generic;
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
	public class PutBucketLoggingRequestMarshaller : IMarshaller<IRequest, PutBucketLoggingRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutBucketLoggingRequestMarshaller _instance;

		public static PutBucketLoggingRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutBucketLoggingRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutBucketLoggingRequest)input);
		}

		public IRequest Marshall(PutBucketLoggingRequest putBucketLoggingRequest)
		{
			IRequest request = new DefaultRequest(putBucketLoggingRequest, "AmazonS3");
			request.HttpMethod = "PUT";
			if (putBucketLoggingRequest.IsSetChecksumAlgorithm())
			{
				request.Headers.Add(S3Constants.AmzHeaderSdkChecksumAlgorithm, S3Transforms.ToStringValue(putBucketLoggingRequest.ChecksumAlgorithm));
			}
			if (putBucketLoggingRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(putBucketLoggingRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(putBucketLoggingRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "PutBucketLoggingRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("logging");
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				xmlWriter.WriteStartElement("BucketLoggingStatus", "http://s3.amazonaws.com/doc/2006-03-01/");
				S3BucketLoggingConfig loggingConfig = putBucketLoggingRequest.LoggingConfig;
				if (loggingConfig != null && loggingConfig != null)
				{
					S3BucketLoggingConfig s3BucketLoggingConfig = loggingConfig;
					if (s3BucketLoggingConfig != null && s3BucketLoggingConfig.IsSetTargetBucket())
					{
						xmlWriter.WriteStartElement("LoggingEnabled");
						xmlWriter.WriteElementString("TargetBucket", S3Transforms.ToXmlStringValue(s3BucketLoggingConfig.TargetBucketName));
						List<S3Grant> grants = s3BucketLoggingConfig.Grants;
						if (grants != null && grants.Count > 0)
						{
							xmlWriter.WriteStartElement("TargetGrants");
							foreach (S3Grant item in grants)
							{
								xmlWriter.WriteStartElement("Grant");
								if (item != null)
								{
									S3Grantee grantee = item.Grantee;
									if (grantee != null)
									{
										xmlWriter.WriteStartElement("xsi", "Grantee", "http://www.w3.org/2001/XMLSchema-instance");
										if (grantee.IsSetType())
										{
											xmlWriter.WriteAttributeString("xsi", "type", "http://www.w3.org/2001/XMLSchema-instance", grantee.Type.ToString());
										}
										if (grantee.IsSetDisplayName())
										{
											xmlWriter.WriteElementString("DisplayName", S3Transforms.ToXmlStringValue(grantee.DisplayName));
										}
										if (grantee.IsSetEmailAddress())
										{
											xmlWriter.WriteElementString("EmailAddress", S3Transforms.ToXmlStringValue(grantee.EmailAddress));
										}
										if (grantee.IsSetCanonicalUser())
										{
											xmlWriter.WriteElementString("ID", S3Transforms.ToXmlStringValue(grantee.CanonicalUser));
										}
										if (grantee.IsSetURI())
										{
											xmlWriter.WriteElementString("URI", S3Transforms.ToXmlStringValue(grantee.URI));
										}
										xmlWriter.WriteEndElement();
									}
									if (item.IsSetPermission())
									{
										xmlWriter.WriteElementString("Permission", S3Transforms.ToXmlStringValue(item.Permission));
									}
								}
								xmlWriter.WriteEndElement();
							}
							xmlWriter.WriteEndElement();
						}
						if (s3BucketLoggingConfig.TargetObjectKeyFormat != null)
						{
							xmlWriter.WriteStartElement("TargetObjectKeyFormat", "http://s3.amazonaws.com/doc/2006-03-01/");
							if (s3BucketLoggingConfig.TargetObjectKeyFormat.PartitionedPrefix != null)
							{
								xmlWriter.WriteStartElement("PartitionedPrefix", "http://s3.amazonaws.com/doc/2006-03-01/");
								if (s3BucketLoggingConfig.TargetObjectKeyFormat.PartitionedPrefix.IsSetPartitionDateSource())
								{
									xmlWriter.WriteElementString("PartitionDateSource", "http://s3.amazonaws.com/doc/2006-03-01/", StringUtils.FromString(s3BucketLoggingConfig.TargetObjectKeyFormat.PartitionedPrefix.PartitionDateSource));
								}
								xmlWriter.WriteEndElement();
							}
							if (s3BucketLoggingConfig.TargetObjectKeyFormat.SimplePrefix != null)
							{
								xmlWriter.WriteStartElement("SimplePrefix", "http://s3.amazonaws.com/doc/2006-03-01/");
								xmlWriter.WriteEndElement();
							}
							xmlWriter.WriteEndElement();
						}
						if (s3BucketLoggingConfig.IsSetTargetPrefix())
						{
							xmlWriter.WriteElementString("TargetPrefix", S3Transforms.ToXmlStringValue(s3BucketLoggingConfig.TargetPrefix));
						}
						else
						{
							xmlWriter.WriteStartElement("TargetPrefix");
							xmlWriter.WriteEndElement();
						}
						xmlWriter.WriteEndElement();
					}
				}
				xmlWriter.WriteEndElement();
			}
			try
			{
				string s = xMLEncodedStringWriter.ToString();
				request.Content = Encoding.UTF8.GetBytes(s);
				request.Headers["Content-Type"] = "application/xml";
				ChecksumUtils.SetChecksumData(request, putBucketLoggingRequest.ChecksumAlgorithm, fallbackToMD5: false, isRequestChecksumRequired: true, S3Constants.AmzHeaderSdkChecksumAlgorithm);
				return request;
			}
			catch (EncoderFallbackException innerException)
			{
				throw new AmazonServiceException("Unable to marshall request to XML", innerException);
			}
		}
	}
}
