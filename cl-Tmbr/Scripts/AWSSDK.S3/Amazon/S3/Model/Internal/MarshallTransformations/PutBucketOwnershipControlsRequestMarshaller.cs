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
	public class PutBucketOwnershipControlsRequestMarshaller : IMarshaller<IRequest, PutBucketOwnershipControlsRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutBucketOwnershipControlsRequestMarshaller _instance;

		public static PutBucketOwnershipControlsRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutBucketOwnershipControlsRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutBucketOwnershipControlsRequest)input);
		}

		public IRequest Marshall(PutBucketOwnershipControlsRequest putBucketOwnershipControlsRequest)
		{
			IRequest request = new DefaultRequest(putBucketOwnershipControlsRequest, "AmazonS3");
			request.HttpMethod = "PUT";
			if (string.IsNullOrEmpty(putBucketOwnershipControlsRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "PutBucketOwnershipControlsRequest.BucketName");
			}
			if (putBucketOwnershipControlsRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(putBucketOwnershipControlsRequest.ExpectedBucketOwner));
			}
			request.ResourcePath = "/";
			request.AddSubResource("ownershipControls");
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				OwnershipControls ownershipControls = putBucketOwnershipControlsRequest.OwnershipControls;
				if (ownershipControls != null)
				{
					xmlWriter.WriteStartElement("OwnershipControls", "http://s3.amazonaws.com/doc/2006-03-01/");
					if (ownershipControls.Rules != null)
					{
						foreach (OwnershipControlsRule rule in ownershipControls.Rules)
						{
							xmlWriter.WriteStartElement("Rule");
							if (rule.IsSetObjectOwnership())
							{
								xmlWriter.WriteElementString("ObjectOwnership", S3Transforms.ToXmlStringValue(rule.ObjectOwnership));
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
