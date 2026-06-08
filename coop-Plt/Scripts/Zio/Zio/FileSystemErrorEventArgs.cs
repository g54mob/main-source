using System;

namespace Zio
{
	public class FileSystemErrorEventArgs : EventArgs
	{
		public Exception Exception { get; }

		public FileSystemErrorEventArgs(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			Exception = exception;
		}
	}
}
