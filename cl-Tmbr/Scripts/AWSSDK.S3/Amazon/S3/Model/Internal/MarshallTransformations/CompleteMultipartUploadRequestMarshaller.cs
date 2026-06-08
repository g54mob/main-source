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
	public class CompleteMultipartUploadRequestMarshaller : IMarshaller<IRequest, CompleteMultipartUploadRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static CompleteMultipartUploadRequestMarshaller _instance;

		public static CompleteMultipartUploadRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new CompleteMultipartUploadRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((CompleteMultipartUploadRequest)input);
		}

		public IRequest Marshall(CompleteMultipartUploadRequest completeMultipartUploadRequest)
		{
			IRequest request = new DefaultRequest(completeMultipartUploadRequest, "AmazonS3");
			request.HttpMethod = "POST";
			if (completeMultipartUploadRequest.IsSetRequestPayer())
			{
				request.Headers.Add(S3Constants.AmzHeaderRequestPayer, S3Transforms.ToStringValue(completeMultipartUploadRequest.RequestPayer.ToString()));
			}
			if (completeMultipartUploadRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(completeMultipartUploadRequest.ExpectedBucketOwner));
			}
			if (completeMultipartUploadRequest.IsSetChecksumCRC32())
			{
				request.Headers["x-amz-checksum-crc32"] = completeMultipartUploadRequest.ChecksumCRC32;
			}
			if (completeMultipartUploadRequest.IsSetChecksumCRC32C())
			{
				request.Headers["x-amz-checksum-crc32c"] = completeMultipartUploadRequest.ChecksumCRC32C;
			}
			if (completeMultipartUploadRequest.IsSetChecksumCRC64NVME())
			{
				request.Headers["x-amz-checksum-crc64nvme"] = completeMultipartUploadRequest.ChecksumCRC64NVME;
			}
			if (completeMultipartUploadRequest.IsSetChecksumSHA1())
			{
				request.Headers["x-amz-checksum-sha1"] = completeMultipartUploadRequest.ChecksumSHA1;
			}
			if (completeMultipartUploadRequest.IsSetChecksumSHA256())
			{
				request.Headers["x-amz-checksum-sha256"] = completeMultipartUploadRequest.ChecksumSHA256;
			}
			if (completeMultipartUploadRequest.IsSetChecksumType())
			{
				request.Headers[S3Constants.AmzHeaderChecksumType] = completeMultipartUploadRequest.ChecksumType;
			}
			if (completeMultipartUploadRequest.IsSetMpuObjectSize())
			{
				request.Headers["x-amz-mp-object-size"] = S3Transforms.ToStringValue(completeMultipartUploadRequest.MpuObjectSize);
			}
			if (completeMultipartUploadRequest.IsSetSSECustomerAlgorithm())
			{
				request.Headers["x-amz-server-side-encryption-customer-algorithm"] = completeMultipartUploadRequest.SSECustomerAlgorithm;
			}
			if (completeMultipartUploadRequest.IsSetSSECustomerKey())
			{
				request.Headers["x-amz-server-side-encryption-customer-key"] = completeMultipartUploadRequest.SSECustomerKey;
			}
			if (completeMultipartUploadRequest.IsSetSSECustomerKeyMD5())
			{
				request.Headers["x-amz-server-side-encryption-customer-key-MD5"] = completeMultipartUploadRequest.SSECustomerKeyMD5;
			}
			if (completeMultipartUploadRequest.IsSetIfNoneMatch())
			{
				request.Headers["If-None-Match"] = completeMultipartUploadRequest.IfNoneMatch;
			}
			if (completeMultipartUploadRequest.IsSetIfMatch())
			{
				request.Headers["If-Match"] = completeMultipartUploadRequest.IfMatch;
			}
			if (string.IsNullOrEmpty(completeMultipartUploadRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "CompleteMultipartUploadRequest.BucketName");
			}
			if (string.IsNullOrEmpty(completeMultipartUploadRequest.Key))
			{
				throw new ArgumentException("Key is a required property and must be set before making this call.", "CompleteMultipartUploadRequest.Key");
			}
			request.AddPathResource("{Key+}", S3Transforms.ToStringValue(completeMultipartUploadRequest.Key));
			request.ResourcePath = "/{Key+}";
			request.AddSubResource("uploadId", S3Transforms.ToStringValue(completeMultipartUploadRequest.UploadId));
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				xmlWriter.WriteStartElement("CompleteMultipartUpload", "http://s3.amazonaws.com/doc/2006-03-01/");
				List<PartETag> partETags = completeMultipartUploadRequest.PartETags;
				if (partETags != null)
				{
					partETags.Sort();
					if (partETags != null && partETags.Count > 0)
					{
						foreach (PartETag item in partETags)
						{
							xmlWriter.WriteStartElement("Part");
							if (item.IsSetETag())
							{
								xmlWriter.WriteElementString("ETag", S3Transforms.ToXmlStringValue(item.ETag));
							}
							if (item.IsSetPartNumber())
							{
								xmlWriter.WriteElementString("PartNumber", S3Transforms.ToXmlStringValue(item.PartNumber.Value));
							}
							if (item.IsSetChecksumCRC32())
							{
								xmlWriter.WriteElementString("ChecksumCRC32", S3Transforms.ToXmlStringValue(item.ChecksumCRC32));
							}
							if (item.IsSetChecksumCRC32C())
							{
								xmlWriter.WriteElementString("ChecksumCRC32C", S3Transforms.ToXmlStringValue(item.ChecksumCRC32C));
							}
							if (item.IsSetChecksumCRC64NVME())
							{
								xmlWriter.WriteElementString("ChecksumCRC64NVME", S3Transforms.ToXmlStringValue(item.ChecksumCRC64NVME));
							}
							if (item.IsSetChecksumSHA1())
							{
								xmlWriter.WriteElementString("ChecksumSHA1", S3Transforms.ToXmlStringValue(item.ChecksumSHA1));
							}
							if (item.IsSetChecksumSHA256())
							{
								xmlWriter.WriteElementString("ChecksumSHA256", S3Transforms.ToXmlStringValue(item.ChecksumSHA256));
							}
							xmlWriter.WriteEndElement();
						}
					}
				}
				xmlWriter.WriteEndElement();
			}
			try
			{
				string s = xMLEncodedStringWriter.ToString();
				request.Content = Encoding.UTF8.GetBytes(s);
				request.Headers["Content-Type"] = "application/xml";
				ChecksumUtils.SetChecksumData(request);
				return request;
			}
			catch (EncoderFallbackException innerException)
			{
				throw new AmazonServiceException("Unable to marshall request to XML", innerException);
			}
		}
	}
}
