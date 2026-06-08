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
	public class PutBucketRequestPaymentRequestMarshaller : IMarshaller<IRequest, PutBucketRequestPaymentRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutBucketRequestPaymentRequestMarshaller _instance;

		public static PutBucketRequestPaymentRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutBucketRequestPaymentRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutBucketRequestPaymentRequest)input);
		}

		public IRequest Marshall(PutBucketRequestPaymentRequest putBucketRequestPaymentRequest)
		{
			IRequest request = new DefaultRequest(putBucketRequestPaymentRequest, "AmazonS3");
			request.HttpMethod = "PUT";
			if (putBucketRequestPaymentRequest.IsSetChecksumAlgorithm())
			{
				request.Headers.Add(S3Constants.AmzHeaderSdkChecksumAlgorithm, S3Transforms.ToStringValue(putBucketRequestPaymentRequest.ChecksumAlgorithm));
			}
			if (putBucketRequestPaymentRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(putBucketRequestPaymentRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(putBucketRequestPaymentRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "PutBucketRequestPaymentRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("requestPayment");
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				RequestPaymentConfiguration requestPaymentConfiguration = putBucketRequestPaymentRequest.RequestPaymentConfiguration;
				if (requestPaymentConfiguration != null)
				{
					xmlWriter.WriteStartElement("RequestPaymentConfiguration", "http://s3.amazonaws.com/doc/2006-03-01/");
					if (requestPaymentConfiguration.IsSetPayer())
					{
						xmlWriter.WriteElementString("Payer", S3Transforms.ToXmlStringValue(requestPaymentConfiguration.Payer));
					}
					xmlWriter.WriteEndElement();
				}
			}
			try
			{
				string s = xMLEncodedStringWriter.ToString();
				request.Content = Encoding.UTF8.GetBytes(s);
				request.Headers["Content-Type"] = "application/xml";
				ChecksumUtils.SetChecksumData(request, putBucketRequestPaymentRequest.ChecksumAlgorithm, fallbackToMD5: false, isRequestChecksumRequired: true, S3Constants.AmzHeaderSdkChecksumAlgorithm);
				return request;
			}
			catch (EncoderFallbackException innerException)
			{
				throw new AmazonServiceException("Unable to marshall request to XML", innerException);
			}
		}
	}
}
