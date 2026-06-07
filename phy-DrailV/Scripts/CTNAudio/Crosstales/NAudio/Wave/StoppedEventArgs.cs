using System;

namespace Crosstales.NAudio.Wave
{
	public class StoppedEventArgs : EventArgs
	{
		private readonly Exception exception;

		public Exception Exception => exception;

		public StoppedEventArgs(Exception exception)
		{
			this.exception = exception;
		}
	}
}
