using System;
using Google.Apis.Util;

namespace Google.Apis.Download
{
	public static class DownloadProgress
	{
		public static void ThrowOnFailure(this IDownloadProgress progress)
		{
			progress.ThrowIfNull("progress");
			Exception exception = progress.Exception;
			if (exception == null)
			{
				return;
			}
			if (progress is MediaDownloader.DownloadProgress { ExceptionDispatchInfo: { } exceptionDispatchInfo })
			{
				exceptionDispatchInfo.Throw();
			}
			throw exception;
		}
	}
}
