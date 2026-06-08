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
	public class RestoreObjectRequestMarshaller : IMarshaller<IRequest, RestoreObjectRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static RestoreObjectRequestMarshaller _instance;

		public static RestoreObjectRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new RestoreObjectRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((RestoreObjectRequest)input);
		}

		public IRequest Marshall(RestoreObjectRequest restoreObjectRequest)
		{
			IRequest request = new DefaultRequest(restoreObjectRequest, "AmazonS3");
			request.HttpMethod = "POST";
			if (restoreObjectRequest.IsSetRequestPayer())
			{
				request.Headers.Add(S3Constants.AmzHeaderRequestPayer, S3Transforms.ToStringValue(restoreObjectRequest.RequestPayer.ToString()));
			}
			if (restoreObjectRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(restoreObjectRequest.ExpectedBucketOwner));
			}
			if (restoreObjectRequest.IsSetChecksumAlgorithm())
			{
				request.Headers.Add(S3Constants.AmzHeaderSdkChecksumAlgorithm, S3Transforms.ToStringValue(restoreObjectRequest.ChecksumAlgorithm));
			}
			if (string.IsNullOrEmpty(restoreObjectRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "RestoreObjectRequest.BucketName");
			}
			if (string.IsNullOrEmpty(restoreObjectRequest.Key))
			{
				throw new ArgumentException("Key is a required property and must be set before making this call.", "RestoreObjectRequest.Key");
			}
			request.ResourcePath = "/{Key+}";
			request.AddPathResource("{Key+}", S3Transforms.ToStringValue(restoreObjectRequest.Key));
			request.AddSubResource("restore");
			if (restoreObjectRequest.IsSetVersionId())
			{
				request.AddSubResource("versionId", S3Transforms.ToStringValue(restoreObjectRequest.VersionId));
			}
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				restoreObjectRequest.Marshall("RestoreRequest", xmlWriter);
			}
			try
			{
				string s = xMLEncodedStringWriter.ToString();
				request.Content = Encoding.UTF8.GetBytes(s);
				request.Headers["Content-Type"] = "application/xml";
				ChecksumUtils.SetChecksumData(request, restoreObjectRequest.ChecksumAlgorithm, fallbackToMD5: false, isRequestChecksumRequired: false, S3Constants.AmzHeaderSdkChecksumAlgorithm);
				return request;
			}
			catch (EncoderFallbackException innerException)
			{
				throw new AmazonServiceException("Unable to marshall request to XML", innerException);
			}
		}
	}
}
