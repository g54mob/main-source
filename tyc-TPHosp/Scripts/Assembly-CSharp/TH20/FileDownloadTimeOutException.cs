using System;

namespace TH20
{
	public class FileDownloadTimeOutException : Exception
	{
		public FileDownloadTimeOutException()
		{
		}

		public FileDownloadTimeOutException(string message)
			: base(message)
		{
		}

		public FileDownloadTimeOutException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
