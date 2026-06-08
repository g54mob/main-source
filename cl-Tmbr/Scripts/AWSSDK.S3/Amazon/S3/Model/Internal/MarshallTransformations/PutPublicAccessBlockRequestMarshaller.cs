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
	public class PutPublicAccessBlockRequestMarshaller : IMarshaller<IRequest, PutPublicAccessBlockRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutPublicAccessBlockRequestMarshaller _instance;

		public static PutPublicAccessBlockRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutPublicAccessBlockRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutPublicAccessBlockRequest)input);
		}

		public IRequest Marshall(PutPublicAccessBlockRequest putPutPublicAccessBlockRequest)
		{
			IRequest request = new DefaultRequest(putPutPublicAccessBlockRequest, "AmazonS3");
			request.HttpMethod = "PUT";
			if (putPutPublicAccessBlockRequest.IsSetChecksumAlgorithm())
			{
				request.Headers.Add(S3Constants.AmzHeaderSdkChecksumAlgorithm, S3Transforms.ToStringValue(putPutPublicAccessBlockRequest.ChecksumAlgorithm));
			}
			if (putPutPublicAccessBlockRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(putPutPublicAccessBlockRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(putPutPublicAccessBlockRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "putPutPublicAccessBlockRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("publicAccessBlock");
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				PublicAccessBlockConfiguration publicAccessBlockConfiguration = putPutPublicAccessBlockRequest.PublicAccessBlockConfiguration;
				if (publicAccessBlockConfiguration != null)
				{
					xmlWriter.WriteStartElement("PublicAccessBlockConfiguration", "http://s3.amazonaws.com/doc/2006-03-01/");
					if (publicAccessBlockConfiguration.IsSetBlockPublicAcls())
					{
						xmlWriter.WriteElementString("BlockPublicAcls", S3Transforms.ToXmlStringValue(publicAccessBlockConfiguration.BlockPublicAcls.Value));
					}
					if (publicAccessBlockConfiguration.IsSetIgnorePublicAcls())
					{
						xmlWriter.WriteElementString("IgnorePublicAcls", S3Transforms.ToXmlStringValue(publicAccessBlockConfiguration.IgnorePublicAcls.Value));
					}
					if (publicAccessBlockConfiguration.IsSetBlockPublicPolicy())
					{
						xmlWriter.WriteElementString("BlockPublicPolicy", S3Transforms.ToXmlStringValue(publicAccessBlockConfiguration.BlockPublicPolicy.Value));
					}
					if (publicAccessBlockConfiguration.IsSetRestrictPublicBuckets())
					{
						xmlWriter.WriteElementString("RestrictPublicBuckets", S3Transforms.ToXmlStringValue(publicAccessBlockConfiguration.RestrictPublicBuckets.Value));
					}
					xmlWriter.WriteEndElement();
				}
			}
			try
			{
				string s = xMLEncodedStringWriter.ToString();
				request.Content = Encoding.UTF8.GetBytes(s);
				request.Headers["Content-Type"] = "application/xml";
				ChecksumUtils.SetChecksumData(request, putPutPublicAccessBlockRequest.ChecksumAlgorithm, fallbackToMD5: false, isRequestChecksumRequired: true, S3Constants.AmzHeaderSdkChecksumAlgorithm);
				return request;
			}
			catch (EncoderFallbackException innerException)
			{
				throw new AmazonServiceException("Unable to marshall request to XML", innerException);
			}
		}
	}
}
