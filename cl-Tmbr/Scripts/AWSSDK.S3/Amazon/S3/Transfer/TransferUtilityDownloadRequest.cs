using System;
using Amazon.S3.Model;
using Amazon.Util;

namespace Amazon.S3.Transfer
{
	public class TransferUtilityDownloadRequest : BaseDownloadRequest
	{
		public string FilePath { get; set; }

		public event EventHandler<WriteObjectProgressArgs> WriteObjectProgressEvent;

		internal bool IsSetFilePath()
		{
			return !string.IsNullOrEmpty(FilePath);
		}

		internal void OnRaiseProgressEvent(WriteObjectProgressArgs progressArgs)
		{
			AWSSDKUtils.InvokeInBackground(this.WriteObjectProgressEvent, progressArgs, this);
		}
	}
}
