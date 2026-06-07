using System;
using Google.Apis.Util;

namespace Google.Apis.Upload
{
	public static class UploadProgress
	{
		public static void ThrowOnFailure(this IUploadProgress progress)
		{
			progress.ThrowIfNull("progress");
			Exception exception = progress.Exception;
			if (exception == null)
			{
				return;
			}
			if (progress is ResumableUpload.ResumableUploadProgress { ExceptionDispatchInfo: { } exceptionDispatchInfo })
			{
				exceptionDispatchInfo.Throw();
			}
			throw exception;
		}
	}
}
