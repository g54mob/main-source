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
	public class PutCORSConfigurationRequestMarshaller : IMarshaller<IRequest, PutCORSConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutCORSConfigurationRequestMarshaller _instance;

		public static PutCORSConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutCORSConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutCORSConfigurationRequest)input);
		}

		public IRequest Marshall(PutCORSConfigurationRequest putCORSConfigurationRequest)
		{
			IRequest request = new DefaultRequest(putCORSConfigurationRequest, "AmazonS3");
			request.HttpMethod = "PUT";
			if (putCORSConfigurationRequest.IsSetChecksumAlgorithm())
			{
				request.Headers.Add(S3Constants.AmzHeaderSdkChecksumAlgorithm, S3Transforms.ToStringValue(putCORSConfigurationRequest.ChecksumAlgorithm));
			}
			if (putCORSConfigurationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(putCORSConfigurationRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(putCORSConfigurationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "PutCORSConfigurationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("cors");
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				CORSConfiguration configuration = putCORSConfigurationRequest.Configuration;
				if (configuration != null)
				{
					xmlWriter.WriteStartElement("CORSConfiguration", "http://s3.amazonaws.com/doc/2006-03-01/");
					if (configuration != null)
					{
						List<CORSRule> rules = configuration.Rules;
						if (rules != null && rules.Count > 0)
						{
							foreach (CORSRule item in rules)
							{
								xmlWriter.WriteStartElement("CORSRule");
								if (item != null)
								{
									List<string> allowedMethods = item.AllowedMethods;
									if (allowedMethods != null && allowedMethods.Count > 0)
									{
										foreach (string item2 in allowedMethods)
										{
											xmlWriter.WriteStartElement("AllowedMethod");
											xmlWriter.WriteValue(item2);
											xmlWriter.WriteEndElement();
										}
									}
								}
								if (item != null)
								{
									List<string> allowedOrigins = item.AllowedOrigins;
									if (allowedOrigins != null && allowedOrigins.Count > 0)
									{
										foreach (string item3 in allowedOrigins)
										{
											xmlWriter.WriteStartElement("AllowedOrigin");
											xmlWriter.WriteValue(item3);
											xmlWriter.WriteEndElement();
										}
									}
								}
								if (item != null)
								{
									List<string> exposeHeaders = item.ExposeHeaders;
									if (exposeHeaders != null && exposeHeaders.Count > 0)
									{
										foreach (string item4 in exposeHeaders)
										{
											xmlWriter.WriteStartElement("ExposeHeader");
											xmlWriter.WriteValue(item4);
											xmlWriter.WriteEndElement();
										}
									}
								}
								if (item != null)
								{
									List<string> allowedHeaders = item.AllowedHeaders;
									if (allowedHeaders != null && allowedHeaders.Count > 0)
									{
										foreach (string item5 in allowedHeaders)
										{
											xmlWriter.WriteStartElement("AllowedHeader");
											xmlWriter.WriteValue(item5);
											xmlWriter.WriteEndElement();
										}
									}
								}
								if (item.IsSetMaxAgeSeconds())
								{
									xmlWriter.WriteElementString("MaxAgeSeconds", S3Transforms.ToXmlStringValue(item.MaxAgeSeconds.Value));
								}
								if (item.IsSetId())
								{
									xmlWriter.WriteElementString("ID", S3Transforms.ToXmlStringValue(item.Id));
								}
								xmlWriter.WriteEndElement();
							}
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
				ChecksumUtils.SetChecksumData(request, putCORSConfigurationRequest.ChecksumAlgorithm, fallbackToMD5: false, isRequestChecksumRequired: true, S3Constants.AmzHeaderSdkChecksumAlgorithm);
				return request;
			}
			catch (EncoderFallbackException innerException)
			{
				throw new AmazonServiceException("Unable to marshall request to XML", innerException);
			}
		}
	}
}
