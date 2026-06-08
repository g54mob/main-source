using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Amazon.Runtime;
using Amazon.Runtime.Internal;

namespace Amazon.S3.Model
{
	public class GetObjectRequest : AmazonWebServiceRequest
	{
		private string bucketName;

		private string expectedBucketOwner;

		private DateTime? modifiedSinceDate;

		private DateTime? unmodifiedSinceDate;

		private string etagToMatch;

		private string etagToNotMatch;

		private string key;

		private int? partNumber;

		private ByteRange byteRange;

		private RequestPayer requestPayer;

		private DateTime? responseExpires;

		private ResponseHeaderOverrides responseHeaders;

		private ServerSideEncryptionCustomerMethod serverSideCustomerEncryption;

		private string serverSideEncryptionCustomerProvidedKey;

		private string serverSideEncryptionCustomerProvidedKeyMD5;

		private string versionId;

		private ChecksumMode _checksumMode;

		private static List<CoreChecksumAlgorithm> _supportedChecksumAlgorithms = new List<CoreChecksumAlgorithm>
		{
			CoreChecksumAlgorithm.CRC64NVME,
			CoreChecksumAlgorithm.CRC32C,
			CoreChecksumAlgorithm.CRC32,
			CoreChecksumAlgorithm.SHA256,
			CoreChecksumAlgorithm.SHA1
		};

		public string BucketName
		{
			get
			{
				return bucketName;
			}
			set
			{
				bucketName = value;
			}
		}

		public string ExpectedBucketOwner
		{
			get
			{
				return expectedBucketOwner;
			}
			set
			{
				expectedBucketOwner = value;
			}
		}

		public DateTime? ModifiedSinceDate
		{
			get
			{
				return modifiedSinceDate ?? DateTime.SpecifyKind(default(DateTime), DateTimeKind.Utc);
			}
			set
			{
				if (!value.HasValue)
				{
					modifiedSinceDate = null;
				}
				else
				{
					modifiedSinceDate = value;
				}
			}
		}

		public DateTime? UnmodifiedSinceDate
		{
			get
			{
				return unmodifiedSinceDate ?? DateTime.SpecifyKind(default(DateTime), DateTimeKind.Utc);
			}
			set
			{
				if (!value.HasValue)
				{
					unmodifiedSinceDate = null;
				}
				else
				{
					unmodifiedSinceDate = value;
				}
			}
		}

		public string Key
		{
			get
			{
				return key;
			}
			set
			{
				key = value;
			}
		}

		public int? PartNumber
		{
			get
			{
				return partNumber;
			}
			set
			{
				if (value.HasValue && (value < 1 || 10000 < value))
				{
					throw new ArgumentException("PartNumber must be a positve integer between 1 and 10,000.");
				}
				partNumber = value;
			}
		}

		public RequestPayer RequestPayer
		{
			get
			{
				return requestPayer;
			}
			set
			{
				requestPayer = value;
			}
		}

		public DateTime? ResponseExpires
		{
			get
			{
				return responseExpires;
			}
			set
			{
				if (!value.HasValue)
				{
					responseExpires = null;
				}
				else
				{
					responseExpires = value;
				}
			}
		}

		public ServerSideEncryptionCustomerMethod ServerSideEncryptionCustomerMethod
		{
			get
			{
				return serverSideCustomerEncryption;
			}
			set
			{
				serverSideCustomerEncryption = value;
			}
		}

		[AWSProperty(Sensitive = true)]
		public string ServerSideEncryptionCustomerProvidedKey
		{
			get
			{
				return serverSideEncryptionCustomerProvidedKey;
			}
			set
			{
				serverSideEncryptionCustomerProvidedKey = value;
			}
		}

		public string ServerSideEncryptionCustomerProvidedKeyMD5
		{
			get
			{
				return serverSideEncryptionCustomerProvidedKeyMD5;
			}
			set
			{
				serverSideEncryptionCustomerProvidedKeyMD5 = value;
			}
		}

		public string VersionId
		{
			get
			{
				return versionId;
			}
			set
			{
				versionId = value;
			}
		}

		public string EtagToMatch
		{
			get
			{
				return etagToMatch;
			}
			set
			{
				etagToMatch = value;
			}
		}

		public string EtagToNotMatch
		{
			get
			{
				return etagToNotMatch;
			}
			set
			{
				etagToNotMatch = value;
			}
		}

		public ByteRange ByteRange
		{
			get
			{
				return byteRange;
			}
			set
			{
				byteRange = value;
			}
		}

		public ResponseHeaderOverrides ResponseHeaderOverrides
		{
			get
			{
				if (responseHeaders == null)
				{
					responseHeaders = new ResponseHeaderOverrides();
				}
				return responseHeaders;
			}
			set
			{
				responseHeaders = value;
			}
		}

		public ChecksumMode ChecksumMode
		{
			get
			{
				return _checksumMode;
			}
			set
			{
				_checksumMode = value;
			}
		}

		protected override CoreChecksumResponseBehavior CoreChecksumMode
		{
			get
			{
				if (IsSetChecksumMode())
				{
					return (CoreChecksumResponseBehavior)Enum.Parse(typeof(CoreChecksumResponseBehavior), ChecksumMode);
				}
				return CoreChecksumResponseBehavior.DISABLED;
			}
			set
			{
				ChecksumMode = value.ToString();
			}
		}

		protected override ReadOnlyCollection<CoreChecksumAlgorithm> ChecksumResponseAlgorithms => _supportedChecksumAlgorithms.AsReadOnly();

		internal bool IsSetBucketName()
		{
			return bucketName != null;
		}

		internal bool IsSetExpectedBucketOwner()
		{
			return !string.IsNullOrEmpty(expectedBucketOwner);
		}

		internal bool IsSetModifiedSinceDate()
		{
			return modifiedSinceDate.HasValue;
		}

		internal bool IsSetUnmodifiedSinceDate()
		{
			return unmodifiedSinceDate.HasValue;
		}

		internal bool IsSetKey()
		{
			return key != null;
		}

		internal bool IsSetPartNumber()
		{
			return partNumber.HasValue;
		}

		internal bool IsSetRequestPayer()
		{
			return requestPayer != null;
		}

		internal bool IsSetResponseExpires()
		{
			return responseExpires.HasValue;
		}

		internal bool IsSetServerSideEncryptionCustomerMethod()
		{
			if (serverSideCustomerEncryption != null)
			{
				return serverSideCustomerEncryption != ServerSideEncryptionCustomerMethod.None;
			}
			return false;
		}

		internal bool IsSetServerSideEncryptionCustomerProvidedKey()
		{
			return !string.IsNullOrEmpty(serverSideEncryptionCustomerProvidedKey);
		}

		internal bool IsSetServerSideEncryptionCustomerProvidedKeyMD5()
		{
			return !string.IsNullOrEmpty(serverSideEncryptionCustomerProvidedKeyMD5);
		}

		internal bool IsSetVersionId()
		{
			return versionId != null;
		}

		internal bool IsSetEtagToMatch()
		{
			return etagToMatch != null;
		}

		internal bool IsSetEtagToNotMatch()
		{
			return etagToNotMatch != null;
		}

		internal bool IsSetByteRange()
		{
			if (byteRange != null)
			{
				return byteRange.FormattedByteRange != null;
			}
			return false;
		}

		internal bool IsSetChecksumMode()
		{
			return _checksumMode != null;
		}
	}
}
