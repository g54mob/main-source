using System;
using Amazon.Runtime.Internal;
using Amazon.Util;

namespace Amazon.S3.Transfer
{
	public class TransferUtilityDownloadDirectoryRequest
	{
		private string bucketName;

		private string s3Directory;

		private string localDirectory;

		private bool downloadFilesConcurrently;

		private DateTime? modifiedSinceDate;

		private DateTime? unmodifiedSinceDate;

		private bool disableSlashCorrection;

		private ServerSideEncryptionCustomerMethod serverSideCustomerEncryption;

		private string serverSideEncryptionCustomerProvidedKey;

		private string serverSideEncryptionCustomerProvidedKeyMD5;

		private RequestPayer requestPayer;

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

		public string LocalDirectory
		{
			get
			{
				return localDirectory;
			}
			set
			{
				localDirectory = value;
			}
		}

		public string S3Directory
		{
			get
			{
				return s3Directory;
			}
			set
			{
				s3Directory = value;
			}
		}

		public DateTime ModifiedSinceDate
		{
			get
			{
				return modifiedSinceDate.GetValueOrDefault();
			}
			set
			{
				modifiedSinceDate = value;
			}
		}

		public DateTime UnmodifiedSinceDate
		{
			get
			{
				return unmodifiedSinceDate.GetValueOrDefault();
			}
			set
			{
				unmodifiedSinceDate = value;
			}
		}

		public bool DownloadFilesConcurrently
		{
			get
			{
				return downloadFilesConcurrently;
			}
			set
			{
				downloadFilesConcurrently = value;
			}
		}

		public bool DisableSlashCorrection
		{
			get
			{
				return disableSlashCorrection;
			}
			set
			{
				disableSlashCorrection = value;
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

		public event EventHandler<DownloadDirectoryProgressArgs> DownloadedDirectoryProgressEvent;

		internal bool IsSetBucketName()
		{
			return !string.IsNullOrEmpty(bucketName);
		}

		internal bool IsSetLocalDirectory()
		{
			return !string.IsNullOrEmpty(localDirectory);
		}

		internal bool IsSetS3Directory()
		{
			return !string.IsNullOrEmpty(s3Directory);
		}

		internal bool IsSetModifiedSinceDate()
		{
			return modifiedSinceDate.HasValue;
		}

		internal bool IsSetUnmodifiedSinceDate()
		{
			return unmodifiedSinceDate.HasValue;
		}

		internal void OnRaiseProgressEvent(DownloadDirectoryProgressArgs downloadDirectoryProgress)
		{
			AWSSDKUtils.InvokeInBackground(this.DownloadedDirectoryProgressEvent, downloadDirectoryProgress, this);
		}
	}
}
