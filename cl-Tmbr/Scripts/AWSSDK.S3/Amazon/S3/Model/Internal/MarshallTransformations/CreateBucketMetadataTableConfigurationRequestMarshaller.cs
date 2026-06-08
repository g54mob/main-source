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
	public class CreateBucketMetadataTableConfigurationRequestMarshaller : IMarshaller<IRequest, CreateBucketMetadataTableConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static CreateBucketMetadataTableConfigurationRequestMarshaller _instance;

		public static CreateBucketMetadataTableConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new CreateBucketMetadataTableConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((CreateBucketMetadataTableConfigurationRequest)input);
		}

		public IRequest Marshall(CreateBucketMetadataTableConfigurationRequest createBucketMetadataTableConfigurationRequest)
		{
			IRequest request = new DefaultRequest(createBucketMetadataTableConfigurationRequest, "AmazonS3");
			request.HttpMethod = "POST";
			if (createBucketMetadataTableConfigurationRequest.IsSetChecksumAlgorithm())
			{
				request.Headers.Add(S3Constants.AmzHeaderSdkChecksumAlgorithm, S3Transforms.ToStringValue(createBucketMetadataTableConfigurationRequest.ChecksumAlgorithm));
			}
			if (createBucketMetadataTableConfigurationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(createBucketMetadataTableConfigurationRequest.ExpectedBucketOwner));
			}
			if (createBucketMetadataTableConfigurationRequest.IsSetContentMD5())
			{
				request.Headers.Add("Content-MD5", S3Transforms.ToStringValue(createBucketMetadataTableConfigurationRequest.ContentMD5));
			}
			if (string.IsNullOrEmpty(createBucketMetadataTableConfigurationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "CreateBucketMetadataTableConfigurationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("metadataTable");
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				MetadataTableConfiguration metadataTableConfiguration = createBucketMetadataTableConfigurationRequest.MetadataTableConfiguration;
				if (metadataTableConfiguration != null)
				{
					xmlWriter.WriteStartElement("MetadataTableConfiguration", "http://s3.amazonaws.com/doc/2006-03-01/");
					if (metadataTableConfiguration.IsSetS3TablesDestination())
					{
						xmlWriter.WriteStartElement("S3TablesDestination");
						if (metadataTableConfiguration.S3TablesDestination.IsSetTableBucketArn())
						{
							xmlWriter.WriteElementString("TableBucketArn", metadataTableConfiguration.S3TablesDestination.TableBucketArn);
						}
						if (metadataTableConfiguration.S3TablesDestination.IsSetTableName())
						{
							xmlWriter.WriteElementString("TableName", metadataTableConfiguration.S3TablesDestination.TableName);
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
				ChecksumUtils.SetChecksumData(request, createBucketMetadataTableConfigurationRequest.ChecksumAlgorithm, fallbackToMD5: false, isRequestChecksumRequired: true, S3Constants.AmzHeaderSdkChecksumAlgorithm);
				return request;
			}
			catch (EncoderFallbackException innerException)
			{
				throw new AmazonServiceException("Unable to marshall request to XML", innerException);
			}
		}
	}
}
