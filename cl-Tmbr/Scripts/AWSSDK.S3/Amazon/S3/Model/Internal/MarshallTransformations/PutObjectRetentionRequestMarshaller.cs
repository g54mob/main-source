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
	public class PutObjectRetentionRequestMarshaller : IMarshaller<IRequest, PutObjectRetentionRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutObjectRetentionRequestMarshaller _instance;

		public static PutObjectRetentionRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutObjectRetentionRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutObjectRetentionRequest)input);
		}

		public IRequest Marshall(PutObjectRetentionRequest publicRequest)
		{
			DefaultRequest defaultRequest = new DefaultRequest(publicRequest, "AmazonS3");
			defaultRequest.HttpMethod = "PUT";
			defaultRequest.AddSubResource("retention");
			if (publicRequest.IsSetBypassGovernanceRetention())
			{
				defaultRequest.Headers.Add("x-amz-bypass-governance-retention", S3Transforms.ToStringValue(publicRequest.BypassGovernanceRetention.Value));
			}
			if (publicRequest.IsSetChecksumAlgorithm())
			{
				defaultRequest.Headers.Add(S3Constants.AmzHeaderSdkChecksumAlgorithm, S3Transforms.ToStringValue(publicRequest.ChecksumAlgorithm));
			}
			if (publicRequest.IsSetContentMD5())
			{
				defaultRequest.Headers.Add("Content-MD5", S3Transforms.ToStringValue(publicRequest.ContentMD5));
			}
			if (publicRequest.IsSetRequestPayer())
			{
				defaultRequest.Headers.Add(S3Constants.AmzHeaderRequestPayer, S3Transforms.ToStringValue(publicRequest.RequestPayer.ToString()));
			}
			if (publicRequest.IsSetExpectedBucketOwner())
			{
				defaultRequest.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(publicRequest.ExpectedBucketOwner));
			}
			if (!publicRequest.IsSetBucketName())
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "publicRequest.BucketName");
			}
			if (!publicRequest.IsSetKey())
			{
				throw new ArgumentException("Key is a required property and must be set before making this call.", "publicRequest.Key");
			}
			defaultRequest.AddPathResource("{Key+}", publicRequest.Key);
			if (publicRequest.IsSetVersionId())
			{
				defaultRequest.Parameters.Add("versionId", StringUtils.FromString(publicRequest.VersionId));
			}
			defaultRequest.ResourcePath = "/{Key+}";
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				if (publicRequest.IsSetRetention())
				{
					xmlWriter.WriteStartElement("Retention", "http://s3.amazonaws.com/doc/2006-03-01/");
					if (publicRequest.Retention.IsSetMode())
					{
						xmlWriter.WriteElementString("Mode", StringUtils.FromString(publicRequest.Retention.Mode));
					}
					if (publicRequest.Retention.IsSetRetainUntilDate())
					{
						xmlWriter.WriteElementString("RetainUntilDate", StringUtils.FromDateTimeToISO8601WithOptionalMs(publicRequest.Retention.RetainUntilDate.Value));
					}
					xmlWriter.WriteEndElement();
				}
			}
			try
			{
				string s = xMLEncodedStringWriter.ToString();
				defaultRequest.Content = Encoding.UTF8.GetBytes(s);
				defaultRequest.Headers["Content-Type"] = "application/xml";
				ChecksumUtils.SetChecksumData(defaultRequest, publicRequest.ChecksumAlgorithm, fallbackToMD5: false, isRequestChecksumRequired: true, S3Constants.AmzHeaderSdkChecksumAlgorithm);
			}
			catch (EncoderFallbackException innerException)
			{
				throw new AmazonServiceException("Unable to marshall request to XML", innerException);
			}
			defaultRequest.UseQueryString = true;
			return defaultRequest;
		}
	}
}
