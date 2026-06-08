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
	public class PutBucketVersioningRequestMarshaller : IMarshaller<IRequest, PutBucketVersioningRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutBucketVersioningRequestMarshaller _instance;

		public static PutBucketVersioningRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutBucketVersioningRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutBucketVersioningRequest)input);
		}

		public IRequest Marshall(PutBucketVersioningRequest putBucketVersioningRequest)
		{
			IRequest request = new DefaultRequest(putBucketVersioningRequest, "AmazonS3");
			request.HttpMethod = "PUT";
			if (putBucketVersioningRequest.IsSetChecksumAlgorithm())
			{
				request.Headers.Add(S3Constants.AmzHeaderSdkChecksumAlgorithm, S3Transforms.ToStringValue(putBucketVersioningRequest.ChecksumAlgorithm));
			}
			if (putBucketVersioningRequest.IsSetMfaCodes())
			{
				request.Headers.Add("x-amz-mfa", putBucketVersioningRequest.MfaCodes.FormattedMfaCodes);
			}
			if (putBucketVersioningRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(putBucketVersioningRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(putBucketVersioningRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "PutBucketVersioningRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("versioning");
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				S3BucketVersioningConfig versioningConfig = putBucketVersioningRequest.VersioningConfig;
				if (versioningConfig != null)
				{
					xmlWriter.WriteStartElement("VersioningConfiguration", "http://s3.amazonaws.com/doc/2006-03-01/");
					if (versioningConfig.IsSetEnableMfaDelete())
					{
						xmlWriter.WriteElementString("MfaDelete", versioningConfig.EnableMfaDelete.Value ? "Enabled" : "Disabled");
					}
					if (versioningConfig.IsSetStatus())
					{
						xmlWriter.WriteElementString("Status", S3Transforms.ToXmlStringValue(versioningConfig.Status));
					}
					xmlWriter.WriteEndElement();
				}
			}
			try
			{
				string s = xMLEncodedStringWriter.ToString();
				request.Content = Encoding.UTF8.GetBytes(s);
				request.Headers["Content-Type"] = "application/xml";
				ChecksumUtils.SetChecksumData(request, putBucketVersioningRequest.ChecksumAlgorithm, fallbackToMD5: false, isRequestChecksumRequired: true, S3Constants.AmzHeaderSdkChecksumAlgorithm);
				return request;
			}
			catch (EncoderFallbackException innerException)
			{
				throw new AmazonServiceException("Unable to marshall request to XML", innerException);
			}
		}
	}
}
