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
	public class PutBucketTaggingRequestMarshaller : IMarshaller<IRequest, PutBucketTaggingRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutBucketTaggingRequestMarshaller _instance;

		public static PutBucketTaggingRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutBucketTaggingRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutBucketTaggingRequest)input);
		}

		public IRequest Marshall(PutBucketTaggingRequest putBucketTaggingRequest)
		{
			IRequest request = new DefaultRequest(putBucketTaggingRequest, "AmazonS3");
			request.HttpMethod = "PUT";
			if (putBucketTaggingRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(putBucketTaggingRequest.ExpectedBucketOwner));
			}
			if (putBucketTaggingRequest.IsSetChecksumAlgorithm())
			{
				request.Headers.Add(S3Constants.AmzHeaderSdkChecksumAlgorithm, S3Transforms.ToStringValue(putBucketTaggingRequest.ChecksumAlgorithm));
			}
			if (string.IsNullOrEmpty(putBucketTaggingRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "PutBucketTaggingRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("tagging");
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				xmlWriter.WriteStartElement("Tagging", "http://s3.amazonaws.com/doc/2006-03-01/");
				List<Tag> tagSet = putBucketTaggingRequest.TagSet;
				if (tagSet != null && tagSet.Count > 0)
				{
					xmlWriter.WriteStartElement("TagSet");
					foreach (Tag item in tagSet)
					{
						item.Marshall("Tag", xmlWriter);
					}
					xmlWriter.WriteEndElement();
				}
				xmlWriter.WriteEndElement();
			}
			try
			{
				string s = xMLEncodedStringWriter.ToString();
				request.Content = Encoding.UTF8.GetBytes(s);
				request.Headers["Content-Type"] = "application/xml";
				ChecksumUtils.SetChecksumData(request, putBucketTaggingRequest.ChecksumAlgorithm, fallbackToMD5: false, isRequestChecksumRequired: true, S3Constants.AmzHeaderSdkChecksumAlgorithm);
				return request;
			}
			catch (EncoderFallbackException innerException)
			{
				throw new AmazonServiceException("Unable to marshall request to XML", innerException);
			}
		}
	}
}
