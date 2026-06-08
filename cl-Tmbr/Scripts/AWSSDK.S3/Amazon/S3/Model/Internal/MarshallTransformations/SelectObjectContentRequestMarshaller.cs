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
	public class SelectObjectContentRequestMarshaller : IMarshaller<IRequest, AmazonWebServiceRequest>, IMarshaller<IRequest, SelectObjectContentRequest>
	{
		private static SelectObjectContentRequestMarshaller _instance;

		public static SelectObjectContentRequestMarshaller Instance => _instance ?? (_instance = new SelectObjectContentRequestMarshaller());

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((SelectObjectContentRequest)input);
		}

		public IRequest Marshall(SelectObjectContentRequest selectObjectContentRequest)
		{
			if (string.IsNullOrEmpty(selectObjectContentRequest.BucketName))
			{
				throw ConstructExceptionArgumentRequired("BucketName");
			}
			if (string.IsNullOrEmpty(selectObjectContentRequest.Key))
			{
				throw ConstructExceptionArgumentRequired("Key");
			}
			if (string.IsNullOrEmpty(selectObjectContentRequest.Expression))
			{
				throw ConstructExceptionArgumentRequired("Expression");
			}
			if (!selectObjectContentRequest.IsSetExpressionType())
			{
				throw ConstructExceptionArgumentRequired("ExpressionType");
			}
			if (!selectObjectContentRequest.IsSetInputSerialization())
			{
				throw ConstructExceptionArgumentRequired("InputSerialization");
			}
			if (!selectObjectContentRequest.IsSetOutputSerialization())
			{
				throw ConstructExceptionArgumentRequired("OutputSerialization");
			}
			DefaultRequest defaultRequest = new DefaultRequest(selectObjectContentRequest, "AmazonS3")
			{
				HttpMethod = "POST",
				ResourcePath = "/{Key+}",
				UseQueryString = true
			};
			defaultRequest.AddPathResource("{Key+}", S3Transforms.ToStringValue(selectObjectContentRequest.Key));
			if (selectObjectContentRequest.IsSetServerSideCustomerEncryptionMethod())
			{
				defaultRequest.Headers.Add("x-amz-server-side-encryption-customer-algorithm", selectObjectContentRequest.ServerSideCustomerEncryptionMethod);
			}
			if (selectObjectContentRequest.IsSetServerSideEncryptionCustomerProvidedKey())
			{
				defaultRequest.Headers.Add("x-amz-server-side-encryption-customer-key", selectObjectContentRequest.ServerSideEncryptionCustomerProvidedKey);
				if (selectObjectContentRequest.IsSetServerSideEncryptionCustomerProvidedKeyMD5())
				{
					defaultRequest.Headers.Add("x-amz-server-side-encryption-customer-key-MD5", selectObjectContentRequest.ServerSideEncryptionCustomerProvidedKeyMD5);
				}
				else
				{
					defaultRequest.Headers.Add("x-amz-server-side-encryption-customer-key-MD5", AmazonS3Util.ComputeEncodedMD5FromEncodedString(selectObjectContentRequest.ServerSideEncryptionCustomerProvidedKey));
				}
			}
			if (selectObjectContentRequest.IsSetExpectedBucketOwner())
			{
				defaultRequest.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(selectObjectContentRequest.ExpectedBucketOwner));
			}
			defaultRequest.AddSubResource("select");
			defaultRequest.AddSubResource("select-type", "2");
			using XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			XmlWriterSettings settings = new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			};
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, settings))
			{
				xmlWriter.WriteStartElement("SelectObjectContentRequest", "http://s3.amazonaws.com/doc/2006-03-01/");
				xmlWriter.WriteElementString("Expression", S3Transforms.ToXmlStringValue(selectObjectContentRequest.Expression));
				xmlWriter.WriteElementString("ExpressionType", S3Transforms.ToXmlStringValue(selectObjectContentRequest.ExpressionType.Value));
				selectObjectContentRequest.InputSerialization.Marshall("InputSerialization", xmlWriter);
				selectObjectContentRequest.OutputSerialization.Marshall("OutputSerialization", xmlWriter);
				xmlWriter.WriteStartElement("RequestProgress");
				xmlWriter.WriteElementString("Enabled", (selectObjectContentRequest.RequestProgress ?? false).ToString().ToUpperInvariant());
				xmlWriter.WriteEndElement();
				if (selectObjectContentRequest.IsSetScanRange())
				{
					selectObjectContentRequest.ScanRange.Marshall("ScanRange", xmlWriter);
				}
				xmlWriter.WriteEndElement();
			}
			try
			{
				string s = xMLEncodedStringWriter.ToString();
				defaultRequest.Content = Encoding.UTF8.GetBytes(s);
				defaultRequest.Headers["Content-Type"] = "application/xml";
				ChecksumUtils.SetChecksumData(defaultRequest);
				return defaultRequest;
			}
			catch (EncoderFallbackException innerException)
			{
				throw new AmazonServiceException("Unable to marshall request to XML", innerException);
			}
		}

		private static ArgumentException ConstructExceptionArgumentRequired(string parameterName)
		{
			return new ArgumentException(string.Format(CultureInfo.InvariantCulture, "{0}  is a required property and must be set before making this call.", parameterName), string.Format(CultureInfo.InvariantCulture, "{0}.{1}", "SelectObjectContentRequest", parameterName));
		}
	}
}
