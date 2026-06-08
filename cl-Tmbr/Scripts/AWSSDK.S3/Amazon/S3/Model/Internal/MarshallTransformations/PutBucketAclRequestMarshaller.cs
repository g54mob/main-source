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
	public class PutBucketAclRequestMarshaller : IMarshaller<IRequest, PutBucketAclRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutBucketAclRequestMarshaller _instance = new PutBucketAclRequestMarshaller();

		public static PutBucketAclRequestMarshaller Instance => _instance;

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutBucketAclRequest)input);
		}

		public IRequest Marshall(PutBucketAclRequest publicRequest)
		{
			DefaultRequest defaultRequest = new DefaultRequest(publicRequest, "Amazon.S3");
			defaultRequest.HttpMethod = "PUT";
			defaultRequest.AddSubResource("acl");
			if (publicRequest.IsSetACL())
			{
				defaultRequest.Headers["x-amz-acl"] = publicRequest.ACL;
			}
			if (publicRequest.IsSetChecksumAlgorithm())
			{
				defaultRequest.Headers["x-amz-sdk-checksum-algorithm"] = publicRequest.ChecksumAlgorithm;
			}
			if (publicRequest.IsSetContentMD5())
			{
				defaultRequest.Headers["Content-MD5"] = publicRequest.ContentMD5;
			}
			if (publicRequest.IsSetExpectedBucketOwner())
			{
				defaultRequest.Headers["x-amz-expected-bucket-owner"] = publicRequest.ExpectedBucketOwner;
			}
			if (publicRequest.IsSetGrantFullControl())
			{
				defaultRequest.Headers["x-amz-grant-full-control"] = publicRequest.GrantFullControl;
			}
			if (publicRequest.IsSetGrantRead())
			{
				defaultRequest.Headers["x-amz-grant-read"] = publicRequest.GrantRead;
			}
			if (publicRequest.IsSetGrantReadACP())
			{
				defaultRequest.Headers["x-amz-grant-read-acp"] = publicRequest.GrantReadACP;
			}
			if (publicRequest.IsSetGrantWrite())
			{
				defaultRequest.Headers["x-amz-grant-write"] = publicRequest.GrantWrite;
			}
			if (publicRequest.IsSetGrantWriteACP())
			{
				defaultRequest.Headers["x-amz-grant-write-acp"] = publicRequest.GrantWriteACP;
			}
			if (!publicRequest.IsSetBucketName())
			{
				throw new AmazonS3Exception("Request object does not have required field BucketName set");
			}
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				if (publicRequest.IsSetAccessControlPolicy())
				{
					xmlWriter.WriteStartElement("AccessControlPolicy", "http://s3.amazonaws.com/doc/2006-03-01/");
					List<S3Grant> grants = publicRequest.AccessControlPolicy.Grants;
					if (grants != null && (grants.Count > 0 || !AWSConfigs.InitializeCollections))
					{
						xmlWriter.WriteStartElement("AccessControlList");
						foreach (S3Grant item in grants)
						{
							xmlWriter.WriteStartElement("Grant");
							if (item == null)
							{
								continue;
							}
							if (item.Grantee != null)
							{
								xmlWriter.WriteStartElement("xsi", "Grantee", "http://www.w3.org/2001/XMLSchema-instance");
								if (item.Grantee.IsSetType())
								{
									xmlWriter.WriteAttributeString("xsi", "type", "http://www.w3.org/2001/XMLSchema-instance", S3Transforms.ToXmlStringValue(item.Grantee.Type));
								}
								if (item.Grantee.IsSetDisplayName())
								{
									xmlWriter.WriteElementString("DisplayName", S3Transforms.ToXmlStringValue(item.Grantee.DisplayName));
								}
								if (item.Grantee.IsSetEmailAddress())
								{
									xmlWriter.WriteElementString("EmailAddress", S3Transforms.ToXmlStringValue(item.Grantee.EmailAddress));
								}
								if (item.Grantee.IsSetCanonicalUser())
								{
									xmlWriter.WriteElementString("ID", S3Transforms.ToXmlStringValue(item.Grantee.CanonicalUser));
								}
								if (item.Grantee.IsSetURI())
								{
									xmlWriter.WriteElementString("URI", S3Transforms.ToXmlStringValue(item.Grantee.URI));
								}
								xmlWriter.WriteEndElement();
							}
							if (item.IsSetPermission())
							{
								xmlWriter.WriteElementString("Permission", S3Transforms.ToXmlStringValue(item.Permission));
							}
							xmlWriter.WriteEndElement();
						}
						xmlWriter.WriteEndElement();
					}
					if (publicRequest.AccessControlPolicy.Owner != null)
					{
						xmlWriter.WriteStartElement("Owner");
						if (publicRequest.AccessControlPolicy.Owner.IsSetDisplayName())
						{
							xmlWriter.WriteElementString("DisplayName", S3Transforms.ToXmlStringValue(publicRequest.AccessControlPolicy.Owner.DisplayName));
						}
						if (publicRequest.AccessControlPolicy.Owner.IsSetId())
						{
							xmlWriter.WriteElementString("ID", S3Transforms.ToXmlStringValue(publicRequest.AccessControlPolicy.Owner.Id));
						}
						xmlWriter.WriteEndElement();
					}
					xmlWriter.WriteEndElement();
				}
			}
			try
			{
				string s = xMLEncodedStringWriter.ToString();
				defaultRequest.Content = Encoding.UTF8.GetBytes(s);
				defaultRequest.Headers["Content-Type"] = "application/xml";
				ChecksumUtils.SetChecksumData(defaultRequest, publicRequest.ChecksumAlgorithm, fallbackToMD5: false, isRequestChecksumRequired: true, S3Constants.AmzHeaderSdkChecksumAlgorithm);
				return defaultRequest;
			}
			catch (EncoderFallbackException innerException)
			{
				throw new AmazonServiceException("Unable to marshall request to XML", innerException);
			}
		}

		internal static PutBucketAclRequestMarshaller GetInstance()
		{
			return _instance;
		}
	}
}
