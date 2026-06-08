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
	public class PutBucketAccelerateConfigurationRequestMarshaller : IMarshaller<IRequest, PutBucketAccelerateConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutBucketAccelerateConfigurationRequestMarshaller _instance;

		public static PutBucketAccelerateConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutBucketAccelerateConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutBucketAccelerateConfigurationRequest)input);
		}

		public IRequest Marshall(PutBucketAccelerateConfigurationRequest putBucketAccelerateRequest)
		{
			IRequest request = new DefaultRequest(putBucketAccelerateRequest, "AmazonS3");
			request.HttpMethod = "PUT";
			if (putBucketAccelerateRequest.IsSetChecksumAlgorithm())
			{
				request.Headers.Add(S3Constants.AmzHeaderSdkChecksumAlgorithm, S3Transforms.ToStringValue(putBucketAccelerateRequest.ChecksumAlgorithm));
			}
			if (putBucketAccelerateRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(putBucketAccelerateRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(putBucketAccelerateRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "PutBucketAccelerateConfigurationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("accelerate");
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				AccelerateConfiguration accelerateConfiguration = putBucketAccelerateRequest.AccelerateConfiguration;
				if (accelerateConfiguration != null)
				{
					xmlWriter.WriteStartElement("AccelerateConfiguration", "http://s3.amazonaws.com/doc/2006-03-01/");
					BucketAccelerateStatus status = accelerateConfiguration.Status;
					if (accelerateConfiguration.IsSetBucketAccelerateStatus() && status != null)
					{
						xmlWriter.WriteElementString("Status", S3Transforms.ToXmlStringValue(accelerateConfiguration.Status));
					}
					xmlWriter.WriteEndElement();
				}
			}
			try
			{
				string s = xMLEncodedStringWriter.ToString();
				request.Content = Encoding.UTF8.GetBytes(s);
				request.Headers["Content-Type"] = "application/xml";
				ChecksumUtils.SetChecksumData(request, putBucketAccelerateRequest.ChecksumAlgorithm, fallbackToMD5: false, isRequestChecksumRequired: false, S3Constants.AmzHeaderSdkChecksumAlgorithm);
				return request;
			}
			catch (EncoderFallbackException innerException)
			{
				throw new AmazonServiceException("Unable to marshall request to XML", innerException);
			}
		}
	}
}
