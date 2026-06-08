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
	public class DeleteObjectsRequestMarshaller : IMarshaller<IRequest, DeleteObjectsRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static DeleteObjectsRequestMarshaller _instance;

		public static DeleteObjectsRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new DeleteObjectsRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((DeleteObjectsRequest)input);
		}

		public IRequest Marshall(DeleteObjectsRequest deleteObjectsRequest)
		{
			IRequest request = new DefaultRequest(deleteObjectsRequest, "AmazonS3");
			request.HttpMethod = "POST";
			if (deleteObjectsRequest.IsSetBypassGovernanceRetention())
			{
				request.Headers.Add("x-amz-bypass-governance-retention", S3Transforms.ToStringValue(deleteObjectsRequest.BypassGovernanceRetention.Value));
			}
			if (deleteObjectsRequest.IsSetMfaCodes())
			{
				request.Headers.Add("x-amz-mfa", deleteObjectsRequest.MfaCodes.FormattedMfaCodes);
			}
			if (deleteObjectsRequest.IsSetRequestPayer())
			{
				request.Headers.Add(S3Constants.AmzHeaderRequestPayer, S3Transforms.ToStringValue(deleteObjectsRequest.RequestPayer.ToString()));
			}
			if (deleteObjectsRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(deleteObjectsRequest.ExpectedBucketOwner));
			}
			if (deleteObjectsRequest.IsSetChecksumAlgorithm())
			{
				request.Headers[S3Constants.AmzHeaderSdkChecksumAlgorithm] = S3Transforms.ToStringValue(deleteObjectsRequest.ChecksumAlgorithm);
			}
			if (string.IsNullOrEmpty(deleteObjectsRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "DeleteObjectsRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("delete");
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				xmlWriter.WriteStartElement("Delete", "http://s3.amazonaws.com/doc/2006-03-01/");
				List<KeyVersion> objects = deleteObjectsRequest.Objects;
				if (objects != null && objects.Count > 0)
				{
					foreach (KeyVersion item in objects)
					{
						xmlWriter.WriteStartElement("Object", "");
						if (item.IsSetKey())
						{
							xmlWriter.WriteElementString("Key", "", S3Transforms.ToXmlStringValue(item.Key));
						}
						if (item.IsSetVersionId())
						{
							xmlWriter.WriteElementString("VersionId", "", S3Transforms.ToXmlStringValue(item.VersionId));
						}
						if (item.IsSetETag())
						{
							xmlWriter.WriteElementString("ETag", "", S3Transforms.ToXmlStringValue(item.ETag));
						}
						if (item.IsSetLastModifiedTime())
						{
							xmlWriter.WriteElementString("LastModifiedTime", "", S3Transforms.ToXmlStringValue(item.LastModifiedTime.Value));
						}
						if (item.IsSetSize())
						{
							xmlWriter.WriteElementString("Size", "", S3Transforms.ToXmlStringValue(item.Size.Value));
						}
						xmlWriter.WriteEndElement();
					}
				}
				if (deleteObjectsRequest.IsSetQuiet())
				{
					xmlWriter.WriteElementString("Quiet", "", S3Transforms.ToXmlStringValue(deleteObjectsRequest.Quiet.Value));
				}
				xmlWriter.WriteEndElement();
			}
			try
			{
				string s = xMLEncodedStringWriter.ToString();
				request.Content = Encoding.UTF8.GetBytes(s);
				request.Headers["Content-Type"] = "application/xml";
				ChecksumUtils.SetChecksumData(request, deleteObjectsRequest.ChecksumAlgorithm, fallbackToMD5: false, isRequestChecksumRequired: true, S3Constants.AmzHeaderSdkChecksumAlgorithm);
				return request;
			}
			catch (EncoderFallbackException innerException)
			{
				throw new AmazonServiceException("Unable to marshall request to XML", innerException);
			}
		}
	}
}
