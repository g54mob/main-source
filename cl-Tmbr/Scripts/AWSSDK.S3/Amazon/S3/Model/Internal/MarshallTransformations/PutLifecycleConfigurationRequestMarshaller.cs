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
	public class PutLifecycleConfigurationRequestMarshaller : IMarshaller<IRequest, PutLifecycleConfigurationRequest>, IMarshaller<IRequest, AmazonWebServiceRequest>
	{
		private static PutLifecycleConfigurationRequestMarshaller _instance;

		public static PutLifecycleConfigurationRequestMarshaller Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PutLifecycleConfigurationRequestMarshaller();
				}
				return _instance;
			}
		}

		public IRequest Marshall(AmazonWebServiceRequest input)
		{
			return Marshall((PutLifecycleConfigurationRequest)input);
		}

		public IRequest Marshall(PutLifecycleConfigurationRequest putLifecycleConfigurationRequest)
		{
			IRequest request = new DefaultRequest(putLifecycleConfigurationRequest, "AmazonS3");
			request.HttpMethod = "PUT";
			if (putLifecycleConfigurationRequest.IsSetExpectedBucketOwner())
			{
				request.Headers.Add(S3Constants.AmzHeaderExpectedBucketOwner, S3Transforms.ToStringValue(putLifecycleConfigurationRequest.ExpectedBucketOwner));
			}
			if (putLifecycleConfigurationRequest.IsSetChecksumAlgorithm())
			{
				request.Headers[S3Constants.AmzHeaderSdkChecksumAlgorithm] = S3Transforms.ToStringValue(putLifecycleConfigurationRequest.ChecksumAlgorithm);
			}
			if (string.IsNullOrEmpty(putLifecycleConfigurationRequest.BucketName))
			{
				throw new ArgumentException("BucketName is a required property and must be set before making this call.", "PutLifecycleConfigurationRequest.BucketName");
			}
			request.ResourcePath = "/";
			request.AddSubResource("lifecycle");
			XMLEncodedStringWriter xMLEncodedStringWriter = new XMLEncodedStringWriter(CultureInfo.InvariantCulture);
			using (XmlWriter xmlWriter = XmlWriter.Create(xMLEncodedStringWriter, new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				OmitXmlDeclaration = true,
				NewLineHandling = NewLineHandling.Entitize
			}))
			{
				LifecycleConfiguration configuration = putLifecycleConfigurationRequest.Configuration;
				if (configuration != null)
				{
					xmlWriter.WriteStartElement("LifecycleConfiguration", "http://s3.amazonaws.com/doc/2006-03-01/");
					if (configuration != null)
					{
						List<LifecycleRule> rules = configuration.Rules;
						if (rules != null && rules.Count > 0)
						{
							foreach (LifecycleRule item in rules)
							{
								xmlWriter.WriteStartElement("Rule");
								if (item != null)
								{
									LifecycleRuleExpiration expiration = item.Expiration;
									if (expiration != null)
									{
										xmlWriter.WriteStartElement("Expiration");
										if (expiration.IsSetDate())
										{
											xmlWriter.WriteElementString("Date", StringUtils.FromDateTimeToISO8601WithOptionalMs(expiration.Date.Value));
										}
										if (expiration.IsSetDays())
										{
											xmlWriter.WriteElementString("Days", S3Transforms.ToXmlStringValue(expiration.Days.Value));
										}
										if (expiration.IsSetExpiredObjectDeleteMarker())
										{
											xmlWriter.WriteElementString("ExpiredObjectDeleteMarker", S3Transforms.ToXmlStringValue(expiration.ExpiredObjectDeleteMarker.Value));
										}
										xmlWriter.WriteEndElement();
									}
									List<LifecycleTransition> transitions = item.Transitions;
									if (transitions != null && transitions.Count > 0)
									{
										foreach (LifecycleTransition item2 in transitions)
										{
											if (item2 != null)
											{
												xmlWriter.WriteStartElement("Transition");
												if (item2.IsSetDate())
												{
													xmlWriter.WriteElementString("Date", StringUtils.FromDateTimeToISO8601WithOptionalMs(item2.Date.Value));
												}
												if (item2.IsSetDays())
												{
													xmlWriter.WriteElementString("Days", S3Transforms.ToXmlStringValue(item2.Days.Value));
												}
												if (item2.IsSetStorageClass())
												{
													xmlWriter.WriteElementString("StorageClass", S3Transforms.ToXmlStringValue(item2.StorageClass));
												}
												xmlWriter.WriteEndElement();
											}
										}
									}
									LifecycleRuleNoncurrentVersionExpiration noncurrentVersionExpiration = item.NoncurrentVersionExpiration;
									if (noncurrentVersionExpiration != null)
									{
										xmlWriter.WriteStartElement("NoncurrentVersionExpiration");
										if (noncurrentVersionExpiration.IsSetNewerNoncurrentVersions())
										{
											xmlWriter.WriteElementString("NewerNoncurrentVersions", S3Transforms.ToXmlStringValue(noncurrentVersionExpiration.NewerNoncurrentVersions.Value));
										}
										if (noncurrentVersionExpiration.IsSetNoncurrentDays())
										{
											xmlWriter.WriteElementString("NoncurrentDays", S3Transforms.ToXmlStringValue(noncurrentVersionExpiration.NoncurrentDays.Value));
										}
										xmlWriter.WriteEndElement();
									}
									List<LifecycleRuleNoncurrentVersionTransition> noncurrentVersionTransitions = item.NoncurrentVersionTransitions;
									if (noncurrentVersionTransitions != null && noncurrentVersionTransitions.Count > 0)
									{
										foreach (LifecycleRuleNoncurrentVersionTransition item3 in noncurrentVersionTransitions)
										{
											if (item3 != null)
											{
												xmlWriter.WriteStartElement("NoncurrentVersionTransition");
												if (item3.IsSetNewerNoncurrentVersions())
												{
													xmlWriter.WriteElementString("NewerNoncurrentVersions", S3Transforms.ToXmlStringValue(item3.NewerNoncurrentVersions.Value));
												}
												if (item3.IsSetNoncurrentDays())
												{
													xmlWriter.WriteElementString("NoncurrentDays", S3Transforms.ToXmlStringValue(item3.NoncurrentDays.Value));
												}
												if (item3.IsSetStorageClass())
												{
													xmlWriter.WriteElementString("StorageClass", S3Transforms.ToXmlStringValue(item3.StorageClass));
												}
												xmlWriter.WriteEndElement();
											}
										}
									}
									LifecycleRuleAbortIncompleteMultipartUpload abortIncompleteMultipartUpload = item.AbortIncompleteMultipartUpload;
									if (abortIncompleteMultipartUpload != null)
									{
										xmlWriter.WriteStartElement("AbortIncompleteMultipartUpload");
										if (abortIncompleteMultipartUpload.IsSetDaysAfterInitiation())
										{
											xmlWriter.WriteElementString("DaysAfterInitiation", S3Transforms.ToXmlStringValue(abortIncompleteMultipartUpload.DaysAfterInitiation.Value));
										}
										xmlWriter.WriteEndElement();
									}
								}
								if (item.IsSetId())
								{
									xmlWriter.WriteElementString("ID", S3Transforms.ToXmlStringValue(item.Id));
								}
								if (item.IsSetFilter())
								{
									xmlWriter.WriteStartElement("Filter");
									if (item.Filter.IsSetLifecycleFilterPredicate())
									{
										item.Filter.LifecycleFilterPredicate.Accept(new LifecycleFilterPredicateMarshallVisitor(xmlWriter));
									}
									xmlWriter.WriteEndElement();
								}
								if (item.IsSetStatus())
								{
									xmlWriter.WriteElementString("Status", S3Transforms.ToXmlStringValue(item.Status));
								}
								else
								{
									xmlWriter.WriteElementString("Status", "Disabled");
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
				ChecksumUtils.SetChecksumData(request, putLifecycleConfigurationRequest.ChecksumAlgorithm, fallbackToMD5: false, isRequestChecksumRequired: true, S3Constants.AmzHeaderSdkChecksumAlgorithm);
				return request;
			}
			catch (EncoderFallbackException innerException)
			{
				throw new AmazonServiceException("Unable to marshall request to XML", innerException);
			}
		}
	}
}
