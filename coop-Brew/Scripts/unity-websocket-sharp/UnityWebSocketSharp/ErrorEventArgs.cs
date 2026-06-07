using System;

namespace UnityWebSocketSharp
{
	internal class ErrorEventArgs : EventArgs
	{
		private Exception _exception;

		private string _message;

		public Exception Exception => null;

		public string Message => null;

		internal ErrorEventArgs(string message)
		{
		}

		internal ErrorEventArgs(string message, Exception exception)
		{
		}
	}
}
