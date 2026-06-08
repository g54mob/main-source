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
	public class PutBucketEncryptionRequestMarshaller : IMarshaller<IRequest, PutBucketEncryptionRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutBucketEncryptionRequestMarshaller _instance;

		public static PutBucketEncryptionRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutBucketEncryptionRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutBucketEncryptionRequest)input);
		}

		public IRequest Marshall(PutBucketEncryptionRequest putBucketEncryptionRequest)
		{
			IRequest request = new DefaultRequest(putBucketEncryptionRequest, "AmazonS3");
			request.HttpMethod = "PUT";
			if (putBucketEncryptionRequest.IsSetChecksumAlgorithm())
			{
				request.Headers.Add(S3Constants.AmzHeaderSdkChecksumAlgorithm, S3Transforms.ToStringValue(putBucketEncryptionRequest.ChecksumAlgorithm));
			}
			if (putBucketEncryptionRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(putBucketEncryptionRequest.ExpectedBucketOwner));
			}
			if (putBucketEncryptionRequest.IsSetContentMD5())
			{
				request.Headers.Add("Content-MD5", S3Transforms.ToStringValue(putBucketEncryptionRequest.ContentMD5));
			}
			if (string.IsNullOrEmpty(putBucketEncryptionRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "PutBucketEncryptionRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("encryption");
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				if (putBucketEncryptionRequest.IsSetServerSideEncryptionConfiguration())
				{
					ServerSideEncryptionConfiguration serverSideEncryptionConfiguration = putBucketEncryptionRequest.ServerSideEncryptionConfiguration;
					xmlWriter.WriteStartElement("ServerSideEncryptionConfiguration", "http://s3.amazonaws.com/doc/2006-03-01/");
					if (serverSideEncryptionConfiguration != null && serverSideEncryptionConfiguration.ServerSideEncryptionRules != null)
					{
						foreach (ServerSideEncryptionRule serverSideEncryptionRule in serverSideEncryptionConfiguration.ServerSideEncryptionRules)
						{
							xmlWriter.WriteStartElement("Rule");
							if (serverSideEncryptionRule != null)
							{
								if (serverSideEncryptionRule.IsSetServerSideEncryptionByDefault())
								{
									xmlWriter.WriteStartElement("ApplyServerSideEncryptionByDefault");
									ServerSideEncryptionByDefault serverSideEncryptionByDefault = serverSideEncryptionRule.ServerSideEncryptionByDefault;
									if (serverSideEncryptionByDefault.IsSetServerSideEncryptionAlgorithm())
									{
										xmlWriter.WriteElementString("SSEAlgorithm", S3Transforms.ToXmlStringValue(serverSideEncryptionByDefault.ServerSideEncryptionAlgorithm));
									}
									if (serverSideEncryptionByDefault.IsSetServerSideEncryptionKeyManagementServiceKeyId())
									{
										xmlWriter.WriteElementString("KMSMasterKeyID", S3Transforms.ToXmlStringValue(serverSideEncryptionByDefault.ServerSideEncryptionKeyManagementServiceKeyId));
									}
									xmlWriter.WriteEndElement();
								}
								if (serverSideEncryptionRule.IsSetBucketKeyEnabled())
								{
									xmlWriter.WriteElementString("BucketKeyEnabled", S3Transforms.ToXmlStringValue(serverSideEncryptionRule.BucketKeyEnabled.Value));
								}
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
				ChecksumUtils.SetChecksumData(request, putBucketEncryptionRequest.ChecksumAlgorithm, fallbackToMD5: false, isRequestChecksumRequired: true, S3Constants.AmzHeaderSdkChecksumAlgorithm);
				return request;
			}
			catch (EncoderFallbackException innerException)
			{
				throw new AmazonServiceException("Unable to marshall request to XML", innerException);
			}
		}
	}
}
