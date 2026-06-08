using System;
using Amazon.Runtime;

namespace Amazon.S3.Transfer.Internal
{
	internal class ProgressHandler
	{
		private StreamTransferProgressArgs _lastProgressArgs;

		private EventHandler<UploadProgressArgs> _callback;

		public ProgressHandler(EventHandler<UploadProgressArgs> callback)
		{
			if (callback == null)
			{
				throw new ArgumentNullException("callback");
			}
			_callback = callback;
		}

		public void OnTransferProgress(object sender, StreamTransferProgressArgs e)
		{
			long compensationForRetry = 0L;
			if (_lastProgressArgs != null && _lastProgressArgs.TransferredBytes >= e.TransferredBytes)
			{
				compensationForRetry = _lastProgressArgs.TransferredBytes;
			}
			UploadProgressArgs e2 = new UploadProgressArgs(e.IncrementTransferred, e.TransferredBytes, e.TotalBytes, compensationForRetry, null);
			_callback(this, e2);
			_lastProgressArgs = e;
		}
	}
}
