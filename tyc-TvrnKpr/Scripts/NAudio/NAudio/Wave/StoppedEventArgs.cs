using System;

namespace NAudio.Wave
{
	public class StoppedEventArgs : EventArgs
	{
		private readonly Exception exception;

		public Exception Exception => null;

		public StoppedEventArgs(Exception exception = null)
		{
		}
	}
}
