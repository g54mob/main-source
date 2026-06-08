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
	public class PutObjectLockConfigurationRequestMarshaller : IMarshaller<IRequest, PutObjectLockConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutObjectLockConfigurationRequestMarshaller _instance;

		public static PutObjectLockConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutObjectLockConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutObjectLockConfigurationRequest)input);
		}

		public IRequest Marshall(PutObjectLockConfigurationRequest publicRequest)
		{
			DefaultRequest defaultRequest = new DefaultRequest(publicRequest, "AmazonS3");
			defaultRequest.HttpMethod = "PUT";
			string resourcePath = "/";
			defaultRequest.AddSubResource("object-lock");
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
			if (publicRequest.IsSetToken())
			{
				defaultRequest.Headers.Add("x-amz-bucket-object-lock-token", publicRequest.Token);
			}
			if (publicRequest.IsSetExpectedBucketOwner())
			{
				defaultRequest.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(publicRequest.ExpectedBucketOwner));
			}
			if (!publicRequest.IsSetBucketName())
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "publicRequest.BucketName");
			}
			defaultRequest.ResourcePath = resourcePath;
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				if (publicRequest.IsSetObjectLockConfiguration())
				{
					xmlWriter.WriteStartElement("ObjectLockConfiguration", "http://s3.amazonaws.com/doc/2006-03-01/");
					if (publicRequest.ObjectLockConfiguration.IsSetObjectLockEnabled())
					{
						xmlWriter.WriteElementString("ObjectLockEnabled", StringUtils.FromString(publicRequest.ObjectLockConfiguration.ObjectLockEnabled));
					}
					if (publicRequest.ObjectLockConfiguration.Rule != null)
					{
						xmlWriter.WriteStartElement("Rule");
						if (publicRequest.ObjectLockConfiguration.Rule.DefaultRetention != null)
						{
							xmlWriter.WriteStartElement("DefaultRetention");
							if (publicRequest.ObjectLockConfiguration.Rule.DefaultRetention.IsSetDays())
							{
								xmlWriter.WriteElementString("Days", StringUtils.FromInt(publicRequest.ObjectLockConfiguration.Rule.DefaultRetention.Days));
							}
							if (publicRequest.ObjectLockConfiguration.Rule.DefaultRetention.IsSetMode())
							{
								xmlWriter.WriteElementString("Mode", StringUtils.FromString(publicRequest.ObjectLockConfiguration.Rule.DefaultRetention.Mode));
							}
							if (publicRequest.ObjectLockConfiguration.Rule.DefaultRetention.IsSetYears())
							{
								xmlWriter.WriteElementString("Years", StringUtils.FromInt(publicRequest.ObjectLockConfiguration.Rule.DefaultRetention.Years));
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
				defaultRequest.Content = Encoding.UTF8.GetBytes(s);
				defaultRequest.Headers["Content-Type"] = "application/xml";
				ChecksumUtils.SetChecksumData(defaultRequest, publicRequest.ChecksumAlgorithm, fallbackToMD5: false, isRequestChecksumRequired: true, S3Constants.AmzHeaderSdkChecksumAlgorithm);
				return defaultRequest;
			}
			catch (EncoderFallbackException innerException)
			{
				throw new AmazonServiceException("Unable to marshall request to XML", innerException);
			}
		}
	}
}
