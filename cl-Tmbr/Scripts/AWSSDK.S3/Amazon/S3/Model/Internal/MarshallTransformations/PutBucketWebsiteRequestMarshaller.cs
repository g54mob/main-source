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
	public class PutBucketWebsiteRequestMarshaller : IMarshaller<IRequest, PutBucketWebsiteRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutBucketWebsiteRequestMarshaller _instance;

		public static PutBucketWebsiteRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutBucketWebsiteRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutBucketWebsiteRequest)input);
		}

		public IRequest Marshall(PutBucketWebsiteRequest putBucketWebsiteRequest)
		{
			IRequest request = new DefaultRequest(putBucketWebsiteRequest, "AmazonS3");
			request.HttpMethod = "PUT";
			if (putBucketWebsiteRequest.IsSetChecksumAlgorithm())
			{
				request.Headers.Add(S3Constants.AmzHeaderSdkChecksumAlgorithm, S3Transforms.ToStringValue(putBucketWebsiteRequest.ChecksumAlgorithm));
			}
			if (putBucketWebsiteRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(putBucketWebsiteRequest.ExpectedBucketOwner));
			}
			if (string.IsNullOrEmpty(putBucketWebsiteRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "PutBucketWebsiteRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("website");
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				WebsiteConfiguration websiteConfiguration = putBucketWebsiteRequest.WebsiteConfiguration;
				if (websiteConfiguration != null)
				{
					xmlWriter.WriteStartElement("WebsiteConfiguration", "http://s3.amazonaws.com/doc/2006-03-01/");
					if (websiteConfiguration != null)
					{
						string errorDocument = websiteConfiguration.ErrorDocument;
						if (errorDocument != null)
						{
							xmlWriter.WriteStartElement("ErrorDocument");
							xmlWriter.WriteElementString("Key", S3Transforms.ToXmlStringValue(errorDocument));
							xmlWriter.WriteEndElement();
						}
					}
					if (websiteConfiguration != null)
					{
						string indexDocumentSuffix = websiteConfiguration.IndexDocumentSuffix;
						if (indexDocumentSuffix != null)
						{
							xmlWriter.WriteStartElement("IndexDocument");
							xmlWriter.WriteElementString("Suffix", S3Transforms.ToXmlStringValue(indexDocumentSuffix));
							xmlWriter.WriteEndElement();
						}
					}
					if (websiteConfiguration != null)
					{
						RoutingRuleRedirect redirectAllRequestsTo = websiteConfiguration.RedirectAllRequestsTo;
						if (redirectAllRequestsTo != null)
						{
							xmlWriter.WriteStartElement("RedirectAllRequestsTo");
							if (redirectAllRequestsTo.IsSetHostName())
							{
								xmlWriter.WriteElementString("HostName", S3Transforms.ToXmlStringValue(redirectAllRequestsTo.HostName));
							}
							if (redirectAllRequestsTo.IsSetHttpRedirectCode())
							{
								xmlWriter.WriteElementString("HttpRedirectCode", S3Transforms.ToXmlStringValue(redirectAllRequestsTo.HttpRedirectCode));
							}
							if (redirectAllRequestsTo.IsSetProtocol())
							{
								xmlWriter.WriteElementString("Protocol", S3Transforms.ToXmlStringValue(redirectAllRequestsTo.Protocol));
							}
							if (redirectAllRequestsTo.IsSetReplaceKeyPrefixWith())
							{
								xmlWriter.WriteElementString("ReplaceKeyPrefixWith", S3Transforms.ToXmlStringValue(redirectAllRequestsTo.ReplaceKeyPrefixWith));
							}
							if (redirectAllRequestsTo.IsSetReplaceKeyWith())
							{
								xmlWriter.WriteElementString("ReplaceKeyWith", S3Transforms.ToXmlStringValue(redirectAllRequestsTo.ReplaceKeyWith));
							}
							xmlWriter.WriteEndElement();
						}
					}
					if (websiteConfiguration != null)
					{
						List<RoutingRule> routingRules = websiteConfiguration.RoutingRules;
						if (routingRules != null && routingRules.Count > 0)
						{
							xmlWriter.WriteStartElement("RoutingRules");
							foreach (RoutingRule item in routingRules)
							{
								xmlWriter.WriteStartElement("RoutingRule");
								if (item != null)
								{
									RoutingRuleCondition condition = item.Condition;
									if (condition != null)
									{
										xmlWriter.WriteStartElement("Condition");
										if (condition.IsSetHttpErrorCodeReturnedEquals())
										{
											xmlWriter.WriteElementString("HttpErrorCodeReturnedEquals", S3Transforms.ToXmlStringValue(condition.HttpErrorCodeReturnedEquals));
										}
										if (condition.IsSetKeyPrefixEquals())
										{
											xmlWriter.WriteElementString("KeyPrefixEquals", S3Transforms.ToXmlStringValue(condition.KeyPrefixEquals));
										}
										xmlWriter.WriteEndElement();
									}
								}
								if (item != null)
								{
									RoutingRuleRedirect redirect = item.Redirect;
									if (redirect != null)
									{
										xmlWriter.WriteStartElement("Redirect");
										if (redirect.IsSetHostName())
										{
											xmlWriter.WriteElementString("HostName", S3Transforms.ToXmlStringValue(redirect.HostName));
										}
										if (redirect.IsSetHttpRedirectCode())
										{
											xmlWriter.WriteElementString("HttpRedirectCode", S3Transforms.ToXmlStringValue(redirect.HttpRedirectCode));
										}
										if (redirect.IsSetProtocol())
										{
											xmlWriter.WriteElementString("Protocol", S3Transforms.ToXmlStringValue(redirect.Protocol));
										}
										if (redirect.IsSetReplaceKeyPrefixWith())
										{
											xmlWriter.WriteElementString("ReplaceKeyPrefixWith", S3Transforms.ToXmlStringValue(redirect.ReplaceKeyPrefixWith));
										}
										if (redirect.IsSetReplaceKeyWith())
										{
											xmlWriter.WriteElementString("ReplaceKeyWith", S3Transforms.ToXmlStringValue(redirect.ReplaceKeyWith));
										}
										xmlWriter.WriteEndElement();
									}
								}
								xmlWriter.WriteEndElement();
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
				ChecksumUtils.SetChecksumData(request, putBucketWebsiteRequest.ChecksumAlgorithm, fallbackToMD5: false, isRequestChecksumRequired: true, S3Constants.AmzHeaderSdkChecksumAlgorithm);
				return request;
			}
			catch (EncoderFallbackException innerException)
			{
				throw new AmazonServiceException("Unable to marshall request to XML", innerException);
			}
		}
	}
}
