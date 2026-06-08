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
	public class PutACLRequestMarshaller : IMarshaller<IRequest, PutACLRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutACLRequestMarshaller _instance;

		public static PutACLRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutACLRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutACLRequest)input);
		}

		public IRequest Marshall(PutACLRequest putObjectAclRequest)
		{
			IRequest request = new DefaultRequest(putObjectAclRequest, "AmazonS3");
			request.HttpMethod = "PUT";
			if (putObjectAclRequest.IsSetCannedACL())
			{
				request.Headers.Add("x-amz-acl", S3Transforms.ToStringValue(putObjectAclRequest.CannedACL));
			}
			if (putObjectAclRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(putObjectAclRequest.ExpectedBucketOwner));
			}
			if (putObjectAclRequest.IsSetChecksumAlgorithm())
			{
				request.Headers.Add(S3Constants.AmzHeaderSdkChecksumAlgorithm, S3Transforms.ToStringValue(putObjectAclRequest.ChecksumAlgorithm));
			}
			if (string.IsNullOrEmpty(putObjectAclRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "PutACLRequest.BucketName");
			}
			request.ResourcePath = "/{Key+}";
			request.AddPathResource("{Key+}", S3Transforms.ToStringValue(putObjectAclRequest.Key));
			request.AddSubResource("acl");
			if (putObjectAclRequest.IsSetVersionId())
			{
				request.AddSubResource("versionId", S3Transforms.ToStringValue(putObjectAclRequest.VersionId));
			}
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				S3AccessControlList accessControlList = putObjectAclRequest.AccessControlList;
				if (accessControlList != null)
				{
					xmlWriter.WriteStartElement("AccessControlPolicy", "http://s3.amazonaws.com/doc/2006-03-01/");
					List<S3Grant> grants = accessControlList.Grants;
					if (grants != null && grants.Count > 0)
					{
						accessControlList.Marshall("AccessControlList", xmlWriter);
						Owner owner = accessControlList.Owner;
						if (owner != null)
						{
							xmlWriter.WriteStartElement("Owner");
							if (owner.IsSetDisplayName())
							{
								xmlWriter.WriteElementString("DisplayName", S3Transforms.ToXmlStringValue(owner.DisplayName));
							}
							if (owner.IsSetId())
							{
								xmlWriter.WriteElementString("ID", S3Transforms.ToXmlStringValue(owner.Id));
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
				ChecksumUtils.SetChecksumData(request, putObjectAclRequest.ChecksumAlgorithm, fallbackToMD5: false, isRequestChecksumRequired: true, S3Constants.AmzHeaderSdkChecksumAlgorithm);
				return request;
			}
			catch (EncoderFallbackException innerException)
			{
				throw new AmazonServiceException("Unable to marshall request to XML", innerException);
			}
		}
	}
}
